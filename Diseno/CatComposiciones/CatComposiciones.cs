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

namespace ALTIMA_ERP_2022.Diseno.CatComposiciones
{
    public partial class CatComposiciones : Office2007Form
    {
        public CatComposiciones()
        {
            InitializeComponent();
        }
        GridPanel panel;
        List<EComposicion> lstComposiciones = new List<EComposicion>();
        private void CatComposiciones_Load(object sender, EventArgs e)
        {
            lstComposiciones = DComposicion.ListarComposiciones();
            panel = sgcComposiciones.PrimaryGrid;
            panel.DataSource = lstComposiciones;
        }

        private void superGridControl1_DataBindingComplete(object sender, DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs e)
        {
            Font fuente = new Font(FontFamily.GenericSansSerif, 8.5f, FontStyle.Bold);

            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["Estatus"].Value);

                if (estatus == 0)
                {
                    row["Estatus_Texto"].Value = "DESACTIVADO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                    row.CellStyles.Default.Font = fuente;
                }
                else
                {
                    row["Estatus_Texto"].Value = "ACTIVO";
                }
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow fila = FilaSeleccionada();
            if (fila != null)
            {
                DialogResult dr = MessageBoxEx.Show("Se desactivará la composición seleccionada, ¿Está seguro?", "Desactivar composición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int id_composicion = Convert.ToInt32(fila["id_composicion"].Value);
                    DComposicion.DesactivaComposicion(id_composicion);
                    DHistorico.RegistraHistorico("Diseño", "Composiciòn", "Desactivar composición", "", fila["nombre"].Value.ToString(), "");

                    CatComposiciones_Load(this, EventArgs.Empty);
                }
            }
        }
        private GridRow FilaSeleccionada()
        {
            //Obtenemos la fila seleccionada
            GridRow fila = panel.ActiveRow as GridRow;
            if (fila != null)
            {
                return fila;
            }
            else
            {
                return null;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void sgcComposiciones_SelectionChanged(object sender, GridEventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (Convert.ToInt32(row["Estatus"].Value) == 0)
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

        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow fila = FilaSeleccionada();
            if (fila != null)
            {
                DialogResult dr = MessageBoxEx.Show("Se activará la composición seleccionada, ¿Está seguro?", "Activar composición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int id_composicion = Convert.ToInt32(fila["id_composicion"].Value);
                    DComposicion.ActivaComposicion(id_composicion);

                    DHistorico.RegistraHistorico("Diseño", "Familia composición", "Activar composición", "", fila["nombre"].Value.ToString(), "");

                    CatComposiciones_Load(this, EventArgs.Empty);
                }

            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var nuevaComposicion = new ComposicionesAM();
            nuevaComposicion.movimiento = ComposicionesAM.Movimiento.agregar;
            nuevaComposicion.refrescar += () => CatComposiciones_Load(this, EventArgs.Empty);
            nuevaComposicion.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            var editaComposicion = new ComposicionesAM();
            editaComposicion.movimiento = ComposicionesAM.Movimiento.modificar;
            editaComposicion.ce = (EComposicion)row.DataItem;
            editaComposicion.refrescar += () => CatComposiciones_Load(this, EventArgs.Empty);
            editaComposicion.ShowDialog();
        }
    }
}
