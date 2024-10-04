using System;

namespace DarazClone.Core.Shared.Interfaces;

public interface IPagination
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
    int TotalItems { get; set; }


}