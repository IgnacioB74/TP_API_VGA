using Application.DTOs.UsuariosDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
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
        public async Task<IActionResult> Create(UsuarioCreateDTO dto)
        {
            await _service.CreateAsync(dto);

            return Ok("Usuario creado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UsuarioUpdateDTO dto)
        {
            dto.Id = id;

            await _service.UpdateAsync(dto);

            return Ok("Usuario actualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok("Usuario eliminado");
        }
    }
}