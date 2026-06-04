using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Cuota
{
    [Key]
    public int ID_Cuota { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Monto { get; set; }
    public string Username { get; set; } = string.Empty;
}