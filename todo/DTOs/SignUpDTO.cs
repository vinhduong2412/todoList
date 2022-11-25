using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs
{
    public class SignUpDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
