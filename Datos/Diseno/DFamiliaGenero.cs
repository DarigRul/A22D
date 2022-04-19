using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Diseno;
using System.Data.SqlClient;
using System.Data;

namespace Datos.Diseno
{
    public static class DFamiliaGenero
    {
        public static List<EFamiliaGenero> ListarGeneros()
        {
            List<EFamiliaGenero> lstGeneros = new List<EFamiliaGenero>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_familia_genero_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstGeneros.Add(new EFamiliaGenero
                    {
                        id_familia_genero = Convert.ToInt32(rd["id_familia_genero"]), 
                        nombre = rd["nombre"].ToString(), 
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }
            }
            return lstGeneros;
        }

        public static int AgregaGenero(EFamiliaGenero genero)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_familia_genero_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre", genero.nombre);
                cn.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }

        public static int ModificaGenero(EFamiliaGenero genero)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_familia_genero_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_familia_genero", genero.id_familia_genero); 
                cmd.Parameters.AddWithValue("nombre", genero.nombre);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ActivaGenero(int id_familia_genero)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_familia_genero_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_familia_genero", id_familia_genero);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DesactivaGenero(int id_familia_genero)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_familia_genero_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_familia_genero", id_familia_genero);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
