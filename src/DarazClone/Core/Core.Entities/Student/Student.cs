using System;

namespace DarazClone.Core.Entities.Student;

public class Student : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public int Age { get; set; } = 0;

    public string Group { get; set; } = string.Empty;

    public List<string> FavoriteFruits { get; set; } = new List<string>();

    public int FamilyMonthlyIncome { get; set; } = 0;

    public string Gender { get; set; } = string.Empty;

    public int Year { get; set; } = 0;

    public int Session { get; set; } = 0;

    public int RollNumber { get; set; } = 0;
}
