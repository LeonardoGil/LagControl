namespace LagControlCLI.Options
{
    internal static class DateDialogOptions
    {
        internal static Dictionary<DateDialogOptionsEnum, string> Options => new()
        {
            { DateDialogOptionsEnum.Today, "Hoje" },
            { DateDialogOptionsEnum.Yesterday, "Ontem"},
            { DateDialogOptionsEnum.Other, "Outro" }
        };

        internal enum DateDialogOptionsEnum
        {
            Today,
            Yesterday,
            Other
        }

        internal static DateTime Convert(this DateDialogOptionsEnum option)
        {
            switch (option)
            {
                case DateDialogOptionsEnum.Today:
                    return DateTime.Today;

                case DateDialogOptionsEnum.Yesterday:
                    return DateTime.Today.AddDays(-1);
                
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
