using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database.Configurations
{
    public static class CreditCardConfiguration
    {
        public static ModelBuilder CreditCardConfig(this ModelBuilder modelBuilder) =>
            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(c => c.HolderName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.CreditLimit)
                      .HasPrecision(12, 2)
                      .IsRequired();

                entity.Property(c => c.ClosingDay)
                      .IsRequired();

                entity.Property(c => c.DueDay)
                      .IsRequired();

                entity.Property(c => c.Active)
                      .IsRequired()
                      .HasDefaultValue(true);

                entity.HasOne(c => c.Account)
                      .WithMany(a => a.CreditCards)
                      .HasForeignKey(c => c.AccountId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(c => c.Invoices)
                      .WithOne(i => i.CreditCard)
                      .HasForeignKey(i => i.CreditCardId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(c => c.Transactions)
                      .WithOne(t => t.CreditCard)
                      .HasForeignKey(t => t.CreditCardId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(c => c.AccountId);
            });
    }
}
