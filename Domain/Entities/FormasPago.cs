using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("FormasPago")]
    public class FormaPago
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; } = string.Empty;
    }
}