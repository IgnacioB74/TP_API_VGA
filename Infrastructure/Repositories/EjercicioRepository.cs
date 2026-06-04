using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class EjercicioRepository : RepositoryBase<Ejercicio>, IEjercicioRepository
    {
        private readonly AppDbContext _context;

        public EjercicioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Ejercicio>> GetAllWithGrupoAsync()
        {
            return await _context.Ejercicios
                .Include(e => e.GrupoMuscular)
                .ToListAsync();
        }

        public async Task<Ejercicio?> GetByIdWithGrupoAsync(int id)
        {
            return await _context.Ejercicios
                .Include(e => e.GrupoMuscular)
                .FirstOrDefaultAsync(e => e.ID_Ejercicio == id);
        }

        public async Task<List<Ejercicio>> GetByGrupoAsync(int idGrupo)
        {
            return await _context.Ejercicios
                .Include(e => e.GrupoMuscular)
                .Where(e => e.ID_Grupo == idGrupo)
                .ToListAsync();
        }

        public async Task<bool> ExistsGrupoMuscularAsync(int idGrupo)
        {
            return await _context.GruposMusculares
                .AnyAsync(g => g.ID_Grupo == idGrupo);
        }
    }
}