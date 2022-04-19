using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Comercial.Precios
{
    public class EPrecios
    {
        public int id_precio { get; set; }
        public string  familia_prenda { get; set; }
        public string  familia_composicion { get; set; }
        public int id_familia_prenda { get; set; }
        public int id_familia_composicion { get; set; }
        public double local_actual { get; set; }
        public double foraneo_actual { get; set; }
        public double linea_expres_local_actual { get; set; }
        public double linea_expres_foraneo_actual { get; set; }
        public double local_anterior { get; set; }
        public double foraneo_anterior { get; set; }
        public double linea_expres_local_anterior { get; set; }
        public double linea_expres_foraneo_anterior { get; set; }
        public double ecommerce_actual { get; set; }
        public double ecommerce_anterior { get; set; }
        public double muestrario { get; set; }
        public double venta_interna { get; set; }
        public double extra1 { get; set; }
        public double extra2 { get; set; }
        public double extra3 { get; set; }
        public int estatus { get; set; }

       

        
        





    }
}
