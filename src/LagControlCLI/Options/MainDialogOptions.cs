using LagControlCLI.Resources;

namespace LagControlCLI.Options
{
    internal static class MainDialogOptions
    {
        internal static Dictionary<MainDialogOptionsEnum, string> Options => new()
        {
            { MainDialogOptionsEnum.Finance, Resource.Finance },
            { MainDialogOptionsEnum.Diet, Resource.Diet },
            { MainDialogOptionsEnum.Exit, Resource.Exit }
        };

        internal enum MainDialogOptionsEnum
        {
            Finance,
            Diet,
            Exit,
        }
    }
}
