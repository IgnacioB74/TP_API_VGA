namespace Domain.Entities
{
    public class Ejercicio
    {
        public int ID_Ejercicio { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public int ID_Grupo { get; set; }

        public GrupoMuscular GrupoMuscular { get; set; } = null!;
    }
}