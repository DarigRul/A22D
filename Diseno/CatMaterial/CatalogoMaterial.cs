using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Diseno;
using Datos.Diseno;

namespace ALTIMA_ERP_2022.Diseno.CatMaterial
{
    public partial class CatalogoMaterial: OfficeForm
    {
        private GridPanel panel;
        private List<EMateriales> lstMateriales = new List<EMateriales>();

        public CatalogoMaterial()
        {
            InitializeComponent();
        }

        public void CatalogoMaterial_Load(object sender, EventArgs e)
        {
            //Instanciamos la capa de datos y obtenemos la lista que será fuente de datos para el supergrid
            lstMateriales = DMateriales.ListaMateriales();

            // Asignamos el gridpanel al PrimaryGrid y asignamos la fuente de datos
            panel = sgcMateriales.PrimaryGrid;
            panel.DataSource = lstMateriales;

        }

        public void sgcMaterial_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var ntm = new Diseno.CatMaterial.CatalogoMaterialAM();
            ntm.refrescar += () => CatalogoMaterial_Load(this, EventArgs.Empty);
            ntm.movimiento = CatalogoMaterialAM.Movimiento.agregar;
            ntm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la fila seleccionada
            GridRow row = panel.ActiveRow as GridRow;

            //Obtenemos el id_color y lo buscamos en la lista de colores (es la fuente del supegrid)
            int id_material_tipo = Convert.ToInt32(row["id_material_tipo"].Value);
            var materialTipoModificar = lstMateriales.Find(x => x.id_material_tipo == id_material_tipo);

            //Instanciamos el formulario y asignamos sus valores
            var ctm = new CatalogoMaterialAM();
            ctm.materialModificar = materialTipoModificar;
            ctm.movimiento = CatalogoMaterialAM.Movimiento.modificar;

            //Escuchamos el delegado para refrescar la pantalla del catálogo
            ctm.refrescar += () => CatalogoMaterial_Load(this, EventArgs.Empty);

            //Mostramos el formulario con los datos pasados 
            ctm.ShowDialog();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar marcador
            DialogResult dr = MessageBoxEx.Show("Se activará el registro de materiales, ¿Está seguro?", "Activar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_familia_prenda
                var row = panel.ActiveRow as GridRow;
                int id_material = Convert.ToInt32(row["id_material"].Value);

                //Activamos el color 
                DMateriales.ActivarMaterial(id_material);
                CatalogoMaterial_Load(this, EventArgs.Empty);
            }

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar marcador
            DialogResult dr = MessageBoxEx.Show("Se desactivará el Material, ¿Está seguro?", "Desactivar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_familia_prenda
                var row = panel.ActiveRow as GridRow;
                int id_material = Convert.ToInt32(row["id_material"].Value);

                //Activamos el color 
                DMateriales.DesactivarMaterial(id_material);
                CatalogoMaterial_Load(this, EventArgs.Empty);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcMateriales, "catalogo_materiales");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
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

                //Si hacer_prueba_calidad es 0, Se pondrá el texto de "Si", de lo contrario "No"
                int hacer_prueba_calidad = Convert.ToInt32(row["hacer_prueba_calidad"].Value);
                if(hacer_prueba_calidad == 0)
                {
                    row["prueba_calidad_texto"].Value = "No";
                }
                else
                {
                    row["prueba_calidad_texto"].Value = "Si";
                }

                decimal precio_unitario = Convert.ToInt32(row["precio_unitario"].Value);
                if (precio_unitario > 0)
                {
                    string format_precio_unitario = string.Format("{0:#,##0.00}", precio_unitario);
                    row["precio_unitario_texto"].Value = format_precio_unitario;
                }

                decimal tamano = Convert.ToInt32(row["tamano"].Value);
                if (tamano > 0)
                {
                    string format_tamano = string.Format("{0:#,##0.00}", tamano);
                    row["tamano_texto"].Value = format_tamano;
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
    }
}
