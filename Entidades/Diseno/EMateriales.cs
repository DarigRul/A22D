using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class EMateriales
    {
        public int id_familia_prenda { get; set; }
        public int id_material  { get; set; }
        public int tipo  { get; set; }
        public int id_material_tipo  { get; set; }
        public string material_tipo { get; set; }
        public int id_proveedor  { get; set; }
        public string nombre_comercial { get; set; }
        public int id_material_proceso  { get; set; }
        public string proceso { get; set; }
        public int id_unidad_medida  { get; set; }
        public string unidad_medida { get; set; }
        public string nombre  { get; set; }
        public int id_color  { get; set; }
        public string color  { get; set; }
        public string uso  { get; set; }
        public string clave_proveedor  { get; set; }
        public decimal tamano  { get; set; }
        public string  observaciones  { get; set; }
        public string imagen  { get; set; }
        public int hacer_prueba_calidad  { get; set; }
        public decimal precio_unitario  { get; set; }
        public int estatus { get; set; }
        public int auxestatus { get; set; }
    }
}
