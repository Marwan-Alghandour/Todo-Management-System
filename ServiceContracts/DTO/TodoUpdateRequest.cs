using Entities;
using ServiceContracts.CustomValidators;
using ServiceContracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class TodoUpdateRequest
    {
        [Required(ErrorMessage = "Todo Id can't be blank")]
        public required Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Todo Title can't be blank")]
        [MaxLength(100, ErrorMessage = "Title can't exceed 100 characters")]
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        [NotBeforeTodayDateValidator(ErrorMessage = "Todo Due Date can't be earlier than today's date")]
        [DataType(DataType.Date)]
        public DateOnly? DueDate { get; set; }

        public Todo ToTodo()
        {
            return new Todo() { Id = Id, Title = Title, Description = Description, Status = Status.ToString(), Priority = Priority.ToString(), DueDate = DueDate };
        }
    }
}
