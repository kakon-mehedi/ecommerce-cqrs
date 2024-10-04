using System;

namespace Reports.Services.Models;

public class UserReportResponseModel
{
    public int NumberOfActiveUser { get; set; } = 0;
    public int AvgAgeOfUsers { get; set; } = 0;
    public List<string> TopFiveFavoriteFruits { get; set; } = new List<string>();

    public int TotalNumberOfFemales { get; set; } = 0;

    public int TotalNumberOfMales { get; set; } = 0;

}
