using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Compras; 

namespace Datos.Compras
{
    public class DProveedor
    {
        public static List<EProveedor> ListarProveedores()
        {
            var lstProveedores = new List<Entidades.Compras.EProveedor>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("compras_proveedores_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstProveedores.Add(new Entidades.Compras.EProveedor
                    {
                        id_proveedor = Convert.ToInt32(rd["id_proveedor"]),
                        tipo = rd["tipo"].ToString(),
                        nombre_comercial = rd["nombre_comercial"].ToString(),
                        nomenclatura = rd["nomenclatura"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"]),
                        razon_social = rd["razon_social"].ToString(),
                        rfc = rd["rfc"].ToString(),
                        calle = rd["calle"].ToString(),
                        numero_exterior = rd["numero_exterior"].ToString(), 
                        numero_interior = rd["numero_interior"].ToString(), 
                        colonia = rd["colonia"].ToString(), 
                        municipio = rd["municipio"].ToString(), 
                        estado = rd["estado"].ToString(), 
                        codigo_postal = rd["codigo_postal"].ToString(), 
                        pais = rd["pais"].ToString(), 
                        telefono = rd["telefono"].ToString(), 
                        email = rd["email"].ToString(),
                        pagina_web = rd["pagina_web"].ToString(),
                        whatsapp = rd["whatsapp"].ToString(),
                        facebook = rd["facebook"].ToString(), 
                        instagram = rd["instagram"].ToString(), 
                        tik_tok = rd["tik_tok"].ToString(),
                        twitter = rd["twitter"].ToString(),
                        otras_redes = rd["otras_redes"].ToString()
                    });
                }

                return lstProveedores;
            }
        }

        public static int Agregar(EProveedor proveedor)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("compras_proveedores_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("tipo", proveedor.tipo);
                cmd.Parameters.AddWithValue("nombre_comercial", proveedor.nombre_comercial);
                cmd.Parameters.AddWithValue("razon_social", proveedor.razon_social);
                cmd.Parameters.AddWithValue("rfc", proveedor.rfc);
                cmd.Parameters.AddWithValue("calle", proveedor.calle);
                cmd.Parameters.AddWithValue("numero_exterior", proveedor.numero_exterior);
                cmd.Parameters.AddWithValue("numero_interior", proveedor.numero_interior);
                cmd.Parameters.AddWithValue("colonia", proveedor.colonia);
                cmd.Parameters.AddWithValue("municipio", proveedor.municipio);
                cmd.Parameters.AddWithValue("estado", proveedor.estado);
                cmd.Parameters.AddWithValue("codigo_postal", proveedor.codigo_postal);
                cmd.Parameters.AddWithValue("pais", proveedor.pais);
                cmd.Parameters.AddWithValue("telefono", proveedor.telefono);
                cmd.Parameters.AddWithValue("email", proveedor.email);
                cmd.Parameters.AddWithValue("pagina_web", proveedor.pagina_web);
                cmd.Parameters.AddWithValue("whatsapp", proveedor.whatsapp);
                cmd.Parameters.AddWithValue("facebook", proveedor.facebook);
                cmd.Parameters.AddWithValue("instagram", proveedor.instagram);
                cmd.Parameters.AddWithValue("tik_tok", proveedor.tik_tok);
                cmd.Parameters.AddWithValue("twitter", proveedor.twitter);
                cmd.Parameters.AddWithValue("otras_redes", proveedor.otras_redes);
                cmd.Parameters.AddWithValue("nomenclatura", proveedor.nomenclatura); 
                cn.Open();
                return cmd.ExecuteNonQuery();

            }
        }

        public static int Modificar(EProveedor proveedor)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("compras_proveedores_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_proveedor", proveedor.id_proveedor);
                cmd.Parameters.AddWithValue("tipo", proveedor.tipo);
                cmd.Parameters.AddWithValue("nombre_comercial", proveedor.nombre_comercial);
                cmd.Parameters.AddWithValue("razon_social", proveedor.razon_social);
                cmd.Parameters.AddWithValue("rfc", proveedor.rfc);
                cmd.Parameters.AddWithValue("calle", proveedor.calle);
                cmd.Parameters.AddWithValue("numero_exterior", proveedor.numero_exterior);
                cmd.Parameters.AddWithValue("numero_interior", proveedor.numero_interior);
                cmd.Parameters.AddWithValue("colonia", proveedor.colonia);
                cmd.Parameters.AddWithValue("municipio", proveedor.municipio);
                cmd.Parameters.AddWithValue("estado", proveedor.estado);
                cmd.Parameters.AddWithValue("codigo_postal", proveedor.codigo_postal);
                cmd.Parameters.AddWithValue("pais", proveedor.pais);
                cmd.Parameters.AddWithValue("telefono", proveedor.telefono);
                cmd.Parameters.AddWithValue("email", proveedor.email);
                cmd.Parameters.AddWithValue("pagina_web", proveedor.pagina_web);
                cmd.Parameters.AddWithValue("whatsapp", proveedor.whatsapp);
                cmd.Parameters.AddWithValue("facebook", proveedor.facebook);
                cmd.Parameters.AddWithValue("instagram", proveedor.instagram);
                cmd.Parameters.AddWithValue("tik_tok", proveedor.tik_tok);
                cmd.Parameters.AddWithValue("twitter", proveedor.twitter);
                cmd.Parameters.AddWithValue("otras_redes", proveedor.otras_redes);
                cmd.Parameters.AddWithValue("nomenclatura", proveedor.nomenclatura);
                cn.Open();
                return cmd.ExecuteNonQuery();

            }
        }

        public static int Estatus(EProveedor proveedor)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("compras_proveedores_estatus", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_proveedor", proveedor.id_proveedor);
                cmd.Parameters.AddWithValue("estatus", proveedor.estatus);
                cn.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }

    }
}