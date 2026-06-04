namespace Application.DTOs.PagosDTO
{
    public class PagoResponseDTO
    {
        public int ID { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Mes { get; set; } = string.Empty;

        public int ID_FormaPago { get; set; }

        public string FormaPago { get; set; } = string.Empty;

        public int ID_Plan { get; set; }

        public string Plan { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }
    }
}