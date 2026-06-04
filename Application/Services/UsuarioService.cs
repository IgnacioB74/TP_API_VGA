using Application.DTOs.UsuarioDTOs;
using Application.DTOs.UsuariosDTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(
            IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioResponseDTO>> GetAllAsync()
        {
            var usuarios =
                await _usuarioRepository.GetAllAsync();

            return usuarios.Select(x => new UsuarioResponseDTO
            {
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Mail = x.Mail,
                Telefono = x.Telefono,
                Username = x.Username,
                Tipo = x.Tipo
            }).ToList();
        }

        public async Task<UsuarioResponseDTO> GetByIdAsync(int id)
        {
            var user =
                await _usuarioRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("Usuario no encontrado");

            return new UsuarioResponseDTO
            {
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Mail = user.Mail,
                Telefono = user.Telefono,
                Username = user.Username,
                Tipo = user.Tipo
            };
        }

        public async Task<UsuarioResponseDTO>
            GetByUsernameAsync(string username)
        {
            var user =
                await _usuarioRepository
                    .GetByUsernameAsync(username);

            if (user == null)
                throw new Exception("Usuario no encontrado");

            return new UsuarioResponseDTO
            {
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Mail = user.Mail,
                Telefono = user.Telefono,
                Username = user.Username,
                Tipo = user.Tipo
            };
        }

        public async Task CreateAsync(UsuarioCreateDTO dto)
        {
            if (await _usuarioRepository
                .ExistsMailAsync(dto.Mail))
            {
                throw new Exception("Mail ya registrado");
            }

            if (await _usuarioRepository
                .ExistsUsernameAsync(dto.Username))
            {
                throw new Exception("Username ya registrado");
            }

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Mail = dto.Mail,
                Telefono = dto.Telefono,
                Username = dto.Username,
                Tipo = dto.Tipo,
                Activo = true,
                Clave = BCrypt.Net.BCrypt
                    .HashPassword(dto.Clave)
            };

            await _usuarioRepository
                .AddAsync(usuario);

            await _usuarioRepository
                .SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioUpdateDTO dto)
        {
            var usuario =
                await _usuarioRepository
                    .GetByIdAsync(dto.Id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Mail = dto.Mail;
            usuario.Telefono = dto.Telefono;
            usuario.Username = dto.Username;
            usuario.Tipo = dto.Tipo;

            _usuarioRepository.Update(usuario);

            await _usuarioRepository
                .SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario =
                await _usuarioRepository
                    .GetByIdAsync(id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            _usuarioRepository.Remove(usuario);

            await _usuarioRepository
                .SaveChangesAsync();
        }

        public async Task ToggleActivoAsync(int id)
        {
            var usuario =
                await _usuarioRepository
                    .GetByIdAsync(id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            usuario.Activo = !usuario.Activo;

            _usuarioRepository.Update(usuario);

            await _usuarioRepository
                .SaveChangesAsync();
        }

        public async Task ChangePasswordAsync(ChangePasswordDTO dto)
        {
            var usuario =
                await _usuarioRepository
                    .GetByIdAsync(dto.UserId);

            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            bool valid =
                BCrypt.Net.BCrypt.Verify(
                    dto.OldPassword,
                    usuario.Clave);

            if (!valid)
                throw new Exception("Contraseña incorrecta");

            usuario.Clave =
                BCrypt.Net.BCrypt
                    .HashPassword(dto.NewPassword);

            _usuarioRepository.Update(usuario);

            await _usuarioRepository
                .SaveChangesAsync();
        }
    }
}