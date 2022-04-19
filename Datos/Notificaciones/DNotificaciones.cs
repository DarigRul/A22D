using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web.UI;
using Entidades.Notificaciones;

namespace Datos.Notificaciones
{
    public static class DNotificaciones
    {
        public static List<ENotificacion> ListarNotificaciones(int id_usuario_destino, DateTime fecha_inicio, DateTime fecha_final)
        {
            List<ENotificacion> lstNotificaciones = new List<ENotificacion>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("notificaciones_listar", cn)
                    {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("id_usuario_destinatario", id_usuario_destino);
                cmd.Parameters.AddWithValue("fecha_inicio", fecha_inicio);
                cmd.Parameters.AddWithValue("fecha_final", fecha_final);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    var notificacion = new ENotificacion()
                    {
                        id_notificacion = Convert.ToInt32(rd["id_notificacion"]), 
                        id_notificacion_tipo = Convert.ToInt32(rd["id_notificacion_tipo"]),
                        tipo = rd["tipo"].ToString(),
                        id_usuario_destinatario = Convert.ToInt32(rd["id_usuario_destinatario"]), 
                        descripcion = rd["descripcion"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"]),
                        fecha_creacion = Convert.ToDateTime(rd["fecha_creacion"]), 
                        fecha_visto = DBNull.Value.Equals(rd["fecha_visto"]) ? Convert.ToDateTime("01/01/2021") : Convert.ToDateTime(rd["fecha_visto"]),
                        usuario_genera = rd["usuario_genera"].ToString()
                    };

                    lstNotificaciones.Add(notificacion);
                }
            }

            return lstNotificaciones;
        }

        public static int CambiarEstatusVisto(int id_notificacion)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("notificaciones_visto", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("id_notificacion", id_notificacion); 
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static string RegistraNotificacion(ENotificacion notificacion)
        {
            try
            {
                //Validamos que el id_tipo_notificacion esté cargado 
                if (notificacion.id_notificacion_tipo < 1 || Object.ReferenceEquals(null, notificacion.id_notificacion_tipo))
                {
                    return "El tipo de notificación es nulo o está vacío\r\nno se registraron notificaciones";
                }
                else
                {
                    //Importamos los destinatarios 
                    List<ENotificacionDestinatario> lstDestinatarios = ImportarDestinatarios(notificacion.id_notificacion_tipo);
                    int procesados = 0;

                    foreach (ENotificacionDestinatario destinatario in lstDestinatarios)
                    {
                        notificacion.id_usuario_destinatario = destinatario.id_destinatario;

                        using (SqlConnection cn = DConexion.obtenerConexion())
                        {
                            SqlCommand cmd = new SqlCommand("notificaciones_agregar", cn)
                                { CommandType = CommandType.StoredProcedure };
                            cmd.Parameters.AddWithValue("id_notificacion_tipo", notificacion.id_notificacion_tipo);
                            cmd.Parameters.AddWithValue("id_usuario_destinatario", notificacion.id_usuario_destinatario);
                            cmd.Parameters.AddWithValue("id_usuario_genera", notificacion.id_usuario_genera);
                            cmd.Parameters.AddWithValue("descripcion", notificacion.descripcion);
                            cn.Open();
                            procesados += cmd.ExecuteNonQuery();
                        }
                    }

                    if (procesados == lstDestinatarios.Count)
                    {
                        return $"Se registró {procesados} notificación(es)";
                    }
                    else
                    {
                        return "No se registraron notificaciones";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Existe un error al registrar notificaciones\r\n{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}"; 
            }
        }

        private static List<ENotificacionDestinatario> ImportarDestinatarios(int id_notificacion_tipo)
        {
            List<ENotificacionDestinatario> lstDestinatarios = new List<ENotificacionDestinatario>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("notificaciones_listar_tipos_destinatarios", cn)
                    {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("id_notificacion_tipo", id_notificacion_tipo);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstDestinatarios.Add(new ENotificacionDestinatario()
                    {
                        id_notificacion_tipo = id_notificacion_tipo, 
                        id_destinatario = Convert.ToInt32(rd["id_usuario"])
                    });
                }
            }

            return lstDestinatarios;
        }
    }

    
}
