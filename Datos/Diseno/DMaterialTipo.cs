using Entidades.Diseno;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Diseno
{
    public class DMaterialTipo
    {
        public List<EMaterialTipo> ListaMaterialTipo()
        {
            List<EMaterialTipo> dMaterialTipos = new List<EMaterialTipo>();
            using (SqlConnection cn = DConexion.obtenerConexion()) {
                SqlCommand cmd = new SqlCommand("diseno_material_tipo_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    dMaterialTipos.Add(new EMaterialTipo
                    {
                        id_material_tipo = DBNull.Value.Equals(rd["id_material_tipo"]) ? 0 : Convert.ToInt32(rd["id_material_tipo"]),
                        descripcion = rd["descripcion"].ToString(),
                        nomenclatura = rd["nomenclatura"].ToString(),
                        tipo_material = rd["tipo_material"].ToString(),
                        clasificacion = rd["clasificacion"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])

                    });
                }
            }
            return dMaterialTipos;
        }

        public int ActivarMaterialTipos(int id_material_tipo)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_material_tipo_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_material_tipo", id_material_tipo);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DesactivarMaterialTipos(int id_material_tipo)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_material_tipo_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_material_tipo", id_material_tipo);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int AgregarMaterialTipo(EMaterialTipo materialTipo)
        {
            int id_material_tipo = 0;

            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("diseno_diseno_material_tipo_agregar", cnn);
            try
            {
                cmd.Parameters.AddWithValue("descripcion", materialTipo.descripcion);
                cmd.Parameters.AddWithValue("nomenclatura", materialTipo.nomenclatura);
                cmd.Parameters.AddWithValue("tipo_material", materialTipo.tipo_material);
                cmd.Parameters.AddWithValue("clasificacion", materialTipo.clasificacion);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        id_material_tipo = Convert.ToInt32(reader["id_material_tipo"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return id_material_tipo;
        }

        public int ModificaMaterialTipo(EMaterialTipo materialTipo)
        {
            int id_material_tipo = 0;

            SqlConnection cnn = DConexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand("diseno_diseno_material_tipo_modificar", cnn);
            try
            {
                cmd.Parameters.AddWithValue("@id_material_tipo", materialTipo.id_material_tipo);
                cmd.Parameters.AddWithValue("@descripcion", materialTipo.descripcion);
                cmd.Parameters.AddWithValue("@nomenclatura", materialTipo.nomenclatura);
                cmd.Parameters.AddWithValue("@tipo_material", materialTipo.tipo_material);
                cmd.Parameters.AddWithValue("@clasificacion", materialTipo.clasificacion);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        id_material_tipo = Convert.ToInt32(reader["id_material_tipo"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return id_material_tipo;
        }
    }
}
