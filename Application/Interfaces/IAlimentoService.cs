using Application.DTOs.AlimentosDTO;

namespace Application.Interfaces
{
    public interface IAlimentoService
    {
        Task<List<AlimentoResponseDTO>> GetAllAsync();

        Task<AlimentoResponseDTO> GetByIdAsync(int id);

        Task<int> CreateAsync(AlimentoCreateDTO dto);

        Task UpdateAsync(int id, AlimentoUpdateDTO dto);

        Task DeleteAsync(int id);
    }
}