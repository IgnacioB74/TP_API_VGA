using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Pagos")]
    public class Pago
    {
        [Key]
        public int ID { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Mes { get; set; } = string.Empty;

        public int ID_FormaPago { get; set; }

        public int ID_Plan { get; set; }

        public string Estado { get; set; } = "PENDIENTE";

        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(ID_FormaPago))]
        public FormaPago? FormaPago { get; set; }

        [ForeignKey(nameof(ID_Plan))]
        public PlanEntrenamiento? Plan { get; set; }
    }
}