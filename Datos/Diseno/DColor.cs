using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Diseno;
using System.Data;
using System.Data.SqlClient; 

namespace Datos.Diseno
{
    public class DColor
    {

        public List<EColor> ListarColores()
        {
            List<EColor> lstColores = new List<EColor>();

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_color_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstColores.Add(new EColor
                    {
                        id_color = DBNull.Value.Equals(rd["id_color"]) ? 0: Convert.ToInt32(rd["id_color"]),
                        nombre = rd["nombre"].ToString(),
                        codigo_color = rd["codigo_color"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])

                    });
                }

            }

            return lstColores;
        }

        public int AgregarColor(EColor color)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_color_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre", color.nombre);
                cmd.Parameters.AddWithValue("codigo_color", color.codigo_color);
                cn.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }

        public int ModificaColor(EColor color)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_color_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_color", color.id_color);
                cmd.Parameters.AddWithValue("nombre", color.nombre);
                cmd.Parameters.AddWithValue("codigo_color", color.codigo_color);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int ActivarColor(int id_color)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_colores_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_color", id_color);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DesactivarColor(int id_color)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_colores_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_color", id_color);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
