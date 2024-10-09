using System;
using System.Security.Cryptography.X509Certificates;
using DarazClone.Core.Services.Repositories;
using DarazClone.Core.Services.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Reports.Services.Models;

namespace Reports.Services.Implementations;

public class UserReportService : IUserReportService
{
    private readonly IRepository _repo;
    private readonly IRepositoryV2 _repoV2;
    public UserReportService(IRepository repo, IRepositoryV2 repoV2)
    {
        _repo = repo;
        _repoV2 = repoV2;
    }

    public async Task<ApiResponseModel> GetListOfActiveUsers()
    {
        var response = new ApiResponseModel();

        var matchFilter = Builders<User>.Filter.Where(f => f.isActive == true);

        var pipeline = new EmptyPipelineDefinition<User>()
            .Match(matchFilter);


        var data = await _repo.RunAggregationAsync(pipeline);
        response.SetData(data);

        return response;

    }

    public async Task<ApiResponseModel> GetNumberOfTotalActiveUsers()
    {
        var response = new ApiResponseModel();

        var matchFilter = Builders<User>.Filter.Where(f => f.isActive == true);


        var pipeline = new EmptyPipelineDefinition<User>();

        pipeline
            .Match(matchFilter)
            .Count();


        var data = await _repo.RunAggregationAsync(pipeline);
        response.SetData(data);

        return response;

    }

    public async Task<ApiResponseModel> GetUsersGroupByGenderWithProjection()
    {
        var response = new ApiResponseModel();

        BsonArray pipelines = MakeUserGroupByGenderAggregationPipelines();

        var data = await _repoV2.RungAggregationPipelinesAsync<User, UserGroupByGenderProjectionModel>(pipelines);

        response.SetData(data);

        return response;
    }

    BsonArray MakeUserGroupByGenderAggregationPipelines()
    {
        var pageSize = 10;
        var pageNumber = 0;

        var pipelines = new BsonArray
        {
            new BsonDocument("$group", 
            new BsonDocument
                {
                    { "_id", "$gender" }, 
                    { "DataKakon", 
            new BsonDocument("$push", 
            new BsonDocument
                        {
                            { "Name", "$name" }, 
                            { "Age", "$age" }, 
                            { "Comapany", "$company" }
                        }) }
                }),
            new BsonDocument("$project", 
            new BsonDocument("DataMehedi", 
            new BsonDocument("$slice", 
            new BsonArray
                        {
                            "$DataKakon",
                            pageSize * pageNumber,
                            pageSize
                        })))
        };

        return pipelines;
    }
}