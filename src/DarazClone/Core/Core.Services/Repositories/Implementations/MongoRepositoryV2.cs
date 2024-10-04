using System;
using System.ComponentModel.DataAnnotations;
using DarazClone.Core.Shared.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DarazClone.Core.Services.Repositories.Implementations;

public class MongoRepositoryV2 : IRepositoryV2
{
    private readonly IMongoDatabase _db;

    public MongoRepositoryV2(IMongoDatabase database)
    {
        _db = database;
    }

    public async Task<DeleteResult> DeleteMultiAsync<TEntity>(List<string> ids)
    {
        List<ObjectId> objectIds = ids.ConvertAll(id => new ObjectId(id));
        FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.In("_id", objectIds);

        var collection = GetCollection<TEntity>();
        return await collection.DeleteManyAsync(filter);
    }

    public async Task<DeleteResult> DeleteOneAsync<TEntity>(string id)
    {
        ObjectId objectId = new ObjectId(id);

        FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

        var collection = GetCollection<TEntity>();
        return await collection.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync<TEntity>()
    {
        FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Empty;
        var collection = GetCollection<TEntity>();
        return await collection.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAllAsyncPaginated<TEntity>(FilterDefinition<TEntity> filter, IPagination pagination)
    {
        var collection = GetCollection<TEntity>();
        var pageNumber = 1;
        var pageSize = 10;

        var find = collection.Find(filter);

        return await find
        .Skip((pageNumber - 1) * pageSize)
        .Limit(pageSize)
        .ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAllAsyncPaginatedWithProjection<TEntity>(
        FilterDefinition<TEntity> filter,
        ProjectionDefinition<TEntity> projection,
        IPagination pagination
    )
    {
        var collection = GetCollection<TEntity>();

        var result = await collection
        .Find(filter)
        .Project<TEntity>(projection)
        .Skip((pagination.PageNumber - 1) * pagination.PageSize)
        .Limit(pagination.PageSize)
        .ToListAsync();

        return result;
    }

    public async Task<IEnumerable<TProjectedValue>> FindAllAsyncWithProjection<TEntity, TProjectedValue>(
        ProjectionDefinition<TEntity> projection
    )
    {
        var collection = GetCollection<TEntity>();
        FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Empty;

        var find = collection.Find(filter);

        List<BsonDocument> data = new List<BsonDocument>();

        data = await find
        .Project(projection)
        .ToListAsync();

        var result = data
            .Select(x => BsonSerializer.Deserialize<TProjectedValue>(x))
            .ToList();

        return result;
    }

    public async Task<TEntity> FindOneAsync<TEntity>(string id)
    {
        ObjectId objectId = new ObjectId(id);

        FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("ItemId", objectId);
        var collection = GetCollection<TEntity>();
        return await collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<TProjectedValue> FindOneAsyncWithProjection<TEntity, TProjectedValue>(
        FilterDefinition<TEntity> filter,
        ProjectionDefinition<TEntity> projection)
    {
        var collection = GetCollection<TEntity>();
        var find = collection.Find(filter);

        BsonDocument data = new BsonDocument();

        data = await find
        .Project(projection)
        .FirstOrDefaultAsync();


        TProjectedValue result = BsonSerializer.Deserialize<TProjectedValue>(data);
        return result;
    }


    public IMongoCollection<TEntity> GetCollection<TEntity>()
    {
        var collectionName = typeof(TEntity).Name + "s";
        var collection = _db.GetCollection<TEntity>(collectionName);

        return collection;
    }

    public async Task InsertMultiAsync<TEntity>(List<TEntity> items)
    {
        var collection = GetCollection<TEntity>();
        await collection.InsertManyAsync(items);
    }

    public async Task InsertOneAsync<TEntity>(TEntity item)
    {
        var collection = GetCollection<TEntity>();
        await collection.InsertOneAsync(item);
    }

    public async Task UpdateMultiAsync<TEntity>(List<string> ids, List<TEntity> items)
    {
        if (ids == null || items == null || ids.Count != items.Count)
        {
            throw new ArgumentException("Ids and items must not be null, and their counts must match.");
        }

        List<ObjectId> objectIds = ids.ConvertAll(x => new ObjectId(x));

        var collection = GetCollection<TEntity>();

        for (int i = 0; i < ids.Count; i++)
        {
            FilterDefinition<TEntity> idFilter = Builders<TEntity>.Filter.Eq("_id", objectIds[i]);
            UpdateDefinition<TEntity> update = Builders<TEntity>.Update.Set(x => x, items[i]);

            // Update each item individually based on its id
            await collection.UpdateOneAsync(idFilter, update);
        }
    }

    public async Task UpdateOneAsync<TEntity>(string id, TEntity item)
    {
        FilterDefinition<TEntity> filterDefinition = Builders<TEntity>.Filter.Eq("_id", id);
        UpdateDefinition<TEntity> updateDefinition = Builders<TEntity>.Update.Set(x => x, item);

        var collection = GetCollection<TEntity>();

        await collection.UpdateOneAsync(filterDefinition, updateDefinition);
    }

    #region Reza bhai
    public async Task<(List<TProjectedValue>, long)> GetProjectedItemsAsync<TEntity, TProjectedValue>(
        int pageNo,
        int pageSize,
        FilterDefinition<TEntity> filter,
        ProjectionDefinition<TEntity> projection,
        SortDefinition<TEntity> sort = null
    )
    {
        var collection = GetCollection<TEntity>();
        var find = collection.Find(filter);
        var countTask = find.CountDocumentsAsync();

        List<BsonDocument> data = new List<BsonDocument>();

        if (sort == null)
        {
            data = await find
           .Project(projection)
           .Skip(pageSize * pageNo)
           .Limit(pageSize)
           .ToListAsync();
        }
        else
        {
            data = await find
           .Sort(sort)
           .Project(projection)
           .Skip(pageSize * pageNo)
           .Limit(pageSize)
           .ToListAsync();
        }

        var projectionData = data
            .Select(d => BsonSerializer.Deserialize<TProjectedValue>(d))
            .ToList();

        return (projectionData, await countTask);
    }

    public async Task<(List<TProjectedValue>, long)> GetProjectedItemsAsync<TEntity, TProjectedValue>(
        FilterDefinition<TEntity> filter,
        ProjectionDefinition<TEntity> projection,
        SortDefinition<TEntity> sort = null
    )
    {
        var collection = GetCollection<TEntity>();
        var find = collection.Find(filter);
        var countTask = find.CountDocumentsAsync();
        var data = new List<BsonDocument>();

        if (sort == null)
        {
            data = await find
           .Project(projection)
           .ToListAsync();
        }
        else
        {
            data = await find
           .Sort(sort)
           .Project(projection)
           .ToListAsync();
        }
        var projectionData = data
            .Select(d => BsonSerializer.Deserialize<TProjectedValue>(d))
            .ToList();

        return (projectionData, await countTask);
    }

    #endregion
}
