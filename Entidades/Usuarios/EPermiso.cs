using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Usuarios
{
    public class EPermiso
    {
        public int Id_perfil { get; set; }
        public int Id_opcion { get; set; }
        public string descripcion { get; set; }
        public string consulta { get; set; }
        public string controller { get; set; }
    }
}
