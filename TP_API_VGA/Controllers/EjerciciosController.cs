using Application.DTOs.EjerciciosDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/ejercicios")]
    public class EjerciciosController : ControllerBase
    {
        private readonly IEjercicioService _service;

        public EjerciciosController(
            IEjercicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            EjercicioCreateDTO dto)
        {
            var id =
                await _service.CreateAsync(dto);

            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            EjercicioUpdateDTO dto)
        {
            dto.ID_Ejercicio = id;

            await _service.UpdateAsync(dto);

            return Ok("Ejercicio actualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok("Ejercicio eliminado");
        }
    }
}