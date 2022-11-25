using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Services;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountRepo;

        public AccountsController(IAccountService repo)
        {
            accountRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpInput input)
        {
            var result = await accountRepo.SignUpAsync(input);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return BadRequest();
        }
        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromBody] SignInInput input)
        {
            var result = await accountRepo.SignInAsync(input);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
