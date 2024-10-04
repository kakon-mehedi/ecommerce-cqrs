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

    Task<List<TEntity>> RunAggregationAsync<TEntity>(PipelineDefinition<TEntity, TEntity> pipeline);

    #endregion

    #region Insert
    
    Task InsertAsync<TEntity>(TEntity entity);
    
    #endregion


    #region Update

    Task UpdateAsync<TEntity, TResponse>(string id, TEntity entity);
   
    #endregion

    #region Upsert

    #endregion

    #region Delete
    Task DeleteAsync(string id);
    
    #endregion
}