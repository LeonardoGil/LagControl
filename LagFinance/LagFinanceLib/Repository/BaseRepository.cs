using LagFinanceLib.Database;
using LagFinanceLib.Interfaces;

namespace LagFinanceLib.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected LagFinanceDbContext _context;

        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> List()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
