using Bank.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _userRepo;
        public UsersController(IUsersRepository userRepo) => this._userRepo = userRepo;

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(string Username, string Password)
        {
            var user = _userRepo.Authenticate(Username, Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(user);
        }
    }
}
