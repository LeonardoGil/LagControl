namespace LagControlCLI.Dialogs.Interfaces.Bases
{
    internal interface IDialogAndReturnBase<TIn, TOut>
    {
        Task<TOut> ShowAndReturn(TIn input);
    }
}
