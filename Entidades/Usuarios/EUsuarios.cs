using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Usuarios
{
    public class EUsuarios
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string telefono { get; set; }
        public int id_perfil { get; set; }
        public string perfil { get; set; }
        public int id_estatus { get; set; }
        public string ui { get; set; }
        public string ultimo_acceso { get; set; }
        public int contrasena_temporal { get; set; }

    }
}
