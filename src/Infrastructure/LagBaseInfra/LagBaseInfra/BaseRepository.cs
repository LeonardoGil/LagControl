using LagBaseDomain;
using Microsoft.EntityFrameworkCore;

namespace LagBaseInfra
{
    public abstract class BaseRepository<TContext, TEntity>(TContext context) : IBaseRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected TContext _context = context;

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
