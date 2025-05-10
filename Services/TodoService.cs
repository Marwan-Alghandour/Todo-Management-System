using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodosRepository _todosRepository;

        public TodoService(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        public async Task<TodoResponse> AddTodo(TodoAddRequest? todoAddRequest)
        {
            if (todoAddRequest == null)
            {
                throw new ArgumentNullException(nameof(todoAddRequest));
            }

            ValidationHelper.ModelValidation(todoAddRequest);

            Todo todo = todoAddRequest.ToTodo();
            await _todosRepository.AddTodo(todo);

            return todo.ToTodoResponse();
        }

        public async Task<List<TodoResponse>> GetAllTodos()
        {
            return (await _todosRepository.GetAllTodos()).Select(todo => todo.ToTodoResponse()).ToList();
        }

        public async Task<TodoResponse> GetTodoById(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Todo? result = await _todosRepository.GetTodoById(id.Value);
            if (result == null)
            {
                throw new ArgumentNullException("Id doesn't exist");
            }
            return result.ToTodoResponse();
        }
        public async Task<List<TodoResponse>> GetFilteredByStatusTodos(string? status)
        {

            return (await _todosRepository.GetFilteredByStatusTodos(status!)).Select(todo => todo.ToTodoResponse()).ToList();

        }

        public async Task<TodoResponse> UpdateTodo(TodoUpdateRequest? todoUpdateRequest)
        {
            if (todoUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(TodoUpdateRequest));
            }

            ValidationHelper.ModelValidation(todoUpdateRequest);

            Todo result = await _todosRepository.UpdateTodo(todoUpdateRequest.ToTodo());

            return result.ToTodoResponse();
        }

        public async Task<bool> DeleteTodo(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _todosRepository.DeleteTodo(id.Value);
        }
        public async Task<bool> MarkAsCompleted(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _todosRepository.MarkAsCompleted(id.Value);
        }
    }
}
