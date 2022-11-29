using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
        public virtual ICollection<todoTask> Tasks { get; set; }
    }
}
