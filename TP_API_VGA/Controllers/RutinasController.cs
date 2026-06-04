using Application.DTOs.RutinasDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/rutinas")]
public class RutinasController : ControllerBase
{
    private readonly IRutinaService _service;

    public RutinasController(IRutinaService service)
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
        RutinaCreateDTO dto)
    {
        var id = await _service.CreateAsync(dto);

        return Ok(new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        RutinaUpdateDTO dto)
    {
        await _service.UpdateAsync(id, dto);

        return Ok("Rutina actualizada");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return Ok("Rutina eliminada");
    }

    [HttpPost("asignar")]
    public async Task<IActionResult> Asignar(
        AsignarRutinaDTO dto)
    {
        var id =
            await _service.AsignarRutinaAsync(dto);

        return Ok(new { id });
    }

    [HttpPost("ejercicio")]
    public async Task<IActionResult> AgregarEjercicio(
        RutinaDetalleCreateDTO dto)
    {
        await _service.AddEjercicioAsync(dto);

        return Ok("Ejercicio agregado");
    }
}