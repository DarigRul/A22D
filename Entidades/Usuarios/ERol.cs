using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Usuarios
{
    public class ERol
    {
        public int Id_perfil { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int id_estatus { get; set; }
        public int orden { get; set; }
    }
}
