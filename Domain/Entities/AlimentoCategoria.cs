using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class AlimentoCategoria
    {
        [Key]
        public int ID_Categoria { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Alimento> Alimentos { get; set; } = new List<Alimento>();
    }
}
