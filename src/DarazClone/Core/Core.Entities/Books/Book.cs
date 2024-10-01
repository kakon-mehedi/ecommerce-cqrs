using System;
using DarazClone.Core.Shared.Enums.Books;
using MongoDB.Bson;

namespace DarazClone.Core.Entities.Books;

public class Book
{
    ObjectId Id { get; set; } = ObjectId.Empty;

    public string Title { get; set; } = string.Empty;

    public ObjectId AuthorId { get; set; } = ObjectId.Empty;

    public BooksGenreEnums Genre { get; set; } = BooksGenreEnums.Default;
}
