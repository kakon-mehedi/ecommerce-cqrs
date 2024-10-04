using System;

namespace DarazClone.Core.Services.Models;

public class Pagination
{
    // Properties
    public int PageNumber { get; private set; }       // Current page number
    public int PageSize { get; private set; }         // Number of items per page
    public int TotalItems { get; private set; }       // Total number of items in the dataset
    public int TotalPages { get; private set; }       // Total number of pages
    public bool HasPreviousPage => PageNumber > 1;    // True if there is a previous page
    public bool HasNextPage => PageNumber < TotalPages; // True if there is a next page

    // Constructor
    public Pagination(int totalItems, int pageNumber, int pageSize)
    {
        // Ensure pageSize is at least 1
        PageSize = (pageSize > 0) ? pageSize : 10; // Default to 10 if not provided or invalid
        
        // Calculate total pages
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
        
        // Ensure page number is within valid range
        PageNumber = (pageNumber > 0) ? pageNumber : 1;
        if (PageNumber > TotalPages) PageNumber = TotalPages;  // Set to last page if exceeded
    }

    // Offset to skip records for the current page
    public int Skip => (PageNumber - 1) * PageSize;

    // Method to create a Pagination object for a list with the same settings
    public static Pagination Create(int totalItems, int pageNumber, int pageSize)
    {
        return new Pagination(totalItems, pageNumber, pageSize);
    }

    // Static method to return an empty pagination (default values)
    public static Pagination Empty => new Pagination(0, 1, 10);
}
