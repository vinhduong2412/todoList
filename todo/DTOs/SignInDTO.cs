using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs
{
    public class SignInInput
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
