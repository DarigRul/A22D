using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Data.SqlClient;
using Entidades;
using Datos;
using System.Collections.ObjectModel;
using System.IO;
using Entidades.Diseno;
using client = Datos.Utilitarios.Historico.DHistorico;
namespace Datos.Diseno
{
    public class DFamiliaPrendas
    {
        SqlConnection _cnn = DConexion.obtenerConexion();
        public static int SetInsertarFamiliaPrenda(EFamiliaPrendas inserta) //PROCESO PARA INSERCION DE REGISTROS PARA LA TABLA DISENO_FAMILIA_PRENDAS
        {
            try
            {
               
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_familia_prendas_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = inserta.nombre;
                    comando.Parameters.Add("@CODIGO", SqlDbType.NVarChar).Value = inserta.codigo;
                    comando.Parameters.Add("@UBICACION", SqlDbType.NVarChar).Value = inserta.ubicacion;
                    cn.Open();
                    comando.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public static int SetActualizaFamiliaPrenda(EFamiliaPrendas actualiza) //PROCESO PARA ACTUALIZACION DE REGISTROS PARA LA TABLA DISENO_FAMILIA_PRENDAS
        {
            try
            {

                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_familia_prendas_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_FAMILIA_PRENDA", SqlDbType.NVarChar).Value = actualiza.id_familia_prenda;
                    comando.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = actualiza.nombre;
                    comando.Parameters.Add("@CODIGO", SqlDbType.NVarChar).Value = actualiza.codigo;
                    comando.Parameters.Add("@UBICACION", SqlDbType.NVarChar).Value = actualiza.ubicacion;
                    cn.Open();
                    comando.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public static void SetHabilitarDeshabilitarFamiliaPrendas(int id_familia_prenda, int estatus ) //PROCESO PARA HABILITAR/DESHABILITAR REGISTROS PARA LA TABLA DISENO_FAMILIA_PRENDAS
        {
                var obj = new EFamiliaPrendas();

                try
                {
             
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("diseno_familia_prendas_habilitar_deshabilitar", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("ID_FAMILIA_PRENDA", id_familia_prenda);
                    cmd.Parameters.AddWithValue("ESTATUS", estatus);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }

        }
      

        public static List<EFamiliaPrendas> GetConsultaDisenoFamiliaPrendas() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO FAMILIA PRENDAS
        {
            List<EFamiliaPrendas> lstPrendas = new List<EFamiliaPrendas>();

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand comando = new SqlCommand("diseno_familia_prendas_consultar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstPrendas.Add(new EFamiliaPrendas
                    {
                        id_familia_prenda = DBNull.Value.Equals(rd["id_familia_prenda"]) ? 0 : Convert.ToInt32(rd["id_familia_prenda"]),
                        nombre = rd["nombre"].ToString(),
                        codigo = rd["codigo"].ToString(),
                        ubicacion = rd["ubicacion"].ToString(),
                        auxestatus = rd["auxestatus"].ToString(),


                    });
                }

            }

            return lstPrendas;
        }
      

    }

}