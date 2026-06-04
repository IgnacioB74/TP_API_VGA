namespace Application.DTOs.PagosDTO
{
    public class PagoUpdateDTO
    {
        public string Mes { get; set; } = string.Empty;

        public int ID_FormaPago { get; set; }

        public int ID_Plan { get; set; }
    }
}