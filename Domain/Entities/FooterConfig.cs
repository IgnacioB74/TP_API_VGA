using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class FooterConfig
{
    [Key]
    public int ID { get; set; }
    public string Texto { get; set; } = string.Empty;
}