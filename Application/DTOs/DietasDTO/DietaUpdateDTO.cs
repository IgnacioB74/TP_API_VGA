namespace GymAPI.DTOs
{
    public class DietaUpdateDTO
    {
        public List<DietaDetalleDTO> Detalles { get; set; } = new();
    }
}