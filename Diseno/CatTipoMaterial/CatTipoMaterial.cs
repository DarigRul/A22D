using Datos.Diseno;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Diseno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALTIMA_ERP_2022.Diseno.CatTipoMaterial
{
    public partial class CatTipoMaterial : OfficeForm
    {
        private List<EMaterialTipo> lstMaterialTipo = new List<EMaterialTipo>();
        private GridPanel panel;
        public CatTipoMaterial()
        {
            InitializeComponent();
        }

        private void CatalogoTipoMaterial_Load(object sender, EventArgs e)
        {
            //Instanciamos la capa de datos y obtenemos la lista que será fuente de datos para el supergrid
            var dc = new DMaterialTipo();
            lstMaterialTipo = dc.ListaMaterialTipo();

            // Asignamos el gridpanel al PrimaryGrid y asignamos la fuente de datos
            panel = sgcMaterialTipo.PrimaryGrid;
            panel.DataSource = lstMaterialTipo;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var ntm = new Diseno.CatTipoMaterial.CatTipoMaterialAM();
            ntm.refrescar += () => CatalogoTipoMaterial_Load(this, EventArgs.Empty);
            ntm.movimiento = CatTipoMaterialAM.Movimiento.agregar;
            ntm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la fila seleccionada
            GridRow row = panel.ActiveRow as GridRow;

            //Obtenemos el id_color y lo buscamos en la lista de colores (es la fuente del supegrid)
            int id_material_tipo = Convert.ToInt32(row["id_material_tipo"].Value);
            var materialTipoModificar = lstMaterialTipo.Find(x => x.id_material_tipo == id_material_tipo);

            //Instanciamos el formulario y asignamos sus valores
            var ctm = new CatTipoMaterialAM();
            ctm.materialTipoModificar = materialTipoModificar;
            ctm.movimiento = CatTipoMaterialAM.Movimiento.modificar;

            //Escuchamos el delegado para refrescar la pantalla del catálogo
            ctm.refrescar += () => CatalogoTipoMaterial_Load(this, EventArgs.Empty);

            //Mostramos el formulario con los datos pasados 
            ctm.ShowDialog();
        }
        private void btnActivar_Click(object sender, EventArgs e)
        {

            //Preguntamos al usuario si quiere activar el color 
            DialogResult dr = MessageBoxEx.Show("Se activará el Material Tipo, ¿Está seguro?", "Activar color", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_color
                var row = panel.ActiveRow as GridRow;
                int id_material_tipo = Convert.ToInt32(row["id_material_tipo"].Value);

                //Activamos el color 
                var dc = new DMaterialTipo();
                dc.ActivarMaterialTipos(id_material_tipo);
                CatalogoTipoMaterial_Load(this, EventArgs.Empty);

            }
        }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar el color 
            DialogResult dr = MessageBoxEx.Show("Se desactivará el Material Tipo, ¿Está seguro?", "desactivar color", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_color
                var row = panel.ActiveRow as GridRow;
                int id_material_tipo = Convert.ToInt32(row["id_material_tipo"].Value);

                //Activamos el color 
                var dc = new DMaterialTipo();
                dc.DesactivarMaterialTipos(id_material_tipo);
                CatalogoTipoMaterial_Load(this, EventArgs.Empty);

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
        private void sgcMaterialTipos_SelectionChanged(object sender, GridEventArgs e)
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
        private void sgcMaterialTipo_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
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
            MessageBoxEx.Show("REPORTE PENDIENTE POR PROGRAMAR", "REPORTE PENDIENTE", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            //Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcMaterialTipo, "catalogo_material_tipo");
        }
    }
}
