using LagFinanceInfra.Database.Configurations;
using LagFinanceLib.Database.Configurations;
using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database
{
    public class LagFinanceDbContext(DbContextOptions<LagFinanceDbContext> options) : DbContext(options)
    {
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
