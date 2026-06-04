using GymAPI.Entities;

namespace GymAPI.Repositories
{
    public interface IDietaRepository
    {
        Task<List<int>> GetDietasIdsAsync();

        Task<List<DietaDetalle>> GetDetallesAsync(int idDieta);

        Task<List<UsuarioDieta>> GetUsuariosAsync(int idDieta);

        Task<int> CreateAsync(List<DietaDetalle> detalles);

        Task UpdateAsync(int idDieta, List<DietaDetalle> detalles);

        Task DeleteAsync(int idDieta);
    }
}