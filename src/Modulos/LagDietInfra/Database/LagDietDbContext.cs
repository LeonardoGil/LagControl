using LagDietDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagDietInfra.Database
{
    public class LagDietDbContext(DbContextOptions<LagDietDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("diet");
        }

        public DbSet<Food> Food { get; set; }
        
        public DbSet<Meal> Meal { get; set; }
        
        public DbSet<MealFood> MealFood { get; set; }
    }
}
