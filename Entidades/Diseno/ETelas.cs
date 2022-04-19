using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class ETelas
    {
        public int id_tela { get; set; }
        public int tipo  { get; set; }
        public string clave_tela { get; set; }
        public string descripcion { get; set; }
        public int id_familia_composicion { get; set; }
        public int id_estampado { get; set; }
        public int id_proveedor { get; set; }
        public string clave_proveedor { get; set; }
        public int id_color { get; set; }
        public double ancho_tela { get; set; }
        public string imagen { get; set; }
        public string  observaciones  { get; set; }
        public int estatus { get; set; }
        public string auxestatus { get; set; }
        public int estatus_tela { get; set; }
        public double prueba_encogimiento_largo { get; set; }
        public double prueba_encogimiento_ancho { get; set; }
        public string auxid_familia_composicion { get; set; }
        public string auxid_estampado { get; set; }
        public string auxid_proveedor { get; set; }
        public string auxid_color { get; set; }
    }
}
