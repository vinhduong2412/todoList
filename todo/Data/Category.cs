using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo.Data
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
