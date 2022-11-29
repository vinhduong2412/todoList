using Microsoft.AspNetCore.Identity;
using Todo.Models;
using Todo.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Services
{
    public interface IAccountService
    {
        Task<ActionResult<SignUpDTO>> SignUpAsync(SignUpDTO model);
        Task<string> SignInAsync(SignInDTO model);
    }
}
