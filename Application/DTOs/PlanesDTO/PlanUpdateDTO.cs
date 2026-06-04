namespace Application.DTOs.PlanesDTO
{
    public class PlanUpdateDTO
    {
        public int ID { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Duracion { get; set; }

        public string Nivel { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }
}