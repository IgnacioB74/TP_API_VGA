using Application.DTOs.PagosDTO;

namespace Application.Interfaces
{
    public interface IPagoService
    {
        Task<List<PagoResponseDTO>> GetAllAsync();

        Task<PagoResponseDTO> GetByIdAsync(int id);

        Task<List<PagoResponseDTO>> GetByUsernameAsync(string username);

        Task<int> CreateAsync(PagoCreateDTO dto);

        Task UpdateAsync(int id, PagoUpdateDTO dto);

        Task DeleteAsync(int id);

        Task AprobarAsync(int id);

        Task RechazarAsync(int id);

        Task ReenviarAsync(int id);
    }
}