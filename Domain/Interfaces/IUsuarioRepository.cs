using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
        : IRepositoryBase<Usuario>
    {
        Task<Usuario?> GetByMailAsync(string mail);

        Task<Usuario?> GetByUsernameAsync(string username);

        Task<bool> ExistsMailAsync(string mail);

        Task<bool> ExistsUsernameAsync(string username);
    }
}