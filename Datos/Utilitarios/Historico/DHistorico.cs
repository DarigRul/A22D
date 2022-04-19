using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Utilitarios.Historico;
using System.Data.SqlClient;
using System.Data;

namespace Datos.Utilitarios.Historico
{
    public static class DHistorico
    {
        public static void RegistraHistorico(string departamento, string modulo, string operacion,
                                     string valor_anterior = "", string valor_nuevo = "", string observaciones = "")
        {
            var eh = new EHistorico();

            eh.departamento = departamento;
            eh.modulo = modulo;
            eh.operacion = operacion;
            eh.valor_anterior = valor_anterior;
            eh.valor_nuevo = valor_nuevo;
            eh.observaciones = observaciones;

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("historico_registrar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("fecha", eh.Fecha);
                cmd.Parameters.AddWithValue("id_usuario", eh.id_usuario); 
                cmd.Parameters.AddWithValue("computadora", eh.Computadora);
                cmd.Parameters.AddWithValue("departamento", eh.departamento);
                cmd.Parameters.AddWithValue("modulo", eh.modulo);
                cmd.Parameters.AddWithValue("operacion", eh.operacion);
                cmd.Parameters.AddWithValue("valor_anterior", eh.valor_anterior);
                cmd.Parameters.AddWithValue("valor_nuevo", eh.valor_nuevo);
                cmd.Parameters.AddWithValue("observaciones", eh.observaciones);

                cn.Open();
                cmd.ExecuteNonQuery(); 
            }
        }

        public static List<EHistorico> ImportarHistorico(DateTime fecha_inicial, DateTime fecha_final)
        {
            List<EHistorico> lstHistorico = new List<EHistorico>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                fecha_final = fecha_final.AddDays(1); 

                SqlCommand cmd = new SqlCommand("historico_listar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("fecha_inicial", fecha_inicial);
                cmd.Parameters.AddWithValue("fecha_final", fecha_final);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lstHistorico.Add(new EHistorico
                    {
                        id_historico = Convert.ToInt32(rd["id_historico"]), 
                        Fecha = Convert.ToDateTime(rd["fecha"]), 
                        id_usuario = Convert.ToInt32(rd["id_usuario"]), 
                        usuario = rd["usuario"].ToString(),
                        Computadora = rd["computadora"].ToString(), 
                        departamento = rd["departamento"].ToString(), 
                        modulo = rd["modulo"].ToString(), 
                        operacion = rd["operacion"].ToString(), 
                        valor_anterior = rd["valor_anterior"].ToString(), 
                        valor_nuevo = rd["valor_nuevo"].ToString(), 
                        observaciones = rd["observaciones"].ToString()
                    }); 
                }
            }

            return lstHistorico; 
        }

    }
}
