using LagFinanceApplication.Dtos.Accounts;
using LagControlCLI.Dialogs.Interfaces.Bases;

namespace LagControlCLI.Dialogs.Interfaces.Finances
{
    internal interface IShowAccountDetailsDialog : IDialogBase<IList<AccountBalanceDto>>
    {
    }
}
