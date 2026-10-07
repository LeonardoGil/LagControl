using LagFinanceInfra.Database.Configurations;
using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;
using LagBaseInfra;

namespace LagFinanceInfra.Database
{
    public class LagFinanceDbContext(DbContextOptions<LagFinanceDbContext> options) : DbContextBase<LagFinanceDbContext>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("finance");

            // Configuration
            modelBuilder.AccountConfig()
                        .CategoryConfig()
                        .TransactionConfig();
        }

        public DbSet<Account> Account { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<CreditCard> CreditCard { get; set; }

        public DbSet<CreditCardTransaction> CreditCardTransaction { get; set; }

        public DbSet<CreditCardInvoice> CreditCardInvoice { get; set; }
    }
}
