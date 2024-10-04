using System;
using DarazClone.Core.Entities.Student;
using DarazClone.Core.Services.Repositories;
using MongoDB.Bson;

namespace DarazClone.Students.Services.Implementations;

public class StudentService : IStudentService
{
    private IRepositoryV2 _repo;
    public StudentService(IRepositoryV2 repo)
    {
        _repo = repo;
    }

    public async Task<List<Student>> CreateMultipleStudentsAsync(List<Student> students)
    {
        foreach (var student in students)
        {
            if (string.IsNullOrWhiteSpace(student.ItemId))
            {
                student.ItemId = ObjectId.GenerateNewId().ToString();
            }
        }

        try
        {
            await _repo.InsertMultiAsync(students);
            return students;
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    public async Task<Student> CreateStudentAsync(Student student)
    {

        if (string.IsNullOrWhiteSpace(student.ItemId))
        {
            student.ItemId = ObjectId.GenerateNewId().ToString();
        }

        try
        {
            await _repo.InsertOneAsync(student);
            return student;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task DeleteMultipleStudentAsync(List<string> ids)
    {
        await _repo.DeleteMultiAsync<Student>(ids);
    }

    public Task DeleteStudentAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Student>> GetAllStudents()
    {
        var res = await _repo.FindAllAsync<Student>();
        return res.ToList();
    }

    public async Task<Student> GetStudentByIdAsync(string id)
    {
        return await _repo.FindOneAsync<Student>(id);
    }

    public async Task<List<Student>> UpdateMultipleStudentAsync(List<string> ids, List<Student> students)
    {
        try
        {
            await _repo.UpdateMultiAsync<Student>(ids, students);
        }
        catch (System.Exception)
        {

            throw;
        }

        return students;


    }

    public async Task<Student> UpdateStudentAsync(string id, Student student)
    {
        await _repo.UpdateOneAsync(id, student);

        return student;
    }
}
