using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Extensions.Logging;

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
            return Ok(JsonSerializer.Serialize("test instead real JWT object"));
        }
    }
}
