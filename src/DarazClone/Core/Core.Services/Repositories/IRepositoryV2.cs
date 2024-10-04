using System;
using DarazClone.Core.Shared.Interfaces;
using MongoDB.Driver;

namespace DarazClone.Core.Services.Repositories;

public interface IRepositoryV2
{
    #region  Commands 
    Task InsertOneAsync<TEntity>(TEntity item);

    Task InsertMultiAsync<TEntity> (List<TEntity> items);

    Task UpdateOneAsync<TEntity>(string id, TEntity item);

    Task UpdateMultiAsync<TEntity>(List<string> ids, List<TEntity> items);

    Task<DeleteResult> DeleteOneAsync<TEntity> (string id);

    Task<DeleteResult> DeleteMultiAsync<TEntity>(List<string> ids);
    
    #endregion

    #region  Query

    Task<TEntity> FindOneAsync<TEntity>(string id);
    Task<TEntity> FindOneAsyncWithProjection<TEntity>(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> projection);

    Task<IEnumerable<TEntity>> FindAllAsync<TEntity>();
    Task<IEnumerable<TEntity>> FindAllAsyncWithProjection<TEntity>(ProjectionDefinition<TEntity> projection);

    Task<IEnumerable<TEntity>> FindAllAsyncPaginated<TEntity>(FilterDefinition<TEntity> filter, IPagination pagination);
    Task<IEnumerable<TEntity>> FindAllAsyncPaginatedWithProjection<TEntity>(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> projection, IPagination pagination);

    #endregion

    
    #region Aggregation 

    #endregion
}
