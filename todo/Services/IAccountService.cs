using Microsoft.AspNetCore.Identity;
using Todo.Models;
using Todo.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Services
{
    public interface IAccountService
    {
        Task<ActionResult<SignUpRequestDTO>> SignUpAsync(SignUpRequestDTO model);
        Task<string> SignInAsync(SignInRequestDTO model);
    }
}
