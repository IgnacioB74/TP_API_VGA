using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PlanRepository
        : RepositoryBase<PlanEntrenamiento>,
          IPlanRepository
    {
        private readonly AppDbContext _context;

        public PlanRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<PlanEntrenamiento>> GetPlanesActivosAsync()
        {
            return await _context.PlanesEntrenamiento
                .Where(p => p.Activo)
                .ToListAsync();
        }
    }
}