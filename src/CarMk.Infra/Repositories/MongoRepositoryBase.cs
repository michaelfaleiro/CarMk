using CarMk.Core.Response;
using CarMk.Core.Shared.Repositories.Generics;
using MongoDB.Driver;

namespace CarMk.Infra.Repositories;

public abstract class MongoRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly IMongoCollection<TEntity> _collection;
    protected readonly IMongoDatabase _database;

    protected MongoRepositoryBase(IMongoDatabase database, string collectionName)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
        _collection = _database.GetCollection<TEntity>(collectionName);
    }


    public virtual async Task<TEntity> Create(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public virtual async Task<PagedResponse<TEntity>> GetAll(int pageNumber, int pageSize)
    {
        var skip = (pageNumber - 1) * pageSize;
        var totalCount = await _collection.CountDocumentsAsync(FilterDefinition<TEntity>.Empty);
        
        var items = await _collection.Find(FilterDefinition<TEntity>.Empty)
            .Skip(skip)
            .Limit(pageSize)
            .ToListAsync();
        
        return new PagedResponse<TEntity>
        {
            Data = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
        };
    }

    public virtual async Task<TEntity> GetById(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        var id = entity.GetType().GetProperty("Id")?.GetValue(entity)?.ToString();
        if (string.IsNullOrEmpty(id))
            throw new InvalidOperationException("Entity must have an Id property");

        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        await _collection.ReplaceOneAsync(filter, entity);
        return entity;
    }
}
