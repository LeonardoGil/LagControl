﻿using Microsoft.EntityFrameworkCore;

namespace LagFinanceLib.Database
{
    public class LagFinanceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=LagFinance;Persist Security Info=True;User ID=sa;Password=P@ssw0rd!;Connect Timeout=900;TrustServerCertificate=true");


    }
}