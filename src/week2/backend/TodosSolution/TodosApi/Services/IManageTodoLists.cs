namespace TodosApi.Services;

public interface IManageTodoLists
{
    Task<todoItemResponse> AddTodoItemAsync(TodoCreateRequest request);
    Task<TodoListSummaryResponse> GetAllTodosAsync();
}
