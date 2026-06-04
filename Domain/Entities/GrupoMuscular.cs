using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GrupoMuscular
    {
        [Key]
        public int ID_Grupo { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Ejercicio> Ejercicios { get; set; } = new List<Ejercicio>();
    }
}


