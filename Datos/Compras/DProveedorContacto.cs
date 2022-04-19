using Entidades.Compras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datos.Compras
{
    public static class DProveedorContacto
    {
        public static List<EProveedorContacto> Listar(EProveedor proveedor)
        {
            List<EProveedorContacto> lstContactos = new List<EProveedorContacto>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("compras_proveedor_contactos_listar", cn) { CommandType = System.Data.CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_proveedor", proveedor.id_proveedor);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstContactos.Add(new EProveedorContacto
                    {
                        id_contacto = Convert.ToInt32(rd["id_contacto"]),
                        id_proveedor_contacto = Convert.ToInt32(rd["id_proveedor"]), 
                        nombre_contacto = rd["nombre"].ToString(),
                        telefono_contacto = rd["telefono"].ToString(), 
                        extension_contacto = rd["extension"].ToString(), 
                        celular_contacto = rd["celular"].ToString(),
                        email_contacto = rd["email"].ToString(),
                        puesto_contacto = rd["puesto"].ToString(), 
                        observaciones = rd["observaciones"].ToString(), 
                        estatus_contacto = Convert.ToInt32(rd["estatus"])
                    });
                }

                cn.Close();
                cn.Dispose();
                rd.Close(); 
            }

            return lstContactos; 
        }

        public static DataTable ReporteContactos()
        {
            List<EProveedorContacto> lstContactos = new List<EProveedorContacto>();
            DataTable dtContactos = new DataTable();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {

                SqlCommand cmd = new SqlCommand("compras_proveedores_contactos_general", cn) { CommandType = System.Data.CommandType.StoredProcedure };
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cn.Open();
                da.Fill(dtContactos);
                //SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                

                //while (rd.Read())
                //{
                //    lstContactos.Add(new EProveedorContacto
                //    {
                //        id_contacto = Convert.ToInt32(rd["id_contacto"]),
                //        id_proveedor_contacto = Convert.ToInt32(rd["id_proveedor"]),
                //        nombre_contacto = rd["nombre"].ToString(),
                //        telefono_contacto = rd["telefono"].ToString(),
                //        extension_contacto = rd["extension"].ToString(),
                //        celular_contacto = rd["celular"].ToString(),
                //        email_contacto = rd["email"].ToString(),
                //        puesto_contacto = rd["puesto"].ToString(),
                //        observaciones = rd["observaciones"].ToString(),
                //        estatus_contacto = Convert.ToInt32(rd["estatus"])
                //    });
                //}
                
                cn.Close();
                cn.Dispose();
                //rd.Close();
            }

            return dtContactos;
        }


        public static int Agregar(EProveedorContacto contacto)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("compras_proveedores_contactos_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_proveedor", contacto.id_proveedor_contacto);
                cmd.Parameters.AddWithValue("nombre", contacto.nombre_contacto);
                cmd.Parameters.AddWithValue("telefono", contacto.telefono_contacto);
                cmd.Parameters.AddWithValue("extension", contacto.extension_contacto); 
                cmd.Parameters.AddWithValue("celular", contacto.celular_contacto);
                cmd.Parameters.AddWithValue("email", contacto.email_contacto);
                cmd.Parameters.AddWithValue("puesto", contacto.puesto_contacto);
                cmd.Parameters.AddWithValue("observaciones", contacto.observaciones);
                cn.Open();
                return cmd.ExecuteNonQuery();

            }
        }


        public static int Modificar(EProveedorContacto contacto)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("compras_proveedores_contactos_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_contacto", contacto.id_contacto); 
                cmd.Parameters.AddWithValue("id_proveedor", contacto.id_proveedor_contacto);
                cmd.Parameters.AddWithValue("nombre", contacto.nombre_contacto);
                cmd.Parameters.AddWithValue("telefono", contacto.telefono_contacto);
                cmd.Parameters.AddWithValue("extension", contacto.extension_contacto);
                cmd.Parameters.AddWithValue("celular", contacto.celular_contacto);
                cmd.Parameters.AddWithValue("email", contacto.email_contacto);
                cmd.Parameters.AddWithValue("puesto", contacto.puesto_contacto);
                cmd.Parameters.AddWithValue("observaciones", contacto.observaciones);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Estatus(EProveedorContacto contacto)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("compras_proveedores_contactos_estatus", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_contacto", contacto.id_contacto);
                cmd.Parameters.AddWithValue("estatus", contacto.estatus_contacto); 
                cn.Open();
                return cmd.ExecuteNonQuery();
            }

        }
    }
}
