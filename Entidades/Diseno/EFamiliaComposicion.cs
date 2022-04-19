using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class EFamiliaComposicion
    {
        public int id_familia_composicion { get; set; }
        public string nombre { get; set; }
        public int estatus { get; set; }
        public List<EComposicion> eComposiciones = new List<EComposicion>();
        public List<EInstruccionesCuidado> eInstruccionesCuidados = new List<EInstruccionesCuidado>();

    }
}
