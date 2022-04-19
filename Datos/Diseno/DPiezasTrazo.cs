using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Diseno;
using Datos.Diseno;
using System.Data.SqlClient;
using System.Data; 

namespace Datos.Diseno
{
    public static class DPiezasTrazo
    {
        public static List<EPiezasTrazo> ListarPiezasTrazo()
        {
            List<EPiezasTrazo> lstPiezasTrazo = new List<EPiezasTrazo>(); 
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_piezas_trazo_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lstPiezasTrazo.Add(new EPiezasTrazo
                    {
                        id_pieza_trazo = Convert.ToInt32(rd["id_pieza_trazo"]), 
                        nombre = rd["nombre"].ToString(), 
                        estatus = Convert.ToInt32(rd["estatus"])
                    });
                }
            }
            return lstPiezasTrazo; 
        }

        public static int AgregarPieza(EPiezasTrazo pieza)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_piezas_trazo_agregar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre", pieza.nombre);
                cn.Open();
                return cmd.ExecuteNonQuery(); 
            }
        }
        
        public static int ModificarPieza(EPiezasTrazo pieza)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_piezas_trazo_modificar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_pieza_trazo", pieza.id_pieza_trazo); 
                cmd.Parameters.AddWithValue("nombre", pieza.nombre);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ActivaPieza(EPiezasTrazo pieza)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_piezas_trazo_activar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_pieza_trazo", pieza.id_pieza_trazo);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DesactivaPieza(EPiezasTrazo pieza)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_piezas_trazo_desactivar", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("id_pieza_trazo", pieza.id_pieza_trazo);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Verifica(string nombre)
        {
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_piezas_trazo_verifica", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("nombre", nombre);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

    }
}
