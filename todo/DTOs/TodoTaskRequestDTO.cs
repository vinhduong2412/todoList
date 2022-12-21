
using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs
{
    public class TodoTaskRequestDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public bool? Status { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public int? CategoryId { get; set; }
    }
}
