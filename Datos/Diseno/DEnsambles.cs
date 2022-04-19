using Entidades.Diseno;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Diseno
{
    public class DEnsambles
    {
        public static List<EEnsambles> getEnsambles()
        {
            List<EEnsambles> result = new List<EEnsambles>();
            EEnsambles eEnsamble;
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("diseno_ensambles_listar", cnn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    eEnsamble = new EEnsambles();
                    if (!reader.IsDBNull(0))
                        eEnsamble.id_ensamble = Convert.ToInt32(reader["id_ensamble"]);
                    if (!reader.IsDBNull(1))
                        eEnsamble.descripcion = Convert.ToString(reader["descripcion"]);
                    if (!reader.IsDBNull(2))
                        eEnsamble.consumo = Convert.ToString(reader["consumo"]);
                    if (!reader.IsDBNull(3))
                        eEnsamble.tipo = Convert.ToString(reader["tipo"]);
                    if (!reader.IsDBNull(4))
                        eEnsamble.estatus = Convert.ToInt32(reader["estatus"]);
                    result.Add(eEnsamble);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return result;
        }

        public static string insertarEnsambles(EEnsambles eEnsambles)
        {
            string result = "";
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("diseno_ensambles_agregar", cnn);
            try
            {
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = eEnsambles.descripcion;
                cmd.Parameters.Add("@consumo", SqlDbType.VarChar).Value = eEnsambles.consumo;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = eEnsambles.tipo;

                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        result = Convert.ToString(reader["mensaje"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return result;
        }

        public static string modificaEnsambles(EEnsambles eEnsambles)
        {
            string result = "";
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("diseno_ensambles_modificar", cnn);
            try
            {
                cmd.Parameters.Add("@id_ensamble", SqlDbType.Int).Value = eEnsambles.id_ensamble;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = eEnsambles.descripcion;
                cmd.Parameters.Add("@consumo", SqlDbType.VarChar).Value = eEnsambles.consumo;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = eEnsambles.tipo;

                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        result = Convert.ToString(reader["mensaje"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return result;
        }

        public static int ActivarEnsambles(int id_ensamble)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_ensambles_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_ensamble", id_ensamble);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DesactivarEnsambles(int id_ensamble)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_ensambles_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_ensamble", id_ensamble);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static List<EEnsambles> getFamilia_predna_Ensambles(int id_familia_prenda)
        {
            List<EEnsambles> result = new List<EEnsambles>();
            EEnsambles eEnsamble;
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("diseno_familia_prendas_estandar_costura_listar", cnn);
            try
            {
                cmd.Parameters.Add("@id_familia_prenda", SqlDbType.Int).Value = id_familia_prenda;
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    eEnsamble = new EEnsambles();
                    if (!reader.IsDBNull(0))
                        eEnsamble.id_ensamble = Convert.ToInt32(reader["id_ensamble"]);
                    if (!reader.IsDBNull(1))
                        eEnsamble.descripcion = Convert.ToString(reader["descripcion"]);
                    if (!reader.IsDBNull(2))
                        eEnsamble.consumo = Convert.ToString(reader["consumo"]);
                    if (!reader.IsDBNull(3))
                        eEnsamble.tipo = Convert.ToString(reader["tipo"]);
                    if (!reader.IsDBNull(4))
                        eEnsamble.estatus = Convert.ToInt32(reader["estatus"]);
                    result.Add(eEnsamble);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return result;
        }

        public static string familia_predna_Ensambles_inserta(int id_familia_prenda, int id_ensamble)
        {
            string result = "";
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("diseno_familia_prendas_estandar_costura_agregar", cnn);
            try
            {
                cmd.Parameters.Add("@id_familia_prenda", SqlDbType.Int).Value = id_familia_prenda;
                cmd.Parameters.Add("@id_ensamble", SqlDbType.Int).Value = id_ensamble;
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        result = Convert.ToString(reader["mensaje"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return result;
        }

        public static string familia_predna_Ensambles_eliminar(int id_familia_prenda, int id_ensamble)
        {
            string result = "";
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("[diseno_familia_prendas_estandar_costura_eliminar]", cnn);
            try
            {
                cmd.Parameters.Add("@id_familia_prenda", SqlDbType.Int).Value = id_familia_prenda;
                cmd.Parameters.Add("@id_ensamble", SqlDbType.Int).Value = id_ensamble;
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        result = Convert.ToString(reader["mensaje"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return result;
        }
    }
}
