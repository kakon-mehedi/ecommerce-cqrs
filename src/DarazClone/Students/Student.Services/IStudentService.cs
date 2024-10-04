using System;
using DarazClone.Core.Entities.Student;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Commands;
using MongoDB.Driver;

namespace DarazClone.Students.Services;

public interface IStudentService
{
    Task<ApiResponseModel> CreateStudentAsync (CreateStudentCommand command);

    Task<ApiResponseModel> CreateMultipleStudentsAsync (CreateMultipleStudentsCommand command);

    Task<ApiResponseModel> GetAllStudents();

    Task<ApiResponseModel> GetAllStudentsWithProjection();

    Task<ApiResponseModel> GetStudentByIdAsync (string id);
    Task<ApiResponseModel> GetStudentByIdAsyncWithProjection (string id);

    Task<ApiResponseModel> UpdateStudentAsync (UpdateStudentCommand command);

    Task<ApiResponseModel> UpdateMultipleStudentAsync(UpdateMultipleStudentsCommand command);

    Task<ApiResponseModel> DeleteStudentAsync (DeleteStudentCommand command);

    Task<ApiResponseModel> DeleteMultipleStudentAsync(DeleteMultipleStudentsCommand command);


}
