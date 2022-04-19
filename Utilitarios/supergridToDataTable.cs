using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar.SuperGrid;

namespace ALTIMA_ERP_2022.Utilitarios
{
    public static class supergridToDataTable
    {
        public static DataTable ObtenerTabla(SuperGridControl supergrid)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Clear();
            GridPanel panel = supergrid.PrimaryGrid;

            //Creamos las columnas del datatable 
            foreach (GridColumn columna in panel.Columns)
            {
                dt.Columns.Add(columna.Name, typeof(string)); 
            }

            //Agregamos las filas que trae el supergrid 
            foreach (GridRow fila in panel.Rows)
            {
                //Si la fila está filtrada, la agregamos
                if (fila.IsRowFilteredOut==false)
                {
                    DataRow row = dt.NewRow();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        row[dc.ColumnName] = fila[dc.ColumnName].Value;
                    }
                    dt.Rows.Add(row); 
                }
            }

            return dt; 
        }
    }
}
