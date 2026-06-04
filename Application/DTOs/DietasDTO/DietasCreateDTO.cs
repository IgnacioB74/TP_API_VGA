namespace GymAPI.DTOs
{
    public class DietaCreateDTO
    {
        public List<DietaDetalleDTO> Detalles { get; set; } = new();
    }
}