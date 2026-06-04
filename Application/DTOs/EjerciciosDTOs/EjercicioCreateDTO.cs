namespace Application.DTOs.EjerciciosDTO
{
    public class EjercicioCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public int ID_Grupo { get; set; }
    }
}