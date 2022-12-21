using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } 
        [Required]
        public string LastName { get; set; }
        public ICollection<TodoTask> TodoTasks { get; set; }
        public ICollection<Category> CategoryTasks { get; set; }
    }
}
