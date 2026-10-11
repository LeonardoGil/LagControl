using LagControlCLI.Resources;

namespace LagControlCLI.Options
{
    internal static class CreditCardsDialogOptions
    {
        internal static Dictionary<CreditCardsDialogOptionEnum, string> Options => new()
        {
            { CreditCardsDialogOptionEnum.AddCreditCard, "Adicionar cartão de crédito" },
            { CreditCardsDialogOptionEnum.Back, Resource.Back }
        };

        internal enum CreditCardsDialogOptionEnum
        {
            AddCreditCard,
            Back
        }
    }
}
