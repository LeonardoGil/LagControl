using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database.Configurations
{
    public static class TransactionConfiguration
    {
        public static ModelBuilder TransactionConfig(this ModelBuilder modelBuilder) =>
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(b => b.Amount)
                      .HasPrecision(6, 2)
                      .IsRequired();

                entity.Property(b => b.Description)
                      .IsRequired()
                      .HasMaxLength(60);

                entity.Property(b => b.Notes)
                      .HasMaxLength(100);

                entity.HasOne(t => t.Account)
                      .WithMany(a => a.Transactions)
                      .HasForeignKey(t => t.AccountId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.TransferAccount)
                      .WithMany()
                      .HasForeignKey(t => t.TransferAccountId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Category)
                      .WithMany()
                      .HasForeignKey(t => t.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
    }
}

