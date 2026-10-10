using LagBaseDomain;

namespace LagBaseInfra
{
    public interface IBaseRepository<TEntity>
        where TEntity : Entity
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params string[] includes);

        IQueryable<TEntity> Get();

        void Remove(TEntity entity);

        void SaveChanges();

        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        Task TransactionAsync(Func<Task> action, CancellationToken cancellationToken = default);
    }
}
