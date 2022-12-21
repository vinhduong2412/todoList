using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
    [Table("todoTasks")]
    public class TodoTask
    {
        [Key]
        public int TaskId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public bool? Status { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("Categories")]
        public string? Id { get; set; }
        [ForeignKey("Users")]   
        public DateTime? Date { get; set; }
    }
}
