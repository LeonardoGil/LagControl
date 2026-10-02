using LagControlCLI.Resources;

namespace LagControlCLI.Options.TransactionDialog
{
    internal static class ShowTransactionDetailsDialogOptions
    {
        internal static Dictionary<ShowTransactionDetailsDialogEnum, string> Options => new()
        {
            { ShowTransactionDetailsDialogEnum.Edit, "Editar" },
            { ShowTransactionDetailsDialogEnum.Exit, Resource.Exit },
        };

        internal enum ShowTransactionDetailsDialogEnum
        {
            Edit,
            Exit
        }
    }
}
