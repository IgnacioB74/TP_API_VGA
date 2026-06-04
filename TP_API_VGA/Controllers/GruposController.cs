using Application.DTOs.GruposDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/grupos")]
    public class GruposController : ControllerBase
    {
        private readonly IGrupoService _service;

        public GruposController(IGrupoService service)
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
            GrupoCreateDTO dto)
        {
            var id =
                await _service.CreateAsync(dto);

            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            GrupoUpdateDTO dto)
        {
            dto.ID_Grupo = id;

            await _service.UpdateAsync(dto);

            return Ok("Grupo actualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok("Grupo eliminado");
        }
    }
}