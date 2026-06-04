namespace Application.DTOs.RutinasDTO;

public class RutinaCreateDTO
{
    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public string Intensidad { get; set; } = string.Empty;

    public bool Activa { get; set; }

    public int EjerciciosXDia { get; set; }
}