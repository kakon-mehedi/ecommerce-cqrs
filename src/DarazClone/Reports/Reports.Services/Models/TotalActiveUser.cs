using System;

namespace Reports.Services.Models;

public class TotalFemaleActiveUserProjectionModel
{
    public int TotalFemaleActiveUser { get; set; } = 0;
}


public class TotalActiveUserProjectionModel
{
    public int TotalActiveUsers { get; set; } = 0;
    public int TotalActiveUsersMale { get; set; } = 0;
    public int TotalActiveUsersFemale { get; set; } = 0;
}
