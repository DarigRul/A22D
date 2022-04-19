using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALTIMA_ERP_2022.Utilitarios
{
    public static class SuperGridAnidadoConfiguracion
    {
        //clase creada para configurar los supergrids anidados de un catalago
        public static void configuracolumnas(GridPanel panel)
        {
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            panel.Filter.Visible = true;
            panel.Filter.RowHeight = 20;
            panel.EnableFiltering = true;
            panel.EnableRowFiltering = true;
            panel.ShowRowHeaders = false;
            panel.EnableColumnFiltering = true;

            foreach (GridColumn i in panel.Columns)
            {
                i.AllowEdit = false;
                i.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
                i.FilterAutoScan = true;
                i.FilterEditType = FilterEditType.TextBox;
                i.FilterMatchType = FilterMatchType.RegularExpressions;
                i.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;

            }
        }
    }
}
