using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;
using Entidades.Diseno;
using Entidades.Compras;
using Datos.Compras;
using Datos.Diseno; 


namespace Datos.Diseno
{
    public static class DForros
    {
        public static List<EForros> ListarForros()
        {
            List<EForros> lstForros = new List<EForros>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstForros.Add(new EForros
                    {
                        id_forro = Convert.ToInt32(rd["id_forro"]), 
                        nombre = rd["nombre"].ToString(), 
                        descripcion = rd["descripcion"].ToString(), 
                        ancho = DBNull.Value.Equals(rd["ancho"]) ? 0: Convert.ToDouble(rd["ancho"]), 
                        id_color = Convert.ToInt32(rd["id_color"]),
                        color = rd["color"].ToString(), 
                        id_proveedor =Convert.ToInt32(rd["id_proveedor"]), 
                        proveedor = rd["proveedor"].ToString(), 
                        clave_proveedor = rd["clave_proveedor"].ToString(), 
                        imagen = rd["imagen"].ToString(), 
                        clave_forro = rd["clave_forro"].ToString(), 
                        clave_prospecto = rd["clave_prospecto"].ToString(),
                        prospecto = Convert.ToInt32(rd["prospecto"]),
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }
                return lstForros;
            }
        }

        public static List<EForrosComposiciones> ListarComposiciones(int idForro)
        {
            List<EForrosComposiciones> lstFC = new List<EForrosComposiciones>(); 

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_listar_composiciones", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                cmd.Parameters.AddWithValue("id_forro", idForro);
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstFC.Add(new EForrosComposiciones
                    {
                        id_forro_composicion = Convert.ToInt32(rd["id_forro_composicion"]), 
                        id_forro = Convert.ToInt32(rd["id_forro"]), 
                        id_composicion = Convert.ToInt32(rd["id_composicion"]), 
                        forro = rd["forro"].ToString(), 
                        composicion = rd["composicion"].ToString(),
                        porcentaje = Convert.ToDecimal(rd["porcentaje"])
                    });
                }
                return lstFC;
            }
        }

        public static EForros RegistrarForro(EForros forro)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();

                //Guardamos el forro
                SqlCommand cmd = new SqlCommand("diseno_forros_agregar", cn, tran) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_forro", 0);
                cmd.Parameters.AddWithValue("nombre", forro.nombre);
                cmd.Parameters.AddWithValue("descripcion", forro.descripcion);
                cmd.Parameters.AddWithValue("ancho", forro.ancho);
                cmd.Parameters.AddWithValue("id_color", forro.id_color);
                cmd.Parameters.AddWithValue("id_proveedor", forro.id_proveedor);
                cmd.Parameters.AddWithValue("clave_proveedor", forro.clave_proveedor);
                cmd.Parameters.AddWithValue("imagen", forro.imagen);
                cmd.Parameters.AddWithValue("clave_forro", forro.clave_forro);
                //cmd.Parameters.AddWithValue("clave_prospecto", forro.clave_prospecto);
                cmd.Parameters.AddWithValue("prospecto", forro.prospecto);

                cmd.Parameters["id_forro"].Direction = ParameterDirection.Output;
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                //cmd.ExecuteNonQuery();

                var _eForro = new EForros();
                while (rd.Read())
                {
                    _eForro.id_forro = Convert.ToInt32(rd["id_forro"]);
                    _eForro.imagen = rd["imagen"].ToString();
                }
                rd.Close();

                int totalComposiciones = 0; 
                //Registramos las composiciones
                foreach (EForrosComposiciones fc in forro.composiciones)
                {
                    fc.id_forro = _eForro.id_forro;
                    totalComposiciones += RegistraComposicion(fc, tran, cn);
                }

                if (totalComposiciones == forro.composiciones.Count)
                {
                    tran.Commit();
                    return _eForro;

                }
                else
                {
                    tran.Rollback();
                    return _eForro; 
                }
            }
        }

        public static int ActualizaEstatus(EForros f)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_habilitar_deshabilitar", cn)
                    {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("id_forro", f.id_forro);
                cmd.Parameters.AddWithValue("estatus", f.estatus);

                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static EForros ActualizaForro(EForros f)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("diseno_forros_actualizar",cn, tran) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("id_forro", f.id_forro);
                cmd.Parameters.AddWithValue("nombre", f.nombre);
                cmd.Parameters.AddWithValue("descripcion", f.descripcion);
                cmd.Parameters.AddWithValue("ancho", f.ancho);
                cmd.Parameters.AddWithValue("id_color", f.id_color);
                cmd.Parameters.AddWithValue("id_proveedor", f.id_proveedor);
                cmd.Parameters.AddWithValue("clave_proveedor", f.clave_proveedor);
                cmd.Parameters.AddWithValue("imagen", f.imagen);
                cmd.Parameters.AddWithValue("clave_forro", f.clave_forro);
                //cmd.Parameters.AddWithValue("clave_prospecto", f.clave_prospecto);
                //cmd.Parameters.AddWithValue("prospecto", f.prospecto);

                //cmd.ExecuteNonQuery();
                var _eForro = new EForros();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    _eForro.id_forro = Convert.ToInt32(rd["id_forro"]);
                    _eForro.imagen = rd["imagen"].ToString();
                }
                rd.Close();
                rd.Dispose();

                int totalComposiciones = 0;

                //Eliminamos las composiciones existentes
                if (EliminarComposiciones(f.id_forro,tran, cn))
                {
                    //Registramos las nuevas composiciones
                    foreach (EForrosComposiciones fc in f.composiciones)
                    {
                        fc.id_forro = f.id_forro;
                        totalComposiciones += RegistraComposicion(fc, tran, cn);
                    }

                    //Si se registraron las nuevas composiciones, confirmamos los cambios
                    if (totalComposiciones == f.composiciones.Count)
                    {
                        tran.Commit();
                        return _eForro;
                    }
                    else //Hubo un error al registrar las nuevas composiciones, cancelamos los cambios
                    {
                        tran.Rollback();
                        return _eForro;
                    }
                }
                else //Hubo un error al eliminar las composiciones, cancelamos los cambios
                {
                    tran.Rollback();
                    return _eForro; 
                }
                
            }
        }
        public static bool EliminarComposiciones(int idForro, SqlTransaction tran, SqlConnection cn)
        {
           
            SqlCommand cmd = new SqlCommand("diseno_forros_eliminar_composiciones", cn, tran) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("id_forro", idForro);
            return cmd.ExecuteNonQuery()>0 ? true :false;
        }

        private static int RegistraComposicion(EForrosComposiciones fc, SqlTransaction tran, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("diseno_forros_agregar_composicion", cn, tran) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("id_forro", fc.id_forro);
            cmd.Parameters.AddWithValue("id_composicion", fc.id_composicion);
            cmd.Parameters.AddWithValue("porcentaje", fc.porcentaje);
            return cmd.ExecuteNonQuery(); 
        }

        public static DataTable ImportaOperarios()
        {
            DataTable dtOperarios = new DataTable();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_calidad_operarios", cn) { CommandType=CommandType.StoredProcedure };
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtOperarios);
                return dtOperarios;
            }
        }

        public static DataTable ImportaEntretelas()
        {
            DataTable dtEntretelas = new DataTable();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_forros_calidad_entretelas", cn) { CommandType = CommandType.StoredProcedure };
                SqlDataAdapter da = new SqlDataAdapter(cmd); 
                da.Fill(dtEntretelas);
                return dtEntretelas;
            }
        }
      
    }
}
