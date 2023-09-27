using Marten;

namespace TodosApi.Services;

public class PostgresMartenTodoListManager : IManageTodoLists
{

    private readonly IDocumentSession _session;

    public PostgresMartenTodoListManager(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<todoItemResponse> AddTodoItemAsync(TodoCreateRequest request)
    {
        var itemToSave = new todoItemResponse
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Completed = false,
        };

        _session.Insert(itemToSave);
        await _session.SaveChangesAsync();
        return itemToSave;
    }

    public async Task<TodoListSummaryResponse> GetAllTodosAsync()
    {
        var items = await _session.Query<todoItemResponse>().ToListAsync();

        return new TodoListSummaryResponse { Items = items };
    }
}
