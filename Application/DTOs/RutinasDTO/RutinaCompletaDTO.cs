using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RutinasDTO
{
    public class RutinaCompletaDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public List<DiaRutinaDTO> Dias { get; set; } = new();
    }

    public class DiaRutinaDTO
    {
        public int Dia { get; set; }
        public List<string> Ejercicios { get; set; } = new();
    }

}