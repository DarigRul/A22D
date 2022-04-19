using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class DConexion
    {
        public static bool conexionLocal;

        public static SqlConnection obtenerConexion()
        {
            //Tomar la conexión dependiendo de si está en forma local o remota, esto se configura desde el login

            string cadenaConexion = "";
            if (conexionLocal)
            {
                cadenaConexion = ConfigurationManager.ConnectionStrings["Altima_ERP_2022_REMOTO"].ConnectionString;
            }
            else
            {
                cadenaConexion = ConfigurationManager.ConnectionStrings["ALTIMA_ERP_2022_LOCAL"].ConnectionString;
            }

            SqlConnection cn = new SqlConnection(cadenaConexion);
            return cn;
        }

        public static bool pruebaConexion()
        {
            try
            {
                string cadenaConexion = "";
                if (conexionLocal)
                {
                    cadenaConexion = ConfigurationManager.ConnectionStrings["Altima_ERP_2022_REMOTO"].ConnectionString;
                }
                else
                {
                    cadenaConexion = ConfigurationManager.ConnectionStrings["ALTIMA_ERP_2022_LOCAL"].ConnectionString;
                }

                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    cn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
