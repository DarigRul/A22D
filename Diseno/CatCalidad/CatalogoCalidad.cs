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
using Entidades.Diseno.Calidad;

namespace ALTIMA_ERP_2022.Diseno.CatCalidad
{
    public partial class CatalogoCalidad : OfficeForm
    {
        private GridPanel panel;
        private List<ECalidad> lstCalidad = new List<ECalidad>();
        public CatalogoCalidad()
        {
            InitializeComponent();
        }

        private void CatalogoCalidad_Load(object sender, EventArgs e)
        {
            try
            {
                lstCalidad = DCalidad.GetConsultaDisenoCalidad();
                if (lstCalidad != null)
                {
                    if (lstCalidad.Count > 0)
                    {
                        panel = sgcCalidad.PrimaryGrid;
                        panel.DataSource = lstCalidad;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //se llama ventana de telas para realizar el alta de registro
                ECalidad obj = new ECalidad();
                var nuevoGenero = new ProcesoCalidad(obj,"Alta");//obj,"Alta");// (obj, "Alta");
              //  nuevoGenero.refrescar += () => CatalogoCalidad_Load(this, EventArgs.Empty);
                nuevoGenero.ShowDialog();
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //se llama ventana de telas para realizar el alta de registro
                //ECalidad obj = new ECalidad();
                //var nuevoGenero = new Calidad(obj, "Modificar");// (obj, "Alta");
                //nuevoGenero.refrescar += () => CatalogoCalidad_Load(this, EventArgs.Empty);
                //nuevoGenero.ShowDialog();
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (panel != null)
            {
                //Preguntamos al usuario quiere activar registro calidad
                DialogResult dr = MessageBoxEx.Show("Se activará el registro de registro de calidad, ¿Está seguro?", "Activar registro calidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        //Obtenemos el  id_calidad para despues procesar la activacion del registro de calidad
                   

                            var row = panel.ActiveRow as GridRow;
                            int id_Calidad = Convert.ToInt32(row["id_calidad"].Value);
                            string nombre = Convert.ToString(row["nombre"]);
                            string clave = Convert.ToString(row["clave"]);
                            string detalle = Convert.ToString(row["detalle"]);
                            int id_prueba_encogimiento = Convert.ToInt32(row["id_prueba_encogimiento"]);
                            int id_prueba_lavado_pilling = Convert.ToInt32(row["id_prueba_lavado_pilling"]);
                            int id_prueba_costura = Convert.ToInt32(row["id_prueba_costura"]);
                            int id_prueba_contaminacion_combinaciontelas = Convert.ToInt32(row["id_prueba_contaminacion_combinaciontelas"]);
                            //   metodo para habilitar registro calidad
                            DCalidad.SetHabilitarDeshabilitarCalidad(id_Calidad, 1);
                            DHistorico.RegistraHistorico("Diseño", "Catálogo de calidad", "Activar registro calidad", "", id_Calidad + "/" + nombre + "/" + clave +
                                "/" + detalle + "/" + id_prueba_encogimiento + "/" +
                                 id_prueba_lavado_pilling + "/" + id_prueba_costura + "/" + id_prueba_contaminacion_combinaciontelas);
                            CatalogoCalidad_Load(this, EventArgs.Empty);

                   
                    }
                    catch (Exception)
                    {
                        MessageBoxEx.Show("Error, ocurrio un error inesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("Error, seleccione algun valor.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
             if (panel != null)
             {
                //Preguntamos al usuario si quiere desactivar registro calidad
                DialogResult dr = MessageBoxEx.Show("Se desactivará el registro de calidad, ¿Está seguro?", "Desactivar registro de calidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        //Obtenemos el id_calidad para posteriormente desactivar el registro
                   
                            var row = panel.ActiveRow as GridRow;
                            int id_Calidad = Convert.ToInt32(row["id_calidad"].Value);
                            string nombre = Convert.ToString(row["nombre"]);
                            string clave = Convert.ToString(row["clave"]);
                            string detalle = Convert.ToString(row["detalle"]);
                            int id_prueba_encogimiento = Convert.ToInt32(row["id_prueba_encogimiento"]);
                            int id_prueba_lavado_pilling = Convert.ToInt32(row["id_prueba_lavado_pilling"]);
                            int id_prueba_costura = Convert.ToInt32(row["id_prueba_costura"]);
                            int id_prueba_contaminacion_combinaciontelas = Convert.ToInt32(row["id_prueba_contaminacion_combinaciontelas"]);
                         //   metodo para deshabilitar registro calidad
                            DCalidad.SetHabilitarDeshabilitarCalidad(id_Calidad, 0);
                            DHistorico.RegistraHistorico("Diseño", "Catálogo de calidad", "Desactivar registro calidad", "", id_Calidad + "/" + nombre + "/" + clave +
                                "/" + detalle + "/" + id_prueba_encogimiento + "/" +
                                 id_prueba_lavado_pilling + "/" + id_prueba_costura + "/" + id_prueba_contaminacion_combinaciontelas);
                            CatalogoCalidad_Load(this, EventArgs.Empty);
                 
                    }
                    catch (Exception)
                    {
                        MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
             }
             else
             {
                MessageBoxEx.Show("Error, seleccione algun valor.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                //proceso para obtener el reporte de calidad
                DHistorico.RegistraHistorico("Diseño", "Catálogo de calidad", "Procesar Reporte calidad", "", "");
                Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcCalidad, "catalogo_calidad");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void sgcCalidad_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
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
                    btnActivar.Enabled = true;
                    btnDesactivar.Enabled = false;
                }
                else
                {
                    btnActivar.Enabled = false;
                    btnDesactivar.Enabled = true;
                }
            }
        }
        private void sgcCalidad_SelectionChanged(object sender, GridEventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            if (Estatus(row))
            {
                btnActivar.Enabled = false;
                btnDesactivar.Enabled = true;
            }
            else
            {
                btnActivar.Enabled = true;
                btnDesactivar.Enabled = false;
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

    }
}