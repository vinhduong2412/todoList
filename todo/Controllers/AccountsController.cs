using Microsoft.AspNetCore.Mvc;
using Todo.DTOs;
using Todo.Models;
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
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO input)
        {
            var result = await accountRepo.SignUpAsync(input);
            return Ok(result);
        }
        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromBody] SignInDTO input)
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
