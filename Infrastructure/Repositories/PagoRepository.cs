using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PagoRepository
        : RepositoryBase<Pago>,
          IPagoRepository
    {
        private readonly AppDbContext _context;

        public PagoRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Pago>> GetByUsernameAsync(
            string username)
        {
            return await _context.Pagos
                .Include(x => x.FormaPago)
                .Include(x => x.Plan)
                .Where(x => x.Username == username)
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();
        }

        public async Task<bool> ExistePagoMesAsync(
            string username,
            string mes)
        {
            return await _context.Pagos
                .AnyAsync(x =>
                    x.Username == username &&
                    x.Mes == mes);
        }

        public async Task<Pago?> GetPagoCompletoAsync(int id)
        {
            return await _context.Pagos
                .Include(x => x.FormaPago)
                .Include(x => x.Plan)
                .FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}