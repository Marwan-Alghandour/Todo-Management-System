using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Status { get; set; }
        public required string Priority { get; set; }
        public DateOnly? DueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }
}
