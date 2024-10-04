using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Services;
using DarazClone.Students.Services.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DarazClone.WebService.Controllers.Students;

[Route("api/[controller]/[action]")]
[ApiController]
public class StudentController : ControllerBase
{
    private IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public async Task<ApiResponseModel> CreateStudent([FromBody] Student student)
    {
        var response = new ApiResponseModel();
        var data = await _studentService.CreateStudentAsync(student);
        response.SetData(data);

        return response;
    }

    [HttpPost]
    public async Task<ApiResponseModel> CreateMultipleStudent([FromBody] List<Student> students)
    {
        var response = new ApiResponseModel();
        var data = await _studentService.CreateMultipleStudentsAsync(students);
        response.SetData(data);

        return response;
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetAllStudents()
    {
        var response = new ApiResponseModel();

        var data = await _studentService.GetAllStudents();

        response.SetData(data);

        return response;
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetAllStudentsWithProjection()
    {
        var response = new ApiResponseModel();

        var data = await _studentService.GetAllStudents();

        response.SetData(data);

        return response;
    }


    [HttpGet]
    public async Task<ApiResponseModel> GetStudentDetails(string id)
    {
        var response = new ApiResponseModel();

        var data = await _studentService.GetStudentByIdAsync(id);

        response.SetData(data);

        return response;
    }
}

