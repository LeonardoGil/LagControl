using LagBaseDomain;
using Microsoft.EntityFrameworkCore;

namespace LagBaseInfra
{
    public class DbContextBase<T>(DbContextOptions<T> options) : DbContext(options) where T : DbContext
    {
        public override int SaveChanges()
        {
            ApplyAuditInformation();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInformation()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is Entity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityState in entries)
            {
                var entity = entityState.Entity as Entity;

                switch (entityState.State)
                {
                    case EntityState.Added:
                        entity!.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entity!.UpdatedAt = DateTime.Now;
                        break;
                }
            }
        }
    }
}
