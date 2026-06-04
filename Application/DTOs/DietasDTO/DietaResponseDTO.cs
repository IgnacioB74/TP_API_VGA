namespace GymAPI.DTOs
{
    public class DietaResponseDTO
    {
        public int ID_Dieta { get; set; }

        public List<DietaDetalleDTO> Detalles { get; set; } = new();

        public List<UsuarioDietaDTO> Usuarios { get; set; } = new();
    }
}