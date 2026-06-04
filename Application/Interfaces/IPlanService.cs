using Application.DTOs.PlanesDTO;

namespace Application.Interfaces
{
    public interface IPlanService
    {
        Task<List<PlanResponseDTO>> GetAllAsync();

        Task<PlanResponseDTO> GetByIdAsync(int id);

        Task<int> CreateAsync(PlanCreateDTO dto);

        Task UpdateAsync(int id, PlanUpdateDTO dto);

        Task DeleteAsync(int id);
    }
}