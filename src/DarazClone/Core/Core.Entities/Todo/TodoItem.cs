namespace DarazClone.Core.Entities.Todo;

public class TodoItem: EntityBase
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
}
