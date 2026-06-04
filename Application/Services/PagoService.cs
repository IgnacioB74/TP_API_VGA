using Application.DTOs.PagosDTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _repository;

        public PagoService(IPagoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PagoResponseDTO>> GetAllAsync()
        {
            var pagos = await _repository.GetAllAsync();

            return pagos.Select(x => new PagoResponseDTO
            {
                ID = x.ID,
                Username = x.Username,
                Mes = x.Mes,
                ID_FormaPago = x.ID_FormaPago,
                ID_Plan = x.ID_Plan,
                Estado = x.Estado,
                Fecha = x.Fecha
            }).ToList();
        }

        public async Task<PagoResponseDTO> GetByIdAsync(int id)
        {
            var pago = await _repository.GetPagoCompletoAsync(id);

            if (pago == null)
                throw new Exception("Pago no encontrado");

            return new PagoResponseDTO
            {
                ID = pago.ID,
                Username = pago.Username,
                Mes = pago.Mes,
                ID_FormaPago = pago.ID_FormaPago,
                FormaPago = pago.FormaPago?.Nombre ?? "",
                ID_Plan = pago.ID_Plan,
                Plan = pago.Plan?.Nombre ?? "",
                Estado = pago.Estado,
                Fecha = pago.Fecha
            };
        }

        public async Task<List<PagoResponseDTO>> GetByUsernameAsync(string username)
        {
            var pagos = await _repository.GetByUsernameAsync(username);

            return pagos.Select(x => new PagoResponseDTO
            {
                ID = x.ID,
                Username = x.Username,
                Mes = x.Mes,
                ID_FormaPago = x.ID_FormaPago,
                ID_Plan = x.ID_Plan,
                Estado = x.Estado,
                Fecha = x.Fecha
            }).ToList();
        }

        public async Task<int> CreateAsync(PagoCreateDTO dto)
        {
            bool existe = await _repository
                .ExistePagoMesAsync(dto.Username, dto.Mes);

            if (existe)
                throw new Exception(
                    "Ya existe un pago para ese usuario y mes.");

            var pago = new Pago
            {
                Username = dto.Username,
                Mes = dto.Mes,
                ID_FormaPago = dto.ID_FormaPago,
                ID_Plan = dto.ID_Plan,
                Estado = "PENDIENTE",
                Fecha = DateTime.Now
            };

            await _repository.AddAsync(pago);
            await _repository.SaveChangesAsync();

            return pago.ID;
        }

        public async Task UpdateAsync(
            int id,
            PagoUpdateDTO dto)
        {
            var pago = await _repository.GetByIdAsync(id);

            if (pago == null)
                throw new Exception("Pago no encontrado");

            if (pago.Estado == "APROBADO")
                throw new Exception(
                    "No se puede modificar un pago aprobado.");

            pago.Mes = dto.Mes;
            pago.ID_FormaPago = dto.ID_FormaPago;
            pago.ID_Plan = dto.ID_Plan;

            _repository.Update(pago);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pago = await _repository.GetByIdAsync(id);

            if (pago == null)
                throw new Exception("Pago no encontrado");

            if (pago.Estado == "APROBADO")
                throw new Exception(
                    "No se puede eliminar un pago aprobado.");

            _repository.Remove(pago);

            await _repository.SaveChangesAsync();
        }

        public async Task AprobarAsync(int id)
        {
            var pago = await _repository.GetByIdAsync(id);

            if (pago == null)
                throw new Exception("Pago no encontrado");

            if (pago.Estado == "APROBADO")
                throw new Exception(
                    "El pago ya fue aprobado.");

            pago.Estado = "APROBADO";

            _repository.Update(pago);

            await _repository.SaveChangesAsync();
        }

        public async Task RechazarAsync(int id)
        {
            var pago = await _repository.GetByIdAsync(id);

            if (pago == null)
                throw new Exception("Pago no encontrado");

            if (pago.Estado == "RECHAZADO")
                throw new Exception(
                    "El pago ya fue rechazado.");

            pago.Estado = "RECHAZADO";

            _repository.Update(pago);

            await _repository.SaveChangesAsync();
        }

        public async Task ReenviarAsync(int id)
        {
            var pago = await _repository.GetByIdAsync(id);

            if (pago == null)
                throw new Exception("Pago no encontrado");

            if (pago.Estado != "RECHAZADO")
                throw new Exception(
                    "Sólo un pago rechazado puede reenviarse.");

            pago.Estado = "PENDIENTE";

            _repository.Update(pago);

            await _repository.SaveChangesAsync();
        }
    }
}