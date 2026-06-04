namespace GymAPI.DTOs
{
    public class DietaDetalleDTO
    {
        public int ID { get; set; }

        public string Dia { get; set; } = String.Empty;

        public string Categoria { get; set; } = String.Empty;

        public string Alimento { get; set; } = String.Empty;
    }
}