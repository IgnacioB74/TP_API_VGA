using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Rutinas")]
public class Rutina
{
    [Key]
    [Column("ID_Rutina")]
    public int ID_Rutina { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public string Intensidad { get; set; } = string.Empty;

    public bool Activa { get; set; }

    public int EjerciciosXDia { get; set; }
}