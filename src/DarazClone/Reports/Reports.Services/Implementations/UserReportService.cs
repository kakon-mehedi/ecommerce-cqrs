using System;
using System.Security.Cryptography.X509Certificates;
using DarazClone.Core.Services.Repositories;
using DarazClone.Core.Services.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Reports.Services.Implementations;

public class UserReportService : IUserReportService
{
    private readonly IRepository _repo;
    public UserReportService(IRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponseModel> GetListOfActiveUsers ()
    {
        var response = new ApiResponseModel();

        var matchFilter = Builders<User>.Filter.Where(f => f.isActive == true);

        var pipeline = new EmptyPipelineDefinition<User>()
            .Match(matchFilter);


        var data = await _repo.RunAggregationAsync(pipeline);
        response.SetData(data);

        return response;

    }

    public async Task<ApiResponseModel> GetNumberOfTotalActiveUsers ()
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

}


public class User
{
    public ObjectId id { get; set; } // Assuming the Id is a string type based on your input
    public int index { get; set; }
    public string name { get; set; }
    public bool isActive { get; set; }
    public DateTime registered { get; set; }
    public int age { get; set; }
    public string gender { get; set; }
    public string eyeColor { get; set; }
    public string favoriteFruit { get; set; }

    // Nested Company class
    public Company company { get; set; }
    public List<string> tags { get; set; }
}

public class Company
{
    public string title { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public Location location { get; set; }
}

public class Location
{
    public string country { get; set; }
    public string address { get; set; }
}