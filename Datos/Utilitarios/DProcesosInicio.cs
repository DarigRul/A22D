using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Usuarios;

namespace Datos.Utilitarios
{
    public static class DProcesosInicio
    {

        public delegate int VerificaNotificacionesDelegado(EUsuarios usuario);
        public static event VerificaNotificacionesDelegado notificaciones; 


        //Notificaciones 
        public static async Task<int> VerificaNotificaciones(EUsuarios usuario)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("notificaciones_usuario_contar", cn)
                    {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("id_usuario_destinatario", usuario.id_usuario); 
                await cn.OpenAsync();
                return Convert.ToInt32(cmd.ExecuteScalar()); 
            }
        }


    }
}
