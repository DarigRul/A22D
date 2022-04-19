using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class EForrosComposiciones
    {
        public int id_forro_composicion { get; set; }
        public int id_forro { get; set; }
        public int id_composicion { get; set; }
        public decimal porcentaje { get; set; }
        public string forro { get; set; }
        public string composicion { get; set; }
    }
}
