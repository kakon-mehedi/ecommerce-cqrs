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
        var pageSize = 10;
        var pageNumber = 0;

        var response = new ApiResponseModel();

        var matchFilter = Builders<User>.Filter.Where(f => f.isActive == true);

        // Giving paginated data 
        var pipeline = new EmptyPipelineDefinition<User>()
            .Match(matchFilter).Skip(pageSize * pageNumber).Limit(pageSize);


        var data = await _repo.RunAggregationAsync(pipeline);
        response.SetData(data);

        return response;

    }

    public async Task<ApiResponseModel> GetTotalActiveFemaleUsers()
    {
        var response = new ApiResponseModel();

        BsonArray pipelines = MakeTotalFemaleActiveUserAggregationPipelines();

        IEnumerable<TotalFemaleActiveUserProjectionModel> data = await _repoV2.RungAggregationPipelinesAsync<User, TotalFemaleActiveUserProjectionModel>(pipelines);
        
        // FristOrDefault will solve Response.Data[0] issue
        var result = data.FirstOrDefault();

        response.SetSuccess(result);

        return response;
    }

    public async Task<ApiResponseModel> GetTotalActiveUsersCount()
    {
        var response = new ApiResponseModel();

        BsonArray pipelines = MakeTotalActiveUserAggregationPipelines();

        var data = await _repoV2.RungAggregationPipelinesAsync<User, TotalActiveUserProjectionModel>(pipelines);

        // FristOrDefault will solve Response.Data[0] issue
        response.SetSuccess(data.FirstOrDefault());

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

    BsonArray MakeTotalActiveUserAggregationPipelines()
    {
        var pipelines = new BsonArray
        {
            new BsonDocument("$match",
            new BsonDocument("isActive", true)),
            new BsonDocument("$facet",
            new BsonDocument
                {
                    { "TotalMaleActiveUsers",
            new BsonArray
                    {
                        new BsonDocument("$match",
                        new BsonDocument("gender", "male")),
                        new BsonDocument("$count", "count")
                    } },
                    { "TotalFemaleActiveUsers",
            new BsonArray
                    {
                        new BsonDocument("$match",
                        new BsonDocument("gender", "female")),
                        new BsonDocument("$count", "count")
                    } },
                    { "TotalActiveUsers",
            new BsonArray
                    {
                        new BsonDocument("$count", "count")
                    } }
                }),
            new BsonDocument("$project",
            new BsonDocument
                {
                    { "TotalActiveUsersMale",
            new BsonDocument("$arrayElemAt",
            new BsonArray
                        {
                            "$TotalMaleActiveUsers.count",
                            0
                        }) },
                    { "TotalActiveUsersFemale",
            new BsonDocument("$arrayElemAt",
            new BsonArray
                        {
                            "$TotalFemaleActiveUsers.count",
                            0
                        }) },
                    { "TotalActiveUsers",
            new BsonDocument("$arrayElemAt",
            new BsonArray
                        {
                            "$TotalActiveUsers.count",
                            0
                        }) }
                })
        };

        return pipelines;
    }

    BsonArray MakeTotalFemaleActiveUserAggregationPipelines()
    {
        var pipelines = new BsonArray
        {
            new BsonDocument("$match",
            new BsonDocument
                {
                    { "isActive", true },
                    { "gender", "female" }
                }),
            new BsonDocument("$count", "TotalFemaleActiveUser")
        };

        return pipelines;
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