using Entidades.Diseno.Calidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Datos.Diseno
{
    public class DCalidad
    {
        public static int SetInsertarCalidad(ECalidad inserta, EPruebaEncogimiento encogimiento, EPruebaLavadoPilling lavado, EPruebaCostura costura)
        {
            int valoridencogimiento = 0;
            int valoridlavado = 0;
            int valoridlavadocostura = 0;
            int valoridcontaminacion = 0;
            try
            {
                List<EPruebaEncogimiento> lstpruebaencogimiento = new List<EPruebaEncogimiento>();
                using (SqlConnection cn = DConexion.obtenerConexion()) // proceso para insercion tabla diseno_forros_prueba_encogimiento
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_encogimiento_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_FORRO", SqlDbType.Int).Value = encogimiento.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = encogimiento.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = encogimiento.fecha_hora;
                    comando.Parameters.Add("@ID_ENTRETELA", SqlDbType.Int).Value = encogimiento.id_entretela;
                    comando.Parameters.Add("@ADHERENCIA", SqlDbType.Decimal).Value = encogimiento.adherencia;
                    comando.Parameters.Add("@ID_PROVEEDOR", SqlDbType.Int).Value = encogimiento.id_proveedor;
                    comando.Parameters.Add("@TEMPERATURA", SqlDbType.Decimal).Value = encogimiento.temperatura;
                    comando.Parameters.Add("@TIEMPO", SqlDbType.Int).Value = encogimiento.tiempo;
                    comando.Parameters.Add("@PRESION", SqlDbType.Decimal).Value = encogimiento.presion;
                    comando.Parameters.Add("@VAPORHILOFINAL", SqlDbType.Decimal).Value = encogimiento.vapor_hilo_final;
                    comando.Parameters.Add("@VAPORTRAMAFINAL", SqlDbType.Decimal).Value = encogimiento.vapor_trama_final;
                    comando.Parameters.Add("@VAPORHILODIFERENCIA", SqlDbType.Decimal).Value = encogimiento.vapor_hilo_diferencia;
                    comando.Parameters.Add("@VAPORTRAMADIFERENCIA", SqlDbType.Decimal).Value = encogimiento.vapor_trama_diferencia;
                    comando.Parameters.Add("@VAPOROBSERVACIONES", SqlDbType.NVarChar).Value = encogimiento.vapor_observaciones;
                    comando.Parameters.Add("@FUSIONHILOFINAL", SqlDbType.Decimal).Value = encogimiento.fusion_hilo_final;
                    comando.Parameters.Add("@FUSIONTRAMAFINAL", SqlDbType.Decimal).Value = encogimiento.fusion_trama_final;
                    comando.Parameters.Add("@FUSIONHILODIFERENCIA", SqlDbType.Decimal).Value = encogimiento.fusion_hilo_diferencia;
                    comando.Parameters.Add("@FUSIONTRAMADIFERENCIA", SqlDbType.Decimal).Value = encogimiento.fusion_trama_diferencia;
                    comando.Parameters.Add("@FUSIONOBSERVACIONES", SqlDbType.NVarChar).Value = encogimiento.fusion_observaciones;
                    comando.Parameters.Add("@PLANCHAHILOFINAL", SqlDbType.Decimal).Value = encogimiento.plancha_hilo_final;
                    comando.Parameters.Add("@PLANCHATRAMAFINAL", SqlDbType.Decimal).Value = encogimiento.plancha_trama_final;
                    comando.Parameters.Add("@PLANCHAHILODIFERENCIA", SqlDbType.Decimal).Value = encogimiento.plancha_hilo_diferencia;
                    comando.Parameters.Add("@PLANCHATRAMADIFERENCIA", SqlDbType.Decimal).Value = encogimiento.plancha_trama_diferencia;
                    comando.Parameters.Add("@PLANCHAOBSERVACIONES", SqlDbType.Decimal).Value = encogimiento.plancha_obvservaciones;
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstpruebaencogimiento.Add(new EPruebaEncogimiento
                        {
                            id_encogimiento = DBNull.Value.Equals(rd["id_prueba_encogimiento"]) ? 0 : Convert.ToInt32(rd["id_prueba_encogimiento"]),

                        });
                    }

                }

                foreach (EPruebaEncogimiento itm in lstpruebaencogimiento)
                {
                    valoridencogimiento = itm.id_encogimiento;// se obtiene el id insertado para utilizarlo en el encabezado del registro
                }

                List<EPruebaLavadoPilling> lstlavado = new List<EPruebaLavadoPilling>();

                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para insersion tabla prueba de diseno_forros_prueba_lavado 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_lavadopilling_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_PRUEBA_LAVADOPILLING", SqlDbType.Int).Value = lavado.id_lavado;
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = lavado.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = lavado.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = lavado.fecha;
                    comando.Parameters.Add("@LAVADO_HILO_FINAL", SqlDbType.Decimal).Value = lavado.lavado_hilo_final;
                    comando.Parameters.Add("@LAVADO_TRAMA_FINAL", SqlDbType.Decimal).Value = lavado.lavado_trama_final;
                    comando.Parameters.Add("@LAVADO_HILO_DIFERENCIA", SqlDbType.Int).Value = lavado.lavado_hilo_diferencia;
                    comando.Parameters.Add("@LAVADO_TRAMA_DIFERENCIA", SqlDbType.Decimal).Value = lavado.lavado_trama_diferencia;
                    comando.Parameters.Add("@LAVADO_OBSERVACIONES", SqlDbType.Int).Value = lavado.lavado_observaciones;
                    comando.Parameters.Add("@SOLIDEZ_COLOR", SqlDbType.Decimal).Value = lavado.solidez_color;
                    comando.Parameters.Add("@SOLIDEZ_OBSERVACIONES", SqlDbType.Decimal).Value = lavado.solidez_observaciones;
                    comando.Parameters.Add("@PILLING", SqlDbType.Decimal).Value = lavado.pilling;
                    comando.Parameters.Add("@PILLING_OBSERVACIONES", SqlDbType.Decimal).Value = lavado.pilling_observacion;
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstlavado.Add(new EPruebaLavadoPilling
                        {
                            id_lavado = DBNull.Value.Equals(rd["id_lavado"]) ? 0 : Convert.ToInt32(rd["id_lavado"]),

                        });
                    }

                }

                foreach (EPruebaLavadoPilling itm in lstlavado)
                {
                    valoridlavado = itm.id_lavado;// se obtiene el id insertado para utilizarlo en el encabezado del registro
                }

                //proceso para insertar costura


                List<EPruebaCostura> lstcostura = new List<EPruebaCostura>();

                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para insersion tabla prueba de diseno_forros_prueba_lavado 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_costura_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = costura.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = costura.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = costura.fecha;
                    comando.Parameters.Add("@LAVADO_HILO_FINAL", SqlDbType.Decimal).Value = costura.aguja;
                    comando.Parameters.Add("@LAVADO_TRAMA_FINAL", SqlDbType.Decimal).Value = costura.deslizamiento;
                    comando.Parameters.Add("@LAVADO_HILO_DIFERENCIA", SqlDbType.Int).Value = costura.deslizamientoobservaciones;
                    comando.Parameters.Add("@LAVADO_TRAMA_DIFERENCIA", SqlDbType.Decimal).Value = costura.rasgado;
                    comando.Parameters.Add("@LAVADO_OBSERVACIONES", SqlDbType.Int).Value = costura.rasgadoobservaciones;
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstcostura.Add(new EPruebaCostura
                        {
                            id_costura = DBNull.Value.Equals(rd["id_costura"]) ? 0 : Convert.ToInt32(rd["id_costura"]),

                        });
                    }

                }

                foreach (EPruebaCostura itm in lstcostura)
                {
                    valoridlavadocostura = itm.id_costura;// se obtiene el id insertado para utilizarlo en el encabezado del registro
                }



                //proceso para insertar contaminacion combinacion  de telas


                List<EPruebaCostura> lstcombinacion = new List<EPruebaCostura>();

                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para insersion tabla prueba de diseno_forros_prueba_lavado 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_costura_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = costura.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = costura.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = costura.fecha;
                    comando.Parameters.Add("@LAVADO_HILO_FINAL", SqlDbType.Decimal).Value = costura.aguja;
                    comando.Parameters.Add("@LAVADO_TRAMA_FINAL", SqlDbType.Decimal).Value = costura.deslizamiento;
                    comando.Parameters.Add("@LAVADO_HILO_DIFERENCIA", SqlDbType.Int).Value = costura.deslizamientoobservaciones;
                    comando.Parameters.Add("@LAVADO_TRAMA_DIFERENCIA", SqlDbType.Decimal).Value = costura.rasgado;
                    comando.Parameters.Add("@LAVADO_OBSERVACIONES", SqlDbType.Int).Value = costura.rasgadoobservaciones;
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstcombinacion.Add(new EPruebaCostura
                        {
                            id_costura = DBNull.Value.Equals(rd["id_costura"]) ? 0 : Convert.ToInt32(rd["id_costura"]),

                        });
                    }

                }

                foreach (EPruebaCostura itm in lstcombinacion)
                {
                    valoridlavadocostura = itm.id_costura;// se obtiene el id insertado para utilizarlo en el encabezado del registro
                }





                //proceso para insertar nuevo registro a diseno_calidad
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = inserta.nombre;
                    comando.Parameters.Add("@CLAVE", SqlDbType.NVarChar).Value = inserta.clave;
                    comando.Parameters.Add("@DETALLE", SqlDbType.NVarChar).Value = inserta.detalle;
                    comando.Parameters.Add("@ID_PRUEBA_ENCOGIMIENTO", SqlDbType.Int).Value = valoridencogimiento;
                    comando.Parameters.Add("@ID_PRUEBA_LAVADO_PILLING", SqlDbType.Int).Value = valoridlavado;
                    comando.Parameters.Add("@ID_PRUEBA_LAVADO_COSTURA", SqlDbType.Int).Value = valoridlavadocostura;
                    comando.Parameters.Add("@ID_PRUEBA_CONTAMINACION_COMBINACIONTELAS", SqlDbType.Int).Value = inserta.id_prueba_contaminacion_combinaciontelas;
                    cn.Open();
                    comando.ExecuteNonQuery();
                }
                List<ECalidad> lstCalidad = new List<ECalidad>();
                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para obtener el registro (id_calidad) previo insertado
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_consultar_ultimo_registro", cn) { CommandType = CommandType.StoredProcedure };
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstCalidad.Add(new ECalidad
                        {
                            id_calidad = DBNull.Value.Equals(rd["id_calidad"]) ? 0 : Convert.ToInt32(rd["id_calidad"]),

                        });
                    }

                }
                int valor = 0;
                foreach (ECalidad itm in lstCalidad)
                {
                    valor = itm.id_calidad;
                }
                //empieza proceso para insercion de prueba calidad


                return valor;
            }
            catch (Exception e)
            {
                string value = e.InnerException.ToString();
                return 0;
            }
        }
        public static int SetActualizarDisenoCalidad(ECalidad actualiza)
        {
            try
            {
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_CALIDAD", SqlDbType.Int).Value = actualiza.id_calidad;
                    comando.Parameters.Add("@NOMBRE", SqlDbType.Int).Value = actualiza.nombre;
                    comando.Parameters.Add("@CLAVE", SqlDbType.NVarChar).Value = actualiza.clave;
                    comando.Parameters.Add("@ID_PRUEBA_ENCOGIMIENTO", SqlDbType.Int).Value = actualiza.id_prueba_encogimiento;
                    comando.Parameters.Add("@ID_PRUEBA_LAVADO_PILLING", SqlDbType.Int).Value = actualiza.id_prueba_lavado_pilling;
                    comando.Parameters.Add("@ID_PRUEBA_LAVADO_COSTURA", SqlDbType.Int).Value = actualiza.id_prueba_lavado_pilling;
                    comando.Parameters.Add("@ID_PRUEBA_CONTAMINACION_COMBINACIONTELAS", SqlDbType.Int).Value = actualiza.id_prueba_contaminacion_combinaciontelas;
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

        public static List<ECalidad> GetConsultaDisenoCalidad()//PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO MATERIAL
        {
            List<ECalidad> lstCalidad = new List<ECalidad>();
            try
            {
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_consultar", cn) { CommandType = CommandType.StoredProcedure };
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstCalidad.Add(new ECalidad
                        {
                            id_calidad = DBNull.Value.Equals(rd["id_calidad"]) ? 0 : Convert.ToInt32(rd["id_calidad"]),
                            nombre = Convert.ToString(rd["nombre"]),
                            clave = Convert.ToString(rd["clave"]),
                            detalle = Convert.ToString(rd["detalle"]),
                            id_prueba_encogimiento = Convert.ToInt32(rd["id_prueba_encogimiento"]),
                            id_prueba_lavado_pilling = Convert.ToInt32(rd["id_prueba_lavado_pilling"]),
                            id_prueba_costura = Convert.ToInt32(rd["id_prueba_costura"]),
                            id_prueba_contaminacion_combinaciontelas = Convert.ToInt32(rd["id_prueba_contaminacion_combinaciontelas"]),
                            estatus = Convert.ToInt32(rd["estatus"]),
                            auxestatus = rd["auxestatus"].ToString(),
                            auxpruebaencogimiento = Convert.ToString(rd["auxpruebaencogimiento"]),
                            auxpruebalavadopilling = Convert.ToString(rd["auxpruebalavadopilling"]),
                            auxpruebacostura = Convert.ToString(rd["auxpruebacostura"]),
                            auxpruebacontaminacion = rd["auxpruebacontaminacion"].ToString(),

                        });
                    }

                }
                return lstCalidad;
            }
            catch (Exception e)
            {
                string error = e.InnerException.ToString();
                return new List<ECalidad>();
            }
        }

        public static void SetHabilitarDeshabilitarCalidad(int id_calidad, int estatus) //PROCESO PARA HABILITAR/DESHABILITAR REGISTROS PARA LA TABLA DISENO CALIDAD
        {
            var obj = new ECalidad();

            try
            {
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("diseno_calidad_habilitar_deshabilitar", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("ID_CALIDAD", id_calidad);
                    cmd.Parameters.AddWithValue("ESTATUS", estatus);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }

        }
        public static List<EOperariocombo> GetLlenarComboOperario() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO fFAMILIA COMPOSICION TIPO, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {
            try
            {
                List<EOperariocombo> lstoperario = new List<EOperariocombo>();

                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_operario_consultar", cn) { CommandType = CommandType.StoredProcedure };
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstoperario.Add(new EOperariocombo
                        {
                            id_operario = DBNull.Value.Equals(rd["id_operario"]) ? 0 : Convert.ToInt32(rd["id_operario"]),
                            descripcion = Convert.ToString(rd["descripcion"]),
                            estatus = Convert.ToInt32(rd["estatus"]),
                        });
                    }

                }

                return lstoperario;
            }
            catch (Exception e)
            {
                string s = e.InnerException.ToString();
                return new List<EOperariocombo>();
            }
        }
        public static List<EEntretelacombo> GetLlenarComboEntretela() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO fFAMILIA COMPOSICION TIPO, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {
            try
            {
                List<EEntretelacombo> lstentretela = new List<EEntretelacombo>();

                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_entretela_consultar", cn) { CommandType = CommandType.StoredProcedure };
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstentretela.Add(new EEntretelacombo
                        {
                            id_entretela = DBNull.Value.Equals(rd["id_entretela"]) ? 0 : Convert.ToInt32(rd["id_entretela"]),
                            descripcion = Convert.ToString(rd["descripcion"]),
                            estatus = Convert.ToInt32(rd["estatus"]),
                        });
                    }

                }

                return lstentretela;
            }
            catch (Exception e)
            {
                string s = e.InnerException.ToString();
                return new List<EEntretelacombo>();
            }
        }

        public static List<EResultadoPillingcombo> GetLlenarComboPillingResultado() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO fFAMILIA COMPOSICION TIPO, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {
            try
            {
                List<EResultadoPillingcombo> lstpilling = new List<EResultadoPillingcombo>();

                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_resultado_pilling_consultar", cn) { CommandType = CommandType.StoredProcedure };
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstpilling.Add(new EResultadoPillingcombo
                        {
                            id_resultado_pilling = DBNull.Value.Equals(rd["id_resultado_pilling"]) ? 0 : Convert.ToInt32(rd["id_resultado_pilling"]),
                            descripcion = Convert.ToString(rd["descripcion"]),
                            estatus = Convert.ToInt32(rd["estatus"]),
                        });
                    }

                }

                return lstpilling;
            }
            catch (Exception e)
            {
                string s = e.InnerException.ToString();
                return new List<EResultadoPillingcombo>();
            }
        }

    }
}