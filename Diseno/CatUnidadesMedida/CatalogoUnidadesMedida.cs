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
using Datos.Diseno;
using Entidades.Diseno; 

namespace ALTIMA_ERP_2022.Diseno.CatUnidadesMedida
{
    public partial class CatalogoUnidadesMedida : OfficeForm
    {
        private List<EUnidadesMedida> lstUnidades = new List<EUnidadesMedida>();
        GridPanel panel;
        DUnidadesMedida dUnidad = new DUnidadesMedida(); 

        public CatalogoUnidadesMedida()
        {
            InitializeComponent();
        }

        private void CatalogoUnidadesMedida_Load(object sender, EventArgs e)
        {
            lstUnidades = dUnidad.ListarUnidades(); 
            panel = sgcUnidades.PrimaryGrid;
            panel.DataSource = lstUnidades; 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var um = new UnidadesAM();
            um.movimiento = UnidadesAM.Movimiento.agregar;
            um.refrescar += () => CatalogoUnidadesMedida_Load(this, EventArgs.Empty);
            um.ShowDialog(); 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            var eUnidad = (EUnidadesMedida)row.DataItem;

            var modificar = new UnidadesAM();
            modificar.movimiento = UnidadesAM.Movimiento.modificar;
            modificar.eUnidad = eUnidad;
            modificar.refrescar += () => CatalogoUnidadesMedida_Load(this, EventArgs.Empty);
            modificar.ShowDialog(); 
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            var eUnidad = (EUnidadesMedida)row.DataItem; 
            DialogResult rd = MessageBoxEx.Show("Se activará la unidad de medida\r\n¿Está seguro?", "Activar undidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rd == DialogResult.Yes)
            {
                dUnidad.ActivarUnidad(eUnidad);
                CatalogoUnidadesMedida_Load(this, EventArgs.Empty);
            }
            
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            var eUnidad = (EUnidadesMedida)row.DataItem;
            DialogResult rd = MessageBoxEx.Show("Se desactivará la unidad de medida\r\n¿Está seguro?", "Desctivar undidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rd == DialogResult.Yes)
            {
                dUnidad.DesactivarUnidad(eUnidad);
                CatalogoUnidadesMedida_Load(this, EventArgs.Empty);
            }
            
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcUnidades, "unidades_medida"); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }

        private void sgcUnidades_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);
                Font f = new Font(FontFamily.GenericSansSerif, 8.5f); 
                if (estatus == 0)
                {
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White; 
                    row[estatus_texto].Value = "DESACTIVADO";
                    row.CellStyles.Default.Font = f; 
                }
                else
                {
                    row[estatus_texto].Value = "ACTIVADO"; 
                }
            }
        }

        private void sgcUnidades_SelectionChanged(object sender, GridEventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (Convert.ToInt32(row["estatus"].Value) == 1)
            {
                btnActivar.Enabled = false;
                btnDesactivar.Enabled = true; 
            }
            else
            {
                btnActivar.Enabled = true;
                btnDesactivar.Enabled = false;
            }
        }
    }
}
