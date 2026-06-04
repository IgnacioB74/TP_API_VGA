using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        // Ignorar esta propiedad porque no existe en la tabla
        [NotMapped]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public int Tipo { get; set; }
        public string Username { get; set; } = string.Empty;

        // Esta columna sí existe en la tabla
        public int ID_UsuarioTipo { get; set; }
    }
}