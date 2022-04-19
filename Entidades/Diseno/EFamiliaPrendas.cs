using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class EFamiliaPrendas
    {
        public int id_familia_prenda { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string ubicacion { get; set; }
        public string auxestatus { get; set; }
        public int capacidad_semanal { get; set; } = 0;
    }
}
