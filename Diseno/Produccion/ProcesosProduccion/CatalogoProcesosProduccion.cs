using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Datos.Diseno;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Diseno;

namespace ALTIMA_ERP_2022.Diseno.Produccion.ProcesosProduccion
{
    public partial class CatalogoProcesosProduccion : OfficeForm
    {
        public EProcesos proceso;
        List<EProcesos> lstProcesos;
        GridPanel panel;

        public CatalogoProcesosProduccion()
        {
            InitializeComponent();
        }

        private void CatalogoProcesosProduccion_Load(object sender, EventArgs e)
        {
            lstProcesos = DProcesos.ProcesosListar();
            panel = sgcProcesos.PrimaryGrid;
            panel.DataSource =  lstProcesos;


        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProcesosProduccionAM frmnew = new ProcesosProduccionAM();
            frmnew.movimiento = ProcesosProduccionAM.Movimiento.agregar;
            frmnew.ShowDialog();
            CatalogoProcesosProduccion_Load(this, EventArgs.Empty);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //CREAMOS LA ENTIDAD A EDITAR
            GridRow row = panel.ActiveRow as GridRow;
            ProcesosProduccionAM frmnew = new ProcesosProduccionAM();
            frmnew.movimiento = ProcesosProduccionAM.Movimiento.modificar;
            frmnew.eProcesos = (EProcesos)row.DataItem;
           
            frmnew.ShowDialog();
            CatalogoProcesosProduccion_Load(this, EventArgs.Empty);

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            EProcesos pedit = (EProcesos)row.DataItem;
            if (DProcesos.procesoActualizaEstatus(pedit.id_proceso,1) > 0)
            {
                // Registramos el historico
                DHistorico.RegistraHistorico("Diseno", "Procesos Produccion", "Activar proceso", pedit.nombre);

                MessageBoxEx.Show("Proceso activado correctamente", "Proceso activado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CatalogoProcesosProduccion_Load(this, EventArgs.Empty);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            EProcesos pedit = (EProcesos)row.DataItem;
            if (DProcesos.procesoActualizaEstatus(pedit.id_proceso, 0) > 0)
            {
                // Registramos el historico
                DHistorico.RegistraHistorico("Diseno", "Procesos Produccion", "Desactivar proceso", pedit.nombre);

                MessageBoxEx.Show("Proceso Desactivado correctamente", "Proceso Desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CatalogoProcesosProduccion_Load(this, EventArgs.Empty);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void sgcProcesos_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);
                Font f = new Font(FontFamily.GenericSansSerif, 8.5f);
                if (estatus == 0)
                {
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                    row[estatus_nombre].Value = "DESACTIVADO";
                    row.CellStyles.Default.Font = f;
                }
                else
                {
                    row[estatus_nombre].Value = "ACTIVADO";
                }
            }
        }

        private void sgcProcesos_SelectionChanged(object sender, GridEventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (Convert.ToInt32(row["estatus"].Value) == 0)
            {
                btnDesactivar.Enabled = false;
                btnActivar.Enabled = true;
                btnEditar.Enabled = false;
            }
            else
            {
                btnDesactivar.Enabled = true;
                btnActivar.Enabled = false;
                btnEditar.Enabled = true;
            }
        }

     
    }
}
