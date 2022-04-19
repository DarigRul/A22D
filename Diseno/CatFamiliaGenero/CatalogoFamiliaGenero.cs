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
using CrystalDecisions.CrystalReports.Engine;
using System.Net;
using System.IO;
using ALTIMA_ERP_2022.Utilitarios;

namespace ALTIMA_ERP_2022.Diseno.CatFamiliaGenero
{
    public partial class CatalogoFamiliaGenero : OfficeForm
    {
        List<EFamiliaGenero> lstGeneros = new List<EFamiliaGenero>();
        GridPanel panel; 

        public CatalogoFamiliaGenero()
        {
            InitializeComponent();
        }
        private void CatalogoFamiliaGenero_Load(object sender, EventArgs e)
        {
            lstGeneros = DFamiliaGenero.ListarGeneros(); 
            panel = sgcFamiliaGenero.PrimaryGrid;
            panel.DataSource = lstGeneros; 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevoGenero = new FamliaGeneroAM();
            nuevoGenero.movimiento = FamliaGeneroAM.Movimiento.agregar;
            nuevoGenero.refrescar += () => CatalogoFamiliaGenero_Load(this, EventArgs.Empty);
            nuevoGenero.ShowDialog(); 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            GridRow fila = FilaSeleccionada();
            if (fila != null)
            {
                //Obtenemos los datos de la fila 
                var genero = (EFamiliaGenero)fila.DataItem;
                var modifica = new FamliaGeneroAM();
                modifica.movimiento = FamliaGeneroAM.Movimiento.modificar;
                modifica.refrescar += () => CatalogoFamiliaGenero_Load(this, EventArgs.Empty);
                modifica.genero = genero;
                modifica.ShowDialog(); 
            }
        }
        private void btnActivar_Click(object sender, EventArgs e)
        {
            GridRow fila = FilaSeleccionada();
            if (fila != null)
            {
                DialogResult dr = MessageBoxEx.Show("Se activará el género seleccionado, ¿Está seguro?", "Activar género", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int id_familia_genero = Convert.ToInt32(fila["id_familia_genero"].Value);
                    DFamiliaGenero.ActivaGenero(id_familia_genero);

                    DHistorico.RegistraHistorico("Diseño", "Familia Género", "Activar género", "", fila["nombre"].Value.ToString(), ""); 

                    CatalogoFamiliaGenero_Load(this, EventArgs.Empty); 
                }

            }
        }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            GridRow fila = FilaSeleccionada();
            if (fila != null)
            {
                DialogResult dr = MessageBoxEx.Show("Se desactivará el género seleccionado, ¿Está seguro?", "Desactivar género", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int id_familia_genero = Convert.ToInt32(fila["id_familia_genero"].Value);
                    DFamiliaGenero.DesactivaGenero(id_familia_genero);
                    DHistorico.RegistraHistorico("Diseño", "Familia Género", "Desactivar género", "", fila["nombre"].Value.ToString(), "");

                    CatalogoFamiliaGenero_Load(this, EventArgs.Empty);
                }
            }
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            ConfiguracionGlobal.GeneraReporte(sgcFamiliaGenero, "familia_generos"); 
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

        private void sgcFamiliaGenero_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            Font fuente = new Font(FontFamily.GenericSansSerif, 8.5f, FontStyle.Bold);

            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);

                if (estatus == 0 )
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }

        private void sgcFamiliaGenero_RowActivated(object sender, GridRowActivatedEventArgs e)
        {
            
        }

        private void sgcFamiliaGenero_SelectionChanged(object sender, GridEventArgs e)
        {
            GridRow row = panel.ActiveRow as GridRow;
            if (Convert.ToInt32(row["estatus"].Value) == 0)
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
