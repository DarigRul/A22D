using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno.Calidad
{
    public class EPruebaEncogimiento
    {
        public int id_prueba_encogimiento { get; set; }
        public int id_forro { get; set; }
        public int id_operario { get; set; }
        public DateTime fecha_hora { get; set; }
        public int id_entretela { get; set; }
        public double adherencia { get; set; }
        public int id_proveedor { get; set; }
        public double temperatura { get; set; }
        public int tiempo { get; set; }
        public double presion { get; set; }
        public double vapor_hilo_final { get; set; }
        public double vapor_trama_final { get; set; }
        public double vapor_hilo_diferencia { get; set; }
        //public double cm_hilo_resultado { get; set; }
        public double vapor_trama_diferencia { get; set; }
        //public double cm_trama_resultado { get; set; }
        public string vapor_observaciones { get; set; }
        public double fusion_hilo_final { get; set; }
        public double fusion_trama_final { get; set; }
        public double fusion_hilo_diferencia { get; set; }
        public double cm_hilo_fusion { get; set; }
        //public double diferencia_trama_fision { get; set; }
        //public double cm_trama_fision { get; set; }
        public double fusion_trama_diferencia { get; set; }
        public string fusion_observaciones { get; set; }
        public double plancha_hilo_final { get; set; }
        public double plancha_trama_final { get; set; }
        public double plancha_hilo_diferencia { get; set; }
        public double plancha_trama_diferencia { get; set; }
        //public double diferencia_trama_planchavapor { get; set; }
        //public double cm_trama_planchavapor { get; set; }
        public string plancha_obvservaciones { get; set; }

    }
}