using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database.Configurations
{
    public static class CreditCardInvoiceConfiguration
    {
        public static ModelBuilder CreditCardInvoiceConfig(this ModelBuilder modelBuilder) =>
            modelBuilder.Entity<CreditCardInvoice>(entity =>
            {
                entity.Property(i => i.ReferenceMonth)
                      .IsRequired();

                entity.Property(i => i.ReferenceYear)
                      .IsRequired();

                entity.Property(i => i.OpeningDate)
                      .HasColumnType("date")
                      .IsRequired();

                entity.Property(i => i.ClosingDate)
                      .HasColumnType("date")
                      .IsRequired();

                entity.Property(i => i.DueDate)
                      .HasColumnType("date")
                      .IsRequired();

                entity.Property(i => i.Status)
                      .IsRequired();

                entity.HasOne(i => i.CreditCard)
                      .WithMany(c => c.Invoices)
                      .HasForeignKey(i => i.CreditCardId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(i => i.Transactions)
                      .WithOne(t => t.Invoice)
                      .HasForeignKey(t => t.InvoiceId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(i => i.Payment)
                      .WithMany()
                      .HasForeignKey(i => i.PaymentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(i => new { i.CreditCardId, i.ReferenceYear, i.ReferenceMonth }).IsUnique();
                entity.HasIndex(i => i.CreditCardId);
            });
    }
}
