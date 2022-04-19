using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Compras;

namespace Entidades.Diseno
{
    public class EForros
    {
        public int id_forro { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double ancho { get; set; }
        public int id_color { get; set; }
        public string color { get; set; }
        public int id_proveedor { get; set; }
        public string proveedor { get; set; }
        public string clave_proveedor { get; set; }
        public string clave_forro { get; set; }
        public string clave_prospecto { get; set; }
        public int prospecto { get; set; }
        public string imagen { get; set; }
        public int estatus { get; set; }
        public List<EForrosComposiciones> composiciones { get; set; }

    }
}
