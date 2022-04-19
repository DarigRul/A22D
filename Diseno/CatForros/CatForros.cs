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
using Datos.Compras;

namespace ALTIMA_ERP_2022.Diseno.CatForros
{
    public partial class CatForros : OfficeForm
    {

        List<EForros> lstForros = new List<EForros>();
        GridPanel panel;

        public CatForros()
        {
            InitializeComponent();
        }

        private void CatForros_Load(object sender, EventArgs e)
        {
            lstForros = DForros.ListarForros();
            panel = sgcForros.PrimaryGrid;
            panel.DataSource = lstForros;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var agregar = new ForrosAM();
            agregar.movimiento = ForrosAM.Movimiento.agregar;
            agregar.refrescar += () => CatForros_Load(this, EventArgs.Empty);
            agregar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Verificamos que este seleccionado un forro
            GridRow row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                EForros eForro = (EForros)row.DataItem;
                var editar = new ForrosAM();
                editar.movimiento = ForrosAM.Movimiento.modificar;
                editar.refrescar += () => CatForros_Load(this, EventArgs.Empty);
                editar.eForro = eForro;
                editar.ShowDialog();
            }
            else
            {
                MessageBoxEx.Show("Seleccione un forro", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                GridRow row = panel.ActiveRow as GridRow;
                if (row != null)
                {
                    EForros f = (EForros)row.DataItem;
                    DialogResult dr = MessageBoxEx.Show($"Se activará el forro {f.nombre}\r\n¿Está seguro?",
                        "Activar forro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        f.estatus = 1;
                        DForros.ActualizaEstatus(f);
                        CatForros_Load(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}",
                    "Error de conexión con la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                GridRow row = panel.ActiveRow as GridRow;
                if (row != null)
                {
                    EForros f = (EForros)row.DataItem;
                    DialogResult dr = MessageBoxEx.Show($"Se desactivará el forro {f.nombre}\r\n¿Está seguro?",
                        "Desactivar forro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        f.estatus = 0;
                        DForros.ActualizaEstatus(f);
                        CatForros_Load(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}",
                    "Error de conexión con la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcForros, "catalogo_forros");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void sgcForros_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            //Recorremos el supergrid 
            foreach (GridRow row in panel.Rows)
            {
                if (Convert.ToInt32(row.Cells["estatus"].Value) == 0)
                {
                    row.Cells["estatus_texto"].Value = "DESACTIVADO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                }
                else
                {
                    row.Cells["estatus_texto"].Value = "ACTIVO";
                }

                if (Convert.ToInt32(row.Cells["prospecto"].Value) == 0)
                {
                    row.Cells["prospecto_texto"].Value = "NO";
                }
                else
                {
                    row.Cells["prospecto_texto"].Value = "SI";
                }

            }
        }

        private void sgcForros_SelectionChanged(object sender, GridEventArgs e)
        {
            //El registro está desactivado
            GridRow row = panel.ActiveRow as GridRow;
            if (Convert.ToInt32(row.Cells["estatus"].Value) == 0)
            {
                btnActivar.Enabled = true;
                btnDesactivar.Enabled = false;
                btnEditar.Enabled = false;
            }
            else //Registro activo
            {
                btnActivar.Enabled = false;
                btnDesactivar.Enabled = true;
                btnEditar.Enabled = true;
            }
        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            try
            {
                var row = panel.ActiveRow as GridRow;
                if (row != null)
                {
                    var forro = row.DataItem as EForros;
                    var calidad = new ForrosPruebasCalidad();
                    calidad.forro = forro;
                    calidad.ShowDialog();
                }
                else
                {
                    MessageBoxEx.Show("Seleccione un forro", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

