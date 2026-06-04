using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEjercicioRepository : IRepositoryBase<Ejercicio>
    {
        Task<List<Ejercicio>> GetAllWithGrupoAsync();

        Task<Ejercicio?> GetByIdWithGrupoAsync(int id);

        Task<List<Ejercicio>> GetByGrupoAsync(int idGrupo);

        Task<bool> ExistsGrupoMuscularAsync(int idGrupo);
    }
}