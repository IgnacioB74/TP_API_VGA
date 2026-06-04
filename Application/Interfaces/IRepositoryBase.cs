using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<List<T?>> GetByGrupoAsync(int id);

    Task AddAsync(T entity);
    void Update(T entity);

    void Delete(T entity);

    void Remove(T entity);

    Task SaveChangesAsync();
}

