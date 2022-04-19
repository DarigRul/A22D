using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class EMaterialTipo
    {
        public int id_material_tipo { get; set; }
        public string descripcion { get; set; }
        public string nomenclatura { get; set; }
        public string tipo_material { get; set; }
        public string clasificacion { get; set; }
        public int estatus { get; set; }
    }
}
