using Datos.Diseno;
using DevComponents.DotNetBar;
using Entidades.Compras;
using Entidades.Diseno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Utilitarios;
using System.Configuration;
using Datos.Utilitarios.Historico;
using Datos.Compras;

namespace ALTIMA_ERP_2022.Diseno.CatMaterial
{
    public partial class CatalogoMaterialAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public Action refrescar;
        public EMateriales materialModificar;
        public string rutaArchivo;
        public string nombreArchivo;
        private List<EMaterialTipo> lstMaterialTipo = new List<EMaterialTipo>();
        private List<EColor> lstColores = new List<EColor>();
        private List<EColor> listaColores = new List<EColor>();
        private List<EProveedor> listaProveedores = new List<EProveedor>();
        private List<EUnidadesMedida> lstUnidades = new List<EUnidadesMedida>();
        private List<EMaterialesProcesos> lstMaterialesProceso = new List<EMaterialesProcesos>();
        private static string ruta_temp = ConfigurationManager.AppSettings.GetValues("ruta_temp")[0];

        public CatalogoMaterialAM()
        {
            InitializeComponent();
        }

        private void MaterialAM_Load(object sender, EventArgs e)
        {
            //Se llena el combo de Uso
            List<Uso> usos = new List<Uso>();
            Uso uso = new Uso();
            uso.id_uso = 1;
            uso.uso = "Combinación";
            usos.Add(uso);
            Uso uso1 = new Uso();
            uso1.id_uso = 2;
            uso1.uso = "Dependiente del Color";
            usos.Add(uso1);
            Uso uso2 = new Uso();
            uso2.id_uso = 3;
            uso2.uso = "Independiente del color de tela";
            usos.Add(uso2);

            cmbUso.DataSource = usos;
            cmbUso.DisplayMember = "uso";
            cmbUso.ValueMember = "id_uso";

            //Se llena el combo de proveedores
            listaProveedores = DProveedor.ListarProveedores();
            listaProveedores = listaProveedores.Where(x => x.estatus == 1).ToList();
            cmbProveedor.DataSource = listaProveedores;
            cmbProveedor.DisplayMember = "nombre_comercial";
            cmbProveedor.ValueMember = "id_proveedor";

            //Se llena el combo de tipo material
            var dmt = new DMaterialTipo();
            lstMaterialTipo = dmt.ListaMaterialTipo();
            lstMaterialTipo = lstMaterialTipo.Where(x => x.estatus == 1).ToList();
            cmbTipo.DataSource = lstMaterialTipo;
            cmbTipo.DisplayMember = "descripcion";
            cmbTipo.ValueMember = "id_material_tipo";

            //Se llena el combo de Color
            var dc = new DColor();
            lstColores = dc.ListarColores();
            lstColores = lstColores.Where(x => x.estatus == 1).ToList();
            cmbColor.DataSource = lstColores;
            cmbColor.DisplayMember = "nombre";
            cmbColor.ValueMember = "id_color";

            //Se llena el combo de Unidad Medida
            var dUnidad = new DUnidadesMedida();
            lstUnidades = dUnidad.ListarUnidades();
            lstUnidades = lstUnidades.Where(x => x.estatus == 1).ToList();
            cmbUnidadMedida.DataSource = lstUnidades;
            cmbUnidadMedida.DisplayMember = "nombre";
            cmbUnidadMedida.ValueMember = "id_unidad_medida";

            //Se llena el combo de Material Proceso
            var materialProcesos = new DMaterialesProcesos();
            lstMaterialesProceso = materialProcesos.ListaMaterialesProcesos();
            cmbProcesoAplica.DataSource = lstMaterialesProceso;
            cmbProcesoAplica.DisplayMember = "proceso";
            cmbProcesoAplica.ValueMember = "id_material_proceso";

            swcPrueba.OffText = "No";
            swcPrueba.OffBackColor = Color.DarkRed;
            swcPrueba.OffTextColor = Color.White;
            swcPrueba.OnText = "Si";
            swcPrueba.OnBackColor = Color.Green;
            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtNombre.Text = "";
                    cmbUso.SelectedIndex = -1;
                    cmbProveedor.SelectedIndex = -1;
                    cmbTipo.SelectedIndex = -1;
                    cmbColor.SelectedIndex = -1;
                    cmbUnidadMedida.SelectedIndex = -1;
                    cmbProcesoAplica.SelectedIndex = -1;
                    txtClveProveedor.Text = "";
                    txtPrecioUnitario.Text = "";
                    txtTamano.Text = "";
                    txtObservaciones.Text = "";
                    swcPrueba.Value = true;
                    txtNombre.Focus();
                    break;
                case Movimiento.modificar:

                    txtNombre.Text = materialModificar.nombre;

                    cmbUso.SelectedIndex = -1;
                    if (materialModificar.uso != "")
                    {
                        switch (materialModificar.uso)
                        {
                            case "Combinación":
                                cmbUso.SelectedValue = 1;
                                break;
                            case "Dependiente del Color":
                                cmbUso.SelectedValue = 2;
                                break;
                            case "Independiente del color de tela":
                                cmbUso.SelectedValue = 3;
                                break;
                            default:
                                break;
                        }
                    }

                    cmbProveedor.SelectedIndex = -1;
                    if (materialModificar.id_proveedor != 0)
                    {
                        cmbProveedor.SelectedValue = materialModificar.id_proveedor;
                    }

                    cmbTipo.SelectedIndex = -1;
                    if(materialModificar.id_material_tipo != 0)
                    {
                        cmbTipo.SelectedValue = materialModificar.id_material_tipo;
                    }

                    cmbColor.SelectedIndex = -1;
                    if(materialModificar.id_color != 0)
                    {
                        cmbColor.SelectedValue = materialModificar.id_color;
                    }

                    cmbUnidadMedida.SelectedIndex = -1;
                    if(materialModificar.id_unidad_medida != 0)
                    {
                        cmbUnidadMedida.SelectedValue = materialModificar.id_unidad_medida;
                    }

                    cmbProcesoAplica.SelectedIndex = -1;
                    if(materialModificar.id_material_proceso != 0)
                    {
                        cmbProcesoAplica.SelectedValue = materialModificar.id_material_proceso;
                    }

                    txtClveProveedor.Text = materialModificar.clave_proveedor;
                    txtPrecioUnitario.Text = string.Format("{0:#,##0.00}", materialModificar.precio_unitario);
                    txtTamano.Text = string.Format("{0:#,##0.00}", materialModificar.tamano);
                    txtObservaciones.Text = materialModificar.observaciones;
                    if(materialModificar.hacer_prueba_calidad == 1)
                    {
                        swcPrueba.Value = true;
                    }
                    else
                    {
                        swcPrueba.Value = false;
                    }
                    Utilitarios.ftp.DescargarImagen(materialModificar.imagen);
                    string ruta_imagen = ruta_temp + materialModificar.imagen;
                    nombreArchivo = "";
                    picBox.ImageLocation = ruta_imagen;
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtNombre.Focus();
                    break;
                default:
                    break;
            }
        }

        private void btnCargaImagen_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    rutaArchivo = filePath;
                    picBox.ImageLocation = filePath;
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                    nombreArchivo = openFileDialog.SafeFileName;
                    //Mat_id_nombreArchivo
                    var asd = Utilitarios.ftp.SubirImagen(filePath, nombreArchivo);
                }
            }


        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBoxEx.Show("¿Está seguro de eliminar la imágen?", "Eliminar Imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                switch (movimiento)
                {
                    case Movimiento.agregar:
                        
                        break;
                    case Movimiento.modificar:

                        break;
                    default:
                        break;
                }

                rutaArchivo = "";
                picBox.ImageLocation = null;
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox.BackColor = Color.White;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private class Uso
        {
            public int id_uso { get; set; }
            public string uso { get; set; }
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioUnitario_Leave(object sender, EventArgs e)
        {
            if (txtPrecioUnitario.Text != "")
            {
                txtPrecioUnitario.Text = string.Format("{0:#,##0.00}", Convert.ToDecimal(txtPrecioUnitario.Text));
            }
        }

        private void txtTamano_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTamano_Leave(object sender, EventArgs e)
        {
            if (txtTamano.Text != "")
            {
                txtTamano.Text = string.Format("{0:#,##0.00}", Convert.ToDecimal(txtTamano.Text));
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            EMateriales eMaterialesIns = new EMateriales();
            string valor_nuevo = "";
            string valor_anterior = "";
            try
            {
                if (ValidaCampos())
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            EMateriales eMateriales = new EMateriales();
                            eMateriales.nombre = txtNombre.Text;
                            eMateriales.id_unidad_medida = (int)cmbUnidadMedida.SelectedValue;
                            eMateriales.uso = cmbUso.Text;
                            eMateriales.id_material_proceso = (int)cmbProcesoAplica.SelectedValue;
                            eMateriales.id_proveedor = (int)cmbProveedor.SelectedValue;
                            eMateriales.clave_proveedor = txtClveProveedor.Text;
                            eMateriales.id_material_tipo = (int)cmbTipo.SelectedValue;
                            eMateriales.precio_unitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                            eMateriales.id_color = (int)cmbColor.SelectedValue;
                            eMateriales.tamano = Convert.ToDecimal(txtTamano.Text);
                            eMateriales.observaciones = txtObservaciones.Text;
                            eMateriales.imagen = nombreArchivo;
                            if (swcPrueba.Value)
                            {
                                eMateriales.hacer_prueba_calidad = 1;
                            }
                            else
                            {
                                eMateriales.hacer_prueba_calidad = 0;
                            }

                            eMaterialesIns = DMateriales.SetInsertarMateriales(eMateriales);

                            valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                            valor_nuevo += "Unidad de Medida: " + cmbUnidadMedida.Text + " / ";
                            valor_nuevo += "Uso: " + cmbUso.Text + " / ";
                            valor_nuevo += "Proceso al que aplica: " + cmbProcesoAplica.Text + " / ";
                            valor_nuevo += "Proveedor: " + cmbProveedor.Text + " / ";
                            valor_nuevo += "Clave proveedor: " + txtClveProveedor.Text + " / ";
                            valor_nuevo += "Tipo: " + cmbTipo.Text + " / ";
                            valor_nuevo += "Precio Unitario: " + txtPrecioUnitario.Text + " / ";
                            valor_nuevo += "Color: " + cmbColor.Text + " / ";
                            valor_nuevo += "Tamaño: " + txtTamano.Text + " / ";
                            valor_nuevo += "Imagen: " + nombreArchivo + " / ";
                            valor_nuevo += "Observaciones: " + txtObservaciones.Text + " / ";

                            if (eMaterialesIns.id_material > 0)
                            {
                                bool agregar_archivo = false;
                                agregar_archivo = Utilitarios.ftp.SubirImagen(rutaArchivo, eMaterialesIns.imagen);
                                if(agregar_archivo == false)
                                {
                                    MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    DHistorico.RegistraHistorico("Diseño", "Catálogo Material Tipo", "Nuevo Material Tipo", valor_anterior, valor_nuevo);
                                    refrescar.Invoke();
                                    MessageBoxEx.Show("Material tipo registrado correctamente", "Nuevo Material Tipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Close();
                                    Dispose();
                                }
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case Movimiento.modificar:
                            EMateriales materialActualizar = new EMateriales();

                            materialActualizar.nombre = txtNombre.Text;
                            materialActualizar.id_unidad_medida = (int)cmbUnidadMedida.SelectedValue;
                            materialActualizar.uso = cmbUso.Text;
                            materialActualizar.id_material_proceso = (int)cmbProcesoAplica.SelectedValue;
                            materialActualizar.id_proveedor = (int)cmbProveedor.SelectedValue;
                            materialActualizar.clave_proveedor = txtClveProveedor.Text;
                            materialActualizar.id_material_tipo = (int)cmbTipo.SelectedValue;
                            materialActualizar.precio_unitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                            materialActualizar.id_color = (int)cmbColor.SelectedValue;
                            materialActualizar.tamano = Convert.ToDecimal(txtTamano.Text);
                            materialActualizar.observaciones = txtObservaciones.Text;
                            materialActualizar.imagen = picBox.Image == null ? string.Empty : nombreArchivo;
                            if (swcPrueba.Value)
                            {
                                materialActualizar.hacer_prueba_calidad = 1;
                            }
                            else
                            {
                                materialActualizar.hacer_prueba_calidad = 0;
                            }

                            valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                            valor_nuevo += "Unidad de Medida: " + cmbUnidadMedida.Text + " / ";
                            valor_nuevo += "Uso: " + cmbUso.Text + " / ";
                            valor_nuevo += "Proceso al que aplica: " + cmbProcesoAplica.Text + " / ";
                            valor_nuevo += "Proveedor: " + cmbProveedor.Text + " / ";
                            valor_nuevo += "Clave proveedor: " + txtClveProveedor.Text + " / ";
                            valor_nuevo += "Tipo: " + cmbTipo.Text + " / ";
                            valor_nuevo += "Precio Unitario: " + txtPrecioUnitario.Text + " / ";
                            valor_nuevo += "Color: " + cmbColor.Text + " / ";
                            valor_nuevo += "Tamaño: " + txtTamano.Text + " / ";
                            valor_nuevo += "Imagen: " + nombreArchivo + " / ";
                            valor_nuevo += "Observaciones: " + txtObservaciones.Text + " / ";

                            string unidadMedida = "";
                            string procesoAplica = "";
                            string proveedor = "";
                            string tipo = "";
                            string color = "";

                            foreach (var item in lstUnidades)
                            {
                                if(item.id_unidad_medida == materialModificar.id_unidad_medida)
                                {
                                    unidadMedida = item.nombre;
                                }
                            }

                            foreach (var item in lstMaterialesProceso)
                            {
                                if(item.id_material_proceso == materialModificar.id_material_proceso)
                                {
                                    procesoAplica = item.proceso;
                                }
                            }

                            foreach (var item in listaProveedores)
                            {
                                if(item.id_proveedor == materialModificar.id_proveedor)
                                {
                                    proveedor = item.nombre_comercial;
                                }
                            }

                            foreach (var item in lstMaterialTipo)
                            {
                                if(item.id_material_tipo == materialModificar.id_material_tipo)
                                {
                                    tipo = item.descripcion;
                                }
                            }

                            foreach (var item in lstColores)
                            {
                                if (item.id_color == materialModificar.id_color)
                                {
                                    color = materialModificar.nombre;
                                }
                            }
                                                        
                            valor_anterior += "Nombre: " + materialModificar.nombre.ToString() + " / ";
                            valor_anterior += "Unidad de Medida: " + unidadMedida + " / ";
                            valor_anterior += "Uso: " + materialModificar.uso + " / ";
                            valor_anterior += "Proceso al que aplica: " + procesoAplica + " / ";
                            valor_anterior += "Proveedor: " + proveedor + " / ";
                            valor_anterior += "Clave proveedor: " + materialModificar.clave_proveedor + " / ";
                            valor_anterior += "Tipo: " + tipo + " / ";
                            valor_anterior += "Precio Unitario: " + string.Format("{0:#,##0.00}", materialModificar.precio_unitario) + " / ";
                            valor_anterior += "Color: " + color + " / ";
                            valor_anterior += "Tamaño: " + string.Format("{0:#,##0.00}", materialModificar.tamano) + " / ";
                            valor_anterior += "Imagen: " + materialModificar.imagen + " / ";
                            valor_anterior += "Observaciones: " + materialModificar.observaciones + " / ";

                            var material = DMateriales.ModificaMateriales(materialActualizar);
                            if(material.id_material > 0)
                            {
                                if(nombreArchivo != "")
                                {
                                    bool modificarArchivo = false;
                                    modificarArchivo = Utilitarios.ftp.SubirImagen(rutaArchivo, material.imagen);
                                    if (modificarArchivo == false)
                                    {
                                        MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        DHistorico.RegistraHistorico("Diseño", "Catálogo Material Tipo", "Modificar Material Tipo", valor_anterior, valor_nuevo);
                                        refrescar.Invoke();
                                        MessageBoxEx.Show("Material tipo actualizado correctamente", "Modificar Material Tipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Close();
                                        Dispose();
                                    }
                                }
                                else
                                {
                                    refrescar.Invoke();
                                    MessageBoxEx.Show("Material tipo actualizado correctamente", "Modificar Material Tipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Close();
                                    Dispose();
                                }
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidaCampos()
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el nombre del material", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (cmbUnidadMedida.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione una unidad de medida", "Sin unidad de medida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUnidadMedida.Focus();
                return false;
            }
            if (cmbUso.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione un uso", "Sin uso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUso.Focus();
                return false;
            }
            if (cmbProcesoAplica.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione un proceso al que aplica", "Sin Proceso al que apica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProcesoAplica.Focus();
                return false;
            }
            if (cmbProveedor.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione un proveedor", "Sin proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProveedor.Focus();
                return false;
            }
            if (txtClveProveedor.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture la clave del proveedor", "Clave de proveedor no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClveProveedor.Focus();
                return false;
            }
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione el tipo de material", "Sin Tipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTipo.Focus();
                return false;
            }
            decimal precio_unitario = 0;
            if(txtPrecioUnitario.Text != "")
            {
                bool convert = Decimal.TryParse(txtPrecioUnitario.Text, out precio_unitario);
            }
            
            if (txtPrecioUnitario.Text == string.Empty || precio_unitario == 0)
            {
                MessageBoxEx.Show("Capture el precio unitario", "Precio unitario no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClveProveedor.Focus();
                return false;
            }
            if (cmbColor.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione un color", "Sin Color", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbColor.Focus();
                return false;
            }
            decimal tamano = 0;
            if (txtTamano.Text != "")
            {
                bool convert = Decimal.TryParse(txtTamano.Text, out tamano);
            }
            if (txtTamano.Text == string.Empty || tamano == 0)
            {
                MessageBoxEx.Show("Capture el tamaño", "Tamaño no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClveProveedor.Focus();
                return false;
            }
            if(rutaArchivo == string.Empty)
            {
                MessageBoxEx.Show("Cargue una imagen", "Imagen no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCargaImagen.Focus();
                return false;
            }

            return true;
        }
    }
}
