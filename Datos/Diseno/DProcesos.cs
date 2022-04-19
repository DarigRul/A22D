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
    public class DProcesos
    {
        public static List<EProcesos> ProcesosListar()
        {
            List<EProcesos> lstProcesos = new List<EProcesos>();

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("procesos_produccion_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstProcesos.Add(new EProcesos
                    {
                        id_proceso = DBNull.Value.Equals(rd["id_proceso"]) ? 0 : Convert.ToInt32(rd["id_proceso"]),
                        nombre = rd["nombre"].ToString(),
                        tipo = rd["tipo"].ToString(),
                        id_departamento = Convert.ToInt32(rd["id_departamento"]),
                        departamento = rd["departamento"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }
            }
            return lstProcesos;
        }
        public static int procesoActualizaEstatus(int id_proceso, int estatus)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("procesos_produccion_actualiza_estatus", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_proceso", id_proceso);
                cmd.Parameters.AddWithValue("estatus", estatus);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static int  procesosProduccionAgrega(EProcesos eProcesos)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("procesos_produccion_agrega", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre", eProcesos.nombre);
                cmd.Parameters.AddWithValue("tipo", eProcesos.tipo);
             
                cmd.Parameters.AddWithValue("id_departemento", eProcesos.id_departamento);
                cn.Open ();
                return cmd.ExecuteNonQuery();
            }
        }
        public static int procesosProduccionModifica(EProcesos eProcesos)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("procesos_produccion_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre", eProcesos.nombre);
                cmd.Parameters.AddWithValue("tipo", eProcesos.tipo);

                cmd.Parameters.AddWithValue("id_proceso", eProcesos.id_proceso);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
