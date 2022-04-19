using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Entidades.Produccion;

namespace Datos.Produccion
{
    public static class DTallas
    {

        public static List<ETallas> Listar()
        {
            List<ETallas> lstTallas = new List<ETallas>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("tallas_listar", cn) {CommandType = CommandType.StoredProcedure};
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstTallas.Add(new ETallas()
                    {
                        id_talla =  Convert.ToInt32(rd["id_talla"]), 
                        talla = Convert.ToInt32(rd["talla"]), 
                        id_genero = Convert.ToInt32(rd["id_genero"]), 
                        genero = rd["genero"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])

                    });
                }
            }

            return lstTallas;
        }
        public static int Agregar(ETallas talla)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("tallas_agregar", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("talla", talla.talla);
                cmd.Parameters.AddWithValue("id_genero", talla.id_genero); 
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Actualizar(ETallas talla)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("tallas_actualiza", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("id_talla", talla.id_talla); 
                cmd.Parameters.AddWithValue("talla", talla.talla); 
                cmd.Parameters.AddWithValue("id_genero", talla.id_genero); 
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int CambiaEstatus(ETallas talla)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("tallas_estatus", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_talla", talla.id_talla);
                cmd.Parameters.AddWithValue("estatus", talla.estatus);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }


    }
}
