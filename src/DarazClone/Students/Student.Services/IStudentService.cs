using System;
using DarazClone.Core.Entities.Student;

namespace DarazClone.Students.Services;

public interface IStudentService
{
    Task<Student> CreateStudentAsync (Student student);

    Task<List<Student>> CreateMultipleStudentsAsync (List<Student> students);

    Task<List<Student>> GetAllStudents();

    Task<Student> GetStudentByIdAsync (string id);

    Task<Student> UpdateStudentAsync (string id, Student student);

    Task<List<Student>> UpdateMultipleStudentAsync(List<string> ids, List<Student> students);

    Task DeleteStudentAsync (string id);

    Task DeleteMultipleStudentAsync(List<string> ids);


}
