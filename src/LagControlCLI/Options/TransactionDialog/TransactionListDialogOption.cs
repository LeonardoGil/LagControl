using LagControlCLI.Resources;

namespace LagControlCLI.Options.TransactionDialog
{
    internal static class TransactionListDialogOption
    {
        internal static Dictionary<TransactionListDialogEnum, string> Options => new()
        {
            { TransactionListDialogEnum.Filter, "Filtrar" },
            { TransactionListDialogEnum.Refresh, "Atualizar" },
            { TransactionListDialogEnum.Details, "Detalhes" },
            { TransactionListDialogEnum.Exit, Resource.Exit },
        };

        internal enum TransactionListDialogEnum
        {
            Filter,
            Refresh,
            Details,
            Exit
        }
    }
}
