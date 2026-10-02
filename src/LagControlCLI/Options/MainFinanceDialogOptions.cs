using LagControlCLI.Resources;

namespace LagControlCLI.Options
{
    internal static class MainFinanceDialogOptions
    {
        internal static Dictionary<MainFinanceDialogOptionEnum, string> Options => new()
        {
            { MainFinanceDialogOptionEnum.Transaction, "Transações"},
            { MainFinanceDialogOptionEnum.Categories, "Categorias"},
            { MainFinanceDialogOptionEnum.Accounts, "Contas" },
            { MainFinanceDialogOptionEnum.Reports, "Relatórios" },
            { MainFinanceDialogOptionEnum.Back, Resource.Back },
        };

        internal enum MainFinanceDialogOptionEnum
        {
            Transaction,
            Categories,
            Accounts,
            Reports,
            Back
        }
    }
}
