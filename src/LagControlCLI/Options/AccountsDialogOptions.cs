using LagControlCLI.Resources;

namespace LagControlCLI.Options
{
    internal static class AccountsDialogOptions
    {
        internal static Dictionary<AccountsDialogOptionEnum, string> Options => new()
        {
            { AccountsDialogOptionEnum.Detail, "Detalhe da Conta" },
            { AccountsDialogOptionEnum.AddAccount, "Adicionar Conta" },
            { AccountsDialogOptionEnum.Back, Resource.Back }
        };

        internal enum AccountsDialogOptionEnum
        {
            Detail,
            AddAccount,
            Back
        }
    }
}
