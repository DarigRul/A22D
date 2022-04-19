using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Usuarios;
namespace Datos.Usuarios
{
    public class DUsuario
    {
        public static EUsuarios login(string usuario, string password)
        {
            bool test = DConexion.pruebaConexion();
            if (!test)
            {
                throw new Exception("Revisa tu tipo de conexión");
            }

            EUsuarios eUsuario = new EUsuarios();
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("Usuario_acceso", cnn);
            try
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", password);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        eUsuario.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    if (!reader.IsDBNull(1))
                        eUsuario.usuario = Convert.ToString(reader["usuario"]);
                    if (!reader.IsDBNull(2))
                        eUsuario.nombre = Convert.ToString(reader["nombre"]);
                    if (!reader.IsDBNull(3))
                        eUsuario.paterno = Convert.ToString(reader["paterno"]);
                    if (!reader.IsDBNull(4))
                        eUsuario.materno = Convert.ToString(reader["materno"]);
                    if (!reader.IsDBNull(5))
                        eUsuario.correo = Convert.ToString(reader["correo"]);
                    if (!reader.IsDBNull(6))
                        eUsuario.contrasena = Convert.ToString(reader["contrasena"]);
                    if (!reader.IsDBNull(7))
                        eUsuario.telefono = Convert.ToString(reader["telefono"]);
                    if (!reader.IsDBNull(8))
                        eUsuario.id_perfil = Convert.ToInt32(reader["id_perfil"]);
                    if (!reader.IsDBNull(9))
                        eUsuario.id_estatus = Convert.ToInt32(reader["id_estatus"]);
                    if (!reader.IsDBNull(10))
                        eUsuario.ui = Convert.ToString(reader["ui"]);
                    if (!reader.IsDBNull(11))
                        eUsuario.ultimo_acceso = Convert.ToString(reader["ultimo_acceso"]);
                    if (!reader.IsDBNull(12))
                        eUsuario.contrasena_temporal = Convert.ToInt32(reader["contrasena_temporal"]);
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
            return eUsuario;
        }

        public static List<EUsuarios> getUsuarios()
        {
            List<EUsuarios> usuarios = new List<EUsuarios>();
            EUsuarios eUsuario;
            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("usuario_listar", cnn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    eUsuario = new EUsuarios();
                    if (!reader.IsDBNull(0))
                        eUsuario.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    if (!reader.IsDBNull(1))
                        eUsuario.usuario = Convert.ToString(reader["usuario"]);
                    if (!reader.IsDBNull(2))
                        eUsuario.nombre = Convert.ToString(reader["nombre"]);
                    if (!reader.IsDBNull(3))
                        eUsuario.paterno = Convert.ToString(reader["paterno"]);
                    if (!reader.IsDBNull(4))
                        eUsuario.materno = Convert.ToString(reader["materno"]);
                    if (!reader.IsDBNull(5))
                        eUsuario.correo = Convert.ToString(reader["correo"]);
                    if (!reader.IsDBNull(6))
                        eUsuario.contrasena = Convert.ToString(reader["contrasena"]);
                    if (!reader.IsDBNull(7))
                        eUsuario.telefono = Convert.ToString(reader["telefono"]);
                    if (!reader.IsDBNull(8))
                        eUsuario.id_perfil = Convert.ToInt32(reader["id_perfil"]);
                    if (!reader.IsDBNull(9))
                        eUsuario.perfil = Convert.ToString(reader["perfil"]);
                    if (!reader.IsDBNull(10))
                        eUsuario.id_estatus = Convert.ToInt32(reader["id_estatus"]);
                    if (!reader.IsDBNull(11))
                        eUsuario.ultimo_acceso = Convert.ToString(reader["ultimo_acceso"]);
                    usuarios.Add(eUsuario);
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
            return usuarios;
        }

        public static int ActivarUsuario(int id_usuario)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("usuario_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_usuario", id_usuario);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DesactivarUsuario(int id_usuario)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("usuario_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_usuario", id_usuario);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int AgregarUsuario(EUsuarios usuarios)
        {
            int id_usuario = 0;

            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("usuario_agregar", cnn);
            try
            {
                cmd.Parameters.AddWithValue("usuario", usuarios.usuario);
                cmd.Parameters.AddWithValue("nombre", usuarios.nombre);
                cmd.Parameters.AddWithValue("paterno", usuarios.paterno);
                cmd.Parameters.AddWithValue("materno", usuarios.materno);
                cmd.Parameters.AddWithValue("correo", usuarios.correo);
                cmd.Parameters.AddWithValue("contrasena", usuarios.contrasena);
                cmd.Parameters.AddWithValue("telefono", usuarios.telefono);
                cmd.Parameters.AddWithValue("id_perfil", usuarios.id_perfil);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        id_usuario = Convert.ToInt32(reader["id_usuario"]);
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
            return id_usuario;
        }

        public static int ModificarUsuario(EUsuarios usuarios)
        {
            int id_usuario = 0;

            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("usuario_modificar", cnn);
            try
            {
                cmd.Parameters.AddWithValue("id_usuario", usuarios.id_usuario);
                cmd.Parameters.AddWithValue("usuario", usuarios.usuario);
                cmd.Parameters.AddWithValue("nombre", usuarios.nombre);
                cmd.Parameters.AddWithValue("paterno", usuarios.paterno);
                cmd.Parameters.AddWithValue("materno", usuarios.materno);
                cmd.Parameters.AddWithValue("correo", usuarios.correo);
                cmd.Parameters.AddWithValue("contrasena", usuarios.contrasena);
                cmd.Parameters.AddWithValue("telefono", usuarios.telefono);
                cmd.Parameters.AddWithValue("id_perfil", usuarios.id_perfil);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        id_usuario = Convert.ToInt32(reader["id_usuario"]);
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
            return id_usuario;
        }
    }
}
