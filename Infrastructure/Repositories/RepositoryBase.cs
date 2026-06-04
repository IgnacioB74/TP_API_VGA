using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public abstract class RepositoryBase<T>
        : IRepositoryBase<T>
        where T : class
    {
        protected readonly DbContext _dbContext;

        protected RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Set<T>()
                .FindAsync(
                    new object[] { id },
                    cancellationToken
                );
        }

        public async Task<List<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Set<T>()
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<List<T?>> GetByGrupoAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Set<T>()
                .Cast<T?>()
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(
            T entity,
            CancellationToken cancellationToken = default)
        {
            await _dbContext
                .Set<T>()
                .AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(
            T entity,
            CancellationToken cancellationToken = default)
        {
            _dbContext
                .Set<T>()
                .Update(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(
            T entity,
            CancellationToken cancellationToken = default)
        {
            _dbContext
                .Set<T>()
                .Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            _dbContext
                .Set<T>()
                .Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext
                .Set<T>()
                .Remove(entity);
        }

        public void Remove(T entity)
        {
            _dbContext
                .Set<T>()
                .Remove(entity);
        }

        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .SaveChangesAsync(cancellationToken);
        }
    }
}