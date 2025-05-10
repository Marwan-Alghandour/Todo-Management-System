using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using ServiceContracts.Enums;

namespace Repositories
{
    public class TodosRepository : ITodosRepository
    {
        private readonly TodoDbContext _db;
        public TodosRepository(TodoDbContext db)
        {
            _db = db;
        }

        public async Task<Todo> AddTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            todo.CreatedDate = DateTime.Now;
            todo.LastModifiedDate = DateTime.Now;

            await _db.Todos.AddAsync(todo);
            await _db.SaveChangesAsync();

            return todo;

        }
        public async Task<List<Todo>> GetAllTodos()
        {
            return await _db.Todos.ToListAsync();
        }

        public async Task<Todo?> GetTodoById(Guid id)
        {
            return await _db.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
        }
        public async Task<List<Todo>> GetFilteredByStatusTodos(string status)
        {
            return await _db.Todos.Where(todo => todo.Status == status).ToListAsync();
        }

        public async Task<Todo> UpdateTodo(Todo todo)
        {
            Todo? result = await _db.Todos.FirstOrDefaultAsync(dbTodo => dbTodo.Id == todo.Id);
            if (result == null)
            {
                throw new ArgumentNullException("Id doesn't exist");
            }

            result.Title = todo.Title;
            result.Description = todo.Description;
            result.Status = todo.Status.ToString();
            result.Priority = todo.Priority.ToString();
            result.DueDate = todo.DueDate;
            result.LastModifiedDate = DateTime.Now;

            await _db.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteTodo(Guid id)
        {
            Todo? todo = await _db.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkAsCompleted(Guid id)
        {
            Todo? todo = await _db.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            todo.Status = Status.Completed.ToString();
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
