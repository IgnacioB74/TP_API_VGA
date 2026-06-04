using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymAPI.Entities
{
    [Table("DietasDetalles")]
    public class DietaDetalle
    {
        [Key]
        public int ID { get; set; }

        public int ID_Dieta { get; set; }

        [Required]
        public string Dia { get; set; } = String.Empty;

        [Required]
        public string Categoria { get; set; } = String.Empty;

        [Required]
        public string Alimento { get; set; } = String.Empty;
    }
}