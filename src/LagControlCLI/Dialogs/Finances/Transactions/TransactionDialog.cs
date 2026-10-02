using LagControlCLI.Dialogs.Bases;
using LagControlCLI.Dialogs.Interfaces.Finances;
using LagControlCLI.Extensions;
using LagControlCLI.Extensions.Finances;
using LagControlCLI.Options.TransactionDialog;
using LagControlCLI.Prompts;
using LagControlCLI.Resources;
using LagFinanceApplication.Dtos.Transactions;
using LagFinanceApplication.Queries.Transactions;
using MediatR;
using Spectre.Console;

namespace LagControlCLI.Dialogs.Finances.Transactions
{
    internal class TransactionDialog(IAnsiConsole console,
                                     IMediator mediator,
                                     IAddTransactionDialog addTransactionDialog,
                                     IListTransactionDialog listTransactionDialog,
                                     IConfirmPendingTransactionDialog confirmPendingTransactionDialog,
                                     IAddTransferTransactionDialog transferTransactionDialog) : LoopDialogBase(console), ITransactionDialog
    {
        private IList<TransactionGridDto> lastTransactions = [];
        

        protected override async Task ExecuteAsync()
        {
            if (lastTransactions.Count > 0)
            {
                var transactionTable = TransactionExtensions.BuildTable(lastTransactions, "Transações recentes");
                Console.Write(transactionTable);
            }

            var action = SelectionPrompt.Ask(Console, Resource.SelectAction, TransactionDialogOption.Options);

            switch (action)
            {
                case TransactionDialogOption.TransactionDialogEnum.Add:
                    await addTransactionDialog.Show();
                    await LoadAsync();
                    break;

                case TransactionDialogOption.TransactionDialogEnum.ConfirmPending:
                    await confirmPendingTransactionDialog.Show();
                    await LoadAsync();
                    break;
                case TransactionDialogOption.TransactionDialogEnum.Transfer:
                    await transferTransactionDialog.Show();
                    await LoadAsync();
                    break;
                
                case TransactionDialogOption.TransactionDialogEnum.List:
                    await listTransactionDialog.Show();
                    await LoadAsync();
                    break;

                case TransactionDialogOption.TransactionDialogEnum.Exit:
                    Stop();
                    break;
            }
        }

        protected override async Task LoadAsync()
        {
            try
            {
                await Console.LoadingAsync(Resource.LoadingTransactions, async _ =>
                {
                    lastTransactions = await mediator.Send(new ListRecentTransactionsQuery());
                });
            }
            catch (Exception ex)
            {
                Console.MarkupLine(Resource.ErrorLoadingTransactions.Color(Color.Red));
                Console.MarkupLine(ex.Message.Color(Color.Grey));

                var retry = Console.Confirm(Resource.RetryPrompt, defaultValue: true);

                if (!retry)
                {
                    Stop();
                }
            }
        }
    }
}
