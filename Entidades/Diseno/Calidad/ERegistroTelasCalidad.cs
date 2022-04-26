using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Diseno.Calidad
{
    public class ERegistroTelasCalidad
    {
        public int id_tela { get; set; }
        public int id_prueba_encogimiento { get; set; }
        public int id_prueba_lavado_pilling { get; set; }
        public int id_prueba_costura { get; set; }
        public int id_prueba_contaminacion_telas { get; set; }
        public EPruebaEncogimiento encogimiento { get; set; }
        public EPruebaLavadoPilling lavadoPilling { get; set; }
        public EPruebaCostura costura { get; set; }
        public EPruebaContaminacion contaminacion { get; set; }

    }
}
