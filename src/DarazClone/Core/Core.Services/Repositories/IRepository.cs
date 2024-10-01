using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity.Data;
using MongoDB.Driver;

namespace DarazClone.Core.Services.Repositories;

public interface IRepository
{
    #region  Get

    Task<TResponse> GetByIdAsync<TEntity, TResponse>(string id);
    Task<IEnumerable<TRes>> GetAllAsync<TQuery, TRes>();

    Task<IEnumerable<TModel>> GetAllAsync<TModel>();

    Task<IEnumerable<TResponse>> GetAllAsync<TEntity, TResponse>(Expression<Func<TEntity, bool>> predicate);

    Task<IAsyncCursor<TProjection>> FindAsync<TProjection, TEntity>(FilterDefinition<TEntity> filter, FindOptions<TEntity, TProjection> options = null);


    #endregion

    #region Insert
    
    Task InsertOneAsync<TEntity>(TEntity entity);
    Task InsertManyAsync<TEntity>(List<TEntity> entities);
    
    #endregion


    #region Update

    Task UpdateOneAsync<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updatedData, UpdateOptions options);
    Task UpdateManyAsync<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updatedDataList, UpdateOptions options);
    
   
    #endregion

    #region Upsert

    #endregion

    #region Delete
    Task DeleteAsync(string id);
    
    #endregion
}