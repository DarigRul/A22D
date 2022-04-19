using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Diseno;

namespace Datos.Diseno
{ 
    public class DComposicion
    {
        public static List<EComposicion> ListarComposiciones()
        {
            List<EComposicion> lstComposiciones = new List<EComposicion>();

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_composiciones_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstComposiciones.Add(new EComposicion
                    {
                        id_composicion = DBNull.Value.Equals(rd["id_composicion"]) ? 0 : Convert.ToInt32(rd["id_composicion"]),
                        nombre = rd["nombre"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }
            }
            return lstComposiciones;
        }
       
        public static int DesactivaComposicion(int id_Composicion)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_composicion_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_Composicion", id_Composicion);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static int ActivaComposicion(int id_Composicion)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_composicion_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_Composicion", id_Composicion);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static int AgregaComposicion(EComposicion composicion)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_composicion_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre",composicion.nombre);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static int ModificaComposicion(EComposicion composicion)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_composiciones_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_composicion", composicion.id_composicion);
                cmd.Parameters.AddWithValue("nombre", composicion.nombre);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
