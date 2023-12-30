using Kinogo.WebAPI.Data.Common.Config.MongoDb.Contracts;
using Kinogo.WebAPI.Domain.Common.Entities;
using Kinogo.WebAPI.Domain.Common.Pagination;
using Kinogo.WebAPI.Domain.Common.Repository;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Kinogo.WebAPI.Data.Common.Repository
{
    public abstract class MongoDbBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMongoCollection<TEntity> _collection;

        public MongoDbBaseRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TEntity>(CollectionName);
        }

        public abstract string CollectionName { get; set; }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct)
        {
            await _collection.InsertOneAsync(entity, null, ct);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken ct)
        {
            return (await _collection.FindAsync(filter, cancellationToken: ct)).ToEnumerable(cancellationToken: ct);
        }

        public async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> filter, CancellationToken ct)
        {
            return (await _collection.FindAsync(filter, cancellationToken: ct)).FirstOrDefault(cancellationToken: ct);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct)
        {
            return (await _collection.FindAsync(x => true, cancellationToken: ct)).ToEnumerable(cancellationToken: ct);
        }

        public async Task<TEntity> GetByIdAsync(string id, CancellationToken ct)
        {
            return (await _collection.FindAsync(x => x.Id == id, cancellationToken: ct)).FirstOrDefault(cancellationToken: ct);
        }

        public async Task<TEntity> RemoveAsync(string id, CancellationToken ct)
        {
            return (await _collection.FindOneAndDeleteAsync(x => x.Id == id, cancellationToken: ct));
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct)
        {
            var options = new FindOneAndReplaceOptions<TEntity>
            {
                ReturnDocument = ReturnDocument.After
            };
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);

            return await _collection.FindOneAndReplaceAsync(filter, entity, options: options, cancellationToken: ct);

        }
        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken token)
        {
            return (await _collection.FindAsync(filter, cancellationToken: token)).ToEnumerable(cancellationToken: token).Count();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, PaginationParameters paginationParameters, CancellationToken ct)
        {
            var collection = await _collection.Find(filter)
                .Skip((paginationParameters.CurrentPage - 1) * paginationParameters.PageSize)
                .Limit(paginationParameters.PageSize)
                .ToListAsync(ct);

            return collection;
        }
    }
}
