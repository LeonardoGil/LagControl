using LagFinanceLib.Domain;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceLib.Database.Configurations
{
    public static class ContaConfiguration
    {
        public static ModelBuilder ContaConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>()
                        .HasMany(b => b.Movimentacoes)
                        .WithOne(b => b.Conta);

            return modelBuilder;
        }

        public static ModelBuilder ContaSeed(this ModelBuilder modelBuilder)
        {
            var contas = new Conta[]
            {
                new Conta()
                {
                    Descricao = "Bradesco",
                    Id = Guid.Parse("9AB68E5A-A829-40B9-9D32-B9746D3134F5")
                },
                new Conta()
                {
                    Descricao = "Banco do Brasil",
                    Id = Guid.Parse("60B44DCC-950E-45B1-BBB2-32C5DEB9EC90")
                },
                new Conta()
                {
                    Descricao = "Santander",
                    Id = Guid.Parse("64ABC81E-DD01-40B8-983A-3DBA10CFB7AB")
                },
                new Conta()
                {
                    Descricao = "PicPay",
                    Id = Guid.Parse("0CA05B72-4E7D-4AFE-8BC9-C0B8CC860073")
                }
            };

            modelBuilder.Entity<Conta>().HasData(contas);
            return modelBuilder;
        }
    }
}
