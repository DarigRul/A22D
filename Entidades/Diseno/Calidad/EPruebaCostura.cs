using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno.Calidad
{
    public class EPruebaCostura
    {
        public int id_costura { get; set; }
        public int id_tela { get; set; }
        public int id_operario { get; set; }
        public DateTime fecha { get; set; }
        public double aguja { get; set; }
        public double deslizamiento { get; set; }
        public double deslizamientoobservaciones { get; set; }
        public string rasgado { get; set; }
        public string rasgadoobservaciones { get; set; }

    }
}
