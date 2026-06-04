using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UsuariosDTO
{
    public class UsuarioResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public int Tipo { get; set; } // FK
        public string Username { get; set; } = string.Empty;
    }
}
