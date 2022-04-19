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
    public class DMaterialesProcesos
    {
        public List<EMaterialesProcesos> ListaMaterialesProcesos()
        {
            List<EMaterialesProcesos> dMaterialProcesos = new List<EMaterialesProcesos>();
            using (SqlConnection cn = DConexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("diseno_material_listar", cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                while (rd.Read())
                {
                    dMaterialProcesos.Add(new EMaterialesProcesos
                    {
                        id_material_proceso = DBNull.Value.Equals(rd["id_material_proceso"]) ? 0 : Convert.ToInt32(rd["id_material_proceso"]),
                        proceso = rd["proceso"].ToString(),
                        tipo = rd["tipo"].ToString(),
                    });
                }
            }
            return dMaterialProcesos;
        }
    }
}
