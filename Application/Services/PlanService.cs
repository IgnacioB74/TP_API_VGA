using Application.DTOs.PlanesDTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _repository;

        public PlanService(IPlanRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PlanResponseDTO>> GetAllAsync()
        {
            var planes = await _repository.GetAllAsync();

            return planes.Select(x => new PlanResponseDTO
            {
                ID = x.ID,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Precio = x.Precio,
                Duracion = x.Duracion,
                Nivel = x.Nivel,
                Activo = x.Activo
            }).ToList();
        }

        public async Task<PlanResponseDTO> GetByIdAsync(int id)
        {
            var plan = await _repository.GetByIdAsync(id);

            if (plan == null)
                throw new Exception("Plan no encontrado");

            return new PlanResponseDTO
            {
                ID = plan.ID,
                Nombre = plan.Nombre,
                Descripcion = plan.Descripcion,
                Precio = plan.Precio,
                Duracion = plan.Duracion,
                Nivel = plan.Nivel,
                Activo = plan.Activo
            };
        }

        public async Task<int> CreateAsync(PlanCreateDTO dto)
        {
            var plan = new PlanEntrenamiento
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Duracion = dto.Duracion,
                Nivel = dto.Nivel,
                Activo = dto.Activo
            };

            await _repository.AddAsync(plan);

            await _repository.SaveChangesAsync();

            return plan.ID;
        }

        public async Task UpdateAsync(
            int id,
            PlanUpdateDTO dto)
        {
            var plan = await _repository.GetByIdAsync(id);

            if (plan == null)
                throw new Exception("Plan no encontrado");

            plan.Nombre = dto.Nombre;
            plan.Descripcion = dto.Descripcion;
            plan.Precio = dto.Precio;
            plan.Duracion = dto.Duracion;
            plan.Nivel = dto.Nivel;
            plan.Activo = dto.Activo;

            _repository.Update(plan);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plan = await _repository.GetByIdAsync(id);

            if (plan == null)
                throw new Exception("Plan no encontrado");

            _repository.Remove(plan);

            await _repository.SaveChangesAsync();
        }
    }
}