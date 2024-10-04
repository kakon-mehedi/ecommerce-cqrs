using System;
using DarazClone.Core.Entities.Student;
using DarazClone.Core.Services.Injectors;
using DarazClone.Core.Services.Repositories;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Commands;
using DarazClone.Students.Services.Mappings;
using MongoDB.Bson;

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

    public Task DeleteMultipleStudentAsync(DeleteMultipleStudentsCommand command)
    {
        throw new NotImplementedException();
    }

    public Task DeleteStudentAsync(DeleteStudentCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponseModel> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponseModel> GetStudentByIdAsync(string id)
    {
        throw new NotImplementedException();
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
