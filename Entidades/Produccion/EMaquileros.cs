using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Produccion
{
    public class EMaquileros
    {
        public int  id_maquilero { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string  materno { get; set; }
        public string  email { get; set; }
        public string  direccion { get; set; }
        public string  cp { get; set; }
        public string telefono { get; set; }
        public string  celular { get; set; }
        public string  razon_social { get; set; }
        public string rfc { get; set; }
        public string  direccion_facturacion { get; set; }
        public string cp_facturacion { get; set; }
        public int estatus { get; set; }
        public string  estatus_texto { get; set; }
        List<familia> familiapormaquilero = new List<familia>();
        private class familia
        {
            public int id_familia { get; set; }
            public string nombre_familia { get; set; }
            public int capacidad_semanal { get; set; }
        }
    }
  

}
