using LagFinanceLib.Domain;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceLib.Database.Model
{
    public class MovimentacaoModel
    {
        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimentacao>()
                .Property(b => b.Valor)
                .HasPrecision(6, 2)
                .IsRequired();

            modelBuilder.Entity<Movimentacao>()
                .Property(b => b.Descricao)
                .IsRequired();
        }
    }
}
