using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Diseno; 

namespace Datos.Diseno
{
    public class DUnidadesMedida
    {
        public List<EUnidadesMedida> ListarUnidades()
        {
            List<EUnidadesMedida> lstUnidades = new List<EUnidadesMedida>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_unidades_medida_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstUnidades.Add(new EUnidadesMedida
                    {
                        id_unidad_medida = Convert.ToInt32(rd["id_unidad_medida"]),
                        nombre = rd["nombre"].ToString(), 
                        simbolo = rd["simbolo"].ToString(), 
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }
                return lstUnidades;
            }
        }

        public int AgregarUnidad(EUnidadesMedida unidad)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_unidades_medida_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre", unidad.nombre);
                cmd.Parameters.AddWithValue("simbolo", unidad.simbolo);
                cn.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }

        public int ModificarUnidad(EUnidadesMedida unidad)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_unidades_medida_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_unidad_medida", unidad.id_unidad_medida);
                cmd.Parameters.AddWithValue("nombre", unidad.nombre);
                cmd.Parameters.AddWithValue("simbolo", unidad.simbolo);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int ActivarUnidad(EUnidadesMedida unidad)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_unidades_medida_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_unidad_medida", unidad.id_unidad_medida);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DesactivarUnidad(EUnidadesMedida unidad)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_unidades_medida_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_unidad_medida", unidad.id_unidad_medida);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int VerificaUnidad(EUnidadesMedida unidad)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_unidad_medida_verifica", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre", unidad.nombre);
                cmd.Parameters.AddWithValue("simbolo", unidad.simbolo);
                cn.Open();
                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                return cantidad; 
            }
        }

    }
}
