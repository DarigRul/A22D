using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class EForrosLavado
    {
        public int id_lavado { get; set; }
        public int id_forro { get; set; }
        public int id_tela { get; set; }
        public int id_operario { get; set; }
        public DateTime fecha { get; set; }
        public double lavado_hilo_final { get; set; }
        public double lavado_trama_final { get; set; }
        public double lavado_hilo_diferencia { get; set; }
        public double lavado_trama_diferencia { get; set; }
        public string lavado_observaciones { get; set; }
        public string solidez_calidad { get; set; }
        public string solidez_observaciones { get; set; }
        public string pilling { get; set; }
        public string pilling_observaciones { get; set; }

    }
}
