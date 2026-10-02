using LagFinanceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceInfra.Database.Configurations
{
    public static class CategoryConfiguration
    {
        public static ModelBuilder CategoryConfig(this ModelBuilder modelBuilder) =>
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(b => b.Description)
                      .IsRequired()
                      .HasMaxLength(60);

                entity.HasOne(c => c.ParentCategory)
                      .WithMany(c => c.Children)
                      .HasForeignKey(c => c.ParentCategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
    }
}

