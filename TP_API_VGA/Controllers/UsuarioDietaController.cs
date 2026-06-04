using GymAPI.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioDietaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioDietaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioDieta
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuariosDieta = await _context.UsuarioDietas
                .ToListAsync();

            return Ok(usuariosDieta);
        }

        // GET: api/UsuarioDieta/juan
        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var dietas = await _context.UsuarioDietas
                .Where(x => x.Username == username)
                .ToListAsync();

            if (!dietas.Any())
                return NotFound($"No se encontraron dietas para el usuario {username}");

            return Ok(dietas);
        }

        // GET: api/UsuarioDieta/dieta/11
        [HttpGet("dieta/{idDieta}")]
        public async Task<IActionResult> GetByDieta(int idDieta)
        {
            var usuarios = await _context.UsuarioDietas
                .Where(x => x.ID_Dieta == idDieta)
                .ToListAsync();

            return Ok(usuarios);
        }

        // POST: api/UsuarioDieta
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDieta model)
        {
            _context.UsuarioDietas.Add(model);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetByUsername),
                new { username = model.Username },
                model);
        }

        // PUT: api/UsuarioDieta
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UsuarioDieta model)
        {
            var registro = await _context.UsuarioDietas
                .FirstOrDefaultAsync(x =>
                    x.ID_Dieta == model.ID_Dieta &&
                    x.Username == model.Username);

            if (registro == null)
                return NotFound();

            registro.FechaInicio = model.FechaInicio;
            registro.FechaFin = model.FechaFin;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/UsuarioDieta/11/juan
        [HttpDelete("{idDieta}/{username}")]
        public async Task<IActionResult> Delete(int idDieta, string username)
        {
            var registro = await _context.UsuarioDietas
                .FirstOrDefaultAsync(x =>
                    x.ID_Dieta == idDieta &&
                    x.Username == username);

            if (registro == null)
                return NotFound();

            _context.UsuarioDietas.Remove(registro);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}