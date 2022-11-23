using Microsoft.AspNetCore.Identity;
using todo.Models;

namespace todo.Repositories
{
    public interface IAccountRepo
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
