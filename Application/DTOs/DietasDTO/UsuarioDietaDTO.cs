namespace GymAPI.DTOs
{
    public class UsuarioDietaDTO
    {
        public string Username { get; set; } = String.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}