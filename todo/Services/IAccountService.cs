using Microsoft.AspNetCore.Identity;
using Todo.Models;
using Todo.DTOs;

namespace Todo.Services
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUpInput model);
        public Task<string> SignInAsync(SignInInput model);
    }
}
