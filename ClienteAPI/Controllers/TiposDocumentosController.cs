using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposDocumentosController : ControllerBase
    {
        private static readonly List<object> tipos = new List<object>
        {
            new { Id = 1, Nombre = "DNI" },
            new { Id = 2, Nombre = "Pasaporte" },
            new { Id = 3, Nombre = "Carnet de Extranjería" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tipo = tipos.Find(t => (int)t.GetType().GetProperty("Id").GetValue(t) == id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }
    }
} 