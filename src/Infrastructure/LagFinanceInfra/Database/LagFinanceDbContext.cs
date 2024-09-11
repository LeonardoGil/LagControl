using LagFinanceInfra.Database.Configurations;
using LagFinanceLib.Database.Configurations;
using LagFinanceDomain.Domain;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database
{
    public class LagFinanceDbContext : DbContext
    {
        public LagFinanceDbContext() { }

        public LagFinanceDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=LagControl;Persist Security Info=True;User ID=sa;Password=P@ssw0rd!;Connect Timeout=900;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("finance");

            // Configuration
            modelBuilder.ContaConfig()
                        .MovimentacaoConfig();

            // SEEDS
            modelBuilder.ContaSeed()
                        .CategoriaSeed();
        }

        public DbSet<Conta> Conta { get; set; }

        public DbSet<Movimentacao> Movimentacao { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
    }
}
