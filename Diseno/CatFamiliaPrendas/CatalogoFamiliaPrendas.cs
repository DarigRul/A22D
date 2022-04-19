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
using Entidades.Diseno;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;
using Datos.Utilitarios.Historico;
using ALTIMA_ERP_2022.Diseno.CatFamiliaPrendas;
namespace ALTIMA_ERP_2022.Diseno.CatFamiliaPrendas
{
    public partial class CatalogoFamiliaPrendas : OfficeForm
    {

        public int ID_Aux = 0;
        private List<EFamiliaPrendas> lstPrendas = new List<EFamiliaPrendas>();
        private GridPanel panel;
        public CatalogoFamiliaPrendas()
        {
            InitializeComponent();
            Cargarsgc();
        }

        private void CatalogoFamiliaPrendas_Load(object sender, EventArgs e)
        {
            try
            {
                //llamada a stord procedure para llenar el grid de informacion de la tabla familia prendas
                lstPrendas = DFamiliaPrendas.GetConsultaDisenoFamiliaPrendas();
                if (lstPrendas != null)
                {
                    if (lstPrendas.Count > 0)
                    {
                        panel = SgcModelo.PrimaryGrid;
                        panel.DataSource = lstPrendas;
                        if (ID_Aux != 0)
                        {
                            int contador = 0;
                            foreach (var itm in lstPrendas)
                            {
                                contador += 1;
                                if (itm.id_familia_prenda == ID_Aux)
                                {

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("No existen registros." ,"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxEx.Show("No existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, no existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void superGridControl1_DataBindingComplete(object sender, DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                string estatus = Convert.ToString(row["auxestatus"].Value);

            //Si el estatus es 0, coloreamos la fila completa en rojo y el texto en blanco, además de activar o desactivar los botones  
            if (estatus =="DESACTIVADO")
            {
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;

                    //Configuramos el tipo y color de las letras
                    FontFamily family = new FontFamily("Microsoft Sans Serif");
                    Font f = new Font(family, 8.5f, FontStyle.Bold);

                    row.CellStyles.Default.Font = f;
                    row.CellStyles.Default.TextColor = Color.White;
                    BtnActivar.Enabled = true;
                    BtnDesactivar.Enabled = false;
            }
            else
            {
                    BtnActivar.Enabled = false;
                    BtnDesactivar.Enabled = true;
            }
        }
    }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();

        }
        public void Cargarsgc()
        {
            try
            {
                lstPrendas = DFamiliaPrendas.GetConsultaDisenoFamiliaPrendas();
                if (lstPrendas != null)
                {
                    if (lstPrendas.Count > 0)
                    {
                        panel = SgcModelo.PrimaryGrid;
                        panel.DataSource = lstPrendas;
                    }
                    else
                    {
                        MessageBoxEx.Show("Error, no existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Error, no existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, no existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            //llamada a metodo para generar reporte de familia prendas
            DHistorico.RegistraHistorico("Diseño", "Catálogo de familia prendas", "Procesar Reporte familia prendas", "", "");
            Utilitarios.ConfiguracionGlobal.GeneraReporte(SgcModelo, "catalogo_familia_prendas");
        
        }

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            try
                {
                var row = panel.ActiveRow as GridRow;

                //Preguntamos al usuario si quiere activar la familia prenda


                DialogResult dr = MessageBoxEx.Show("Se activará el registro de familia prenda, ¿Está seguro?", "Activar familia prenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Obtenemos el id_familia_prenda
                    int id_familia_prenda = Convert.ToInt32(row["id_familia_prenda"].Value);
                    string nombre = Convert.ToString(row["nombre"].Value);
                    string codigo = Convert.ToString(row["codigo"].Value);
                    string ubicacion = Convert.ToString(row["ubicacion"].Value);

                    //llamamos funcion para habilitar familia prenda
                    DFamiliaPrendas.SetHabilitarDeshabilitarFamiliaPrendas(id_familia_prenda, 1);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de familia prendas", "Activar prenda", "", id_familia_prenda + "/" + nombre + "/" + codigo + "/" + ubicacion);
                    CatalogoFamiliaPrendas_Load(this, EventArgs.Empty);
                }
            }
            catch(Exception)
            {
                MessageBoxEx.Show("Verifique todos los campos", "Los campos no pueden estar vacíos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar la familia prenda
            DialogResult dr = MessageBoxEx.Show("Se desactivará el registro de familia prenda, ¿Está seguro?", "Desactivar familia prenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_familia_prenda
                var row = panel.ActiveRow as GridRow;
                int id_familia_prenda = Convert.ToInt32(row["id_familia_prenda"].Value);
                string nombre = Convert.ToString(row["nombre"].Value);
                string codigo = Convert.ToString(row["codigo"].Value);
                string ubicacion = Convert.ToString(row["ubicacion"].Value);
                ID_Aux = id_familia_prenda;
                //llamamos funcion para deshabilitar familia prenda
                DFamiliaPrendas.SetHabilitarDeshabilitarFamiliaPrendas(id_familia_prenda, 0);
                DHistorico.RegistraHistorico("Diseño", "Catálogo de familia prendas", "Desactivar prenda", "", id_familia_prenda + "/" + nombre + "/" + codigo + "/" + ubicacion);
                CatalogoFamiliaPrendas_Load(this, EventArgs.Empty);
            }
        }
        private bool Estatus(GridRow row)
        {
            // recuperar el estatus del registro seleccionado
            string estatus = Convert.ToString(row["auxestatus"].Value);
            if (estatus != "DESACTIVADO")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SgcModelo_SelectionChanged(object sender, GridEventArgs e)
        {
            // En este evento activamos o desactivamos los botones "Activar" o "Desactivar"
            var row = panel.ActiveRow as GridRow;
            if (Estatus(row))
            {
                BtnActivar.Enabled = false;
                BtnDesactivar.Enabled = true;
            }
            else
            {
                BtnActivar.Enabled = true;
                BtnDesactivar.Enabled = false;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatFamiliaPrendas.FamiliaPrendas);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                var row = panel.ActiveRow as GridRow;
                int id_familia_prenda = Convert.ToInt32(row["id_familia_prenda"].Value);
                string nombre = Convert.ToString(row["nombre"].Value);
                string codigo = Convert.ToString(row["codigo"].Value);
                string ubicacion = Convert.ToString(row["ubicacion"].Value);
              
                var nuevoGenero = new Diseno.CatFamiliaPrendas.FamiliaPrendas(id_familia_prenda, nombre, codigo, ubicacion, "Alta");
                nuevoGenero.refrescar += () => CatalogoFamiliaPrendas_Load(this, EventArgs.Empty);
                nuevoGenero.ShowDialog();

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatFamiliaPrendas.FamiliaPrendas);
                if (frm != null)
                {
                    frm.BringToFront();
                    return;
                }
                else
                {
                    var row = panel.ActiveRow as GridRow;
                    string estatus = Convert.ToString(row["auxestatus"].Value);
                    //condicion para evaluar que el registro sea diferente a desactivado, con la finalidad de abrir la forma para actualizar el registro
                    if (estatus != "DESACTIVADO")
                    {
                        int id_familia_prenda = Convert.ToInt32(row["id_familia_prenda"].Value);
                        string nombre = Convert.ToString(row["nombre"].Value);
                        string codigo = Convert.ToString(row["codigo"].Value);
                        string ubicacion = Convert.ToString(row["ubicacion"].Value);
                        var nuevoGenero = new Diseno.CatFamiliaPrendas.FamiliaPrendas(id_familia_prenda, nombre, codigo, ubicacion, "Modificacion");
                        //al finalizar con exito la actualizacion, se ejecuta el evento action, el cual recarga de manera inmediata el supergrid, para poder visualizar la informacion actualizada
                        nuevoGenero.refrescar += () => CatalogoFamiliaPrendas_Load(this, EventArgs.Empty);
                        nuevoGenero.ShowDialog();
                    }
                    else
                    {
                        MessageBoxEx.Show("Error, no se puede editar el registro", "El registro está desactivado y no puede ser modificado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, no se puede editar el registro", "Ocurrio un error inesperado.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEstandaresCostura_Click(object sender, EventArgs e)
        {
            //Obtenemos la fila seleccionada
            GridRow row = panel.ActiveRow as GridRow;

            //Obtenemos el id_color y lo buscamos en la lista de colores (es la fuente del supegrid)
            int id_familia_prenda = Convert.ToInt32(row["id_familia_prenda"].Value);
            var prendaModificar = lstPrendas.Find(x => x.id_familia_prenda == id_familia_prenda);

            //Instanciamos el formulario y asignamos sus valores
            var ctm = new CatalogoFamiliaPrendasEnsambles();
            ctm.prendaModificar = prendaModificar;

            //Escuchamos el delegado para refrescar la pantalla del catálogo
            ctm.refrescar += () => CatalogoFamiliaPrendas_Load(this, EventArgs.Empty);

            //Mostramos el formulario con los datos pasados 
            ctm.ShowDialog();
        }
    }
}
