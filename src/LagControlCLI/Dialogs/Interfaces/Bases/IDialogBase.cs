namespace LagControlCLI.Dialogs.Interfaces.Bases
{
    internal interface IDialogBase
    {
        Task Show();
    }

    internal interface IDialogBase<TInput> where TInput : notnull
    {
        Task Show(TInput input);
    }
}
