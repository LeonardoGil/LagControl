using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceLib.Database.Configurations
{
    public static class MovimentacaoConfiguration
    {
        public static ModelBuilder MovimentacaoConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimentacao>()
                .Property(b => b.Valor)
                .HasPrecision(6, 2)
                .IsRequired();

            modelBuilder.Entity<Movimentacao>()
                .Property(b => b.Descricao)
                .IsRequired();
            
            return modelBuilder;
        }
    }
}
