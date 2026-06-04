using Application.DTOs.AlimentosDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/alimentos")]
    public class AlimentosController : ControllerBase
    {
        private readonly IAlimentoService _service;

        public AlimentosController(
            IAlimentoService service)
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
            AlimentoCreateDTO dto)
        {
            var id =
                await _service.CreateAsync(dto);

            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            AlimentoUpdateDTO dto)
        {
            await _service.UpdateAsync(id, dto);

            return Ok("Alimento actualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok("Alimento eliminado");
        }
    }
}