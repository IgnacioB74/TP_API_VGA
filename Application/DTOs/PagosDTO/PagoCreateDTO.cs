namespace Application.DTOs.PagosDTO
{
    public class PagoCreateDTO
    {
        public string Username { get; set; } = string.Empty;

        public string Mes { get; set; } = string.Empty;

        public int ID_FormaPago { get; set; }

        public int ID_Plan { get; set; }
    }
}