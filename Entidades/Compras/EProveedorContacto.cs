using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Compras
{
    public class EProveedorContacto
    {
        public int id_contacto { get; set; }
        public int id_proveedor_contacto { get; set; }
        public string nombre_contacto { get; set; }
        public string telefono_contacto { get; set; }
        public string extension_contacto { get; set; }
        public string celular_contacto { get; set; }
        public string email_contacto { get; set; }
        public string puesto_contacto { get; set; }
        public string observaciones { get; set; }
        public int estatus_contacto { get; set; }
    }
}
