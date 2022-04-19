using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;
using Entidades.Comercial.Precios;

namespace Datos.Comercial
{
    public class DPreciosfamiliacomposicion
    {
        public static int PreciosFamiliaComposicionGuardar(EPrecios p)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("comercial_precios_familia_composicion_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_familia_prenda", p.id_familia_prenda);
                cmd.Parameters.AddWithValue("id_familia_composicion", p.id_familia_composicion);
                cmd.Parameters.AddWithValue("local_actual", p.local_actual);
                cmd.Parameters.AddWithValue("local_anterior", p.local_anterior);
                cmd.Parameters.AddWithValue("foraneo_actual", p.foraneo_actual);
                cmd.Parameters.AddWithValue("foraneo_anterior", p.foraneo_anterior);
                cmd.Parameters.AddWithValue("linea_expres_local_actual", p.linea_expres_local_actual);
                cmd.Parameters.AddWithValue("linea_expres_local_anterior", p.linea_expres_local_anterior);
                cmd.Parameters.AddWithValue("linea_expres_foraneo_actual", p.linea_expres_foraneo_actual);
                cmd.Parameters.AddWithValue("linea_expres_foraneo_anterior", p.linea_expres_foraneo_anterior);
                cmd.Parameters.AddWithValue("ecommerce_actual", p.ecommerce_actual);
                cmd.Parameters.AddWithValue("ecommerce_anterior", p.ecommerce_anterior);
                cmd.Parameters.AddWithValue("muestrario", p.muestrario);
                cmd.Parameters.AddWithValue("venta_interna", p.venta_interna);
     
                cmd.Parameters.AddWithValue("extra1", p.extra1);
                cmd.Parameters.AddWithValue("extra2", p.extra2);
                cmd.Parameters.AddWithValue("extra3", p.extra3);

                cn.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }
        public static int PreciosFamiliaComposicionActualizaEstatus(EPrecios p, int estatus)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("comercial_precios_familia_composicion_estatus_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_precio", p.id_precio);
                cmd.Parameters.AddWithValue("estatus", estatus);

                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static int PreciosFamiliaComposicionModifica(EPrecios p)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("comercial_precios_familia_composicion_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_precio", p.id_precio);
                
                cmd.Parameters.AddWithValue("local_actual", p.local_actual);
                cmd.Parameters.AddWithValue("local_anterior", p.local_anterior);
                cmd.Parameters.AddWithValue("foraneo_actual", p.foraneo_actual);
                cmd.Parameters.AddWithValue("foraneo_anterior", p.foraneo_anterior);
                cmd.Parameters.AddWithValue("linea_expres_local_actual", p.linea_expres_local_actual);
                cmd.Parameters.AddWithValue("linea_expres_local_anterior", p.linea_expres_local_anterior);
                cmd.Parameters.AddWithValue("linea_expres_foraneo_actual", p.linea_expres_foraneo_actual);
                cmd.Parameters.AddWithValue("linea_expres_foraneo_anterior", p.linea_expres_foraneo_anterior);
                cmd.Parameters.AddWithValue("ecommerce_actual", p.ecommerce_actual);
                cmd.Parameters.AddWithValue("ecommerce_anterior", p.ecommerce_anterior);
                cmd.Parameters.AddWithValue("muestrario", p.muestrario);
                cmd.Parameters.AddWithValue("venta_interna", p.venta_interna);
                
                cmd.Parameters.AddWithValue("extra1", p.extra1);
                cmd.Parameters.AddWithValue("extra2", p.extra2);
                cmd.Parameters.AddWithValue("extra3", p.extra3);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static List<EPrecios> ConsultaPrecios()
        {
            List<EPrecios> precios = new List<EPrecios>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("comercial_precios_familia_composicion_consultar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    precios.Add(new EPrecios
                    {
                        id_precio = DBNull.Value.Equals(rd["id_precio"]) ? 0 : Convert.ToInt32(rd["id_precio"]),
                        id_familia_composicion = (int)rd["id_familia_composicion"],
                        id_familia_prenda = (int)rd["id_familia_prenda"],
                        familia_composicion = rd["familia_composicion"].ToString(),
                        familia_prenda = rd["familia_prenda"].ToString(),
                        local_actual = Convert.ToDouble( rd["local_actual"]),
                        local_anterior = Convert.ToDouble(rd["local_anterior"]),
                        foraneo_actual = Convert.ToDouble(rd["foraneo_actual"]),
                        foraneo_anterior = Convert.ToDouble(rd["foraneo_anterior"]),
                        linea_expres_local_actual = Convert.ToDouble(rd["linea_expres_local_actual"]),
                        linea_expres_foraneo_anterior = Convert.ToDouble(rd["linea_expres_foraneo_anterior"]),
                        linea_expres_local_anterior = Convert.ToDouble(rd["linea_expres_local_anterior"]),
                        linea_expres_foraneo_actual = Convert.ToDouble(rd["linea_expres_foraneo_actual"]),
                        muestrario = Convert.ToDouble(rd["muestrario"]),
                        ecommerce_actual = Convert.ToDouble( rd["ecommerce_actual"]),
                        ecommerce_anterior = Convert.ToDouble(rd["ecommerce_anterior"]),
                        venta_interna = Convert.ToDouble(rd["venta_interna"]),
                        extra1 = Convert.ToDouble(rd["extra1"]),
                        extra2 = Convert.ToDouble(rd["extra2"]),
                        extra3  = Convert.ToDouble(rd["extra3"]),
                        estatus = Convert.ToInt32( rd["estatus"])


                    });
                }
            }
            return precios;
        }
    }


}
