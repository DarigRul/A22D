using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Diseno;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Diseno;

namespace ALTIMA_ERP_2022.Diseno.Produccion.CatRutasProduccion
{
    public partial class CatalogoRutasProduccion : OfficeForm
    {
        GridPanel panel;
        public CatalogoRutasProduccion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RutasProduccionAM frm = new RutasProduccionAM();
            frm.movimiento = RutasProduccionAM.Movimiento.agregar;
            frm.ShowDialog();
            CatalogoRutasProduccion_Load(sender, EventArgs.Empty);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow rw = panel.ActiveRow as GridRow;
            ERutasProduccion rutaactualizar = (ERutasProduccion)rw.DataItem;
            if (rutaactualizar.procesos.Count == 0)
            {
                List<EProcesos> proc = DRutasProduccion.consultaProcesosPorRuta(rutaactualizar.id_ruta);
                rutaactualizar.procesos = proc;
            }

            RutasProduccionAM frm = new RutasProduccionAM();
            frm.movimiento = RutasProduccionAM.Movimiento.modificar;
            frm.rutaModificar = rutaactualizar;
            frm.ShowDialog();
            CatalogoRutasProduccion_Load(sender, EventArgs.Empty);
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow rw = panel.ActiveRow as GridRow;
            ERutasProduccion rutaactualizar = (ERutasProduccion)rw.DataItem;
            if (DRutasProduccion.RutaCambiaEstatus(rutaactualizar, 1) > 0)
            {
                // Registramos el historico
                DHistorico.RegistraHistorico("Diseño", "Ruta de producción", "Activar Ruta producción", rutaactualizar.nombre);

                MessageBoxEx.Show("Ruta de producción activada correctamente", "Ruta de producción activada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CatalogoRutasProduccion_Load(sender, EventArgs.Empty);
            } 

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow rw = panel.ActiveRow as GridRow;
            ERutasProduccion rutaactualizar = (ERutasProduccion)rw.DataItem;
            if (DRutasProduccion.RutaCambiaEstatus(rutaactualizar, 0) > 0)
            {
                // Registramos el historico
                DHistorico.RegistraHistorico("Diseño", "Ruta de producción", "Desactivar Ruta producción", rutaactualizar.nombre);

                MessageBoxEx.Show("Ruta de producción desactivada correctamente", "Ruta de producción desactivada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CatalogoRutasProduccion_Load(sender, EventArgs.Empty);
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


        private void sgcRutasProduccion_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            Font fuente = new Font(FontFamily.GenericSansSerif, 8.5f, FontStyle.Bold);
            GridPanel panelactual = e.GridPanel;
            
            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);

                if (estatus == 0)
                {
                    row["estatus_texto"].Value = "DESACTIVADO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                    row.CellStyles.Default.Font = fuente;
                    btnEditar.Enabled = false;
                    btnDesactivar.Enabled = false;
                }
                else
                {
                    row["estatus_texto"].Value = "ACTIVO";
                    btnEditar.Enabled = true;
                    btnDesactivar.Enabled = true;
                }

            }
            if (panelactual.Name == "procesos")
            {
                //ConfiguraColumnasPanel(panelactual);
                Utilitarios.SuperGridAnidadoConfiguracion.configuracolumnas(panelactual);
                panelactual.AllowEdit = false;
                panelactual.Columns["id_proceso"].Visible = false;
                panelactual.Columns["nombre"].HeaderText = "Proceso";
                panelactual.Columns["tipo"].HeaderText = "Tipo";
                panelactual.Columns["id_departamento"].Visible = false;
                panelactual.Columns["departamento"].Visible = false;
                panelactual.Columns["estatus"].Visible = false;
                panelactual.Caption.Visible = true;

            }



        }

        private void CatalogoRutasProduccion_Load(object sender, EventArgs e)
        {
            List<ERutasProduccion> lstRutas = new List<ERutasProduccion>();
            panel = sgcRutasProduccion.PrimaryGrid;
            lstRutas = DRutasProduccion.RutasListar();
            panel.DataSource = lstRutas;
        }
  

        private void sgcRutasProduccion_BeforeExpand(object sender, GridBeforeExpandEventArgs e)
        {
            GridRow r = (GridRow)panel.ActiveRow;
            ERutasProduccion item = (ERutasProduccion)r.DataItem;
            if (item.procesos.Count == 0)
            {

                List<EProcesos> proc = DRutasProduccion.consultaProcesosPorRuta((int)r[id_ruta].Value);
                item.procesos = proc;

            }
        }

        private void sgcRutasProduccion_SelectionChanged(object sender, GridEventArgs e)
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
