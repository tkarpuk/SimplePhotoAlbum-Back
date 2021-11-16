using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SimplePhotoAlbum_Back.Authorization;

namespace SimplePhotoAlbum_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger _logger;
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var userInspector = new UserInspector(email, password);
            if (!userInspector.ChekUser())
            {
                _logger.LogWarning($"Unknown user email {email}.");
                return BadRequest(new { errorText = "Invalid email or password." });
            }

            var claimIndentity = new ClaimIndentity(userInspector.GetUser());
            var jwtCreator = new JwtCreator(claimIndentity.ReturnClaims());

            return Ok(JsonSerializer.Serialize(jwtCreator.GetResponse()));
        }
    }
}
