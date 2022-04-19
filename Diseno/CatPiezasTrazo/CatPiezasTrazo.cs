using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Diseno;
using Datos.Diseno;
using Datos.Utilitarios.Historico; 

namespace ALTIMA_ERP_2022.Diseno.CatPiezasTrazo
{
    public partial class CatPiezasTrazo : OfficeForm
    {
        List<EPiezasTrazo> lstPiezas = new List<EPiezasTrazo>();
        GridPanel panel; 

        public CatPiezasTrazo()
        {
            InitializeComponent();
        }

        private void CatPiezasTrazo_Load(object sender, EventArgs e)
        {
            panel = sgcPiezas.PrimaryGrid;
            lstPiezas = DPiezasTrazo.ListarPiezasTrazo();
            panel.DataSource = lstPiezas; 
        }

        private void sgcPiezas_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);
                //Font fuente = new Font(FontFamily.GenericSansSerif, 8.5f); 
                
                if (estatus == 0)
                {
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                    row["estatus_texto"].Value = "DESACTIVADO"; 
                }
                else
                {
                    row["estatus_texto"].Value = "ACTIVADO"; 
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var np = new PiezasTrazoAM();
            np.movimiento = PiezasTrazoAM.Movimiento.agregar;
            np.refrescar += () => CatPiezasTrazo_Load(this, EventArgs.Empty);
            np.ShowDialog(); 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            var pieza = (EPiezasTrazo)row.DataItem;
            var pt = new PiezasTrazoAM();
            pt.movimiento = PiezasTrazoAM.Movimiento.modificar;
            pt.ePieza = pieza;
            pt.refrescar += () => CatPiezasTrazo_Load(this, EventArgs.Empty);
            pt.ShowDialog(); 
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            var pieza = (EPiezasTrazo)row.DataItem;
            DialogResult dr = MessageBoxEx.Show("Se activará la pieza de trazo seleccionada\r\n¿Está seguro?", "Activación de trazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DPiezasTrazo.ActivaPieza(pieza);
                CatPiezasTrazo_Load(this, EventArgs.Empty);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            var pieza = (EPiezasTrazo)row.DataItem;
            DialogResult dr = MessageBoxEx.Show("Se desactivará la pieza de trazo seleccionada\r\n¿Está seguro?", "Desactivación de trazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DPiezasTrazo.DesactivaPieza(pieza);
                CatPiezasTrazo_Load(this, EventArgs.Empty);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcPiezas, "piezas_trazo"); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }

        private void sgcPiezas_SelectionChanged(object sender, GridEventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            var pieza = (EPiezasTrazo)row.DataItem;
            if (pieza.estatus == 0)
            {
                btnDesactivar.Enabled = false;
                btnActivar.Enabled = true; 
            }
            else
            {
                btnDesactivar.Enabled = true;
                btnActivar.Enabled = false; 
            }
        }
    }
}
