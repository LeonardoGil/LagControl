using LagControlCLI.Resources;

namespace LagControlCLI.Options
{
    internal static class ReportsDialogOptions
    {
        internal static Dictionary<ReportsDialogOptionEnum, string> Options => new()
        {
            { ReportsDialogOptionEnum.Statement, "Extrato" },
            { ReportsDialogOptionEnum.Back, Resource.Back }
        };

        internal enum ReportsDialogOptionEnum
        {
            Statement,
            Back
        }
    }
}
