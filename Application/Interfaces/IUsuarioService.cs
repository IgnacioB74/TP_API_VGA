using Application.DTOs.UsuarioDTOs;
using Application.DTOs.UsuariosDTO;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioResponseDTO>> GetAllAsync();

        Task<UsuarioResponseDTO> GetByIdAsync(int id);

        Task<UsuarioResponseDTO> GetByUsernameAsync(string username);

        Task CreateAsync(UsuarioCreateDTO dto);

        Task UpdateAsync(UsuarioUpdateDTO dto);

        Task DeleteAsync(int id);

        Task ToggleActivoAsync(int id);

        Task ChangePasswordAsync(ChangePasswordDTO dto);
    }
}