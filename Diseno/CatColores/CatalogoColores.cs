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
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace ALTIMA_ERP_2022.Diseno.CatColores
{
    public partial class CatalogoColores : OfficeForm
    {
        private List<EColor> lstColores = new List<EColor>();

        //Este GridPanel hace referencia al primaryGrid del supergrid
        private GridPanel panel;

        public CatalogoColores()
        {
            InitializeComponent();
        }
      
        private void CatalogoColores_Load(object sender, EventArgs e)
        {
            //Instanciamos la capa de datos y obtenemos la lista que será fuente de datos para el supergrid
            var dc = new DColor();
            lstColores = dc.ListarColores();

            // Asignamos el gridpanel al PrimaryGrid y asignamos la fuente de datos
            panel = sgcColores.PrimaryGrid;
            panel.DataSource = lstColores;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var nc = new Diseno.CatColores.ColorAM();
            nc.refrescar += () => CatalogoColores_Load(this, EventArgs.Empty);
            nc.movimiento = ColorAM.Movimiento.agegar;
            nc.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la fila seleccionada
            GridRow row = panel.ActiveRow as GridRow;

            //Obtenemos el id_color y lo buscamos en la lista de colores (es la fuente del supegrid)
            int id_color = Convert.ToInt32(row["id_color"].Value);
            var colorModificar = lstColores.Find(x => x.id_color == id_color);

            //Instanciamos el formulario y asignamos sus valores
            var cm = new ColorAM();
            cm.colorModificar = colorModificar;
            cm.movimiento = ColorAM.Movimiento.modificar;

            //Escuchamos el delegado para refrescar la pantalla del catálogo
            cm.refrescar += () => CatalogoColores_Load(this, EventArgs.Empty);

            //Mostramos el formulario con los datos pasados 
            cm.ShowDialog();
        }
        private void btnActivar_Click(object sender, EventArgs e)
        {

            //Preguntamos al usuario si quiere activar el color 
            DialogResult dr = MessageBoxEx.Show("Se activará el color, ¿Está seguro?", "Activar color", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_color
                var row = panel.ActiveRow as GridRow;
                int id_color = Convert.ToInt32(row["id_color"].Value);
                                
                //Activamos el color 
                var dc = new DColor();
                dc.ActivarColor(id_color);
                CatalogoColores_Load(this, EventArgs.Empty);
                
            }
        }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar el color 
            DialogResult dr = MessageBoxEx.Show("Se desactivará el color, ¿Está seguro?", "desactivar color", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_color
                var row = panel.ActiveRow as GridRow;
                int id_color = Convert.ToInt32(row["id_color"].Value);

                //Activamos el color 
                var dc = new DColor();
                dc.DesactivarColor(id_color);
                CatalogoColores_Load(this, EventArgs.Empty);

            }
        }
        private bool Estatus(GridRow row)
        {
            int estatus = Convert.ToInt32(row["estatus"].Value);
            if (estatus == 1)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }
        //Cuando la selccion ha cambiado
        private void sgcColores_SelectionChanged(object sender, GridEventArgs e)
        {
            // En este evento activamos o desactivamos los botones "Activar" o "Desactivar"
            var row = panel.ActiveRow as GridRow;

            //Si el estatus está activado 
            if (Estatus(row))
            {
                btnActivar.Enabled = false;
                btnDesactivar.Enabled = true;
                btnEditar.Enabled = true; 
            }
            else //Estatus desactivado
            {
                btnActivar.Enabled = true;
                btnDesactivar.Enabled = false;
                btnEditar.Enabled = false; 
            }
        }


        //Este evento ocurre cuando ya se termino de cargar la informacion en el super grid
        private void sgcColores_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                //Coloreamos la celda de cada registro en la columna COLOR
                int r, g, b;
                string rgb = row["codigo_color"].Value.ToString();
                string[] codigos = rgb.Split(',');
                r = Convert.ToInt32(codigos[0]);
                g = Convert.ToInt32(codigos[1]);
                b = Convert.ToInt32(codigos[2]);

                row["codigo_color"].CellStyles.Default.Background.Color1 = Color.FromArgb(r, g, b);
                int estatus = Convert.ToInt32(row["estatus"].Value);

                //Si el estatus es 0, coloreamos la fila completa en rojo y el texto en blanco 
                if (estatus == 0)
                {
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;

                    //Configuramos el tipo y color de las letras
                    FontFamily family = new FontFamily("Microsoft Sans Serif");
                    Font f = new Font(family, 8.5f, FontStyle.Bold);

                    row.CellStyles.Default.Font = f;
                    row.CellStyles.Default.TextColor = Color.White;
                    
                    //El estatus en la base de datos es cero y uno, por lo cual agregamos el texto en forma manual 
                    row["estatus_texto"].Value = "DESACTIVADO";
                }
                else
                {
                    row["estatus_texto"].Value = "ACTIVO";
                }

                row.Cells["codigo_color"].CellStyles.Default.TextColor = Color.FromArgb(r, g, b); 
                
            }
        }
        //Metodo para configurar los shortcuts
        private void CatalogoColores_KeyDown(object sender, KeyEventArgs e)
        {
            //Shortcuts
            if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(this, EventArgs.Empty);
            }
            else if (e.Control && e.KeyCode == Keys.A) //Combinacion de teclas Control + A
            {
                btnAgregar_Click(this, EventArgs.Empty);
            }
            else if (e.Control && e.KeyCode == Keys.E) // Combinacion Control + E 
            {
                btnEditar_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnDesactivar_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                btnActivar_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(this, EventArgs.Empty);
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcColores, "catalogo_colores"); 
        }
    }
}
