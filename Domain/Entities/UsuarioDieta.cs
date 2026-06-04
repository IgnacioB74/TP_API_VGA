using System.ComponentModel.DataAnnotations.Schema;

namespace GymAPI.Entities
{
    [Table("UsuarioDietas")]
    public class UsuarioDieta
    {
        public int ID_Dieta { get; set; }

        public string Username { get; set; } = String.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}