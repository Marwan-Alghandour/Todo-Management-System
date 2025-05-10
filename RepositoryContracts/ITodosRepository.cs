using Entities;

namespace RepositoryContracts
{
    public interface ITodosRepository
    {
        Task<Todo> AddTodo(Todo todo);
        Task<List<Todo>> GetAllTodos();
        Task<Todo?> GetTodoById(Guid id);
        Task<List<Todo>> GetFilteredByStatusTodos(string status);
        Task<Todo> UpdateTodo(Todo todo);
        Task<bool> DeleteTodo(Guid id);
        Task<bool> MarkAsCompleted(Guid id);
    }
}
