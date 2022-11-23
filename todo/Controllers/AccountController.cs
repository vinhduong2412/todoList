using Microsoft.AspNetCore.Mvc;
using todo.Models;
using todo.Repositories;

namespace todo.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo accountRepo;

        public AccountController(IAccountRepo repo)
        {
            accountRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel model)
        {
            var result = await accountRepo.SignUpAsync(model);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return BadRequest();
        }
        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromBody] SignInModel model)
        {
            var result = await accountRepo.SignInAsync(model);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();    
            }
            return Ok(result);
        }
    }
}
