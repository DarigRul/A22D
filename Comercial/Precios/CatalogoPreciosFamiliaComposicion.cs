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
using Entidades.Comercial.Precios;
using Datos.Comercial;
using Datos.Utilitarios.Historico;

namespace ALTIMA_ERP_2022.Comercial.Precios
{
    public partial class CatalogoPreciosFamiliaComposicion : Office2007Form
    {
        public CatalogoPreciosFamiliaComposicion()
        {
            InitializeComponent();
        }
        GridPanel panel;
        public List<EPrecios> lstPrecios;
        private void CatalogoPreciosFamiliaComposicion_Load(object sender, EventArgs e)
        {
            lstPrecios = DPreciosfamiliacomposicion.ConsultaPrecios();
            panel = sgcPreciosFamiliaComposicion.PrimaryGrid;
            panel.DataSource = lstPrecios;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frmnuevo = new PreciosPorFamiliaAM();
            frmnuevo.movimiento = PreciosPorFamiliaAM.Movimiento.agregar;
            frmnuevo.refrescar += () => CatalogoPreciosFamiliaComposicion_Load(this, EventArgs.Empty);
            frmnuevo.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            GridRow row = FilaSeleccionada();
            EPrecios precioModificar = row.DataItem as EPrecios;


            var frmnuevo = new PreciosPorFamiliaAM();
            frmnuevo.ePrecios = precioModificar;
            frmnuevo.movimiento = PreciosPorFamiliaAM.Movimiento.modificar;
            frmnuevo.refrescar += () => CatalogoPreciosFamiliaComposicion_Load(this, EventArgs.Empty);
            frmnuevo.ShowDialog();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow row = FilaSeleccionada();
            EPrecios precioDesactivar = row.DataItem as EPrecios;
            if (DPreciosfamiliacomposicion.PreciosFamiliaComposicionActualizaEstatus(precioDesactivar, 1) > 0)
            {
                // Registramos el historico
                DHistorico.RegistraHistorico("comercial", "precios familia composicion", "modifica precios", precioDesactivar.familia_composicion.ToString() + ' ' + precioDesactivar.familia_prenda.ToString());
                MessageBoxEx.Show("Precios desctivados correctamente", "Precios desactivados correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CatalogoPreciosFamiliaComposicion_Load(null, null);

            }
        } 

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow row = FilaSeleccionada();
            EPrecios precioDesactivar = row.DataItem as EPrecios;
            if (DPreciosfamiliacomposicion.PreciosFamiliaComposicionActualizaEstatus(precioDesactivar, 0) >0)
            {
                // Registramos el historico
                DHistorico.RegistraHistorico("comercial", "precios familia composicion", "modifica precios", precioDesactivar.familia_composicion.ToString() + ' ' + precioDesactivar.familia_prenda.ToString());
                MessageBoxEx.Show("Precios desctivados correctamente", "Precios desactivados correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CatalogoPreciosFamiliaComposicion_Load(null, null);
         
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcPreciosFamiliaComposicion, "catalogo_precios");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
       
        private void sgcPreciosFamiliaComposicion_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            Font fuente = new Font(FontFamily.GenericSansSerif, 8.5f, FontStyle.Bold);

            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);

                if (estatus == 0)
                {
                    row["estatus_texto"].Value = "DESACTIVADO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                    row.CellStyles.Default.Font = fuente;
                }
                else
                {
                    row["estatus_texto"].Value = "ACTIVO";
                }
            }
            
        }

        private void sgcPreciosFamiliaComposicion_SelectionChanged(object sender, GridEventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (Convert.ToInt32(row["estatus"].Value) == 0)
            {
                btnDesactivar.Enabled = false;
                btnActivar.Enabled = true;
                btnModificar.Enabled = false; 
            }
            else
            {
                btnDesactivar.Enabled = true;
                btnActivar.Enabled = false;
                btnModificar.Enabled = true; 
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
    }
}
