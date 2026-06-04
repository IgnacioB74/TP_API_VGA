namespace Application.DTOs.EjerciciosDTO
{
    public class EjercicioResponseDTO
    {
        public int ID_Ejercicio { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public int ID_Grupo { get; set; }

        public string Grupo { get; set; } = string.Empty;
    }
}