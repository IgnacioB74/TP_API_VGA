using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthService(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task<string> LoginAsync(LoginDTO dto)
    {
        var user = await _context.Usuarios
            .FirstOrDefaultAsync(x => x.Mail == dto.Mail);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Clave))
            throw new Exception("Credenciales inválidas");

        return GenerateToken(user);
    }

    public async Task RegisterAsync(RegisterDTO dto)
    {
        // Verificar si ya existe un usuario con el mismo mail
        if (await _context.Usuarios.AnyAsync(x => x.Mail == dto.Mail))
            throw new Exception("El usuario ya existe");

        // Crear nuevo usuario
        var user = new Usuario
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Mail = dto.Mail,
            Telefono = dto.Telefono,
            Username = dto.Username,

            // Columna Tipo (existe en la tabla)
            Tipo = dto.Tipo,

            // Columna ID_UsuarioTipo (también existe en la tabla y es obligatoria)
            ID_UsuarioTipo = dto.Tipo,

            // Estado activo por defecto
            Activo = true,

            // Hash de la contraseña
            Clave = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        // Guardar en la base de datos
        _context.Usuarios.Add(user);
        await _context.SaveChangesAsync();
    }

    private string GenerateToken(Usuario user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Tipo.ToString()),
            new Claim("UserId", user.Id.ToString())
        };

        var jwtKey = _config["Key"] ?? _config["Jwt:Key"];

        if (string.IsNullOrWhiteSpace(jwtKey))
        {
            throw new Exception("Key no configurada.");
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey)
        );

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}