using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database.Configurations
{
    public static class CreditCardConfiguration
    {
        public static ModelBuilder CreditCardConfig(this ModelBuilder modelBuilder) =>
            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(c => c.HolderName).IsRequired().HasMaxLength(100);

                entity.Property(c => c.CreditLimit).HasPrecision(12, 2);

                entity.HasOne(c => c.Account)
                      .WithMany(c => c.CreditCards)
                      .HasForeignKey(c => c.AccountId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
    }
}
