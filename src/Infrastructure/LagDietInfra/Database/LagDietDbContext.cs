using LagDietDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database
{
    public class LagDietDbContext(DbContextOptions<LagDietDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("diet");
        }

        public DbSet<Alimento> Alimento { get; set; }
    }
}
