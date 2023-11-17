using LagFinanceLib.Domain;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceLib.Database
{
    public class LagFinanceDbConfiguration
    {
        public static void SetEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimentacao>()
                .Property(b => b.Valor)
                .HasPrecision(6, 2)
                .IsRequired();

            modelBuilder.Entity<Movimentacao>()
                .Property(b => b.Descricao)
                .IsRequired();
        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>().HasData(
                new Conta()
                {
                    Descricao = "Bradesco",
                    Id = Guid.NewGuid()
                },
                new Conta()
                {
                    Descricao = "Banco do Brasil",
                    Id = Guid.NewGuid()
                },
                new Conta()
                {
                    Descricao = "Santander",
                    Id = Guid.NewGuid()
                },
                new Conta()
                {
                    Descricao = "PicPay",
                    Id = Guid.NewGuid()
                }
            );
        }
    }
}
