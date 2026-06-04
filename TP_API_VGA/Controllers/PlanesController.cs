using Application.DTOs.PlanesDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/planes")]
    public class PlanesController : ControllerBase
    {
        private readonly IPlanService _service;

        public PlanesController(IPlanService service)
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
            PlanCreateDTO dto)
        {
            var id = await _service.CreateAsync(dto);

            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            PlanUpdateDTO dto)
        {
            await _service.UpdateAsync(id, dto);

            return Ok("Plan actualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok("Plan eliminado");
        }
    }
}