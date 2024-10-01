using System.Linq.Expressions;
using MongoDB.Driver;


namespace DarazClone.Core.Services.Repositories.Implementations;

public class MongoRepository : IRepository
{
    private readonly IMongoDatabase _db;

    public MongoRepository(IMongoDatabase database)
    {
        _db = database;
        
        
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IAsyncCursor<TProjection>> FindAsync<TProjection, TEntity>(FilterDefinition<TEntity> filter, FindOptions<TEntity, TProjection> options = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TResponse>> GetAllAsync<TEntity, TResponse>()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TResponse>> GetAllAsync<TEntity, TResponse>(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>()
    {
        var collection = GetCollection<TEntity>();
        var pageSize = 10;
        var pageNumber = 1;

        var paginatedResult = collection
        .Find(Builders<TEntity>.Filter.Empty) 
        .Skip((pageNumber - 1) * pageSize)
        .Limit(pageSize)
        .ToList();

        return paginatedResult;
    }

    public Task<TResponse> GetByIdAsync<TEntity, TResponse>(string id)
    {
        throw new NotImplementedException();
    }

    public async Task InsertManyAsync<TEntity>(List<TEntity> entities)
    {
        var collection = GetCollection<TEntity>();
        await collection.InsertManyAsync(entities);
    }

    public async Task InsertOneAsync<TEntity>(TEntity entity)
    {
        var collection = GetCollection<TEntity>();
        await collection.InsertOneAsync(entity);
    }

    public async Task UpdateManyAsync<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updatedDataList, UpdateOptions options)
    {
         var collection = GetCollection<TEntity>();
         await collection.UpdateManyAsync(filter, updatedDataList, options);
    }

    public async Task UpdateOneAsync<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updatedData, UpdateOptions options)
    {
        var collection = GetCollection<TEntity>();
        await collection.UpdateManyAsync(filter, updatedData, options);
    }

    private IMongoCollection<TEntity> GetCollection<TEntity>()
    {
        // Extracting collection name from the given Type
        var collectionName = typeof(TEntity).Name + "s";
        var collection =  _db.GetCollection<TEntity>(collectionName);

        return collection;
    }

   
}