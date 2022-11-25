using Microsoft.AspNetCore.Identity;
using Todo.Models;
using Todo.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Services
{
    public interface IAccountService
    {
        public Task<ActionResult<SignUpDTO>> SignUpAsync(SignUpDTO model);
        public Task<string> SignInAsync(SignInDTO model);
    }
}
