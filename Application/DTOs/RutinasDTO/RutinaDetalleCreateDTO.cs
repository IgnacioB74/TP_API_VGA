namespace Application.DTOs.RutinasDTO;

public class RutinaDetalleCreateDTO
{
    public int ID_RutinaUsuario { get; set; }

    public string Dia { get; set; } = string.Empty;

    public int ID_Ejercicio { get; set; }
}