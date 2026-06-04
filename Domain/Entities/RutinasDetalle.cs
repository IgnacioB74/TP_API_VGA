using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class RutinaDetalle
{
    [Key]
    public int ID { get; set; }

    public int ID_RutinaUsuario { get; set; }

    public string Dia { get; set; } = string.Empty;

    public int ID_Ejercicio { get; set; }

    [ForeignKey(nameof(ID_Ejercicio))]
    public virtual Ejercicio Ejercicio { get; set; } = null!;
}