using LagControlCLI.Dialogs.Interfaces.Bases;
using LagFinanceApplication.Dtos.Transactions;

namespace LagControlCLI.Dialogs.Interfaces.Finances
{
    internal interface IEditTransactionDialog : IDialogBase<TransactionGridDto>
    {
    }
}
