using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class RutinaRepository
        : RepositoryBase<Rutina>,
          IRutinaRepository
    {
        private readonly AppDbContext _context;

        public RutinaRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        // 🔹 Obtener rutinas activas
        public async Task<List<Rutina>> GetRutinasActivasAsync()
        {
            return await _context.Rutinas
                .Where(r => r.Activa)
                .ToListAsync();
        }

        // 🔹 Obtener rutina por ID
        public async Task<Rutina?> GetRutinaByIdAsync(int id)
        {
            return await _context.Rutinas
                .FirstOrDefaultAsync(r => r.ID_Rutina == id);
        }

        // 🔹 Crear asignación rutina-usuario
        public async Task<RutinaUsuario> AddRutinaUsuarioAsync(
            RutinaUsuario rutinaUsuario)
        {
            await _context.RutinasUsuarios
                .AddAsync(rutinaUsuario);

            await _context.SaveChangesAsync();

            return rutinaUsuario;
        }

        // 🔹 Obtener rutinas asignadas a usuario
        public async Task<List<RutinaUsuario>> GetRutinasUsuarioAsync(
            string mail)
        {
            return await _context.RutinasUsuarios
                .Where(r => r.Mail == mail)
                .OrderByDescending(r => r.Fecha)
                .ToListAsync();
        }

        // 🔹 Obtener asignación por ID
        public async Task<RutinaUsuario?> GetRutinaUsuarioByIdAsync(int id)
        {
            return await _context.RutinasUsuarios
                .FirstOrDefaultAsync(r => r.ID == id);
        }

        // 🔹 Eliminar asignación
        public async Task DeleteRutinaUsuarioAsync(
            RutinaUsuario rutinaUsuario)
        {
            _context.RutinasUsuarios.Remove(rutinaUsuario);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsRutinaUsuarioAsync(int id)
        {
            return await _context.RutinasUsuarios
                .AnyAsync(r => r.ID == id);
        }

        public async Task<RutinaDetalle> AddRutinaDetalleAsync(
            RutinaDetalle detalle)
        {
            await _context.RutinasDetalles
                .AddAsync(detalle);

            await _context.SaveChangesAsync();

            return detalle;
        }

        public async Task<RutinaUsuario?> GetRutinaUsuarioAsync(int id)
        {
            return await _context.RutinasUsuarios
                .FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<List<RutinaDetalle>> GetDetallesRutinaAsync(int rutinaUsuarioId)
        {
            return await _context.RutinasDetalles
                .Where(d => d.ID_RutinaUsuario == rutinaUsuarioId)
                .Include(d => d.Ejercicio)
                .ToListAsync();
        }
    }
}