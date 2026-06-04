namespace Application.DTOs.AlimentosDTO
{
    public class AlimentoCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public int Calorias { get; set; }

        public double Proteinas { get; set; }

        public double Carbohidratos { get; set; }

        public double Grasas { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public int ID_Categoria { get; set; }

        public int ID_Objetivo { get; set; }
    }
}