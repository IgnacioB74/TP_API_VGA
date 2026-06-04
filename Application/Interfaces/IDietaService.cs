using GymAPI.DTOs;

namespace GymAPI.Services
{
    public interface IDietaService
    {
        Task<List<DietaResponseDTO>> GetAllAsync();

        Task<DietaResponseDTO> GetByIdAsync(int id);

        Task<int> CreateAsync(DietaCreateDTO dto);

        Task UpdateAsync(int id, DietaUpdateDTO dto);

        Task DeleteAsync(int id);
    }
}