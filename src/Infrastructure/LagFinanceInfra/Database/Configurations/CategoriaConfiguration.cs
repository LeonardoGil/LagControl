using LagFinanceDomain.Entities;
using LagFinanceDomain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database.Configurations
{
    public static class CategoriaConfiguration
    {
        public static ModelBuilder CategoriaSeed(this ModelBuilder modelBuilder)
        {
            var categorias = new Categoria[]
            {
                new Categoria
                {
                    Id = Guid.Parse("1F7CCE04-9EC5-4F43-BFDB-4ED1E478F1D4"),
                    Descricao = "Alimentação",
                    Tipo = TipoCategoriaEnum.Despesa
                },
                new Categoria
                {
                    Id = Guid.Parse("21BF5615-C004-4A31-99F8-B376AFC573BC"),
                    Descricao = "Habitação",
                    Tipo = TipoCategoriaEnum.Despesa
                },
                new Categoria
                {
                    Id = Guid.Parse("88C747E2-45AD-4067-AAB8-AB287CEED954"),
                    Descricao = "Transporte",
                    Tipo = TipoCategoriaEnum.Despesa
                },
                new Categoria
                {
                    Id = Guid.Parse("42C74818-8EF2-45B9-9AB6-A7DCD6DCC36F"),
                    Descricao = "Educação",
                    Tipo = TipoCategoriaEnum.Despesa
                },
                new Categoria
                {
                    Id = Guid.Parse("CF668FDA-3D80-47C6-8352-6C04FB28C956"),
                    Descricao = "Saúde",
                    Tipo = TipoCategoriaEnum.Despesa
                },
                new Categoria
                {
                    Id = Guid.Parse("7e17e895-1f93-4dd7-8c55-cc1941999e30"),
                    Descricao = "Vestuário",
                    Tipo = TipoCategoriaEnum.Despesa
                },
                new Categoria
                {
                    Id = Guid.Parse("8afb4bec-0b6d-479c-bdd6-7ba7880ebb38"),
                    Descricao = "Taxas",
                    Tipo = TipoCategoriaEnum.Despesa
                },
            };

            modelBuilder.Entity<Categoria>().HasData(categorias);
            return modelBuilder;
        }
    }
}
