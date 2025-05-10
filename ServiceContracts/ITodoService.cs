using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ITodoService
    {
        Task<TodoResponse> AddTodo(TodoAddRequest? todoAddRequest);
        Task<List<TodoResponse>> GetAllTodos();
        Task<TodoResponse> GetTodoById(Guid? id);
        Task<List<TodoResponse>> GetFilteredByStatusTodos(string? status);
        Task<TodoResponse> UpdateTodo(TodoUpdateRequest? todoUpdateRequest);
        Task<bool> DeleteTodo(Guid? id);
        Task<bool> MarkAsCompleted(Guid? id);
    }
}
