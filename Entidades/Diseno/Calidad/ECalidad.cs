using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno.Calidad
{
   public class ECalidad
    {
        public int id_calidad { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
        public int id_prueba_encogimiento { get; set; }
        public int id_prueba_lavado_pilling { get; set; }
        public int id_prueba_costura { get; set; }
        public int id_prueba_contaminacion_combinaciontelas { get; set; }
        public int estatus { get; set; }
        public string detalle { get; set; }
        public string auxestatus { get; set; }
        public string auxpruebaencogimiento { get; set; }
        public string auxpruebalavadopilling { get; set; }
        public string auxpruebacostura { get; set; }
        public string auxpruebacontaminacion { get; set; }

    }
}
