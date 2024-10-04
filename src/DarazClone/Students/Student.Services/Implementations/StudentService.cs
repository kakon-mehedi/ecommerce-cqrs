using System;
using DarazClone.Core.Entities.Student;
using DarazClone.Core.Services.Injectors;
using DarazClone.Core.Services.Repositories;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Commands;
using DarazClone.Students.Services.Mappings;

using MongoDB.Driver;

namespace DarazClone.Students.Services.Implementations;

public class StudentService : IStudentService
{
    private IRepositoryV2 _repo;
    private ICommonValueInjectorService _commonValueInjectorService;

    private IMetadataInjectorService _metadataInjectorService;
    public StudentService(IRepositoryV2 repo, ICommonValueInjectorService commonValueInjector, IMetadataInjectorService metadataInjectorService)
    {
        _repo = repo;
        _commonValueInjectorService = commonValueInjector;
        _metadataInjectorService = metadataInjectorService;

    }

    public Task<ApiResponseModel> CreateMultipleStudentsAsync(CreateMultipleStudentsCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponseModel> CreateStudentAsync(CreateStudentCommand command)
    {
        var response = new ApiResponseModel();
        var student = command.MapToStudentEntity();
        _commonValueInjectorService.Inject(student);
        _metadataInjectorService.Inject(student);

        await _repo.InsertOneAsync(student);

        response.SetSuccess(student);

        return response;
    }

    public async Task<ApiResponseModel> GetAllStudents()
    {
        var response = new ApiResponseModel();

        var data = await _repo.FindAllAsync<Student>();

        response.SetSuccess(data.ToList());

        return response;
    }

    public async Task<ApiResponseModel> GetAllStudentsWithProjection()
    {
        var response = new ApiResponseModel();

        ProjectionDefinition<Student> projection =
        Builders<Student>.Projection
        .Include(x => x.ItemId)
        .Include(x => x.Name)
        .Include(x => x.Age)
        .Include(x => x.Department);

        var data = await _repo.FindAllAsyncWithProjection(projection);

        response.SetSuccess(data.ToList());

        return response;
    }

    public async Task<ApiResponseModel> GetStudentByIdAsync(string id)
    {
        var response = new ApiResponseModel();
        var data = await _repo.FindOneAsync<Student>(id);
        response.SetSuccess(data);

        return response;
    }

    public async Task<ApiResponseModel> GetStudentByIdAsyncWithProjection(string id)
    {
        var response = new ApiResponseModel();
        FilterDefinition<Student> filter = Builders<Student>.Filter.Where(x => x.ItemId == id);
        ProjectionDefinition<Student> projection = 
        Builders<Student>.Projection
        .Include(x => x.ItemId)
        .Include(x => x.Name)
        .Include(x => x.Age)
        .Include(x => x.Department);
        
        var data = await _repo.FindOneAsyncWithProjection<Student>(filter, projection);
        response.SetSuccess(data);

        return response;
    }

    public Task<ApiResponseModel> UpdateMultipleStudentAsync(UpdateMultipleStudentsCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponseModel> UpdateStudentAsync(UpdateStudentCommand command)
    {
        throw new NotImplementedException();
    }

    Task<ApiResponseModel> IStudentService.DeleteMultipleStudentAsync(DeleteMultipleStudentsCommand command)
    {
        throw new NotImplementedException();
    }

    Task<ApiResponseModel> IStudentService.DeleteStudentAsync(DeleteStudentCommand command)
    {
        throw new NotImplementedException();
    }
}
