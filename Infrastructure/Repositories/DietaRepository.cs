
using GymAPI.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Repositories
{
    public class DietaRepository : IDietaRepository
    {
        private readonly AppDbContext _context;

        public DietaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetDietasIdsAsync()
        {
            return await _context.DietasDetalles
                .Select(x => x.ID_Dieta)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<DietaDetalle>> GetDetallesAsync(int idDieta)
        {
            return await _context.DietasDetalles
                .Where(x => x.ID_Dieta == idDieta)
                .ToListAsync();
        }

        public async Task<List<UsuarioDieta>> GetUsuariosAsync(int idDieta)
        {
            return await _context.UsuarioDietas
                .Where(x => x.ID_Dieta == idDieta)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(List<DietaDetalle> detalles)
        {
            int nuevoId = 1;

            if (await _context.DietasDetalles.AnyAsync())
            {
                nuevoId = await _context.DietasDetalles
                    .MaxAsync(x => x.ID_Dieta) + 1;
            }

            foreach (var detalle in detalles)
            {
                detalle.ID_Dieta = nuevoId;
            }

            _context.DietasDetalles.AddRange(detalles);

            await _context.SaveChangesAsync();

            return nuevoId;
        }

        public async Task UpdateAsync(int idDieta, List<DietaDetalle> detalles)
        {
            var existentes = await _context.DietasDetalles
                .Where(x => x.ID_Dieta == idDieta)
                .ToListAsync();

            _context.DietasDetalles.RemoveRange(existentes);

            foreach (var d in detalles)
            {
                d.ID_Dieta = idDieta;
            }

            await _context.DietasDetalles.AddRangeAsync(detalles);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idDieta)
        {
            var detalles = await _context.DietasDetalles
                .Where(x => x.ID_Dieta == idDieta)
                .ToListAsync();

            _context.DietasDetalles.RemoveRange(detalles);

            await _context.SaveChangesAsync();
        }
    }
}