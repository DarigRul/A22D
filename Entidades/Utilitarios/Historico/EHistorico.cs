using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utilitarios.Historico
{
    public class EHistorico
    {
        public int id_historico { get; set; }
        private DateTime fecha = DateTime.Now;
        
        public int id_usuario { get; set; }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string usuario { get; set; }

        private string computadora = Environment.MachineName;
        public string Computadora 
        {
            get { return computadora; }
            set { computadora = value; }
        }
        public string departamento { get; set; }
        public string modulo { get; set; }
        public string operacion { get; set; }
        public string valor_anterior { get; set; }
        public string valor_nuevo { get; set; }
        public string observaciones { get; set; }
    }
}
