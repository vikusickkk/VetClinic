using Microsoft.AspNetCore.Mvc;
using VetClinic.BL.Auth;

namespace VetClinic.WebAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthProvider _authProvider;

        public AuthController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> LoginClient(string email, string password)
        {
            var tokens = await _authProvider.AuthorizeClient(email, password);
            return Ok(tokens);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterClient(string email, string password)
        {
            await _authProvider.RegisterClient(email, password);
            return Ok();
        }
    }
}
