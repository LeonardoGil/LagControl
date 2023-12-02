using LagFinanceLib.Database;
using LagFinanceLib.Interfaces;

namespace LagFinanceLib.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected LagFinanceDbContext _context;

        public BaseRepository(LagFinanceDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
