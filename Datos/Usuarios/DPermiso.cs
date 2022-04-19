using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Usuarios
{
    public class DPermiso
    {
        public static List<EPermiso> getPermisos_por_perfil(int id_perfil, int permisos, int botones)
        {
            List<EPermiso> lPermisos = new List<EPermiso>();
            EPermiso permiso;
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("usuario_perfil_opcion_por_perfil_listar", cnn);
            try
            {
                cmd.Parameters.AddWithValue("id_perfil", id_perfil);
                cmd.Parameters.AddWithValue("permisos", permisos);
                cmd.Parameters.AddWithValue("botones", botones);

                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    permiso = new EPermiso();
                    if (!reader.IsDBNull(0))
                        permiso.Id_opcion = Convert.ToInt32(reader["id_opcion"]);
                    if (!reader.IsDBNull(1))
                        permiso.descripcion = Convert.ToString(reader["descripcion"]);
                    if (!reader.IsDBNull(1))
                        permiso.controller = Convert.ToString(reader["controller"]);
                    lPermisos.Add(permiso);
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
            return lPermisos;
        }

        public static string AgregarPermisos_por_perfil(int id_perfil, string permisos, string botones, string usuario)
        {
            string result = ""; ;
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("usuario_permisos_por_perfil_agregar", cnn);
            try
            {
                cmd.Parameters.AddWithValue("id_perfil", id_perfil);
                cmd.Parameters.AddWithValue("jsonPermisos", permisos);
                cmd.Parameters.AddWithValue("jsonBotones", botones);
                cmd.Parameters.AddWithValue("usuario", usuario);

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
