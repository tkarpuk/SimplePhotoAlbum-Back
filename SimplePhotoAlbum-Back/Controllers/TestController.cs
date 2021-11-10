using Microsoft.AspNetCore.Mvc;
using System;

namespace SimplePhotoAlbum_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("G");
        }
    }
}
