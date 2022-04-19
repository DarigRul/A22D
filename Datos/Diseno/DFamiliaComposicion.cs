using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Diseno;
using System.Data.SqlClient;

namespace Datos.Diseno
{
    public class DFamiliaComposicion
    {
        //consulta Familias
        public static List<EFamiliaComposicion> ListarFamilias()
        {
            List<EFamiliaComposicion> Familia = new List<EFamiliaComposicion>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_familia_composicion_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    Familia.Add(new EFamiliaComposicion
                    {
                        id_familia_composicion = DBNull.Value.Equals(rd["id_familia_composicion"]) ? 0 : Convert.ToInt32(rd["id_familia_composicion"]),
                        nombre = rd["nombre"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }

            }
            return Familia;
        }
        //Consulta Composiciones
        public static List<EComposicion> consultaComposicionesPorFamilia(int id_familia_composicion)
        {
            List<EComposicion> lstc = new List<EComposicion>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_familia_composicion_composicionesporfamilia", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                cmd.Parameters.AddWithValue("id_familia_composicion", id_familia_composicion);
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstc.Add(new EComposicion
                    {
                        id_composicion = DBNull.Value.Equals(rd["id_composicion"]) ? 0 : Convert.ToInt32(rd["id_composicion"]),
                        nombre = rd["nombre"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }

            }
            return lstc;
        }

        //Consulta Instrucciones de cuidado
        public static List<EInstruccionesCuidado> consultaInstruccionesCuidadoPorFamilia(int id_familia_composicion)
        {
            List<EInstruccionesCuidado> lstc = new List<EInstruccionesCuidado>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_familia_composicion_instruccionescuidadoporfamilia", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                cmd.Parameters.AddWithValue("id_familia_composicion", id_familia_composicion);
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstc.Add(new EInstruccionesCuidado
                    {
                        id_instruccion_cuidado = DBNull.Value.Equals(rd["id_instruccion_cuidado"]) ? 0 : Convert.ToInt32(rd["id_instruccion_cuidado"]),
                        nombre = rd["nombre"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }

            }
            return lstc;
        }

        public int GuardaFamiliaComposicion(EFamiliaComposicion eFamilia)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                    cn.Open();
                    SqlTransaction tran = cn.BeginTransaction();
                //Guardamos la familia
                try
                {
                    SqlCommand cmd = new SqlCommand("diseno_familia_composicion_agregar", cn, tran) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("id", 0);
                    cmd.Parameters.AddWithValue("nombre", eFamilia.nombre);
                    cmd.Parameters["id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int id_familia_composicion = (int)cmd.Parameters["id"].Value;
                    GuardaFamiliaComposiciones(cmd, eFamilia.eComposiciones, id_familia_composicion);
                    GuardaFamiliaInstruccionesCuidado(cmd, eFamilia.eInstruccionesCuidados, id_familia_composicion);
                    tran.Commit();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                    tran.Rollback();
                    cn.Close();
                    return 1;
                }
            }
            return 0;
        }
        private void GuardaFamiliaComposiciones(SqlCommand _cmd, List<EComposicion> composiciones, int id_familia_composicion)
        {
            foreach (EComposicion composicion in composiciones)
            {
                _cmd.Parameters.Clear();
                _cmd.CommandText = "diseno_familia_composicion_composiciones_guardar";
                _cmd.Parameters.AddWithValue("id_familia_composicion", id_familia_composicion);
                _cmd.Parameters.AddWithValue("id_composicion", composicion.id_composicion);
                _cmd.ExecuteNonQuery();
            }
        }
        private void GuardaFamiliaInstruccionesCuidado(SqlCommand _cmd, List<EInstruccionesCuidado> ic, int id_familia_composicion)
        {
            foreach (EInstruccionesCuidado _ic in ic)
            {
                _cmd.Parameters.Clear();
                _cmd.CommandText = "diseno_familia_composicion_instruccionescuidado_guardar";
                _cmd.Parameters.AddWithValue("id_familia_composicion", id_familia_composicion);
                _cmd.Parameters.AddWithValue("id_intruccion_cuidado", _ic.id_instruccion_cuidado);
                _cmd.ExecuteNonQuery();
            }
        }
        public int ActualizaFamiliaComposicion(EFamiliaComposicion eFamilia)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();

                //Guardamos la familia
                try
                {
                    SqlCommand cmd = new SqlCommand("diseno_familia_composicion_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("id_familia_composicion", eFamilia.id_familia_composicion);
                    cmd.Parameters.AddWithValue("nombre", eFamilia.nombre);

                    cmd.ExecuteNonQuery();

                    GuardaFamiliaComposiciones(cmd, eFamilia.eComposiciones, eFamilia.id_familia_composicion);
                    GuardaFamiliaInstruccionesCuidado(cmd, eFamilia.eInstruccionesCuidados, eFamilia.id_familia_composicion);

                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);

                    cn.Close();
                    return 1;
                }
            }
            return 0;
        }
        public static int DesactivaFamiliaCoposicion(EFamiliaComposicion eFamilia)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("diseno_familia_composicion_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("id_familia_Composicion", eFamilia.id_familia_composicion   );
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                    cn.Close();
                    return 1;
                }
            }
            return 0;
        }
        public static int ActivarFamiliaCoposicion(EFamiliaComposicion eFamilia)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("diseno_familia_composicion_activar", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("id_familia_Composicion", eFamilia.id_familia_composicion);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                    cn.Close();
                    return 1;
                }
            }
            return 0;
        }

    }
}
