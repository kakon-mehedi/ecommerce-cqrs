using System;
using DarazClone.Core.Entities.Student;
using DarazClone.Students.Commands;

namespace DarazClone.Students.Services.Mappings;

public static class StudentEntityMapper
{
    public static Student MapToStudentEntity(this CreateStudentCommand source) 
    {
        var destination = new Student();

        destination.Name = source.Name;
        destination.Department = source.Department;
        destination.Age = source.Age;
        destination.Group = source.Group;
        destination.FavoriteFruits = source.FavoriteFruits;
        destination.FamilyMonthlyIncome = source.FamilyMonthlyIncome;
        destination.Gender = source.Gender;
        destination.Year = source.Year;
        destination.Session = source.Session;
        destination.RollNumber = source.RollNumber;

        return destination;
    }
}
