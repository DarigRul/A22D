using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Notificaciones
{
    public class ENotificacion
    {
        public int id_notificacion { get; set; }
        public int id_notificacion_tipo { get; set; }
        public string tipo { get; set; }
        public int id_usuario_destinatario { get; set; }
        public int id_usuario_genera { get; set; }
        public string usuario_genera { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_visto { get; set; }
        public int estatus { get; set; }
    }
}
