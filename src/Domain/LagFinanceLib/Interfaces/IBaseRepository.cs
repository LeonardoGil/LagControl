namespace LagFinanceLib.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        IQueryable<TEntity> Get();

        void Remove(TEntity entity);
    }
}
