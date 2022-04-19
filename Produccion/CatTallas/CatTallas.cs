using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Produccion;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Produccion;

namespace ALTIMA_ERP_2022.Produccion.CatTallas
{
    public partial class CatTallas : OfficeForm
    {
        private List<ETallas> lstTallas = new List<ETallas>();
        private GridPanel panel; 

        public CatTallas()
        {
            InitializeComponent();
        }
        private void CatTallas_Load(object sender, EventArgs e)
        {
            panel = sgcTallas.PrimaryGrid;
            lstTallas = DTallas.Listar();
            panel.DataSource = lstTallas;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var tn = new TallasAM();
            tn.movimiento = TallasAM.Movimiento.agegar;
            tn.refrescar += () => CatTallas_Load(this, EventArgs.Empty);
            tn.ShowDialog(); 

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                var tm = row.DataItem as ETallas;
                var t = new TallasAM();
                t.movimiento = TallasAM.Movimiento.modificar;
                t.tm = tm;
                t.refrescar += () => CatTallas_Load(this, EventArgs.Empty);
                t.ShowDialog(); 
            }
            else
            {
                MessageBoxEx.Show("Seleccione una talla", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                DialogResult dr = MessageBoxEx.Show("Se activará la talla\n\r¿Está seguro?", "Activar talla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var t = (ETallas)row.DataItem;
                    t.estatus = 1;
                    DTallas.CambiaEstatus(t);
                    CatTallas_Load(this, EventArgs.Empty);
                }
            }
            else
            {
                MessageBoxEx.Show("Seleccione una talla", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                DialogResult dr =  MessageBoxEx.Show("Se desactivará la talla\n\r¿Está seguro?", "Desactivar talla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var t = (ETallas)row.DataItem;
                    t.estatus = 0;
                    DTallas.CambiaEstatus(t);
                    CatTallas_Load(this, EventArgs.Empty); 
                }
            }
            else
            {
                MessageBoxEx.Show("Seleccione una talla", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcTallas,"catalogo_tallas");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void sgcTallas_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row.Cells["estatus"].Value);
                Font fuente = new Font(FontFamily.GenericSansSerif, 8.25f, FontStyle.Bold);
                
                if (estatus == 0)
                {
                    row.Cells["estatus_texto"].Value = "INACTIVO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                    row.CellStyles.Default.Font = fuente; 
                }
                else
                {
                    row.Cells["estatus_texto"].Value = "ACTIVADO";
                    
                }
            }
        }

        private void sgcTallas_SelectionChanged(object sender, GridEventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            var _et = row.DataItem as ETallas;
            if (_et.estatus == 0)
            {
                btnDesactivar.Enabled = false;
                btnEditar.Enabled = false;
                btnActivar.Enabled = true; 
            }
            else
            {
                btnDesactivar.Enabled = true;
                btnEditar.Enabled = true;
                btnActivar.Enabled = false; 
            }
        }
    }
}
