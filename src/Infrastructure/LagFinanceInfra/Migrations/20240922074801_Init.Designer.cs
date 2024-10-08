﻿// <auto-generated />
using System;
using LagFinanceInfra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LagFinanceInfra.Migrations
{
    [DbContext(typeof(LagFinanceDbContext))]
    [Migration("20240922074801_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("finance")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LagFinanceDomain.Domain.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria", "finance");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f7cce04-9ec5-4f43-bfdb-4ed1e478f1d4"),
                            Descricao = "Alimentação"
                        },
                        new
                        {
                            Id = new Guid("21bf5615-c004-4a31-99f8-b376afc573bc"),
                            Descricao = "Habitação"
                        },
                        new
                        {
                            Id = new Guid("88c747e2-45ad-4067-aab8-ab287ceed954"),
                            Descricao = "Transporte"
                        },
                        new
                        {
                            Id = new Guid("42c74818-8ef2-45b9-9ab6-a7dcd6dcc36f"),
                            Descricao = "Educação"
                        },
                        new
                        {
                            Id = new Guid("cf668fda-3d80-47c6-8352-6c04fb28c956"),
                            Descricao = "Saúde"
                        },
                        new
                        {
                            Id = new Guid("7e17e895-1f93-4dd7-8c55-cc1941999e30"),
                            Descricao = "Vestuário"
                        },
                        new
                        {
                            Id = new Guid("8afb4bec-0b6d-479c-bdd6-7ba7880ebb38"),
                            Descricao = "Taxas"
                        });
                });

            modelBuilder.Entity("LagFinanceDomain.Domain.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conta", "finance");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ab68e5a-a829-40b9-9d32-b9746d3134f5"),
                            Descricao = "Bradesco"
                        },
                        new
                        {
                            Id = new Guid("60b44dcc-950e-45b1-bbb2-32c5deb9ec90"),
                            Descricao = "Banco do Brasil"
                        },
                        new
                        {
                            Id = new Guid("64abc81e-dd01-40b8-983a-3dba10cfb7ab"),
                            Descricao = "Santander"
                        },
                        new
                        {
                            Id = new Guid("0ca05b72-4e7d-4afe-8bc9-c0b8cc860073"),
                            Descricao = "PicPay"
                        });
                });

            modelBuilder.Entity("LagFinanceDomain.Domain.Movimentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContaTransferenciaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pendente")
                        .HasColumnType("bit");

                    b.Property<int>("TipoMovimentacao")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ContaId");

                    b.HasIndex("ContaTransferenciaId");

                    b.ToTable("Movimentacao", "finance");
                });

            modelBuilder.Entity("LagFinanceDomain.Domain.Movimentacao", b =>
                {
                    b.HasOne("LagFinanceDomain.Domain.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LagFinanceDomain.Domain.Conta", "Conta")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LagFinanceDomain.Domain.Conta", "ContaTransferencia")
                        .WithMany()
                        .HasForeignKey("ContaTransferenciaId");

                    b.Navigation("Categoria");

                    b.Navigation("Conta");

                    b.Navigation("ContaTransferencia");
                });

            modelBuilder.Entity("LagFinanceDomain.Domain.Conta", b =>
                {
                    b.Navigation("Movimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
