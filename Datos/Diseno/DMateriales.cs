using Entidades.Diseno;
using FluentFTP;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Datos.Utilitarios;

namespace Datos.Diseno
{
    public class DMateriales
    {
        public static List<EMateriales> ListaMateriales()
        {
            List<EMateriales> dMaterial = new List<EMateriales>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_material_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    dMaterial.Add(new EMateriales
                    {
                        id_material = DBNull.Value.Equals(rd["id_material"]) ? 0 : Convert.ToInt32(rd["id_material"]),
                        tipo = DBNull.Value.Equals(rd["tipo"]) ? 0 : Convert.ToInt32(rd["tipo"]),
                        id_material_tipo = DBNull.Value.Equals(rd["id_material_tipo"]) ? 0 : Convert.ToInt32(rd["id_material_tipo"]),
                        material_tipo = rd["material_tipo"].ToString(),
                        id_proveedor = DBNull.Value.Equals(rd["id_proveedor"]) ? 0 : Convert.ToInt32(rd["id_proveedor"]),
                        nombre_comercial = rd["nombre_comercial"].ToString(),
                        id_material_proceso = DBNull.Value.Equals(rd["id_material_proceso"]) ? 0 : Convert.ToInt32(rd["id_material_proceso"]),
                        proceso = rd["proceso"].ToString(),
                        id_unidad_medida = DBNull.Value.Equals(rd["id_unidad_medida"]) ? 0 : Convert.ToInt32(rd["id_unidad_medida"]),
                        unidad_medida = rd["unidad_medida"].ToString(),
                        nombre = Convert.ToString(rd["nombre"]),
                        id_color = Convert.ToInt32(rd["id_color"]),
                        color = Convert.ToString(rd["color"]),
                        uso = Convert.ToString(rd["uso"]),
                        clave_proveedor = Convert.ToString(rd["clave_proveedor"]),
                        tamano = Convert.ToDecimal(rd["tamano"]),
                        observaciones = Convert.ToString(rd["observaciones"]),
                        imagen = Convert.ToString(rd["imagen"]),
                        hacer_prueba_calidad = Convert.ToInt32(rd["hacer_prueba_calidad"]),
                        precio_unitario = Convert.ToDecimal(rd["precio_unitario"]),
                        estatus = Convert.ToInt32(rd["estatus"]),
                    });
                }
            }
            return dMaterial;
        }

        public static EMateriales SetInsertarMateriales(EMateriales material) //PROCESO PARA INSERCION DE REGISTROS PARA LA TABLA DISENO MATERIAL
        {
            EMateriales eMateriales = new EMateriales();
            string mensaje = "";
            try
            {
                using (SqlConnection cnn = DConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("diseno_material_registrar", cnn);

                    cmd.Parameters.Add("@id_material_tipo", SqlDbType.Int).Value = material.id_material_tipo;
                    cmd.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = material.id_proveedor;
                    cmd.Parameters.Add("@id_material_proceso", SqlDbType.Int).Value = material.id_material_proceso;
                    cmd.Parameters.Add("@id_unidad_medida", SqlDbType.Int).Value = material.id_unidad_medida;
                    cmd.Parameters.Add("@id_color", SqlDbType.Int).Value = material.id_color;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = material.nombre;
                    cmd.Parameters.Add("@uso", SqlDbType.VarChar).Value = material.uso;
                    cmd.Parameters.Add("@clave_proveedor", SqlDbType.VarChar).Value = material.clave_proveedor;
                    cmd.Parameters.Add("@tamano", SqlDbType.Decimal).Value = material.tamano;
                    cmd.Parameters.Add("@observaciones", SqlDbType.Text).Value = material.observaciones;
                    cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value = material.imagen;
                    cmd.Parameters.Add("@hacer_prueba_calidad", SqlDbType.Int).Value = material.hacer_prueba_calidad;
                    cmd.Parameters.Add("@precio_unitario", SqlDbType.Decimal).Value = material.precio_unitario;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            eMateriales.id_material = Convert.ToInt32(reader["id_material"]);
                        if (!reader.IsDBNull(1))
                            eMateriales.imagen = Convert.ToString(reader["imagen"]);
                        if (!reader.IsDBNull(2))
                            mensaje = Convert.ToString(reader["mensaje"]);
                    }
                }

                //Si se agregó correctamente el registro regresará el nombre del archivo
                if(mensaje != "")
                {
                    throw new Exception(mensaje);
                }
                return eMateriales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EMateriales ModificaMateriales(EMateriales material) //PROCESO PARA INSERCION DE REGISTROS PARA LA TABLA DISENO MATERIAL
        {
            EMateriales eMateriales = new EMateriales();
            string mensaje = "";
            try
            {
                using (SqlConnection cnn = DConexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("diseno_material_modificar", cnn);

                    cmd.Parameters.Add("@id_material", SqlDbType.Int).Value = material.id_material;
                    cmd.Parameters.Add("@id_material_tipo", SqlDbType.Int).Value = material.id_material_tipo;
                    cmd.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = material.id_proveedor;
                    cmd.Parameters.Add("@id_material_proceso", SqlDbType.Int).Value = material.id_material_proceso;
                    cmd.Parameters.Add("@id_unidad_medida", SqlDbType.Int).Value = material.id_unidad_medida;
                    cmd.Parameters.Add("@id_color", SqlDbType.Int).Value = material.id_color;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = material.nombre;
                    cmd.Parameters.Add("@uso", SqlDbType.VarChar).Value = material.uso;
                    cmd.Parameters.Add("@clave_proveedor", SqlDbType.VarChar).Value = material.clave_proveedor;
                    cmd.Parameters.Add("@tamano", SqlDbType.Decimal).Value = material.tamano;
                    cmd.Parameters.Add("@observaciones", SqlDbType.Text).Value = material.observaciones;
                    cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value = material.imagen;
                    cmd.Parameters.Add("@hacer_prueba_calidad", SqlDbType.Int).Value = material.hacer_prueba_calidad;
                    cmd.Parameters.Add("@precio_unitario", SqlDbType.Decimal).Value = material.precio_unitario;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            eMateriales.id_material = Convert.ToInt32(reader["id_material"]);
                        if (!reader.IsDBNull(1))
                            eMateriales.imagen = Convert.ToString(reader["imagen"]);
                        if (!reader.IsDBNull(2))
                            mensaje = Convert.ToString(reader["mensaje"]);
                    }
                }

                //Si se agregó correctamente el registro regresará el nombre del archivo
                if (mensaje != "")
                {
                    throw new Exception(mensaje);
                }
                return eMateriales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ActivarMaterial(int id_material)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_material_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_material", id_material);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DesactivarMaterial(int id_material)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_material_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_material", id_material);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}