using Application.DTOs.GruposDTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class GrupoService : IGrupoService
    {
        private readonly IGrupoRepository _grupoRepository;

        public GrupoService(
            IGrupoRepository grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }

        public async Task<List<GrupoDTO>> GetAllAsync()
        {
            var grupos =
                await _grupoRepository.GetAllAsync();

            return grupos
                .Select(g => new GrupoDTO
                {
                    ID_Grupo = g.ID_Grupo,
                    Nombre = g.Nombre
                })
                .ToList();
        }

        public async Task<GrupoDTO> GetByIdAsync(int id)
        {
            var grupo =
                await _grupoRepository.GetByIdAsync(id);

            if (grupo == null)
                throw new Exception("Grupo no encontrado");

            return new GrupoDTO
            {
                ID_Grupo = grupo.ID_Grupo,
                Nombre = grupo.Nombre
            };
        }

        public async Task<int> CreateAsync(
            GrupoCreateDTO dto)
        {
            var grupo = new GrupoMuscular
            {
                Nombre = dto.Nombre
            };

            await _grupoRepository.AddAsync(grupo);

            await _grupoRepository.SaveChangesAsync();

            return grupo.ID_Grupo;
        }

        public async Task UpdateAsync(
            GrupoUpdateDTO dto)
        {
            var grupo =
                await _grupoRepository.GetByIdAsync(dto.ID_Grupo);

            if (grupo == null)
                throw new Exception("Grupo no encontrado");

            grupo.Nombre = dto.Nombre;

            _grupoRepository.Update(grupo);

            await _grupoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var grupo =
                await _grupoRepository.GetByIdAsync(id);

            if (grupo == null)
                throw new Exception("Grupo no encontrado");

            _grupoRepository.Remove(grupo);

            await _grupoRepository.SaveChangesAsync();
        }
    }
}