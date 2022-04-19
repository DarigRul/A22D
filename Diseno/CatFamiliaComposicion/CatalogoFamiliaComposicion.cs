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

namespace ALTIMA_ERP_2022.Diseno.CatFamiliaComposicion
{
    public partial class CatalogoFamiliaComposicion : Office2007Form
    {
        public CatalogoFamiliaComposicion()
        {
            InitializeComponent();
        }
        GridPanel panel;
        List<EFamiliaComposicion> lstFamilaComposicion = new List<EFamiliaComposicion>();
        private void CatalogoFamiliaComposicion_Load(object sender, EventArgs e)
        {
            lstFamilaComposicion= DFamiliaComposicion.ListarFamilias();
            panel = sgcFamiliaComposicion.PrimaryGrid;
            panel.DataSource = lstFamilaComposicion;


        }

        private void sgcFamiliaComposicion_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
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
                }
                else
                {
                    row["estatus_texto"].Value = "ACTIVO";
                }
              
            }
            switch (panelactual.Name)
            {
                case "eComposiciones":
                    Utilitarios.SuperGridAnidadoConfiguracion.configuracolumnas(panelactual);
                    panelactual.AllowEdit = false;
                    panelactual.Columns["id_composicion"].Visible = false;
                    panelactual.Columns["estatus"].Visible = false;
                    panelactual.Columns["nombre"].HeaderText = "Composiciòn";
                    panelactual.Caption.Visible = true;
                    panelactual.Caption.Text = "Composiciones de la familia";
                    break;
                case "eInstruccionesCuidados":
                    Utilitarios.SuperGridAnidadoConfiguracion.configuracolumnas(panelactual);
                    panelactual.AllowEdit = false;
                    panelactual.Columns["id_instruccion_cuidado"].Visible = false;
                    panelactual.Columns["simbolo"].Visible = false;
                    panelactual.Columns["estatus"].Visible = false;
                    panelactual.Columns["nombre"].HeaderText = "Instrucción de cuidado";
                    panelactual.Caption.Visible = true;
                    panelactual.Caption.Text = "Instrucciones de cuidado de la familia";
                    break;


            }
        }
 

        private void sgcFamiliaComposicion_BeforeExpand(object sender, GridBeforeExpandEventArgs e)
        {
            GridRow r = (GridRow)panel.ActiveRow;
            EFamiliaComposicion item = (EFamiliaComposicion)r.DataItem;
            if (item.eComposiciones.Count == 0)
            {
             
                List<EComposicion> composiciones = DFamiliaComposicion.consultaComposicionesPorFamilia((int)r[id_familia_composicion].Value);
                List<EInstruccionesCuidado> instruccionescuidado = DFamiliaComposicion.consultaInstruccionesCuidadoPorFamilia((int)r[id_familia_composicion].Value);
                item.eComposiciones = composiciones;
                item.eInstruccionesCuidados = instruccionescuidado;
         
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frmnuevo = new FamiliaComposicionAM();
            frmnuevo.movimiento = FamiliaComposicionAM.Movimiento.agregar;
            frmnuevo.refrescar += () => CatalogoFamiliaComposicion_Load(this, EventArgs.Empty);
            frmnuevo.ShowDialog();
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

        private void sgcFamiliaComposicion_SelectionChanged(object sender, GridEventArgs e)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            var editafamilia = new FamiliaComposicionAM();
            editafamilia.movimiento = FamiliaComposicionAM.Movimiento.modificar;
            EFamiliaComposicion fedit = (EFamiliaComposicion)row.DataItem;
            //Llenamos las listas si vienen vacias
            if (fedit.eInstruccionesCuidados.Count == 0)
            {
                fedit.eInstruccionesCuidados = DFamiliaComposicion.consultaInstruccionesCuidadoPorFamilia(fedit.id_familia_composicion);
            }
            if (fedit.eComposiciones.Count == 0)
            {
                fedit.eComposiciones = DFamiliaComposicion.consultaComposicionesPorFamilia(fedit.id_familia_composicion);
            }
            
            editafamilia.familiaComposicion = fedit;

            editafamilia.refrescar += () => CatalogoFamiliaComposicion_Load(this, EventArgs.Empty);
            editafamilia.ShowDialog();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            EFamiliaComposicion fedit = (EFamiliaComposicion)row.DataItem;
            if (DFamiliaComposicion.DesactivaFamiliaCoposicion(fedit) ==0)
            {
                // Registramos el historico
                DHistorico.RegistraHistorico("Diseno", "Familia de Composiciones", "desactivar composición", fedit.nombre);
        
                MessageBoxEx.Show("Familia de composición desactivada correctamente", "Familia de Composición desactivada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CatalogoFamiliaComposicion_Load(this, EventArgs.Empty);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            EFamiliaComposicion fedit = (EFamiliaComposicion)row.DataItem;
            if (DFamiliaComposicion.ActivarFamiliaCoposicion(fedit) == 0)
            {
                // Registramos el historico
                DHistorico.RegistraHistorico("Diseno", "Familia de Composiciones", "Activar composición", fedit.nombre);
                
                MessageBoxEx.Show("Familia de composición activada correctamente", "Familia de Composición activada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CatalogoFamiliaComposicion_Load(this, EventArgs.Empty);
            }
        }
    }
}
