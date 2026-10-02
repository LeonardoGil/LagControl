using LagControlCLI.Resources;

namespace LagControlCLI.Options.TransactionDialog
{
    internal static class TransactionFilterDialogOption
    {
        internal static Dictionary<ListTransactionFilterDialogOptionEnum, string> Options => new()
        {
            { ListTransactionFilterDialogOptionEnum.Description, Resource.Description },
            { ListTransactionFilterDialogOptionEnum.Date, Resource.DateLabel },
            { ListTransactionFilterDialogOptionEnum.Pendente, Resource.Pending },
            { ListTransactionFilterDialogOptionEnum.Conta, Resource.AccountLabel },
            { ListTransactionFilterDialogOptionEnum.Categoria, Resource.CategoryLabel },
            { ListTransactionFilterDialogOptionEnum.Clear, Resource.Clear },
            { ListTransactionFilterDialogOptionEnum.Exit, Resource.Exit },
        };

        internal enum ListTransactionFilterDialogOptionEnum
        {
            Description,
            Date,
            Pendente,
            Conta,
            Categoria,
            Clear,
            Exit
        }
    }
}
