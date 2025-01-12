using LagDietDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database
{
    public class LagDietDbContext : DbContext
    {
        public LagDietDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("diet");
        }

        public DbSet<Alimento> Alimento { get; set; }
    }
}
