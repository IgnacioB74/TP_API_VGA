using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UsuarioRepository
        : RepositoryBase<Usuario>,
          IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByMailAsync(string mail)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Mail == mail);
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> ExistsMailAsync(string mail)
        {
            return await _context.Usuarios
                .AnyAsync(x => x.Mail == mail);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsUsernameAsync(string username)
        {
            return await _context.Usuarios
                .AnyAsync(x => x.Username == username);
        }
    }
}