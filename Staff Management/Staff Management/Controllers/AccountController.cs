using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffManage.Models;
using StaffManage.Repositories;

namespace StaffManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository repo)
        {
            accountRepo = repo;
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public IActionResult SignIn(LogInModel model)
        {
            var result =  accountRepo.SignInAsync(model.Username, model.Password);

            if (result == null)
            {
                return BadRequest(new { message = "Account or password is incorrect" });
            }

            return Ok(result);
        }
    }
}
