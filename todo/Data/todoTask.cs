using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo.Data
{
    [Table("todoTask")]
    public class todoTask
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; }
        public bool? Status { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [MaxLength(100)]
        public DateTime? Date { get; set; }
        public int? CId { get; set; }
        [ForeignKey("CId")]
        public Category Category { get; set; }
    }
}
