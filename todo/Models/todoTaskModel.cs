
using System.ComponentModel.DataAnnotations;

namespace todo.Models
{
    public class todoTaskModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; }
        public bool? Status { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? Categoryname { get; set; }
        public DateTime? Date { get; set; }
    }
}
