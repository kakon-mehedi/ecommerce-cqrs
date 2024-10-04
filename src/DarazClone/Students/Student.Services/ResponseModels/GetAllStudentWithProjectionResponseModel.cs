using System;

namespace DarazClone.Students.Services.ResponseModels;

public class GetAllStudentWithProjectionResponseModel
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Department { get; set; } = string.Empty;
    public string ItemId { get; set; } = string.Empty;

}
