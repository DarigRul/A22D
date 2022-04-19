using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno
{
    public class EForrosEncogimiento
    {
        public int id_encogimiento { get; set; }
        public int id_forro { get; set; }
        public int id_operario { get; set; }
        public DateTime fecha_hora { get; set; }
        public int id_entretela { get; set; }
        public double adherencia { get; set; }
        public int id_proveedor { get; set; }
        public double temperatura { get; set; }
        public double tiempo { get; set; }
        public double presion { get; set; }
        public double vapor_hilo_final { get; set; }
        public double vapor_trama_final { get; set; }
        public double vapor_hilo_diferencia { get; set; }
        public double vapor_trama_diferencia { get; set; }
        public string vapor_observaciones { get; set; }
        public double fusion_hilo_final { get; set; }
        public double fusion_trama_final { get; set; }
        public double fusion_hilo_diferencia { get; set; }
        public double fusion_trama_diferencia { get; set; }
        public string fusion_observaciones { get; set; }
        public double plancha_hilo_final { get; set; }
        public double plancha_trama_final { get; set; }
        public double plancha_hilo_diferencia { get; set; }
        public double plancha_trama_diferencia { get; set; }
        public string plancha_observaciones { get; set; }


    }
}
