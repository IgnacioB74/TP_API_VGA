using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class PlanEntrenamiento
{
    [Key]
    public int ID { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }
    public int Duracion { get; set; }
    public string Nivel { get; set; } = string.Empty;
    public bool Activo { get; set; }
}