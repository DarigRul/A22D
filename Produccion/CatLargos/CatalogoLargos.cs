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
using Entidades.Produccion;
using Datos.Produccion;

namespace ALTIMA_ERP_2022.Produccion.CatLargos
{
    public partial class CatalogoLargos : OfficeForm
    {
        GridPanel panel;
        List<ELargos> lstLargos = new List<ELargos>(); 

        public CatalogoLargos()
        {
            InitializeComponent();
        }

        private void CatalogoLargos_Load(object sender, EventArgs e)
        {
            panel = sgcLargos.PrimaryGrid;
            lstLargos = DLargos.Listar();
            panel.DataSource = lstLargos; 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var ln = new LargosAM();
            ln.movimiento = LargosAM.Movimiento.agregar;
            ln.refrescar += () => CatalogoLargos_Load(this, EventArgs.Empty);
            ln.ShowDialog(); 

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                ELargos _elargo = row.DataItem as ELargos; 
                var l = new LargosAM();
                l.lm = _elargo;
                l.movimiento = LargosAM.Movimiento.modificar;
                l.refrescar += ()=>CatalogoLargos_Load(this, EventArgs.Empty);
                l.ShowDialog();
            }
            else
            {
                MessageBoxEx.Show("Seleccione un largo","Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                GridRow row = panel.ActiveRow as GridRow;
                if (row != null)
                {
                    DialogResult dr = MessageBoxEx.Show("Se activará el largo seleccioando\r\n¿Está seguro?", "Activar largo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        var _elargo = row.DataItem as ELargos;
                        _elargo.estatus = 1;
                        DLargos.Estatus(_elargo);
                        CatalogoLargos_Load(this, EventArgs.Empty); 
                    }
                }
                else
                {
                    MessageBoxEx.Show("Seleccione un largo", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\n\r{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                GridRow row = panel.ActiveRow as GridRow;
                if (row != null)
                {
                    DialogResult dr = MessageBoxEx.Show("Se desactivará el largo seleccioando\r\n¿Está seguro?", "Desactivar largo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        var _elargo = row.DataItem as ELargos;
                        _elargo.estatus = 0;
                        DLargos.Estatus(_elargo);
                        CatalogoLargos_Load(this, EventArgs.Empty);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Seleccione un largo", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\n\r{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcLargos, "catalogo_largos"); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }

        private void sgcLargos_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);
                Font fuente = new Font(FontFamily.GenericSansSerif, 8.25f, FontStyle.Bold);

                if(estatus == 1)
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

        private void sgcLargos_SelectionChanged(object sender, GridEventArgs e)
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
