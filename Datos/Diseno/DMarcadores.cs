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
    public class DMarcadores
    {
        SqlConnection _cnn = DConexion.obtenerConexion();
        public static int SetInsertarMarcadores(EMarcadores inserta) //PROCESO PARA INSERCION DE REGISTROS PARA LA TABLA DISENO_MARCADORES
        {
            try
            {
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_marcadores_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = inserta.nombre;
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
        public  static int SetActualizaMarcadores(EMarcadores actualiza) //PROCESO PARA ACTUALIZACION DE REGISTROS PARA LA TABLA DISENO_MARCADORES
        {
            try
            {

                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_marcadores_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_MARCADOR", SqlDbType.Int).Value = actualiza.id_marcador;
                    comando.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = actualiza.nombre;
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
        public static void SetHabilitarDeshabilitarMarcadores(int id_marcador, int estatus) //PROCESO PARA HABILITAR/DESHABILITAR REGISTROS PARA LA TABLA DISENO_MARCADORES
        {
            var obj = new EFamiliaPrendas();

            try
            {

                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("diseno_marcadores_habilitar_deshabilitar", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("ID_MARCADOR", id_marcador);
                    cmd.Parameters.AddWithValue("ESTATUS", estatus);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }
   
        public static List<EMarcadores> GetConsultaDisenoMarcadores() //PROCESO DE CONSULTA DE LA TABLA DISENO MARCADORES
        {
            List<EMarcadores> lstMarcadores = new List<EMarcadores>();

            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand comando = new SqlCommand("diseno_marcadores_consultar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstMarcadores.Add(new EMarcadores
                    {
                        id_marcador = DBNull.Value.Equals(rd["id_marcador"]) ? 0 : Convert.ToInt32(rd["id_marcador"]),
                        nombre = rd["nombre"].ToString(),
                        //codigo = rd["codigo"].ToString(),
                        auxestatus = rd["auxestatus"].ToString(),

                    });
                }
            }
            return lstMarcadores;
        }

    }
}
