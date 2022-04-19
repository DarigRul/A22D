using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class ERutasProduccion
    {
        public int id_ruta { get; set; }
        public string nombre { get; set; }
        public int   id_departamento { get; set; }
        public string departamento { get; set; }
        public int estatus { get; set; }

        public List<EProcesos> procesos = new List<EProcesos>();
    }
}
