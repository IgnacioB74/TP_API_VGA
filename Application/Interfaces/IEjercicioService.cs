using Application.DTOs.EjerciciosDTO;

namespace Application.Interfaces
{
    public interface IEjercicioService
    {
        Task<List<EjercicioResponseDTO>> GetAllAsync();

        Task<EjercicioResponseDTO> GetByIdAsync(int id);

        Task<int> CreateAsync(EjercicioCreateDTO dto);

        Task UpdateAsync(EjercicioUpdateDTO dto);

        Task DeleteAsync(int id);
    }
}