namespace Domain.Entities;

public class RutinaUsuario
{
    public int ID { get; set; }

    public string Mail { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public DateTime Fecha { get; set; }
}