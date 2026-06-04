using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<T>
        where T : class
    {
        Task<List<T>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<T?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task<List<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        Task<List<T?>> GetByGrupoAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            T entity,
            CancellationToken cancellationToken = default);

        Task UpdateAsync(
            T entity,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            T entity,
            CancellationToken cancellationToken = default);

        void Update(T entity);

        void Delete(T entity);

        void Remove(T entity);

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}