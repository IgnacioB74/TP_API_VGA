using Application.DTOs.UsuariosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UsuariosDTO
{
    public class UsuarioUpdateDTO : UsuarioCreateDTO
    {
        public int Id { get; set; }
        public new string Nombre { get; set; } = string.Empty;
        public new string Apellido { get; set; } = string.Empty;
        public new string Mail { get; set; } = string.Empty;
        public new string Telefono { get; set; } = string.Empty;
        public new string Clave { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public new int Tipo { get; set; }
        public new string Username { get; set; } = string.Empty;

    }
}

