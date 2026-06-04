using Application.DTOs.GruposDTO;

namespace Application.Interfaces
{
    public interface IGrupoService
    {
        Task<List<GrupoDTO>> GetAllAsync();

        Task<GrupoDTO> GetByIdAsync(int id);

        Task<int> CreateAsync(GrupoCreateDTO dto);

        Task UpdateAsync(GrupoUpdateDTO dto);

        Task DeleteAsync(int id);
    }
}