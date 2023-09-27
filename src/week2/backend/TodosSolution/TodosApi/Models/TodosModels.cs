using System.ComponentModel.DataAnnotations;

namespace TodosApi.Models;

public record TodoCreateRequest
{
    [Required, MaxLength(255)]
    public string Description { get; set; } = string.Empty;
}

public record todoItemResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
}

public record TodoListSummaryResponse
{
    public IReadOnlyList<todoItemResponse>? Items { get; set; }
}