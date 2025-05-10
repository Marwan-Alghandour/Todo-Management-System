using Entities;
using ServiceContracts.CustomValidators;
using ServiceContracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class TodoAddRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Todo Title can't be blank")]
        [MaxLength(100, ErrorMessage = "Title can't exceed 100 characters")]
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public Status Status { get; set; } = Status.Pending;
        public Priority Priority { get; set; } = Priority.Low;
        [NotBeforeTodayDateValidator(ErrorMessage = "Todo Due Date can't be earlier than today's date")]
        [DataType(DataType.Date)]
        public DateOnly? DueDate { get; set; }

        public Todo ToTodo()
        {
            return new Todo() { Title = Title, Description = Description, Status = Status.ToString(), Priority = Priority.ToString(), DueDate = DueDate };
        }
    }
}
