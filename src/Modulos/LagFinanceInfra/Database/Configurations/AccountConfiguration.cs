using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database.Configurations
{
    public static class AccountConfiguration
    {
        public static ModelBuilder AccountConfig(this ModelBuilder modelBuilder) =>
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(x => x.Description)
                      .IsRequired()
                      .HasMaxLength(60);

                entity.HasMany(b => b.Transactions)
                      .WithOne(b => b.Account);
            });
    }
}
