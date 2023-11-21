using LagFinanceLib.Database;

namespace LagFinanceLib.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        IQueryable<TEntity> List();

        void Remove(Guid id);
    }
}
