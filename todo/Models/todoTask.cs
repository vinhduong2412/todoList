using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
    [Table("TodoTasks")]
    public class TodoTask
    {
        [Key]
        public int TaskId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public bool? Status { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [ForeignKey("Categories")]
        public int? CategoryId { get; set; }
        [ForeignKey("Users")]
        public Guid? UserId { get; set; }
        public DateTime? Date { get; set; }
    }
}
