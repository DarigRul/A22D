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
    public class DRol
    {
        public static List<ERol> getRoles()
        {
            List<ERol> roles = new List<ERol>();
            ERol rol;
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("usuario_perfil_listar", cnn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rol = new ERol();
                    if (!reader.IsDBNull(0))
                        rol.Id_perfil = Convert.ToInt32(reader["Id_perfil"]);
                    if (!reader.IsDBNull(1))
                        rol.Nombre = Convert.ToString(reader["Nombre"]);
                    if (!reader.IsDBNull(2))
                        rol.Descripcion = Convert.ToString(reader["Descripcion"]);
                    if (!reader.IsDBNull(3))
                        rol.id_estatus = Convert.ToInt32(reader["id_estatus"]);
                    if (!reader.IsDBNull(4))
                        rol.orden = Convert.ToInt32(reader["orden"]);
                    roles.Add(rol);
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
            return roles;
        }

        public static string AgregarRol(ERol rol)
        {
            string mensaje = "";

            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("usuario_perfil_agregar", cnn);
            try
            {
                cmd.Parameters.AddWithValue("Nombre", rol.Nombre);
                cmd.Parameters.AddWithValue("Descripcion", rol.Descripcion);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        mensaje = Convert.ToString(reader["mensaje"]);
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
            return mensaje;
        }

        public static string ModificarRol(ERol rol)
        {
            string mensaje = "";

            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("usuario_perfil_modificar", cnn);
            try
            {
                cmd.Parameters.AddWithValue("Id_perfil", rol.Id_perfil);
                cmd.Parameters.AddWithValue("Nombre", rol.Nombre);
                cmd.Parameters.AddWithValue("Descripcion", rol.Descripcion);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        mensaje = Convert.ToString(reader["mensaje"]);
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
            return mensaje;
        }

        public static int ActivarRol(int id_perfil)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("usuario_perfil_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_perfil", id_perfil);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DesactivarRol(int id_perfil)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("usuario_perfil_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_perfil", id_perfil);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
