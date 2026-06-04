using Application.DTOs.EjerciciosDTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class EjercicioService : IEjercicioService
    {
        private readonly IEjercicioRepository _repository;

        public EjercicioService(
            IEjercicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EjercicioResponseDTO>> GetAllAsync()
        {
            var ejercicios =
                await _repository.GetAllAsync();

            return ejercicios.Select(x =>
                new EjercicioResponseDTO
                {
                    ID_Ejercicio = x.ID_Ejercicio,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    ID_Grupo = x.ID_Grupo
                })
                .ToList();
        }

        public async Task<EjercicioResponseDTO> GetByIdAsync(int id)
        {
            var ejercicio =
                await _repository.GetByIdAsync(id);

            if (ejercicio == null)
                throw new Exception("Ejercicio no encontrado");

            return new EjercicioResponseDTO
            {
                ID_Ejercicio = ejercicio.ID_Ejercicio,
                Nombre = ejercicio.Nombre,
                Descripcion = ejercicio.Descripcion,
                ID_Grupo = ejercicio.ID_Grupo
            };
        }

        public async Task<int> CreateAsync(
            EjercicioCreateDTO dto)
        {
            var ejercicio = new Ejercicio
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                ID_Grupo = dto.ID_Grupo
            };

            await _repository.AddAsync(ejercicio);

            await _repository.SaveChangesAsync();

            return ejercicio.ID_Ejercicio;
        }

        public async Task UpdateAsync(
            EjercicioUpdateDTO dto)
        {
            var ejercicio =
                await _repository.GetByIdAsync(dto.ID_Ejercicio);

            if (ejercicio == null)
                throw new Exception("Ejercicio no encontrado");

            ejercicio.Nombre = dto.Nombre;
            ejercicio.Descripcion = dto.Descripcion;
            ejercicio.ID_Grupo = dto.ID_Grupo;

            _repository.Update(ejercicio);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ejercicio =
                await _repository.GetByIdAsync(id);

            if (ejercicio == null)
                throw new Exception("Ejercicio no encontrado");

            _repository.Remove(ejercicio);

            await _repository.SaveChangesAsync();
        }
    }
}