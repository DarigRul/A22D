using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Produccion;
using System.Data.SqlClient;
using System.Data;


namespace Datos.Produccion
{
    public static class DLargos
    {
        public static List<ELargos> Listar()
        {
            List<ELargos> lstLargos = new List<ELargos>(); 
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("largos_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstLargos.Add(new ELargos()
                    {
                        id_largo = Convert.ToInt32(rd["id_largo"]),
                        nomenclatura = rd["nomenclatura"].ToString(),
                        descripcion = rd["descripcion"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])
                    }); 
                }
            }
            return lstLargos;
        }

        public static int Agregar(ELargos largo)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("largos_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nomenclatura", largo.nomenclatura); 
                cmd.Parameters.AddWithValue("descripcion", largo.descripcion);
                cn.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }

        public static int Actualizar(ELargos largo)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("largos_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_largo", largo.id_largo);
                cmd.Parameters.AddWithValue("nomenclatura", largo.nomenclatura);
                cmd.Parameters.AddWithValue("descripcion", largo.descripcion);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Estatus(ELargos largo)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("largos_estatus", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_largo", largo.id_largo);
                cmd.Parameters.AddWithValue("estatus", largo.estatus);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
