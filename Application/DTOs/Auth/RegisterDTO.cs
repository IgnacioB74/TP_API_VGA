using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Auth
{
    public class RegisterDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Tipo { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
