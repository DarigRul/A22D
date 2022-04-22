using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno.Calidad
{
    public class EPruebaContaminacion
    {
        public int id_contaminacion { get; set; }
        public int id_tela { get; set; }
        public int id_operario { get; set; }
        public DateTime fecha { get; set; }
        public string contaminacion { get; set; }
        public string observaciones { get; set; }
    }
}
