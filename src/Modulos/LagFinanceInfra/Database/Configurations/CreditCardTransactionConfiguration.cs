using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database.Configurations
{
    public static class CreditCardTransactionConfiguration
    {
        public static ModelBuilder CreditCardTransactionConfig(this ModelBuilder modelBuilder) =>
            modelBuilder.Entity<CreditCardTransaction>(entity =>
            {
                entity.Property(t => t.Description)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(t => t.Amount)
                      .HasPrecision(12, 2)
                      .IsRequired();

                entity.Property(t => t.Date)
                      .HasColumnType("date")
                      .IsRequired();

                entity.Property(t => t.Pending)
                      .IsRequired()
                      .HasDefaultValue(false);

                entity.HasOne(t => t.CreditCard)
                      .WithMany(c => c.Transactions)
                      .HasForeignKey(t => t.CreditCardId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Invoice)
                      .WithMany(i => i.Transactions)
                      .HasForeignKey(t => t.InvoiceId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Category)
                      .WithMany()
                      .HasForeignKey(t => t.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(t => t.CreditCardId);
                entity.HasIndex(t => t.InvoiceId);
            });
    }
}
