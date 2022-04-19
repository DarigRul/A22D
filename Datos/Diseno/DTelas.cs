using Entidades.Diseno;using Entidades.Diseno.Telas;
using Entidades.Diseno.Marcadores;
using System;using System.Collections.Generic;using System.Data;using System.Data.SqlClient;using System.Linq;using System.Text;using System.Threading.Tasks;namespace Datos.Diseno{
    public class DTelas    {        public static int SetInsertaTelas(ETelas inserta) //PROCESO PARA INSERCION DE REGISTROS PARA LA TABLA DISENO MATERIAL        {            try            {

                using (SqlConnection cn = DConexion.obtenerConexion())                {                    SqlCommand comando = new SqlCommand("diseno_telas_registrar", cn) { CommandType = CommandType.StoredProcedure };                    comando.Parameters.Add("@TIPO", SqlDbType.Int).Value = inserta.tipo;                    comando.Parameters.Add("@CLAVE_TELA", SqlDbType.NVarChar).Value = inserta.clave_tela;                    comando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar).Value = inserta.descripcion;                    comando.Parameters.Add("@ID_FAMILIA_COMPOSICION", SqlDbType.Int).Value = inserta.id_familia_composicion;                    comando.Parameters.Add("@ID_ESTAMPADO", SqlDbType.Int).Value = inserta.id_estampado;                    comando.Parameters.Add("@ID_PROVEEDOR", SqlDbType.Int).Value = inserta.id_proveedor;                    comando.Parameters.Add("@CLAVE_PROVEEDOR", SqlDbType.NVarChar).Value = inserta.clave_proveedor;                    comando.Parameters.Add("@ID_COLOR", SqlDbType.Int).Value = inserta.id_color;                    comando.Parameters.Add("@ANCHO_TELA", SqlDbType.Decimal).Value = inserta.ancho_tela;                    comando.Parameters.Add("@IMAGEN", SqlDbType.NVarChar).Value = inserta.imagen;                    comando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar).Value = inserta.observaciones;                    comando.Parameters.Add("@ESTATUS_TELA", SqlDbType.Int).Value = inserta.estatus_tela;                    comando.Parameters.Add("@PRUEBA_ENCOGIMIENTO_LARGO", SqlDbType.Decimal).Value = inserta.prueba_encogimiento_largo;                    comando.Parameters.Add("@PRUEBA_ENCOGIMIENTO_ANCHO", SqlDbType.Decimal).Value = inserta.prueba_encogimiento_ancho;                    cn.Open();
                    comando.ExecuteNonQuery();
                }
                List<ETelas> lstPrendas = new List<ETelas>();

                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_telas_consultar_ultimo_registro", cn) { CommandType = CommandType.StoredProcedure };
                    cn.Open();
                    SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);
                    while (rd.Read())
                    {
                        lstPrendas.Add(new ETelas
                        {
                            id_tela = DBNull.Value.Equals(rd["id_tela"]) ? 0 : Convert.ToInt32(rd["id_tela"]),
                           
                                });
                    }

                }
                int valor = 0;
                foreach(ETelas itm in lstPrendas)
                {
                    valor = itm.id_tela;
                }
                return valor;            }            catch (Exception e)            {
                string value = e.InnerException.ToString();                return 0;            }        }
        public static int SetActualizaDisenoTelas(ETelas actualiza) //PROCESO PARA ACTUALIZACION DE REGISTROS PARA LA TABLA DISENO_FAMILIA_PRENDAS
        {
            try
            {

                using (SqlConnection cn = DConexion.obtenerConexion())
                {
                    SqlCommand comando = new SqlCommand("diseno_tela_actualizar", cn) { CommandType = CommandType.StoredProcedure };
                    comando.Parameters.Add("@ID_TELA", SqlDbType.NVarChar).Value = actualiza.id_tela;
                    comando.Parameters.Add("@TIPO", SqlDbType.Int).Value = actualiza.tipo;                    comando.Parameters.Add("@CLAVE_TELA", SqlDbType.NVarChar).Value = actualiza.clave_tela;                    comando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar).Value = actualiza.descripcion;                    comando.Parameters.Add("@ID_FAMILIA_COMPOSICION", SqlDbType.Int).Value = actualiza.id_familia_composicion;                    comando.Parameters.Add("@ID_ESTAMPADO", SqlDbType.Int).Value = actualiza.id_estampado;                    comando.Parameters.Add("@ID_PROVEEDOR", SqlDbType.Int).Value = actualiza.id_proveedor;                    comando.Parameters.Add("@CLAVE_PROVEEDOR", SqlDbType.NVarChar).Value = actualiza.clave_proveedor;                    comando.Parameters.Add("@ID_COLOR", SqlDbType.Int).Value = actualiza.id_color;                    comando.Parameters.Add("@ANCHO_TELA", SqlDbType.Decimal).Value = actualiza.ancho_tela;                    comando.Parameters.Add("@IMAGEN", SqlDbType.NVarChar).Value = actualiza.imagen;                    comando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar).Value = actualiza.observaciones;                    comando.Parameters.Add("@ESTATUS_TELA", SqlDbType.Int).Value = actualiza.estatus_tela;                    comando.Parameters.Add("@PRUEBA_ENCOGIMIENTO_LARGO", SqlDbType.Decimal).Value = actualiza.prueba_encogimiento_largo;                    comando.Parameters.Add("@PRUEBA_ENCOGIMIENTO_ANCHO", SqlDbType.Decimal).Value = actualiza.prueba_encogimiento_ancho;                    cn.Open();
                    comando.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public static void SetEliminarImagenTela(int id_tela)
        {
            //actualiza el campo imagen a vacio, del registro de tela
            try            {                using (SqlConnection cn = DConexion.obtenerConexion())                {                    SqlCommand cmd = new SqlCommand("diseno_tela_eliminar_imagen", cn) { CommandType = CommandType.StoredProcedure };                    cmd.Parameters.AddWithValue("ID_TELA",id_tela);                    cn.Open();                    cmd.ExecuteNonQuery();                }            }            catch (Exception)            {            }
        }
            public static void SetHabilitarDeshabilitarTelas(int id_material, int estatus) //PROCESO PARA HABILITAR/DESHABILITAR REGISTROS PARA LA TABLA DISENO MATERIAL
        {            var obj = new ETelas();            try            {                using (SqlConnection cn = DConexion.obtenerConexion())                {                    SqlCommand cmd = new SqlCommand("diseno_tela_habilitar_deshabilitar", cn) { CommandType = CommandType.StoredProcedure };                    cmd.Parameters.AddWithValue("ID_TELA", id_material);                    cmd.Parameters.AddWithValue("ESTATUS", estatus);                    cn.Open();                    cmd.ExecuteNonQuery();                }            }            catch (Exception)            {            }        }        public static List<ETelas> GetConsultaDisenoTelas() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO MATERIAL
        {            List<ETelas> lstPrendas = new List<ETelas>();            try
            {             using (SqlConnection cn = DConexion.obtenerConexion())            {                SqlCommand comando = new SqlCommand("diseno_telas_consultar", cn) { CommandType = CommandType.StoredProcedure };                cn.Open();                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);                while (rd.Read())                {                    lstPrendas.Add(new ETelas                    {                        id_tela = DBNull.Value.Equals(rd["id_tela"]) ? 0 : Convert.ToInt32(rd["id_tela"]),                        tipo = Convert.ToInt32( rd["tipo"]),                        clave_tela = Convert.ToString(rd["clave_tela"]),
                        descripcion = Convert.ToString(rd["descripcion"]),
                        id_familia_composicion = Convert.ToInt32(rd["id_familia_composicion"]),
                        id_estampado = Convert.ToInt32(rd["id_estampado"]),
                        id_proveedor = Convert.ToInt32(rd["id_proveedor"]),
                        clave_proveedor = Convert.ToString(rd["clave_proveedor"]),
                        id_color = Convert.ToInt32(rd["id_color"]),
                        ancho_tela = Convert.ToDouble(rd["ancho_tela"]),
                        imagen = Convert.ToString(rd["imagen"]),
                        observaciones = rd["observaciones"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"]),
                        auxestatus = rd["auxestatus"].ToString(),
                        estatus_tela = Convert.ToInt32(rd["estatus_tela"]),
                        prueba_encogimiento_largo = Convert.ToDouble(rd["prueba_encogimiento_largo"]),
                        prueba_encogimiento_ancho = Convert.ToDouble(rd["prueba_encogimiento_ancho"]),
                        auxtipo = rd["auxtipo"].ToString(),
                        auxid_familia_composicion = rd["auxid_familia_composicion"].ToString(),
                        auxid_estampado = rd["auxid_estampado"].ToString(),
                        auxid_proveedor = rd["auxid_proveedor"].ToString(),
                        auxid_color = rd["auxid_color"].ToString(),
                     });                }            }
                return lstPrendas;            }            catch(Exception e)            {
                string error = e.InnerException.ToString();
                return new List<ETelas>();
            }
        }        public static List<EMaterialTipocbo> GetLlenarComboMaterialTipo() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO MATERIAL TIPO, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {            List<EMaterialTipocbo> lstMaterialTipo = new List<EMaterialTipocbo>();            using (SqlConnection cn = DConexion.obtenerConexion())            {                SqlCommand comando = new SqlCommand("diseno_materiales_consultar_material_tipo", cn) { CommandType = CommandType.StoredProcedure };                cn.Open();                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);                while (rd.Read())                {                    lstMaterialTipo.Add(new EMaterialTipocbo                    {                        id_material_tipo = DBNull.Value.Equals(rd["id_material_tipo"]) ? 0 : Convert.ToInt32(rd["id_material_tipo"]),                        descripcion = Convert.ToString(rd["descripcion"]),                        nomenclatura = Convert.ToString(rd["nomenclatura"]),
                        tipo_material = Convert.ToString(rd["tipo_material"]),
                        clasificacion = Convert.ToString(rd["clasificacion"]),
                        estatus = Convert.ToInt32(rd["estatus"]),
                        auxdescrip = rd["auxdescrip"].ToString(),
                    });                }            }            return lstMaterialTipo;        }


        
        public static List<EFamiliaComposicioncombo> GetLlenarCombofamiliacomposicion() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO fFAMILIA COMPOSICION TIPO, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {        try               {                     List<EFamiliaComposicioncombo> lstcomposicion = new List<EFamiliaComposicioncombo>();            using (SqlConnection cn = DConexion.obtenerConexion())            {                SqlCommand comando = new SqlCommand("diseno_materiales_consultar_familia_composicion", cn) { CommandType = CommandType.StoredProcedure };                cn.Open();                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);                while (rd.Read())                {                    lstcomposicion.Add(new EFamiliaComposicioncombo                    {                        id_familia_composicion = DBNull.Value.Equals(rd["id_familia_composicion"]) ? 0 : Convert.ToInt32(rd["id_familia_composicion"]),                        nombre = Convert.ToString(rd["nombre"]),                        auxdescrip = rd["auxdescrip"].ToString(),
                    });                }            }            return lstcomposicion;
            }
           catch(Exception e )
            {
                string s = e.InnerException.ToString();
                return new List<EFamiliaComposicioncombo>();
            }
            }


        public static List<EComprasProveedores> GetLlenarComboComprasProveedores() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA COMPRAS PROVEEDOR, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {            List<EComprasProveedores> lstProveedores = new List<EComprasProveedores>();            using (SqlConnection cn = DConexion.obtenerConexion())            {                SqlCommand comando = new SqlCommand("diseno_materiales_consultar_compras_proveedores", cn) { CommandType = CommandType.StoredProcedure };                cn.Open();                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);                while (rd.Read())                {                    lstProveedores.Add(new EComprasProveedores                    {                        id_proveedor = DBNull.Value.Equals(rd["id_proveedor"]) ? 0 : Convert.ToInt32(rd["id_proveedor"]),                        tipo = Convert.ToString(rd["tipo"]),                        nombre_comercial = Convert.ToString(rd["nombre_comercial"]),
                        nomenclatura_tela = Convert.ToString(rd["nomenclatura_tela"]),
                        estatus = Convert.ToInt32(rd["estatus"]),
                        auxdescrip = rd["auxdescrip"].ToString(),
                    });                }            }            return lstProveedores;        }

        public static List<EColores> GetLlenarComboDisenoColores() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO COLORES, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {            List<EColores> lstcolores = new List<EColores>();            using (SqlConnection cn = DConexion.obtenerConexion())            {                SqlCommand comando = new SqlCommand("diseno_materiales_consultar_diseno_colores", cn) { CommandType = CommandType.StoredProcedure };                cn.Open();                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);                while (rd.Read())                {                    lstcolores.Add(new EColores                    {                        id_color = DBNull.Value.Equals(rd["id_color"]) ? 0 : Convert.ToInt32(rd["id_color"]),                        nombre = Convert.ToString(rd["nombre"]),                        codigo_color = Convert.ToString(rd["codigo_color"]),
                        estatus = Convert.ToInt32(rd["estatus"]),
                        auxdescrip = rd["auxdescrip"].ToString(),
                    });                }            }            return lstcolores;        }


        public static List<EMaterialesProcesoscombo> GetLlenarComboMaterialesProcesos() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO COLORES, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {            List<EMaterialesProcesoscombo> lstmaterialesprocesos = new List<EMaterialesProcesoscombo>();            using (SqlConnection cn = DConexion.obtenerConexion())            {                SqlCommand comando = new SqlCommand("diseno_materiales_consultar_materiales_procesos", cn) { CommandType = CommandType.StoredProcedure };                cn.Open();                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);                while (rd.Read())                {                    lstmaterialesprocesos.Add(new EMaterialesProcesoscombo                    {                        id_material_proceso = DBNull.Value.Equals(rd["id_material_proceso"]) ? 0 : Convert.ToInt32(rd["id_material_proceso"]),                        proceso = Convert.ToString(rd["proceso"]),                        tipo = Convert.ToString(rd["tipo"]),
                        auxdescrip = rd["auxdescrip"].ToString(),
                    });                }            }            return lstmaterialesprocesos;        }


        public static List<EEstampados> GetLlenarCombodisenoestampado() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO COLORES, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {            List<EEstampados> lstestampados = new List<EEstampados>();            using (SqlConnection cn = DConexion.obtenerConexion())            {                SqlCommand comando = new SqlCommand("diseno_materiales_consultar_diseno_estampados", cn) { CommandType = CommandType.StoredProcedure };                cn.Open();                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);                while (rd.Read())                {                    lstestampados.Add(new EEstampados                    {                        id_diseno_estampado = DBNull.Value.Equals(rd["id_diseno_estampado"]) ? 0 : Convert.ToInt32(rd["id_diseno_estampado"]),                        nombre = Convert.ToString(rd["nombre"]),                        estatus = Convert.ToInt32(rd["estatus"]),
                        auxdescrip = rd["auxdescrip"].ToString(),
                    });                }            }            return lstestampados;        }




        public static List<EUnidadesMedidas> GetLlenarComboUnidadMedida() //PROCESO PARA CONSULTAR INFORMACION DE LA TABLA DISENO COLORES, SE UTILIZA PARA LLENAR LOS COMBOS RELACIONADOS EN LA FORMA MATERIAL
        {            List<EUnidadesMedidas> lstunidadmedida = new List<EUnidadesMedidas>();            using (SqlConnection cn = DConexion.obtenerConexion())            {                SqlCommand comando = new SqlCommand("diseno_materiales_consultar_unidad_medida", cn) { CommandType = CommandType.StoredProcedure };                cn.Open();                SqlDataReader rd = comando.ExecuteReader(CommandBehavior.SingleResult);                while (rd.Read())                {                    lstunidadmedida.Add(new EUnidadesMedidas                    {                        id_unidad_medida = DBNull.Value.Equals(rd["id_unidad_medida"]) ? 0 : Convert.ToInt32(rd["id_unidad_medida"]),                        nombre = Convert.ToString(rd["nombre"]),                        simbolo = Convert.ToString(rd["simbolo"]),
                        estatus = Convert.ToInt32(rd["estatus"]),
                        auxdescrip = rd["auxdescrip"].ToString(),
                    });                }            }            return lstunidadmedida;        }    }}