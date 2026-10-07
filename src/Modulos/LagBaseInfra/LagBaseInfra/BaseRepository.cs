using LagBaseDomain;
using Microsoft.EntityFrameworkCore;

namespace LagBaseInfra
{
    public abstract class BaseRepository<TContext, TEntity>(TContext context) : IBaseRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        protected TContext _context = context;

        public void Add(TEntity entity) => _context.Add(entity);
        public void Update(TEntity entity) => _context.Update(entity);
        public void Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void SaveChanges() => _context.SaveChanges();
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);
    }
}
