using LagBaseDomain;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;

namespace LagFinanceInfra.Repositories
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
            if (entity is Entity baseEntity)
                baseEntity.DataCriacao = DateTime.Now;

            _context.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity is Entity baseEntity)
                baseEntity.DataAtualizacao = DateTime.Now;

            _context.Update(entity);
        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
