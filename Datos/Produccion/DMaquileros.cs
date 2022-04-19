using Entidades.Diseno;
using Entidades.Produccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Produccion
{
    public class DMaquileros
    {
        public static List<EMaquileros> maquilaros_consulta()
        {
            List<EMaquileros> lstmaquileros = new List<EMaquileros>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("produccion_maquilaros_consulta", cn) { CommandType = System.Data.CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lstmaquileros.Add(new EMaquileros()
                    {
                        id_maquilero = Convert.ToInt32(rd["id_maquilero"]),
                        nombre = rd["nombre"].ToString(),
                        paterno = rd["paterno"].ToString(),
                        materno = rd["materno"].ToString(),
                        email = rd["email"].ToString(),
                        direccion = rd["direccion"].ToString(),
                        cp = rd["cp"].ToString(),
                        telefono = rd["telefono"].ToString(),
                        celular = rd["celular"].ToString(),
                        razon_social = rd["razon_social"].ToString(),
                        rfc = rd["rfc"].ToString(),
                        direccion_facturacion = rd["direccion_facturacion"].ToString(),
                        cp_facturacion = rd["cp_facturacion"].ToString(),
                        estatus = Convert.ToInt32(rd["estatus"])
                    });

                }
                return lstmaquileros;
            }
        }
        public int actualizaEstatus(int estatus, EMaquileros maquileroactivar)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("maquileros_actualiza_estatus", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                cmd.Parameters.AddWithValue("id_maquilero", maquileroactivar.id_maquilero);

                cmd.Parameters.AddWithValue("estatus", estatus);
                return cmd.ExecuteNonQuery();
            }

        }
        public bool GuardaMaquilero(EMaquileros maquileroGuardar, List<EFamiliaPrendas> familiaPrendas)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("produccion_maquilero_guarda", cn, tran) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("id", 0);
                    cmd.Parameters.AddWithValue("nombre", maquileroGuardar.nombre);
                    cmd.Parameters.AddWithValue("paterno", maquileroGuardar.paterno);
                    cmd.Parameters.AddWithValue("materno", maquileroGuardar.materno);
                    cmd.Parameters.AddWithValue("email", maquileroGuardar.email);
                    cmd.Parameters.AddWithValue("direccion", maquileroGuardar.direccion);
                    cmd.Parameters.AddWithValue("cp", maquileroGuardar.cp);
                    cmd.Parameters.AddWithValue("telefono", maquileroGuardar.telefono);
                    cmd.Parameters.AddWithValue("celular", maquileroGuardar.celular);
                    cmd.Parameters.AddWithValue("razon_social", maquileroGuardar.razon_social);
                    cmd.Parameters.AddWithValue("rfc", maquileroGuardar.rfc);
                    cmd.Parameters.AddWithValue("direccion_facturacion", maquileroGuardar.direccion_facturacion);
                    cmd.Parameters.AddWithValue("cp_facturacion", maquileroGuardar.cp_facturacion);
                    cmd.Parameters["id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int id_maquilero = Convert.ToInt32(cmd.Parameters["id"].Value);
                    GuardaFamiliaMaquilero(cmd, familiaPrendas, id_maquilero);
                    tran.Commit();
                    cn.Close();
                    return true;
                }
                catch (Exception ex)
                {

                    tran.Rollback();
                    cn.Close();
                    return false;
                }
            }
        }
        public bool ActualizaMaquilero(EMaquileros maquileroGuardar, List<EFamiliaPrendas> familiaPrendas)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("produccion_maquilero_actualiza", cn, tran) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("id_maquilero", maquileroGuardar.id_maquilero);
                    cmd.Parameters.AddWithValue("nombre", maquileroGuardar.nombre);
                    cmd.Parameters.AddWithValue("paterno", maquileroGuardar.paterno);
                    cmd.Parameters.AddWithValue("materno", maquileroGuardar.materno);
                    cmd.Parameters.AddWithValue("email", maquileroGuardar.email);
                    cmd.Parameters.AddWithValue("direccion", maquileroGuardar.direccion);
                    cmd.Parameters.AddWithValue("cp", maquileroGuardar.cp);
                    cmd.Parameters.AddWithValue("telefono", maquileroGuardar.telefono);
                    cmd.Parameters.AddWithValue("celular", maquileroGuardar.celular);
                    cmd.Parameters.AddWithValue("razon_social", maquileroGuardar.razon_social);
                    cmd.Parameters.AddWithValue("rfc", maquileroGuardar.rfc);
                    cmd.Parameters.AddWithValue("direccion_facturacion", maquileroGuardar.direccion_facturacion);
                    cmd.Parameters.AddWithValue("cp_facturacion", maquileroGuardar.cp_facturacion);
                    cmd.ExecuteNonQuery();
                    GuardaFamiliaMaquilero(cmd, familiaPrendas, maquileroGuardar.id_maquilero);
                    tran.Commit();
                    cn.Close();
                    return true;
                }
                catch (Exception ex)
                {

                    tran.Rollback();
                    cn.Close();
                    return false;
                }
            }
        }
        private void GuardaFamiliaMaquilero(SqlCommand cmd, List<EFamiliaPrendas> familias, int id_maquilero)
        {
            foreach (var item in familias)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "produccion_maquilero_familia_guarda";
                cmd.Parameters.AddWithValue("id_maquilero", id_maquilero);
                cmd.Parameters.AddWithValue("id_familia", item.id_familia_prenda);
                cmd.Parameters.AddWithValue("capacidad_semanal", item.capacidad_semanal);
                cmd.ExecuteNonQuery();


            }
        }
        public static List<EFamiliaPrendas> familiaspormaquilero(int id_maquilero)
        {
            List<EFamiliaPrendas> lst = new List<EFamiliaPrendas>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("produccion_familia_prendas_maquilero_consulta", cn) { CommandType = System.Data.CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_maquilero", id_maquilero);
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    lst.Add(new EFamiliaPrendas()
                    {
                        id_familia_prenda = Convert.ToInt32(rd["id_familia_prenda"]),
                        nombre = rd ["nombre"].ToString(),
                        capacidad_semanal = Convert.ToInt32(rd["capacidad_semanal"])
                    });

                }
                return lst;
            }
        }
    }
}
