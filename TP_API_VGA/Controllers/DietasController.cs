using GymAPI.DTOs;
using GymAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietasController : ControllerBase
    {
        private readonly IDietaService _service;

        public DietasController(IDietaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(DietaCreateDTO dto)
        {
            var id = await _service.CreateAsync(dto);

            return Ok(new
            {
                ID_Dieta = id
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DietaUpdateDTO dto)
        {
            await _service.UpdateAsync(id, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}