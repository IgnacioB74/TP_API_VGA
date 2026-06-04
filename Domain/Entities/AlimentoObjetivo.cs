using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class AlimentoObjetivo
{
    [Key]
    public int ID_Objetivo { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<Alimento> Alimentos { get; set; } = new List<Alimento>();
}