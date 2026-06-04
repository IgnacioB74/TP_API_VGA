using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPagoRepository : IRepositoryBase<Pago>
    {
        Task<List<Pago>> GetByUsernameAsync(string username);

        Task<bool> ExistePagoMesAsync(
            string username,
            string mes);

        Task<Pago?> GetPagoCompletoAsync(int id);
    }
}