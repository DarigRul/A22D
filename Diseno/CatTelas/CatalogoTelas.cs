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
namespace ALTIMA_ERP_2022.Diseno.CatTelas
{
    public partial class CatalogTelas: OfficeForm
    {
        private GridPanel panel;
        private List<ETelas> lstTelas = new List<ETelas>();

        public CatalogTelas()
        {
            InitializeComponent();
            Cargarsgc();
        }

        private void CatalogoTela_Load(object sender, EventArgs e)
        {
            try
            {
                lstTelas = DTelas.GetConsultaDisenoTelas();
                if (lstTelas != null)
                {
                    if (lstTelas.Count > 0)
                    {
                        panel = sgcTelas.PrimaryGrid;
                        panel.DataSource = lstTelas;
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

       public void Cargarsgc()
        {
            try
            {
                lstTelas = DTelas.GetConsultaDisenoTelas();
                if (lstTelas != null)
                {
                    if (lstTelas.Count > 0)
                    {
                        panel = sgcTelas.PrimaryGrid;
                        panel.DataSource = lstTelas;
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
                ETelas obj = new ETelas();
                var nuevoGenero = new Telas(obj,"Alta");
                nuevoGenero.refrescar += () => CatalogoTela_Load(this, EventArgs.Empty);
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
                //se obtiene el objeto seleccionado dentro del super grid
                ETelas obj = new ETelas();
                var row = panel.ActiveRow as GridRow;
                int id_tela = Convert.ToInt32(row["id_tela"].Value);
                int tipo = Convert.ToInt32(row["tipo"].Value);
                string clave_tela = Convert.ToString(row["clave_tela"].Value);
                string descripcion = Convert.ToString(row["descripcion"].Value);
                int id_familia_composicion = Convert.ToInt32(row["id_familia_composicion"].Value);
                int id_estampado = Convert.ToInt32(row["id_estampado"].Value);
                int id_proveedor = Convert.ToInt32(row["id_proveedor"].Value);
                string clave_proveedor = Convert.ToString(row["clave_proveedor"].Value);
                int id_color = Convert.ToInt32(row["id_color"].Value);
                double ancho_tela = Convert.ToDouble(row["ancho_tela"].Value);
                string imagen = Convert.ToString(row["imagen"].Value);
                string observaciones = Convert.ToString(row["observaciones"].Value);
                int estatus = Convert.ToInt32(row["estatus"].Value);
                int estatus_tela = Convert.ToInt32(row["estatus_tela"].Value);
                double prueba_encogimiento_largo = Convert.ToDouble(row["prueba_encogimiento_largo"].Value);
                double prueba_encogimiento_ancho = Convert.ToDouble(row["prueba_encogimiento_ancho"].Value);
                obj.id_tela = id_tela;
                obj.tipo = tipo;
                obj.clave_tela = clave_tela;
                obj.descripcion = descripcion;
                obj.id_familia_composicion = id_familia_composicion;
                obj.id_estampado = id_estampado;
                obj.id_proveedor = id_proveedor;
                obj.clave_proveedor = clave_proveedor;
                obj.id_color = id_color;
                obj.ancho_tela = ancho_tela;
                obj.imagen = imagen;
                obj.observaciones = observaciones;
                obj.estatus = estatus;
                obj.estatus_tela = estatus_tela;
                obj.prueba_encogimiento_largo = prueba_encogimiento_largo;
                obj.prueba_encogimiento_ancho = prueba_encogimiento_ancho;
                //se manda el objeto a la ventana de telas para despúes visualizar en pantalla los valores previos
                if (obj.estatus == 1)
                {
                    var ventanatelas = new Telas(obj, "Modificacion");
                    ventanatelas.refrescar += () => CatalogoTela_Load(this, EventArgs.Empty);
                    ventanatelas.ShowDialog();
                }
                else
                {
                    MessageBoxEx.Show("Error, el registro no se puede actualizar.", "Error, la tela esta desactivada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                //Preguntamos al usuario si quiere activar el telas
                DialogResult dr = MessageBoxEx.Show("Se activará el registro de telas, ¿Está seguro?", "Activar tela", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    { 
                        //Obtenemos el  id_tela para despues procesar la activacion del regisro de telas
                        var row = panel.ActiveRow as GridRow;
                        int id_tela = Convert.ToInt32(row["id_tela"].Value);
                        int tipo = Convert.ToInt32(row["tipo"].Value);
                        string clave_tela = Convert.ToString(row["clave_tela"].Value);
                        string descripcion = Convert.ToString(row["descripcion"].Value);
                        int id_familia_composicion = Convert.ToInt32(row["id_familia_composicion"].Value);
                        int id_estampado = Convert.ToInt32(row["id_estampado"].Value);
                        int id_proveedor = Convert.ToInt32(row["id_proveedor"].Value);
                        string clave_proveedor = Convert.ToString(row["clave_proveedor"].Value);
                        int id_color = Convert.ToInt32(row["id_color"].Value);
                        double ancho_tela = Convert.ToDouble(row["ancho_tela"].Value);
                        string imagen = Convert.ToString(row["imagen"].Value);
                        string  observaciones = Convert.ToString(row["observaciones"].Value);
                        int estatus = Convert.ToInt32(row["estatus"].Value);
                        int estatus_tela = Convert.ToInt32(row["estatus_tela"].Value);
                        double prueba_encogimiento_largo = Convert.ToDouble(row["prueba_encogimiento_largo"].Value);
                        double prueba_encogimiento_ancho = Convert.ToDouble(row["prueba_encogimiento_ancho"].Value);
                        //metodo para habilitar tela
                        DTelas.SetHabilitarDeshabilitarTelas(id_tela, 1);
                        DHistorico.RegistraHistorico("Diseño", "Catálogo de telas", "Activar tela", "", id_tela + "/" + tipo + "/" + clave_tela + 
                            "/" + descripcion + "/" + id_familia_composicion + "/" +
                             id_estampado + "/" + id_proveedor + "/" + clave_proveedor + "/" + id_color + "/" + ancho_tela+ "/" + imagen + "/" + 
                             observaciones + "/" + estatus + "/" + estatus_tela + "/" + prueba_encogimiento_largo + "/" +prueba_encogimiento_ancho);
                        CatalogoTela_Load(this, EventArgs.Empty);
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
                //Preguntamos al usuario si quiere desactivar tela
                DialogResult dr = MessageBoxEx.Show("Se desactivará el registro de tela, ¿Está seguro?", "Desactivar tela", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        //Obtenemos el id_tela para posteriormente desactivar el registro
                        var row = panel.ActiveRow as GridRow;
                        int id_tela = Convert.ToInt32(row["id_tela"].Value);
                        int tipo = Convert.ToInt32(row["tipo"].Value);
                        string clave_tela = Convert.ToString(row["clave_tela"].Value);
                        string descripcion = Convert.ToString(row["descripcion"].Value);
                        int id_familia_composicion = Convert.ToInt32(row["id_familia_composicion"].Value);
                        int id_estampado = Convert.ToInt32(row["id_estampado"].Value);
                        int id_proveedor = Convert.ToInt32(row["id_proveedor"].Value);
                        string clave_proveedor = Convert.ToString(row["clave_proveedor"].Value);
                        int id_color = Convert.ToInt32(row["id_color"].Value);
                        double ancho_tela = Convert.ToDouble(row["ancho_tela"].Value);
                        string imagen = Convert.ToString(row["imagen"].Value);
                        string observaciones = Convert.ToString(row["observaciones"].Value);
                        int estatus = Convert.ToInt32(row["estatus"].Value);
                        int estatus_tela = Convert.ToInt32(row["estatus_tela"].Value);
                        double prueba_encogimiento_largo = Convert.ToDouble(row["prueba_encogimiento_largo"].Value);
                        double prueba_encogimiento_ancho = Convert.ToDouble(row["prueba_encogimiento_ancho"].Value);
                        //metodo para deshabilitar tela
                        DTelas.SetHabilitarDeshabilitarTelas(id_tela, 0);
                        DHistorico.RegistraHistorico("Diseño", "Catálogo de telas", "Desactivar tela", "", id_tela + "/" + tipo + "/" + clave_tela +
                            "/" + descripcion + "/" + id_familia_composicion + "/" +
                             id_estampado + "/" + id_proveedor + "/" + clave_proveedor + "/" + id_color + "/" + ancho_tela + "/" + imagen + "/" +
                             observaciones + "/" + estatus + "/" + estatus_tela + "/" + prueba_encogimiento_largo + "/" + prueba_encogimiento_ancho);
                        CatalogoTela_Load(this, EventArgs.Empty);
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
                //proceso para obtener el reporte de telas
                DHistorico.RegistraHistorico("Diseño", "Catálogo de telas", "Procesar Reporte telas", "", "");
                Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcTelas, "catalogo_telas");
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void sgcTela_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
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

        private void sgcTela_SelectionChanged(object sender, GridEventArgs e)
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

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
