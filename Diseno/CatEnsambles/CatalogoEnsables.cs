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

namespace ALTIMA_ERP_2022.Diseno.CatEnsambles
{
    public partial class CatalogoEnsables : OfficeForm
    {
        private List<EEnsambles> lstEnsambles = new List<EEnsambles>();
        private GridPanel panel;

        public CatalogoEnsables()
        {
            InitializeComponent();
        }

        private void CatalogoEnsables_Load(object sender, EventArgs e)
        {
            //Instanciamos la capa de datos y obtenemos la lista que será fuente de datos para el supergrid
            lstEnsambles = DEnsambles.getEnsambles();

            // Asignamos el gridpanel al PrimaryGrid y asignamos la fuente de datos
            panel = sgcEnsambles.PrimaryGrid;
            panel.DataSource = lstEnsambles;
        }

        private void sgcEnsambles_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int id_estatus = Convert.ToInt32(row["estatus"].Value);

                //Si el estatus es 0, coloreamos la fila completa en rojo y el texto en blanco 
                if (id_estatus == 0)
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

        private void sgcEnsambles_SelectionChanged(object sender, GridEventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //var ntm = new Diseno.CatTipoMaterial.CatTipoMaterialAM();
            var nE = new Diseno.CatEnsambles.CatalogoEnsablesAM();
            nE.refrescar += () => CatalogoEnsables_Load(this, EventArgs.Empty);
            nE.movimiento = CatalogoEnsablesAM.Movimiento.agregar;
            nE.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la fila seleccionada
            GridRow row = panel.ActiveRow as GridRow;

            //Obtenemos el id_ensamble y lo buscamos en la lista de ensambles (es la fuente del supegrid)
            int id_ensamble = Convert.ToInt32(row["id_ensamble"].Value);
            var ensambleModificar = lstEnsambles.Find(x => x.id_ensamble == id_ensamble);

            //Instanciamos el formulario y asignamos sus valores
            var cE = new CatalogoEnsablesAM();
            cE.ensamblesModificar = ensambleModificar;
            cE.movimiento = CatalogoEnsablesAM.Movimiento.modificar;

            //Escuchamos el delegado para refrescar la pantalla del catálogo
            cE.refrescar += () => CatalogoEnsables_Load(this, EventArgs.Empty);

            //Mostramos el formulario con los datos pasados 
            cE.ShowDialog();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
                {
                var row = panel.ActiveRow as GridRow;
                
                //Preguntamos al usuario si quiere activar la familia prenda
                DialogResult dr = MessageBoxEx.Show("Se activará el registro de Ensamble, ¿Está seguro?", "Activar ensamble", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Obtenemos el id_familia_prenda
                    
                    int id_ensamble = Convert.ToInt32(row["id_ensamble"].Value);
                    
                    string valor_nuevo = "";

                    valor_nuevo += "Descripción: " + Convert.ToString(row["descripcion"].Value) + " / ";
                    valor_nuevo += "Consumo: " + Convert.ToString(row["consumo"].Value) + " / ";
                    valor_nuevo += "Tipo: " + Convert.ToString(row["tipo"].Value) + " / ";

                    //llamamos funcion para habilitar familia prenda
                    DEnsambles.ActivarEnsambles(id_ensamble);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de Ensambles", "Activar ensamble", "", valor_nuevo);
                    CatalogoEnsables_Load(this, EventArgs.Empty);
                }
            }
            catch(Exception)
            {
                MessageBoxEx.Show("Hubo un error al activar el ensamble", "Intentelo más tarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                var row = panel.ActiveRow as GridRow;

                //Preguntamos al usuario si quiere activar la familia prenda
                DialogResult dr = MessageBoxEx.Show("Se activará el registro de Ensamble, ¿Está seguro?", "Activar ensamble", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Obtenemos el id_familia_prenda

                    int id_ensamble = Convert.ToInt32(row["id_ensamble"].Value);

                    string valor_nuevo = "";

                    valor_nuevo += "Descripción: " + Convert.ToString(row["descripcion"].Value) + " / ";
                    valor_nuevo += "Consumo: " + Convert.ToString(row["consumo"].Value) + " / ";
                    valor_nuevo += "Tipo: " + Convert.ToString(row["tipo"].Value) + " / ";

                    //llamamos funcion para habilitar familia prenda
                    DEnsambles.DesactivarEnsambles(id_ensamble);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de Ensambles", "Activar ensamble", "", valor_nuevo);
                    CatalogoEnsables_Load(this, EventArgs.Empty);
                }
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Hubo un error al desactivar el ensamble", "Intentelo más tarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            //llamada a metodo para generar reporte de familia prendas
            DHistorico.RegistraHistorico("Diseño", "Catálogo de ensambles", "Procesar Reporte ensambles", "", "");
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcEnsambles, "catalogo_ensambles");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
