using Kinogo.WebAPI.Domain.Common.Entities.Contracts;
using Kinogo.WebAPI.Domain.Common.Pagination;
using System.Linq.Expressions;

namespace Kinogo.WebAPI.Domain.Common.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken ct);
        public Task<TEntity> GetByIdAsync(string id, CancellationToken ct);
        public Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct);
        public Task<TEntity> RemoveAsync(string id, CancellationToken ct);
        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);
        public Task<TEntity> FindOne(Expression<Func<TEntity, bool>> filter, CancellationToken ct);
        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, PaginationParameters paginationParameters, CancellationToken ct);
        public Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken token);
    }
}
