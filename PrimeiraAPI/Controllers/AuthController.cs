using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PrimeiraAPI.Services;

namespace PrimeiraAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("api/login")]
        public IActionResult Login(string username, string password)
        {
            var user = _userManager.FindByNameAsync(username).Result;

            if (user == null)
            {
                return BadRequest("Usuario e senhas nao cadastrado");
            }
            var result = _signInManager.CheckPasswordSignInAsync(user, password, false).Result;
            if (result.Succeeded)
            {
                var token = TokenService.GenerateToken(user);
                return Ok(token);
            }
            return Unauthorized();
        }
        [HttpPost("api/logout")]
        public IActionResult Logout()
        {
            var result = _signInManager.SignOutAsync();
            if (result.IsCompletedSuccessfully)
            {
                return Ok();
            }

            return BadRequest(StatusCodes.Status503ServiceUnavailable);
        }
    }
}
