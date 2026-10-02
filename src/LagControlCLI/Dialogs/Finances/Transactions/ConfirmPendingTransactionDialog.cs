using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Options;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Commands.Transactions;
using LagFinanceApplication.Dtos.Transactions;
using LagFinanceApplication.Queries.Transactions;
using MediatR;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Finances.Transactions
{
    internal class ConfirmPendingTransactionDialog(IAnsiConsole console, IMediator mediator) : DialogBase(console), IConfirmPendingTransactionDialog
    {
        private IList<TransactionGridDto> Transactions { get; set; } = [];

        protected override async Task LoadAsync()
        {
            await Console.LoadingAsync(Resource.ConfirmingTransaction, async _ =>
            {
                Transactions = await mediator.Send(new ListTransactionsQuery
                {
                    PendingOnly = true
                });
            });
        }

        protected override async Task ExecuteAsync()
        {
            if (Transactions.Count == 0)
            {
                Console.MarkupLine(Resource.NoPendingTransactions.Color(Color.Yellow));
                Console.AskPressEnterToReturn();
                return;
            }

            var choices = Transactions.OrderByDescending(x => x.Date).ToDictionary(t => t, t => $"{t.Date.ToString(Resource.DateFormat)} | {t.Description} | {t.Amount:C}");

            var selected = SelectionPrompt.Ask(Console, Resource.SelectPendingPrompt, choices);

            if (ConfirmPrompt.Ask(Console, "Desaja alterar a data?"))
            {
                selected.Date = DatePrompt.Ask(Console, Resource.DateLabel, options: DateDialogOptions.Options);
            }

            if (ConfirmPrompt.Ask(Console, "Desaja alterar o valor?"))
            {
                selected.Amount = DecimalPrompt.Ask(Console, Resource.ValueColumn);
            }

            var confirmText = string.Format(Resource.ConfirmPendingQuestion, selected.Description, selected.Amount.ToString("C"));
            
            if (!Console.Confirm(confirmText, defaultValue: false))
            {
                Console.MarkupLine(Resource.OperationCancelled.Color(Color.Grey));
                return;
            }

            try
            {
                await mediator.Send(new ConfirmPendingTransactionCommand()
                {
                    Id = selected.Id,
                    Description = selected.Description,
                    Notes = selected.Notes,
                    Amount = selected.Amount,
                    Date = selected.Date,
                    AccountId = selected.AccountId,
                    CategoryId = selected.CategoryId
                });

                Console.MarkupLine(Resource.TransactionConfirmed.Color(Color.Green));
            }
            catch (Exception ex)
            {
                Console.MarkupLine(Resource.ErrorConfirmingTransaction.Color(Color.Red));
                Console.MarkupLine(ex.Message.Color(Color.Grey));
            }
        }
    }
}
