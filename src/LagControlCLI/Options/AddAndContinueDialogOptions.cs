namespace LagControlCLI.Options
{
    internal static class AddAndContinueDialogOptions
    {
        internal static Dictionary<AddAndContinueDialogOptionsEnum, string> Options => new()
        {
            { AddAndContinueDialogOptionsEnum.Add, "Adicionar" },
            { AddAndContinueDialogOptionsEnum.AddAndContinue, "Adicionar e continuar"},
            { AddAndContinueDialogOptionsEnum.Cancel, "Cancelar" }
        };

        internal static Dictionary<AddAndContinueDialogOptionsEnum, string> Options1 => new()
        {
            { AddAndContinueDialogOptionsEnum.Add, "Adicionar" },
            { AddAndContinueDialogOptionsEnum.Cancel, "Cancelar" }
        };

        internal enum AddAndContinueDialogOptionsEnum
        {
            Add,
            AddAndContinue,
            Cancel
        }
    }
}
