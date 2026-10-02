using LagControlCLI.Dialogs.Interfaces.Bases;
using LagFinanceApplication.Queries.Transactions;

namespace LagControlCLI.Dialogs.Interfaces.Finances
{
    internal interface IListTransactionFilterDialog : IDialogAndReturnBase<ListTransactionsQuery, ListTransactionsQuery>
    {
    }
}
