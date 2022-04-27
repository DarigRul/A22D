using Entidades.Diseno;
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
        public static int SetInsertarCalidad(ETelas inserta, EPruebaEncogimiento encogimiento, EPruebaLavadoPilling lavado, EPruebaCostura costura, EPruebaContaminacion contaminacion)
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
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = inserta.id_tela;
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
                    comando.Parameters.Add("@PLANCHAOBSERVACIONES", SqlDbType.NVarChar).Value = encogimiento.plancha_obvservaciones;
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

                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para insersion tabla prueba de diseno_telas_prueba_lavado 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_lavadopilling_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = inserta.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = lavado.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = lavado.fecha;
                    comando.Parameters.Add("@LAVADO_HILO_FINAL", SqlDbType.Decimal).Value = lavado.lavado_hilo_final;
                    comando.Parameters.Add("@LAVADO_TRAMA_FINAL", SqlDbType.Decimal).Value = lavado.lavado_trama_final;
                    comando.Parameters.Add("@LAVADO_HILO_DIFERENCIA", SqlDbType.Decimal).Value = lavado.lavado_hilo_diferencia;
                    comando.Parameters.Add("@LAVADO_TRAMA_DIFERENCIA", SqlDbType.Decimal).Value = lavado.lavado_trama_diferencia;
                    comando.Parameters.Add("@LAVADO_OBSERVACIONES", SqlDbType.NVarChar).Value = lavado.lavado_observaciones;
                    comando.Parameters.Add("@SOLIDEZ_CALIDAD", SqlDbType.NVarChar).Value = lavado.solidez_calidad;
                    comando.Parameters.Add("@SOLIDEZ_OBSERVACIONES", SqlDbType.NVarChar).Value = lavado.solidez_observaciones;
                    comando.Parameters.Add("@PILLING", SqlDbType.NVarChar).Value = lavado.pilling;
                    comando.Parameters.Add("@PILLING_OBSERVACIONES", SqlDbType.NVarChar).Value = lavado.pilling_observacion;
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

                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para insersion tabla prueba de diseno_telas_prueba_costura 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_costura_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = inserta.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = costura.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = costura.fecha;
                    comando.Parameters.Add("@COSTURA_AGUJA", SqlDbType.NVarChar).Value = costura.aguja;
                    comando.Parameters.Add("@COSTURA_DESLIZAMIENTO", SqlDbType.NVarChar).Value = costura.deslizamiento;
                    comando.Parameters.Add("@COSTURA_DESLIZAMIENTO_OBSERVACIONES", SqlDbType.NVarChar).Value = costura.deslizamientoobservaciones;
                    comando.Parameters.Add("@COSTURA_RASGADO", SqlDbType.NVarChar).Value = costura.rasgado;
                    comando.Parameters.Add("@COSTURA_RASGADO_OBSERVACIONES", SqlDbType.NVarChar).Value = costura.rasgadoobservaciones;
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


                List<EPruebaContaminacion> lstcontaminacion = new List<EPruebaContaminacion>();

                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para insersion tabla prueba de diseno_telas_prueba_contaminacion 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_contaminacion_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = inserta.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = contaminacion.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = contaminacion.fecha;
                    comando.Parameters.Add("@CONTAMINACION", SqlDbType.NVarChar).Value = contaminacion.contaminacion;
                    comando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar).Value = contaminacion.observaciones;
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstcontaminacion.Add(new EPruebaContaminacion
                        {
                            id_contaminacion = DBNull.Value.Equals(rd["id_contaminacion"]) ? 0 : Convert.ToInt32(rd["id_contaminacion"]),

                        });
                    }

                }

                foreach (EPruebaContaminacion itm in lstcontaminacion)
                {
                    valoridcontaminacion = itm.id_contaminacion;// se obtiene el id insertado para utilizarlo en el encabezado del registro
                }





                //proceso para insertar nuevo registro a diseno_calidad
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_telas_pruebas_calidad_registrar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = inserta.id_tela;
                    comando.Parameters.Add("@ID_PRUEBA_ENCOGIMIENTO", SqlDbType.Int).Value = valoridencogimiento;
                    comando.Parameters.Add("@ID_PRUEBA_LAVADO_PILLING", SqlDbType.Int).Value = valoridlavado;
                    comando.Parameters.Add("@ID_PRUEBA_LAVADO_COSTURA", SqlDbType.Int).Value = valoridlavadocostura;
                    comando.Parameters.Add("@ID_PRUEBA_CONTAMINACION_COMBINACIONTELAS", SqlDbType.Int).Value = valoridcontaminacion;
                    cn.Open();
                    comando.ExecuteNonQuery();
                }
                //List<ECalidad> lstCalidad = new List<ECalidad>();
                //using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para obtener el registro (id_calidad) previo insertado
                //{
                //    SqlCommand comando = new SqlCommand("diseno_calidad_consultar_ultimo_registro", cn) { CommandType = CommandType.StoredProcedure };
                //    cn.Open();
                //    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                //    while (rd.Read())
                //    {
                //        lstCalidad.Add(new ECalidad
                //        {
                //            id_calidad = DBNull.Value.Equals(rd["id_calidad"]) ? 0 : Convert.ToInt32(rd["id_calidad"]),

                //        });
                //    }

                //}
                //int valor = 0;
                //foreach (ECalidad itm in lstCalidad)
                //{
                //    valor = itm.id_calidad;
                //}
                //empieza proceso para insercion de prueba calidad


                return 1;
            }
            catch (Exception e)
            {
                string value = e.InnerException.ToString();
                return 0;
            }
        }
        public static int SetActualizarDisenoCalidad(ERegistroTelasCalidad actualiza, EPruebaEncogimiento encogimiento, EPruebaLavadoPilling lavado, EPruebaCostura costura, EPruebaContaminacion contaminacion)
        {
            try
            {
                using (SqlConnection cn = DConexion.obtenerConexion()) // proceso para actualizacion tabla diseno_forros_prueba_encogimiento
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_encogimiento_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_ENCOGIMIENTO", SqlDbType.Int).Value = actualiza.id_prueba_encogimiento;
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = actualiza.id_tela;
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
                    comando.Parameters.Add("@PLANCHAOBSERVACIONES", SqlDbType.NVarChar).Value = encogimiento.plancha_obvservaciones;
                    cn.Open();
                    comando.ExecuteNonQuery();

                }


                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para actualizacion tabla prueba de diseno_telas_prueba_lavado 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_lavadopilling_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_LAVADO", SqlDbType.Int).Value = actualiza.id_prueba_lavado_pilling;
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = actualiza.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = lavado.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = lavado.fecha;
                    comando.Parameters.Add("@LAVADO_HILO_FINAL", SqlDbType.Decimal).Value = lavado.lavado_hilo_final;
                    comando.Parameters.Add("@LAVADO_TRAMA_FINAL", SqlDbType.Decimal).Value = lavado.lavado_trama_final;
                    comando.Parameters.Add("@LAVADO_HILO_DIFERENCIA", SqlDbType.Decimal).Value = lavado.lavado_hilo_diferencia;
                    comando.Parameters.Add("@LAVADO_TRAMA_DIFERENCIA", SqlDbType.Decimal).Value = lavado.lavado_trama_diferencia;
                    comando.Parameters.Add("@LAVADO_OBSERVACIONES", SqlDbType.NVarChar).Value = lavado.lavado_observaciones;
                    comando.Parameters.Add("@SOLIDEZ_CALIDAD", SqlDbType.NVarChar).Value = lavado.solidez_calidad;
                    comando.Parameters.Add("@SOLIDEZ_OBSERVACIONES", SqlDbType.NVarChar).Value = lavado.solidez_observaciones;
                    comando.Parameters.Add("@PILLING", SqlDbType.NVarChar).Value = lavado.pilling;
                    comando.Parameters.Add("@PILLING_OBSERVACIONES", SqlDbType.NVarChar).Value = lavado.pilling_observacion;
                    cn.Open();
                    comando.ExecuteNonQuery();

                }


                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para actualizar tabla prueba de diseno_telas_prueba_costura 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_costura_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_COSTURA", SqlDbType.Int).Value = actualiza.id_prueba_costura;
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = actualiza.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = costura.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = costura.fecha;
                    comando.Parameters.Add("@COSTURA_AGUJA", SqlDbType.NVarChar).Value = costura.aguja;
                    comando.Parameters.Add("@COSTURA_DESLIZAMIENTO", SqlDbType.NVarChar).Value = costura.deslizamiento;
                    comando.Parameters.Add("@COSTURA_DESLIZAMIENTO_OBSERVACIONES", SqlDbType.NVarChar).Value = costura.deslizamientoobservaciones;
                    comando.Parameters.Add("@COSTURA_RASGADO", SqlDbType.NVarChar).Value = costura.rasgado;
                    comando.Parameters.Add("@COSTURA_RASGADO_OBSERVACIONES", SqlDbType.NVarChar).Value = costura.rasgadoobservaciones;
                    cn.Open();
                    comando.ExecuteNonQuery();

                }




                //proceso para insertar contaminacion combinacion  de telas


                using (SqlConnection cn = DConexion.obtenerConexion()) //proceso para actualizar tabla prueba de diseno_telas_prueba_contaminacion 
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_contaminacion_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_CONTAMINACION", SqlDbType.Int).Value = actualiza.id_prueba_contaminacion_telas;
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = actualiza.id_tela;
                    comando.Parameters.Add("@ID_OPERARIO", SqlDbType.Int).Value = contaminacion.id_operario;
                    comando.Parameters.Add("@FECHA", SqlDbType.SmallDateTime).Value = contaminacion.fecha;
                    comando.Parameters.Add("@CONTAMINACION", SqlDbType.NVarChar).Value = contaminacion.contaminacion;
                    comando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar).Value = contaminacion.observaciones;
                    cn.Open();
                    comando.ExecuteNonQuery();
                }


                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static List<ERegistroTelasCalidad> GetConsultaConregistroCalidad(ETelas inserta)
        {
            List<ERegistroTelasCalidad> lst = new List<ERegistroTelasCalidad>();
            List<EPruebaEncogimiento> lstencogimiento = new List<EPruebaEncogimiento>();
            List<EPruebaLavadoPilling> lstlavado = new List<EPruebaLavadoPilling>();
            List<EPruebaCostura> lstcostura = new List<EPruebaCostura>();
            List<EPruebaContaminacion> lstcontaminacion = new List<EPruebaContaminacion>();
            EPruebaEncogimiento objencogimiento = new EPruebaEncogimiento();
            EPruebaLavadoPilling objlavado = new EPruebaLavadoPilling();
            EPruebaCostura objcostura = new EPruebaCostura();
            EPruebaContaminacion objcontaminacion = new EPruebaContaminacion();
            try
            {
                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_calidad_prueba_calidad_consultaexist", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = inserta.id_tela;
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lst.Add(new ERegistroTelasCalidad
                        {
                            id_tela = DBNull.Value.Equals(rd["id_tela"]) ? 0 : Convert.ToInt32(rd["id_tela"]),
                            id_prueba_encogimiento = Convert.ToInt32(rd["id_prueba_encogimiento"]),
                            id_prueba_lavado_pilling = Convert.ToInt32(rd["id_prueba_lavado_pilling"]),
                            id_prueba_costura = Convert.ToInt32(rd["id_prueba_costura"]),
                            id_prueba_contaminacion_telas = Convert.ToInt32(rd["id_prueba_contaminacion_telas"]),

                        });
                    }

                }
                foreach (ERegistroTelasCalidad itm in lst)
                {
                    itm.encogimiento = objencogimiento;
                    itm.lavadoPilling = objlavado;
                    itm.costura = objcostura;
                    itm.contaminacion = objcontaminacion;
                    break;
                }
                return lst;
            }
            catch (Exception e)
            {
                string error = e.InnerException.ToString();
                return new List<ERegistroTelasCalidad>();
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

        public static EPruebaEncogimiento GetCompletarInformacionEncogimiento_PruebaCalidad(int id_tela, int id_encogimiento)
        {
            EPruebaEncogimiento resultado = new EPruebaEncogimiento();
            List<EPruebaEncogimiento> lstpruebaencogimiento = new List<EPruebaEncogimiento>();
            using (SqlConnection cn = DConexion.obtenerConexion()) // proceso para insercion tabla diseno_forros_prueba_encogimiento
            {
                SqlCommand comando = new SqlCommand("", cn) { CommandType = CommandType.StoredProcedure };
                comando.Parameters.Add("@ID_TELA", SqlDbType.Int).Value = id_tela;
                comando.Parameters.Add("@ID_ENCOGIMIENTO", SqlDbType.Int).Value = id_encogimiento;

                cn.Open();
                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstpruebaencogimiento.Add(new EPruebaEncogimiento
                    {
                        id_encogimiento = DBNull.Value.Equals(rd["id_prueba_encogimiento"]) ? 0 : Convert.ToInt32(rd["id_prueba_encogimiento"]),
                        id_tela = Convert.ToInt32(rd["id_tela"]),

                        id_operario = Convert.ToInt32(rd["id_operario"]),
                        fecha_hora = Convert.ToDateTime(rd["fecha_hora"]),
                        id_entretela = Convert.ToInt32(rd["id_entretela"]),
                        adherencia = Convert.ToDouble(rd["adherencia"]),
                        id_proveedor = Convert.ToInt32(rd["id_proveedor"]),
                        temperatura = Convert.ToDouble(rd["temperatura"]),
                        tiempo = Convert.ToInt32(rd["tiempo"]),
                        presion = Convert.ToDouble(rd["presion"]),
                        vapor_hilo_final = Convert.ToDouble(rd["vapor_hilo_final"]),
                        vapor_trama_final = Convert.ToDouble(rd["vapor_trama_final"]),
                        vapor_hilo_diferencia = Convert.ToDouble(rd["vapor_hilo_diferencia"]),
                        vapor_trama_diferencia = Convert.ToDouble(rd["vapor_trama_diferencia"]),


                        vapor_observaciones = Convert.ToString(rd["vapor_observaciones"]),
                        fusion_hilo_final = Convert.ToDouble(rd["fusion_hilo_final"]),
                        fusion_trama_final = Convert.ToDouble(rd["fusion_trama_final"]),
                        fusion_hilo_diferencia = Convert.ToDouble(rd["fusion_hilo_diferencia"]),
                        fusion_trama_diferencia = Convert.ToDouble(rd["fusion_trama_diferencia"]),
                        fusion_observaciones = Convert.ToString(rd["fusion_observaciones"]),
                        plancha_hilo_final = Convert.ToDouble(rd["plancha_hilo_final"]),

                        plancha_trama_final = Convert.ToDouble(rd["plancha_trama_final"]),
                        plancha_hilo_diferencia = Convert.ToDouble(rd["plancha_hilo_diferencia"]),
                        plancha_trama_diferencia = Convert.ToDouble(rd["plancha_trama_diferencia"]),
                        plancha_obvservaciones = Convert.ToString(rd["plancha_obvservaciones"]),


                    });
                }

            }
            foreach (EPruebaEncogimiento itm in lstpruebaencogimiento)
            {
                resultado = itm;// se obtiene el id insertado para utilizarlo en el encabezado del registro
                break;
            }
            return new EPruebaEncogimiento();
        }

    }
}