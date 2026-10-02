using LagControlCLI.Dialogs.Interfaces.Bases;
using LagFinanceApplication.Dtos.Transactions;

namespace LagControlCLI.Dialogs.Interfaces.Finances
{
    internal interface IShowTransactionDetailsDialog : IDialogBase<IList<TransactionGridDto>>
    {
    }
}
