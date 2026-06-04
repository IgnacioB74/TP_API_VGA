using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class CarouselItem
{
    [Key]
    public int ID { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ImagenUrl { get; set; } = string.Empty;
}