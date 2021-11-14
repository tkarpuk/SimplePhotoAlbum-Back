using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SimplePhotoAlbum_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> GetCurrentTime()
        {
            return Ok(DateTime.Now.ToString("G"));
        }
    }
}
