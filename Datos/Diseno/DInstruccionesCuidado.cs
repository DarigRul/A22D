using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Diseno; 

namespace Datos.Diseno
{
    public static class DInstruccionesCuidado
    {
        public static List<EInstruccionesCuidado> ListarInstrucciones()
        {
            List<EInstruccionesCuidado> lstInstrucciones = new List<EInstruccionesCuidado>(); 
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_instrucciones_cuidado_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstInstrucciones.Add(new EInstruccionesCuidado
                    {
                        id_instruccion_cuidado = Convert.ToInt32(rd["id_instruccion_cuidado"]), 
                        nombre = rd["nombre"].ToString(), 
                        simbolo = rd["simbolo"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])

                    }); 
                }
            }
            return lstInstrucciones; 
        }

        public static EInstruccionesCuidado AgregaInstruccion(EInstruccionesCuidado instruccion)
        {
            try
            {
                EInstruccionesCuidado eInstruccionesCuidado = new EInstruccionesCuidado();
                string mensaje = "";
                using (SqlConnection cnn = DConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("diseno_instrucciones_cuidado_agregar", cnn);

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = instruccion.nombre;
                    cmd.Parameters.Add("@simbolo", SqlDbType.VarChar).Value = instruccion.simbolo;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            eInstruccionesCuidado.id_instruccion_cuidado = Convert.ToInt32(reader["id_instruccion_cuidado"]);
                        if (!reader.IsDBNull(1))
                            eInstruccionesCuidado.simbolo = Convert.ToString(reader["simbolo"]);
                        if (!reader.IsDBNull(2))
                            mensaje = Convert.ToString(reader["mensaje"]);
                    }
                }

                //Si se agregó correctamente el registro regresará el nombre del archivo
                if (mensaje != "")
                {
                    throw new Exception(mensaje);
                }

                return eInstruccionesCuidado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EInstruccionesCuidado ModificaInstruccion(EInstruccionesCuidado instruccion)
        {
            try
            {
                EInstruccionesCuidado eInstruccionesCuidado = new EInstruccionesCuidado();
                string mensaje = "";
                using (SqlConnection cnn = DConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("diseno_instrucciones_cuidado_modificar", cnn);

                    cmd.Parameters.Add("@id_instruccion_cuidado", SqlDbType.Int).Value = instruccion.id_instruccion_cuidado;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = instruccion.nombre;
                    cmd.Parameters.Add("@simbolo", SqlDbType.VarChar).Value = instruccion.simbolo;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            eInstruccionesCuidado.id_instruccion_cuidado = Convert.ToInt32(reader["id_instruccion_cuidado"]);
                        if (!reader.IsDBNull(1))
                            eInstruccionesCuidado.simbolo = Convert.ToString(reader["simbolo"]);
                        if (!reader.IsDBNull(2))
                            mensaje = Convert.ToString(reader["mensaje"]);
                    }
                }

                //Si se agregó correctamente el registro regresará el nombre del archivo
                if (mensaje != "")
                {
                    throw new Exception(mensaje);
                }

                return eInstruccionesCuidado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ActivarInstruccion(int id_instruccion_cuidado)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_instrucciones_cuidado_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_instruccion_cuidado", id_instruccion_cuidado);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DesactivarInstruccion(int id_instruccion_cuidado)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_instrucciones_cuidado_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_instruccion_cuidado", id_instruccion_cuidado);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
