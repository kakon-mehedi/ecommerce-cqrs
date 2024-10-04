using System;

namespace DarazClone.Students.Services.Models;

public class GetAllStudentsWithProjectionQueryResponseModel
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; } = 0;

    public string Department { get; set; } = string.Empty;
}
