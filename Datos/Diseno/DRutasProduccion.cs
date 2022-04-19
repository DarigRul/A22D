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
    public  class DRutasProduccion
    {
        public static List<ERutasProduccion> RutasListar()
        {
            List<ERutasProduccion> lstrutaslistar = new List<ERutasProduccion>();

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("rutas_produccion_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstrutaslistar.Add(new ERutasProduccion
                    {
                        id_ruta = DBNull.Value.Equals(rd["id_ruta"]) ? 0 : Convert.ToInt32(rd["id_ruta"]),
                        nombre = rd["nombre"].ToString(),
                        id_departamento = DBNull.Value.Equals(rd["id_departamento"]) ? 0 : Convert.ToInt32(rd["id_departamento"]),
                        departamento = rd["departamento"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }
            }
            return lstrutaslistar;
        }
        public bool rutasAgregar(ERutasProduccion e)
        {
          

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
          
           
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("ruta_produccion_agregar", cn, tran) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("id", 0);
                    cmd.Parameters.AddWithValue("nombre", e.nombre);
                    cmd.Parameters.AddWithValue("id_departamento", e.id_departamento);
                    cmd.Parameters["id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.Parameters["id"].Value;
                    guarda_ruta_proceso(cmd, e.procesos, id);
                    tran.Commit();
                    cn.Close(); 
                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                    tran.Rollback();
                    cn.Close();
                    return false;
                }
            

               
            }
           
        }
        private void guarda_ruta_proceso(SqlCommand _cmd, List<EProcesos> procesos, int id_ruta)
        {
            foreach (EProcesos p in procesos)
            {
                _cmd.Parameters.Clear();
                _cmd.CommandText = "ruta_produccion_guarda_ruta_proceso";
                _cmd.Parameters.AddWithValue("id_ruta", id_ruta);
                _cmd.Parameters.AddWithValue("id_proceso", p.id_proceso);
                _cmd.ExecuteNonQuery();
            }
        }
        public static int RutaCambiaEstatus(ERutasProduccion ruta, int estatus)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("rutas_produccion_actualiza_estatus", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_ruta", ruta.id_ruta);
                cmd.Parameters.AddWithValue("estatus",estatus);
                return cmd.ExecuteNonQuery();
            }
        }
        public static List<EProcesos> consultaProcesosPorRuta(int id_ruta)
        {
            List<EProcesos> procesos = new List<EProcesos>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ruta_produccion_consulta_procesos_por_ruta", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_ruta", id_ruta);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                while (rd.Read())
                {
                    procesos.Add(new EProcesos
                    {
                        id_proceso = DBNull.Value.Equals(rd["id_proceso"]) ? 0 : Convert.ToInt32(rd["id_proceso"]),
                        nombre = rd["nombre"].ToString(),
                        tipo = rd["tipo"].ToString()
                    });
                }
            }
            return procesos;
        }
        public  bool ActualizaRutaPrincipal(ERutasProduccion rutaActualizar)

        {
        
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();
                //eliminamos todos los registros en la tabla Rutas_Procesos
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("ruta_produccion_elimina_procesos", cn, tr) { CommandType = CommandType.StoredProcedure };
                    //cmd.Parameters.AddWithValue("id_ruta", rutaActualizar.id_ruta);
                    //cmd.ExecuteNonQuery();
                    //Actualiza el nombre
                    ActualizaRutaNombre(cmd, rutaActualizar);
                    //Elimina procesos ligados a la ruta
                    ActualizaRutaEliminaProcesos(cmd, rutaActualizar);
                    //Agrega nuevos procesos
                    guarda_ruta_proceso(cmd, rutaActualizar.procesos, rutaActualizar.id_ruta);
                    tr.Commit();
                    cn.Close();
                    return true;
                }
                catch (Exception)
                {

                   tr.Rollback();
                    cn.Close();
                    return false;
                }
       
            }
            
        }
        private void ActualizaRutaEliminaProcesos(SqlCommand _cmd, ERutasProduccion ruta)
        {
            _cmd.Parameters.Clear();
            _cmd.CommandText = "ruta_produccion_elimina_procesos";
            _cmd.Parameters.AddWithValue("id_ruta", ruta.id_ruta);
            _cmd.ExecuteNonQuery();
        }
        private void ActualizaRutaNombre(SqlCommand _cmd, ERutasProduccion ruta)
        {
            _cmd.Parameters.Clear();
            _cmd.CommandText = "rutas_produccion_actualiza_nombre";
            _cmd.Parameters.AddWithValue("id_ruta", ruta.id_ruta);
            _cmd.Parameters.AddWithValue("nombre", ruta.nombre);

            _cmd.ExecuteNonQuery();
        }
    }
}
