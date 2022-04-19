using Datos.Diseno;
using Datos.Utilitarios.Historico;
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
using ALTIMA_ERP_2022.Diseno.CatFamiliaPrendas;
namespace ALTIMA_ERP_2022.Diseno.CatMarcadores
{
    public partial class CatalogoMarcadores : OfficeForm
    {
        private GridPanel panel;
        private  List<EMarcadores> lstMarcadores = new List<EMarcadores>();
        public CatalogoMarcadores()
        {
            InitializeComponent();
            Cargar();
        }
        private void Cargar()
        {
            try
            {
                lstMarcadores = DMarcadores.GetConsultaDisenoMarcadores();
                if (lstMarcadores != null)
                {
                    if (lstMarcadores.Count > 0)
                    {
                        panel = sgcMarcadores.PrimaryGrid;
                        panel.DataSource = lstMarcadores;
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
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        private void CatalogoMarcadores_Load(object sender, EventArgs e)
        {
            try
            {
                lstMarcadores = DMarcadores.GetConsultaDisenoMarcadores();
                if (lstMarcadores != null)
                {
                    if (lstMarcadores.Count > 0)
                    {
                        panel = sgcMarcadores.PrimaryGrid;
                        panel.DataSource = lstMarcadores;
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
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void BtnActivar_Click(object sender, EventArgs e)
            {
                //Preguntamos al usuario si quiere activar marcador
                try
                { 
                    DialogResult dr = MessageBoxEx.Show("Se activará el registro de marcador, ¿Está seguro?", "Activar marcador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //Obtenemos el id_familia_prenda
                        var row = panel.ActiveRow as GridRow;
                        int id_marcador = Convert.ToInt32(row["id_marcador"].Value);
                        string nombre = Convert.ToString(row["nombre"].Value);
             
                        //llamamos funcion para habilitar familia prenda
                        DMarcadores.SetHabilitarDeshabilitarMarcadores(id_marcador, 1);
                        DHistorico.RegistraHistorico("Diseño", "Catálogo de marcadores", "Activar marcador", "", id_marcador + "/" + nombre);
                        CatalogoMarcadores_Load(this, EventArgs.Empty);
                    }
                }
                catch (Exception)
                {
                    MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        private void BtnDesactivad_Click(object sender, EventArgs e)
        {
            try
            { 
                //Preguntamos al usuario si quiere activar el marcador
                DialogResult dr = MessageBoxEx.Show("Se desactivará el registro de marcadores, ¿Está seguro?", "Desactivar marcador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Obtenemos el id marcador
                    var row = panel.ActiveRow as GridRow;
                    int id_marcador = Convert.ToInt32(row["id_marcador"].Value);
                    string nombre = Convert.ToString(row["nombre"].Value);


                    //llamamos funcion para desactivar marcador
                    DMarcadores.SetHabilitarDeshabilitarMarcadores(id_marcador, 0);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de marcadores", "Desactivar marcador", "", id_marcador + "/" + nombre);
                    CatalogoMarcadores_Load(this, EventArgs.Empty);
                }
            }
            catch(Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void sgcMarcadores_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                string estatus = Convert.ToString(row["auxestatus"].Value);

                //Si el estatus es 0, coloreamos la fila completa en rojo y el texto en blanco 
                if (estatus == "DESACTIVADO")
                {
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;

                    //Configuramos el tipo y color de las letras
                    FontFamily family = new FontFamily("Microsoft Sans Serif");
                    Font f = new Font(family, 8.5f, FontStyle.Bold);

                    row.CellStyles.Default.Font = f;
                    row.CellStyles.Default.TextColor = Color.White;
                    BtnActivar.Enabled = true;
                    BtnDesactivad.Enabled = false;
                }
                else
                {
                    BtnActivar.Enabled = false;
                    BtnDesactivad.Enabled = true;
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatMarcadores.Marcadores);
                if (frm != null)
                {
                    frm.BringToFront();
                    return;
                }
                else
                {
                    var row = panel.ActiveRow as GridRow;
                    string estatus = Convert.ToString(row["auxestatus"].Value);
                    if (estatus != "DESACTIVADO")
                    {
                        int id_marcador = Convert.ToInt32(row["id_marcador"].Value);
                        string nombre = Convert.ToString(row["nombre"].Value);

                        var nuevoGenero = new Marcadores(id_marcador, nombre, "Modificacion");
                        nuevoGenero.refrescar += () => CatalogoMarcadores_Load(this, EventArgs.Empty);
                        nuevoGenero.ShowDialog();
                    }
                    else
                    {
                        MessageBoxEx.Show("Error, no se puede editar el registro", "El registro está desactivado y no puede ser modificado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DHistorico.RegistraHistorico("Diseño", "Catálogo de marcadores", "Procesar Reporte marcadores", "", "");
                Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcMarcadores, "catalogo_marcadores");
            }
            catch(Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
         try
            {
                var nuevoGenero = new Marcadores(0,"","Alta");
                nuevoGenero.refrescar += () => CatalogoMarcadores_Load(this, EventArgs.Empty);
                nuevoGenero.ShowDialog();
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void sgcMarcadores_SelectionChanged(object sender, GridEventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            if (Estatus(row))
            {
                BtnActivar.Enabled = false;
                BtnDesactivad.Enabled = true;
            }
            else
            {
                BtnActivar.Enabled = true;
                BtnDesactivad.Enabled = false;
            }
        }
        private bool Estatus(GridRow row)
        {
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



        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var nuevoGenero = new Marcadores(0, "", "Alta");
                nuevoGenero.refrescar += () => CatalogoMarcadores_Load(this, EventArgs.Empty);
                nuevoGenero.ShowDialog();
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReporte_Click_1(object sender, EventArgs e)
        {

            try
            {
                DHistorico.RegistraHistorico("Diseño", "Catálogo de marcadores", "Procesar Reporte marcadores", "", "");
                Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcMarcadores, "catalogo_marcadores");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
    }
}
