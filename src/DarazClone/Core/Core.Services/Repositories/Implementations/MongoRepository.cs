using System.Linq.Expressions;
using DarazClone.Core.Entities.Product;
using MongoDB.Bson;
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

    public async Task InsertAsync<TEntity>(TEntity entity)
    {
        var collection = GetCollection<TEntity>();
        await collection.InsertOneAsync(entity);
    }

    public async Task<List<TEntity>> RunAggregationAsync<TEntity>(PipelineDefinition<TEntity, TEntity> pipeline)
    {

        var collection = GetCollection<TEntity>();

        var res = await collection.Aggregate(pipeline).ToListAsync();

        return res;


    }

    public Task UpdateAsync<TEntity, TResponse>(string id, TEntity entity)
    {
        throw new NotImplementedException();
    }

    private IMongoCollection<TEntity> GetCollection<TEntity>()
    {
        // Extracting collection name from the given Type
        var collectionName = typeof(TEntity).Name + "s";
        var collection = _db.GetCollection<TEntity>(collectionName);

        return collection;
    }

}