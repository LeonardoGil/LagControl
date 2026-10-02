using LagControlCLI.Resources;

namespace LagControlCLI.Options.TransactionDialog
{
    internal static class TransactionDialogOption
    {
        internal static Dictionary<TransactionDialogEnum, string> Options => new()
        {
            { TransactionDialogEnum.Add, "Adicionar" },
            { TransactionDialogEnum.Transfer, Resource.TransferLabel },
            { TransactionDialogEnum.List, "Listar" },
            { TransactionDialogEnum.ConfirmPending, "Confirmar pendente" },
            { TransactionDialogEnum.Exit, Resource.Exit },
        };

        internal enum TransactionDialogEnum
        {
            Add,
            Transfer,
            List,
            ConfirmPending,
            Exit
        }
    }
}
