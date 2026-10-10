namespace LagControlUtil.Extensions
{
    public static class DecimalExtension
    {
        public static decimal[] SplitAmount(this decimal total, int installments)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(total);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(installments);

            var totalInCents = (long)(total * 100m);

            var baseAmount = totalInCents / installments;
            var remainder = totalInCents % installments;

            var amounts = new decimal[installments];

            for (int i = 0; i < installments; i++)
            {
                var cents = baseAmount + (i < remainder ? 1 : 0);
                amounts[i] = cents / 100m;
            }

            return amounts;
        }
    }
}
