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
    public static class DForrosEncogimiento
    {
        public static int Registra(EForrosEncogimiento enc)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_encogimiento_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_forro", enc.id_forro);
                cmd.Parameters.AddWithValue("id_operario", enc.id_operario);
                cmd.Parameters.AddWithValue("fecha_hora", enc.fecha_hora);
                cmd.Parameters.AddWithValue("id_entretela", enc.id_entretela);
                cmd.Parameters.AddWithValue("adherencia", enc.adherencia);
                cmd.Parameters.AddWithValue("id_proveedor", enc.id_proveedor);
                cmd.Parameters.AddWithValue("temperatura", enc.temperatura);
                cmd.Parameters.AddWithValue("tiempo", enc.tiempo);
                cmd.Parameters.AddWithValue("presion", enc.presion);
                cmd.Parameters.AddWithValue("vapor_hilo_final", enc.vapor_hilo_final);
                cmd.Parameters.AddWithValue("vapor_trama_final", enc.vapor_trama_final);
                cmd.Parameters.AddWithValue("vapor_hilo_diferencia", enc.vapor_hilo_diferencia);
                cmd.Parameters.AddWithValue("vapor_trama_diferencia", enc.vapor_trama_diferencia);
                cmd.Parameters.AddWithValue("vapor_observaciones", enc.vapor_observaciones);
                cmd.Parameters.AddWithValue("fusion_hilo_final", enc.fusion_hilo_final);
                cmd.Parameters.AddWithValue("fusion_trama_final", enc.fusion_trama_final);
                cmd.Parameters.AddWithValue("fusion_hilo_diferencia", enc.fusion_hilo_diferencia);
                cmd.Parameters.AddWithValue("fusion_trama_diferencia", enc.fusion_trama_diferencia);
                cmd.Parameters.AddWithValue("fusion_observaciones", enc.fusion_observaciones);
                cmd.Parameters.AddWithValue("plancha_hilo_final", enc.plancha_hilo_final);
                cmd.Parameters.AddWithValue("plancha_trama_final", enc.plancha_trama_final);
                cmd.Parameters.AddWithValue("plancha_hilo_diferencia", enc.plancha_hilo_diferencia);
                cmd.Parameters.AddWithValue("plancha_trama_diferencia", enc.plancha_trama_diferencia);
                cmd.Parameters.AddWithValue("plancha_observaciones", enc.plancha_observaciones);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }


        public static int Actualiza(EForrosEncogimiento enc)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_encogimiento_actualiza", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_encogimiento", enc.id_encogimiento);
                cmd.Parameters.AddWithValue("id_forro", enc.id_forro);
                cmd.Parameters.AddWithValue("id_operario", enc.id_operario);
                cmd.Parameters.AddWithValue("fecha_hora", enc.fecha_hora);
                cmd.Parameters.AddWithValue("id_entretela", enc.id_entretela);
                cmd.Parameters.AddWithValue("adherencia", enc.adherencia);
                cmd.Parameters.AddWithValue("id_proveedor", enc.id_proveedor);
                cmd.Parameters.AddWithValue("temperatura", enc.temperatura);
                cmd.Parameters.AddWithValue("tiempo", enc.tiempo);
                cmd.Parameters.AddWithValue("presion", enc.presion);
                cmd.Parameters.AddWithValue("vapor_hilo_final", enc.vapor_hilo_final);
                cmd.Parameters.AddWithValue("vapor_trama_final", enc.vapor_trama_final);
                cmd.Parameters.AddWithValue("vapor_hilo_diferencia", enc.vapor_hilo_diferencia);
                cmd.Parameters.AddWithValue("vapor_trama_diferencia", enc.vapor_trama_diferencia);
                cmd.Parameters.AddWithValue("vapor_observaciones", enc.vapor_observaciones);
                cmd.Parameters.AddWithValue("fusion_hilo_final", enc.fusion_hilo_final);
                cmd.Parameters.AddWithValue("fusion_trama_final", enc.fusion_trama_final);
                cmd.Parameters.AddWithValue("fusion_hilo_diferencia", enc.fusion_hilo_diferencia);
                cmd.Parameters.AddWithValue("fusion_trama_diferencia", enc.fusion_trama_diferencia);
                cmd.Parameters.AddWithValue("fusion_observaciones", enc.fusion_observaciones);
                cmd.Parameters.AddWithValue("plancha_hilo_final", enc.plancha_hilo_final);
                cmd.Parameters.AddWithValue("plancha_trama_final", enc.plancha_trama_final);
                cmd.Parameters.AddWithValue("plancha_hilo_diferencia", enc.plancha_hilo_diferencia);
                cmd.Parameters.AddWithValue("plancha_trama_diferencia", enc.plancha_trama_diferencia);
                cmd.Parameters.AddWithValue("plancha_observaciones", enc.plancha_observaciones);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static EForrosEncogimiento Importar(int id_forro)
        {
            var enc = new EForrosEncogimiento();

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_encogimiento_importar", cn) { CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("id_forro", id_forro);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    enc.id_encogimiento = Convert.ToInt32(rd["id_encogimiento"]);
                    enc.id_forro = Convert.ToInt32(rd["id_forro"]);
                    enc.id_operario = Convert.ToInt32(rd["id_operario"]);
                    enc.fecha_hora = Convert.ToDateTime(rd["fecha_hora"]);
                    enc.id_entretela = Convert.ToInt32(rd["id_entretela"]);
                    enc.adherencia = Convert.ToDouble(rd["adherencia"]);
                    enc.id_proveedor = Convert.ToInt32(rd["id_proveedor"]);
                    enc.temperatura = Convert.ToDouble(rd["temperatura"]);
                    enc.tiempo = Convert.ToInt32(rd["tiempo"]);
                    enc.presion = Convert.ToDouble(rd["presion"]);
                    enc.vapor_hilo_final = Convert.ToDouble(rd["vapor_hilo_final"]);
                    enc.vapor_trama_final = Convert.ToDouble(rd["vapor_trama_final"]);
                    enc.vapor_hilo_diferencia = Convert.ToDouble(rd["vapor_hilo_diferencia"]);
                    enc.vapor_trama_diferencia = Convert.ToDouble(rd["vapor_trama_diferencia"]);
                    enc.vapor_observaciones = rd["vapor_observaciones"].ToString();
                    enc.fusion_hilo_final = Convert.ToDouble(rd["fusion_hilo_final"]);
                    enc.fusion_trama_final = Convert.ToDouble(rd["fusion_trama_final"]);
                    enc.fusion_hilo_diferencia = Convert.ToDouble(rd["fusion_hilo_diferencia"]);
                    enc.fusion_trama_diferencia = Convert.ToDouble(rd["fusion_trama_diferencia"]);
                    enc.fusion_observaciones = rd["fusion_observaciones"].ToString();
                    enc.plancha_hilo_final = Convert.ToDouble(rd["plancha_hilo_final"]);
                    enc.plancha_trama_final = Convert.ToDouble(rd["plancha_trama_final"]);
                    enc.plancha_hilo_diferencia = Convert.ToDouble(rd["plancha_hilo_diferencia"]);
                    enc.plancha_trama_diferencia = Convert.ToDouble(rd["plancha_trama_diferencia"]);
                    enc.plancha_observaciones = rd["plancha_observaciones"].ToString();
                }
                rd.Close();
                
            }

            return enc;
        }


        public static int Contar(int id_forro)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_encogimiento_contar", cn) { CommandType= CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_forro", id_forro);
                cn.Open(); 
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

    }
}
