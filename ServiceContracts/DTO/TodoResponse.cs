using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.DTO
{
    public class TodoResponse
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Status { get; set; }
        public required string Priority { get; set; }
        public DateOnly? DueDate { get; set; }
        public TodoUpdateRequest ToTodoUpdateRequest()
        {
            return new TodoUpdateRequest() { Id = Id, Title = Title, Description = Description, Status = (Status)Enum.Parse(typeof(Status), Status, true), Priority = (Priority)Enum.Parse(typeof(Priority), Priority, true), DueDate = DueDate };
        }
    }
    public static class TodoExtensions
    {
        public static TodoResponse ToTodoResponse(this Todo todo)
        {
            return new TodoResponse() { Id = todo.Id, Title = todo.Title, Description = todo.Description, Status = todo.Status, Priority = todo.Priority, DueDate = todo.DueDate };
        }
    }
}
