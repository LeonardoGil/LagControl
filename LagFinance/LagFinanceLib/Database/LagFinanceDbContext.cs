using LagFinanceLib.Domain;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceLib.Database
{
    public class LagFinanceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=LagControl;Persist Security Info=True;User ID=sa;Password=P@ssw0rd!;Connect Timeout=900;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("finance");

            LagFinanceDbConfiguration.SetEntity(modelBuilder);
            LagFinanceDbConfiguration.Seed(modelBuilder);
        }

        public DbSet<Conta> Conta { get; set; }

        public DbSet<Movimentacao> Movimentacao { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
    }
}
