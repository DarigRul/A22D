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
        private List<ETelas> lstMarcadores = new List<ETelas>();

        public CatalogTelas()
        {
            InitializeComponent();
            Cargarsgc();
        }

        private void CatalogoMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                //lstMarcadores = DTelas.GetConsultaDisenoMateriales();
                //if (lstMarcadores != null)
                //{
                //    if (lstMarcadores.Count > 0)
                //    {
                //        panel = sgcMaterial.PrimaryGrid;
                //        panel.DataSource = lstMarcadores;
                //    }
                //    else
                //    {
                //        MessageBoxEx.Show("Error, no existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else
                //{
                //    MessageBoxEx.Show("Error, no existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
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
                //lstMarcadores = DTelas.GetConsultaDisenoMateriales();
                //if (lstMarcadores != null)
                //{
                //    if (lstMarcadores.Count > 0)
                //    {
                //        panel = sgcMaterial.PrimaryGrid;
                //        panel.DataSource = lstMarcadores;
                //    }
                //    else
                //    {
                //        MessageBoxEx.Show("Error, no existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else
                //{
                //    MessageBoxEx.Show("Error, no existen registros.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
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
                ETelas obj = new ETelas();
                var row = panel.ActiveRow as GridRow;
                int id_material = Convert.ToInt32(row["id_material"].Value);
                int tipo = Convert.ToInt32(row["tipo"].Value);
                int id_material_tipo = Convert.ToInt32(row["id_material_tipo"].Value);
                int id_proveedor = Convert.ToInt32(row["id_proveedor"].Value);
                int id_material_proceso = Convert.ToInt32(row["id_material_proceso"].Value);
                int id_unidad_medida = Convert.ToInt32(row["id_unidad_medida"].Value);
                string nombre = Convert.ToString(row["nombre"].Value);
                int id_color = Convert.ToInt32(row["id_color"].Value);
                string uso = Convert.ToString(row["uso"].Value);
                string clave_proveedor = Convert.ToString(row["clave_proveedor"].Value);
                decimal tamano = Convert.ToDecimal(row["tamano"].Value);
                string observaciones = Convert.ToString(row["observaciones"].Value);
                string imagen = Convert.ToString(row["imagen"].Value);
                int hacer_prueba_calidad = Convert.ToInt32(row["hacer_prueba_calidad"].Value);
                decimal precio_unitario = Convert.ToDecimal(row["precio_unitario"].Value);
                //obj.id_material = id_material;
                //obj.tipo = tipo;
                //obj.id_material_tipo = id_material_tipo;
                //obj.id_proveedor = id_proveedor;
                //obj.id_material_proceso = id_material_proceso;
                //obj.id_unidad_medida = id_unidad_medida;
                //obj.nombre = nombre;
                //obj.id_color = id_color;
                //obj.uso = uso;
                //obj.clave_proveedor = clave_proveedor;
                //obj.tamano = tamano;
                //obj.observaciones = observaciones;
                //obj.imagen = imagen;
                //obj.hacer_prueba_calidad = hacer_prueba_calidad;
                //obj.precio_unitario = precio_unitario;
                var nuevoGenero = new Telas(obj,"Alta");
                nuevoGenero.refrescar += () => CatalogoMaterial_Load(this, EventArgs.Empty);
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
                ETelas obj = new ETelas();
                var row = panel.ActiveRow as GridRow;
                int id_material = Convert.ToInt32(row["id_material"].Value);
                int tipo = Convert.ToInt32(row["tipo"].Value);
                int id_material_tipo = Convert.ToInt32(row["id_material_tipo"].Value);
                int id_proveedor = Convert.ToInt32(row["id_proveedor"].Value);
                int id_material_proceso = Convert.ToInt32(row["id_material_proceso"].Value);
                int id_unidad_medida = Convert.ToInt32(row["id_unidad_medida"].Value);
                string nombre = Convert.ToString(row["nombre"].Value);
                int id_color = Convert.ToInt32(row["id_color"].Value);
                string uso = Convert.ToString(row["uso"].Value);
                string clave_proveedor = Convert.ToString(row["clave_proveedor"].Value);
                decimal tamano = Convert.ToDecimal(row["tamano"].Value);
                string observaciones = Convert.ToString(row["observaciones"].Value);
                string imagen = Convert.ToString(row["imagen"].Value);
                int hacer_prueba_calidad = Convert.ToInt32(row["hacer_prueba_calidad"].Value);
                //decimal precio_unitario = Convert.ToDecimal(row["precio_unitario"].Value);
                //obj.id_material = id_material;
                //obj.tipo = tipo;
                //obj.id_material_tipo = id_material_tipo;
                //obj.id_proveedor = id_proveedor;
                //obj.id_material_proceso = id_material_proceso;
                //obj.id_unidad_medida = id_unidad_medida;
                //obj.nombre = nombre;
                //obj.id_color = id_color;
                //obj.uso = uso;
                //obj.clave_proveedor = clave_proveedor;
                //obj.tamano = tamano;
                //obj.observaciones = observaciones;
                //obj.imagen = imagen;
                //obj.hacer_prueba_calidad = hacer_prueba_calidad;
                //obj.precio_unitario = precio_unitario;
                var nuevoGenero = new Telas(obj, "Modificacion");
                nuevoGenero.refrescar += () => CatalogoMaterial_Load(this, EventArgs.Empty);
                nuevoGenero.ShowDialog();
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar el material
            DialogResult dr = MessageBoxEx.Show("Se activará el registro de materiales, ¿Está seguro?", "Activar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                { 
                    //Obtenemos el id_material
                    var row = panel.ActiveRow as GridRow;
                    int id_material = Convert.ToInt32(row["id_material"].Value);
                    int tipo = Convert.ToInt32(row["tipo"].Value);
                    int id_material_tipo = Convert.ToInt32(row["id_material_tipo"].Value);
                    int id_proveedor = Convert.ToInt32(row["id_proveedor"].Value);
                    int id_material_proceso = Convert.ToInt32(row["id_material_proceso"].Value);
                    int id_unidad_medida = Convert.ToInt32(row["id_unidad_medida"].Value);
                    string nombre = Convert.ToString(row["nombre"].Value);
                    int id_color = Convert.ToInt32(row["id_color"].Value);
                    string uso = Convert.ToString(row["uso"].Value);
                    string clave_proveedor = Convert.ToString(row["clave_proveedor"].Value);
                    decimal tamano = Convert.ToDecimal(row["tamano"].Value);
                    string  observaciones = Convert.ToString(row["observaciones"].Value);
                    string imagen = Convert.ToString(row["imagen"].Value);
                    int hacer_prueba_calidad = Convert.ToInt32(row["hacer_prueba_calidad"].Value);
                    decimal precio_unitario = Convert.ToDecimal(row["precio_unitario"].Value);
                    //metodo para habilitar material
                    DTelas.SetHabilitarDeshabilitarMateriales(id_material, 1);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de materiales", "Activar material", "", id_material + "/" + tipo + "/" + id_material_tipo + "/" + id_proveedor + "/" + id_material_proceso + "/" +
                         id_unidad_medida + "/" + nombre + "/" + id_color + "/" + uso + "/" + clave_proveedor + "/" + tamano + "/" + observaciones + "/" + imagen + "/" + hacer_prueba_calidad + "/" + precio_unitario);
                    CatalogoMaterial_Load(this, EventArgs.Empty);
                }
                catch (Exception)
                {
                    MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere desactivar el material
            DialogResult dr = MessageBoxEx.Show("Se desactivará el registro de materiales, ¿Está seguro?", "Desactivar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                { 

                    //Obtenemos el id_material
                    var row = panel.ActiveRow as GridRow;
                    int id_material = Convert.ToInt32(row["id_material"].Value);
                    int tipo = Convert.ToInt32(row["tipo"].Value);
                    int id_material_tipo = Convert.ToInt32(row["id_material_tipo"].Value);
                    int id_proveedor = Convert.ToInt32(row["id_proveedor"].Value);
                    int id_material_proceso = Convert.ToInt32(row["id_material_proceso"].Value);
                    int id_unidad_medida = Convert.ToInt32(row["id_unidad_medida"].Value);
                    string nombre = Convert.ToString(row["nombre"].Value);
                    int id_color = Convert.ToInt32(row["id_color"].Value);
                    string uso = Convert.ToString(row["uso"].Value);
                    string clave_proveedor = Convert.ToString(row["clave_proveedor"].Value);
                    decimal tamano = Convert.ToDecimal(row["tamano"].Value);
                    string observaciones = Convert.ToString(row["observaciones"].Value);
                    string imagen = Convert.ToString(row["imagen"].Value);
                    int hacer_prueba_calidad = Convert.ToInt32(row["hacer_prueba_calidad"].Value);
                    decimal precio_unitario = Convert.ToDecimal(row["precio_unitario"].Value);
                    //metodo para deshabilitar material
                    DTelas.SetHabilitarDeshabilitarMateriales(id_material, 0);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de materiales", "Desactivar material", "", id_material + "/" + tipo + "/" + id_material_tipo + "/" + id_proveedor + "/" + id_material_proceso + "/" +
                         id_unidad_medida + "/" + nombre + "/" + id_color + "/" + uso + "/" + clave_proveedor + "/" + tamano + "/" + observaciones + "/" + imagen + "/" + hacer_prueba_calidad + "/" + precio_unitario);
                    CatalogoMaterial_Load(this, EventArgs.Empty);
                }
                catch (Exception)
                {
                    MessageBoxEx.Show("Error, ocurrio un error insesperado intente nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DHistorico.RegistraHistorico("Diseño", "Catálogo de materiales", "Procesar Reporte materiales", "", "");
                Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcMaterial, "catalogo_materiales");
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

        private void sgcMaterial_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
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

        private void sgcMaterial_SelectionChanged(object sender, GridEventArgs e)
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
