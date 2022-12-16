using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs
{
    public class SignInRequestDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
