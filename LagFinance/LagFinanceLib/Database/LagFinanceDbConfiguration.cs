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
            modelBuilder.Entity<Conta>().HasData(ContaSeed());
            modelBuilder.Entity<Categoria>().HasData(CategoriaSeed());
        }

        private static Categoria[] CategoriaSeed()
        {
            return new Categoria[]
            {
                new Categoria
                {
                    Id = Guid.Parse("1F7CCE04-9EC5-4F43-BFDB-4ED1E478F1D4"),
                    Descricao = "Mercado"
                },
                new Categoria
                {
                    Id = Guid.Parse("21BF5615-C004-4A31-99F8-B376AFC573BC"),
                    Descricao = "Contas"
                },
                new Categoria
                {
                    Id = Guid.Parse("88C747E2-45AD-4067-AAB8-AB287CEED954"),
                    Descricao = "Farmacia"
                },
                new Categoria
                {
                    Id = Guid.Parse("42C74818-8EF2-45B9-9AB6-A7DCD6DCC36F"),
                    Descricao = "Lazer"
                },
                new Categoria
                {
                    Id = Guid.Parse("CF668FDA-3D80-47C6-8352-6C04FB28C956"),
                    Descricao = "Restaurante"
                }
            };
        }

        private static Conta[] ContaSeed()
        {
            return new Conta[]
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
        }
    }
}
