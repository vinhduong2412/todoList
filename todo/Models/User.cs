using Microsoft.AspNetCore.Identity;

namespace Todo.Models
{
    public class User : IdentityUser
    {
        [required]
        public string FirstName { get; set; } 
        [required]
        public string LastName { get; set; } 
    }
}
