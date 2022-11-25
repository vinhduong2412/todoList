using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs
{
    public class SignInDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
