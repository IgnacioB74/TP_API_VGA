using GymAPI.DTOs;
using GymAPI.Entities;
using GymAPI.Repositories;

namespace GymAPI.Services
{
    public class DietaService : IDietaService
    {
        private readonly IDietaRepository _repository;

        public DietaService(IDietaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DietaResponseDTO>> GetAllAsync()
        {
            var ids = await _repository.GetDietasIdsAsync();

            var resultado = new List<DietaResponseDTO>();

            foreach (var id in ids)
            {
                resultado.Add(await GetByIdAsync(id));
            }

            return resultado;
        }

        public async Task<DietaResponseDTO> GetByIdAsync(int id)
        {
            var detalles = await _repository.GetDetallesAsync(id);
            var usuarios = await _repository.GetUsuariosAsync(id);

            return new DietaResponseDTO
            {
                ID_Dieta = id,

                Detalles = detalles.Select(x => new DietaDetalleDTO
                {
                    ID = x.ID,
                    Dia = x.Dia,
                    Categoria = x.Categoria,
                    Alimento = x.Alimento
                }).ToList(),

                Usuarios = usuarios.Select(x => new UsuarioDietaDTO
                {
                    Username = x.Username,
                    FechaInicio = x.FechaInicio,
                    FechaFin = x.FechaFin
                }).ToList()
            };
        }

        public async Task<int> CreateAsync(DietaCreateDTO dto)
        {
            var detalles = dto.Detalles.Select(x => new DietaDetalle
            {
                Dia = x.Dia,
                Categoria = x.Categoria,
                Alimento = x.Alimento
            }).ToList();

            return await _repository.CreateAsync(detalles);
        }

        public async Task UpdateAsync(int id, DietaUpdateDTO dto)
        {
            var detalles = dto.Detalles.Select(x => new DietaDetalle
            {
                Dia = x.Dia,
                Categoria = x.Categoria,
                Alimento = x.Alimento
            }).ToList();

            await _repository.UpdateAsync(id, detalles);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}