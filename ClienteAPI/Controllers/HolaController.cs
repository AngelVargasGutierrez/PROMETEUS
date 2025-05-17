using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("¡Hola Mundo desde la API!");
        }
    }
} 