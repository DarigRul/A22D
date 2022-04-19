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

namespace ALTIMA_ERP_2022.Produccion.CatMaquileros
{
    public partial class CatalogoMaquileros : OfficeForm
    {
        GridPanel panel;
        public CatalogoMaquileros()
        {
            InitializeComponent();
        }
        private void CatalogoMaquileros_Load(object sender, EventArgs e)
        {
            panel = sgcmaquileros.PrimaryGrid;
            panel.DataSource = DMaquileros.maquilaros_consulta();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MaquilerosAM frm = new MaquilerosAM();
            frm.movimiento = MaquilerosAM.Movimiento.agregar;
            frm.ShowDialog();
       
            CatalogoMaquileros_Load(sender, EventArgs.Empty);


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            EMaquileros maquleroeditar = (EMaquileros)row.DataItem;

            MaquilerosAM frm = new MaquilerosAM();
            frm.maquileromodificar = maquleroeditar;
            frm.FamiliasAgregadas = DMaquileros.familiaspormaquilero(maquleroeditar.id_maquilero);
            frm.movimiento = MaquilerosAM.Movimiento.modificar;
            frm.ShowDialog();
            CatalogoMaquileros_Load(sender, EventArgs.Empty);
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow rw = (GridRow)panel.ActiveRow;
            EMaquileros maquileroActualiza = (EMaquileros)rw.DataItem;
            DMaquileros datos = new DMaquileros();
            if (datos.actualizaEstatus(1, maquileroActualiza) > 0)
            {
                MessageBoxEx.Show("El maquilero se activo correctamente", "Maquilero activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CatalogoMaquileros_Load(sender, EventArgs.Empty);
            }
            else
            {
                MessageBoxEx.Show("Ocurrio un error al intentar activar el  maquilero ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow rw = (GridRow)panel.ActiveRow;
            EMaquileros maquileroActualiza = (EMaquileros)rw.DataItem;
            DMaquileros datos = new DMaquileros();
            if (datos.actualizaEstatus(0, maquileroActualiza) > 0)
            {
                MessageBoxEx.Show("El maquilero se desactivo correctamente", "Maquilero desactivado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CatalogoMaquileros_Load(sender, EventArgs.Empty);
            }
            else
            {
                MessageBoxEx.Show("Ocurrio un error al intentar desactivar el  maquilero ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void sgc_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);
                Font fuente = new Font(FontFamily.GenericSansSerif, 8.25f, FontStyle.Bold);

                if (estatus == 1)
                {
                    row.Cells["estatus_texto"].Value = "ACTIVADO";
                }
                else
                {
                    row.Cells["estatus_texto"].Value = "DESACTIVADO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                    row.CellStyles.Default.Font = fuente;
                }
            }
        }

        private void sgcmaquileros_SelectionChanged(object sender, GridEventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                int estatus = Convert.ToInt32(row.Cells["estatus"].Value);
                if (estatus == 0)
                {
                    //El registro está desactivado
                    btnDesactivar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnActivar.Enabled = true;
                }
                else //El registro está activo
                {
                    btnDesactivar.Enabled = true;
                    btnEditar.Enabled = true;
                    btnActivar.Enabled = false;
                }
            }
        }
    }
}
