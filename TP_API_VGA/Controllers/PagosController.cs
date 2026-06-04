using Application.DTOs.PagosDTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/pagos")]
    public class PagosController : ControllerBase
    {
        private readonly IPagoService _service;

        public PagosController(IPagoService service)
        {
            _service = service;
        }

        // =====================================
        // GET ALL
        // =====================================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pagos = await _service.GetAllAsync();

                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message
                });
            }
        }

        // =====================================
        // GET BY ID
        // =====================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pago = await _service.GetByIdAsync(id);

                return Ok(pago);
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    error = ex.Message
                });
            }
        }

        // =====================================
        // GET BY USERNAME
        // =====================================
        [HttpGet("usuario/{username}")]
        public async Task<IActionResult> GetByUsername(
            string username)
        {
            try
            {
                var pagos =
                    await _service.GetByUsernameAsync(username);

                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message
                });
            }
        }

        // =====================================
        // CREATE
        // =====================================
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PagoCreateDTO dto)
        {
            try
            {
                var id =
                    await _service.CreateAsync(dto);

                return Ok(new
                {
                    mensaje = "Pago creado correctamente",
                    idPago = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        // =====================================
        // UPDATE
        // =====================================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] PagoUpdateDTO dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);

                return Ok(new
                {
                    mensaje = "Pago actualizado correctamente",
                    idPago = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        // =====================================
        // DELETE
        // =====================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return Ok(new
                {
                    mensaje = "Pago eliminado correctamente",
                    idPago = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        // =====================================
        // APROBAR
        // =====================================
        [HttpPatch("{id}/aprobar")]
        public async Task<IActionResult> Aprobar(int id)
        {
            try
            {
                await _service.AprobarAsync(id);

                return Ok(new
                {
                    mensaje = "Pago aprobado correctamente",
                    idPago = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        // =====================================
        // RECHAZAR
        // =====================================
        [HttpPatch("{id}/rechazar")]
        public async Task<IActionResult> Rechazar(int id)
        {
            try
            {
                await _service.RechazarAsync(id);

                return Ok(new
                {
                    mensaje = "Pago rechazado correctamente",
                    idPago = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }

        // =====================================
        // REENVIAR
        // =====================================
        [HttpPatch("{id}/reenviar")]
        public async Task<IActionResult> Reenviar(int id)
        {
            try
            {
                await _service.ReenviarAsync(id);

                return Ok(new
                {
                    mensaje = "Pago reenviado correctamente",
                    idPago = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }
    }
}