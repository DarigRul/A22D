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
using Entidades.Diseno;
using Entidades.Compras;
using Datos.Diseno;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using ALTIMA_ERP_2022.Utilitarios;
using CrystalDecisions.Shared;
using DevComponents.DotNetBar.Controls;
using System.Configuration;
using Entidades.Notificaciones;
using Datos.Compras; 

namespace ALTIMA_ERP_2022.Diseno.CatForros
{
    public partial class ForrosAM : OfficeForm
    {
        private string ruta_temp;
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public Action refrescar;

        public EForros eForro;
        string rutaImagen, nombreImagen, extension;

        List<EComposicion> listaComposiciones = new List<EComposicion>();
        List<EColor> listaColores = new List<EColor>();
        List<EProveedor> listaProveedores = new List<EProveedor>();


        public ForrosAM()
        {
            InitializeComponent();
        }

        private void ForrosAM_Load(object sender, EventArgs e)
        {
            try
            {
                ruta_temp = ConfigurationManager.AppSettings["ruta_temp"];

                //Lista de composiciones y filtramos las que están activas
                listaComposiciones = DComposicion.ListarComposiciones();
                cmbComposicion.DataSource = listaComposiciones;
                cmbComposicion.DisplayMember = "nombre";
                cmbComposicion.ValueMember = "id_composicion";
                cmbComposicion.SelectedIndex = -1;

                //Lista de colores y filtramos las que están activas
                DColor dColor = new DColor();
                listaColores = dColor.ListarColores();
                listaColores = listaColores.Where(x => x.estatus == 1).ToList();
                cmbColor.DataSource = listaColores;
                cmbColor.DisplayMember = "nombre";
                cmbColor.ValueMember = "id_color";

                //Lista de proveedores y filtramos las que están activas
                listaProveedores = DProveedor.ListarProveedores();
                listaProveedores = listaProveedores.Where(x => x.estatus == 1).ToList();
                cmbProveedor.DataSource = listaProveedores;
                cmbProveedor.DisplayMember = "nombre_comercial";
                cmbProveedor.ValueMember = "id_proveedor";

                switch (movimiento)
                {
                    case Movimiento.agregar:
                        txtNombre.Focus();
                        cmbColor.SelectedIndex = -1;
                        cmbProveedor.SelectedIndex = -1;
                        //Clave prospecto habilitada por default
                        break;
                    case Movimiento.modificar:
                        txtNombre.Text = eForro.nombre;
                        txtDescripcion.Text = eForro.descripcion;
                        txtAncho.Value = eForro.ancho;
                        eForro.composiciones = DForros.ListarComposiciones(eForro.id_forro);

                        foreach (EForrosComposiciones efc in eForro.composiciones)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = efc.id_composicion.ToString();
                            item.SubItems.Add(efc.composicion);
                            item.SubItems.Add(efc.porcentaje.ToString());

                            lvComposiciones.Items.Add(item);
                        }

                        PorcentajeTotal();

                        txtClaveForro.Text = eForro.clave_forro;
                        cmbColor.SelectedValue = eForro.id_color;
                        cmbProveedor.SelectedValue = eForro.id_proveedor;
                        txtClaveProveedor.Text = eForro.clave_proveedor;

                        

                        //Descargamos la imagen del servidor para asignarla al pictureBox
                        if (eForro.imagen != string.Empty)
                        {
                            //Obtenemos la extensión y nombre de la imagen actual
                            extension = eForro.imagen.Substring(eForro.imagen.IndexOf("."));
                            nombreImagen = eForro.imagen.Substring(0, eForro.imagen.IndexOf("."));

                            if (File.Exists(ruta_temp + eForro.imagen))
                            {
                                pbImagen.Image = Image.FromFile(ruta_temp + eForro.imagen);
                            }
                            else
                            {
                                ftp.DescargarImagen(eForro.imagen);
                                pbImagen.Image = Image.FromFile(ruta_temp + eForro.imagen);
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("550"))
                {
                    MessageBoxEx.Show("No se pudo descargar la imagen desde el servidor", "Error de descarga de imagen",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.Source}", "Error inesperado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validamos que se haya seleccionado una composición y el campo porcentaje no estén vacíos 
            int idComposicion = Convert.ToInt32(cmbComposicion.SelectedValue);
            if (idComposicion < 1)
            {
                MessageBoxEx.Show("Seleccione una composición", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbComposicion.Focus();
            }
            else if (txtPorcentaje.Text == string.Empty)
            {
                MessageBoxEx.Show("Introduzca el porcentaje de la composición", "Porcentaje no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPorcentaje.Focus();
            }
            else
            {
                //Buscamos que no se haya agregado la composición anteriormente o que no haya superado el 100% 
                int composicionExistente = 0;
                string seleccion = cmbComposicion.SelectedValue.ToString();

                decimal porcentajeActual = Convert.ToDecimal(txtPorcentaje.Value);

                foreach (ListViewItem item in lvComposiciones.Items)
                {
                    if (item.Text == seleccion.ToString())
                    {
                        composicionExistente++;
                    }
                    porcentajeActual += Convert.ToDecimal(item.SubItems[2].Text);
                }

                if (composicionExistente > 0)
                {
                    MessageBoxEx.Show("La composición ya existe en la lista", "Composición existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPorcentaje.Value < 0)
                {
                    MessageBoxEx.Show("El porcentaje no puede ser menor a 0", "Porcentaje no válido",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPorcentaje.Text = string.Empty;
                    txtPorcentaje.Focus();

                }
                else if (txtPorcentaje.Value == 0)
                {
                    MessageBoxEx.Show("El porcentaje debe ser mayor a cero (0)", "Porcentaje no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPorcentaje.Text = string.Empty;
                    txtPorcentaje.Focus();
                }
                else if (porcentajeActual > 100)
                {
                    MessageBoxEx.Show("Los porcentajes de composición superan el 100%\r\nPor favor verifique", "Porcentaje de composición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPorcentaje.Focus();
                }
                else
                {
                    ListViewItem lvi = new ListViewItem(cmbComposicion.SelectedValue.ToString());
                    lvi.SubItems.Add(cmbComposicion.Text);
                    lvi.SubItems.Add(txtPorcentaje.Text);
                    lvComposiciones.Items.Add(lvi);

                    cmbComposicion.SelectedIndex = -1;
                    txtPorcentaje.Text = string.Empty;

                    PorcentajeTotal();

                    cmbComposicion.Focus();
                }

            }
        }


        private void PorcentajeTotal()
        {
            double porcentajeTotal = 0d;
            foreach (ListViewItem item in lvComposiciones.Items)
            {
                porcentajeTotal += Convert.ToDouble(item.SubItems[2].Text);
            }
            lblPorcentaje.Text = porcentajeTotal.ToString() + " %";
        }

        private void lvComposiciones_KeyDown(object sender, KeyEventArgs e)
        {
            //Eliminamos la composición seleccionada
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem item in lvComposiciones.SelectedItems)
                {
                    item.Remove();
                }
                PorcentajeTotal();
            }
        }



        private void btnCargarImagen_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagen | *.jpg; *.png";
            ofd.FilterIndex = 1;
            ofd.Title = "Seleccione la imagen del forro";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(ofd.FileName);
                rutaImagen = ofd.FileName;
                extension = Path.GetExtension(ofd.FileName);
            }
        }

        private string CrearNombreImagen(string extension, int id_forro)
        {
            string nombre = string.Empty;
            txtNombre.Text = txtNombre.Text.Trim();
            nombre = txtNombre.Text.Replace(" ", "_");
            nombre = nombre + "." + extension;
            return nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            //Cargamos los datos para el forro
                            EForros f = CargaDatosForro();

                            //Registramos el forro
                            var _eForro = DForros.RegistrarForro(f);
                            if (_eForro.id_forro > 0)
                            {
                                //Registramos en el histórico 
                                string valorNuevo = "Nombre:" + txtNombre.Text.Trim() +
                                                    " \n\rDescripción: " + txtDescripcion.Text.Trim() +
                                                    " \n\rAncho: " + txtAncho.Text +
                                                    " \n\rTotal de composiciones: " + lvComposiciones.Items.Count.ToString() +
                                                    " \n\rClave Forro: " + txtClaveForro.Text +
                                                    " \n\rColor: " + cmbColor.Text +
                                                    " \n\rProveedor: " + cmbProveedor.Text +
                                                    "\n\rClave proveedor: " + txtClaveProveedor.Text;
                                Datos.Utilitarios.Historico.DHistorico.RegistraHistorico("Diseño", "Catálogo de forros", "Registrar nuevo forro", "", valorNuevo, "");
                                
                                //Notificamos
                                var _enotificacion = new ENotificacion();
                                _enotificacion.descripcion = valorNuevo;
                                _enotificacion.id_usuario_genera = ConfiguracionGlobal.usuario.id_usuario;
                                _enotificacion.id_notificacion_tipo = 1;
                                Datos.Notificaciones.DNotificaciones.RegistraNotificacion(_enotificacion); 


                                refrescar.Invoke();
                                if (pbImagen.Image != null)
                                {
                                    Utilitarios.ftp.SubirImagen(rutaImagen, _eForro.imagen);
                                }

                                MessageBoxEx.Show("Forro registrado correctamente", "Nuevo forro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;
                        case Movimiento.modificar:

                            //Creamos el valor anterior para el histórico
                            string valorAnteriorActualizacion = "Nombre:" + eForro.nombre +
                                                   " / Descripción: " + eForro.descripcion +
                                                   " / Ancho: " + eForro.ancho +
                                                   " / Total de composiciones: " + eForro.composiciones.Count.ToString() +
                                                   " / Clave Forro: " + eForro.clave_forro +
                                                   " / Prospecto: " + (eForro.prospecto == 1 ? "SI" : "NO") +
                                                   " / Clave prospecto: " + eForro.clave_prospecto +
                                                   " / Color: " + eForro.color +
                                                   " / Proveedor: " + eForro.proveedor +
                                                   " / Clave proveedor: " + eForro.clave_proveedor;

                            // Creamos la entidad para actualización
                            EForros forroActualizacion = CargaDatosForro();

                            //Es una actualización, entonces, extraemos el id del forro y lo asignamos a la entidad creada 
                            forroActualizacion.id_forro = eForro.id_forro;

                            //Creamos el valor nuevo para el histórico 
                            string valorNuevoActualizacion = "Nombre:" + txtNombre.Text.Trim() +
                                                             " / Descripción: " + txtDescripcion.Text.Trim() +
                                                             " / Ancho: " + txtAncho.Text +
                                                             " / Total de composiciones: " + lvComposiciones.Items.Count.ToString() +
                                                             " / Clave Forro: " + txtClaveForro.Text +
                                                             " / Color: " + cmbColor.Text +
                                                             " / Proveedor: " + cmbProveedor.Text +
                                                             " / Clave proveedor: " + txtClaveProveedor.Text;

                            //Actualizamos el forro
                            var _eaForro = DForros.ActualizaForro(forroActualizacion);

                            if (_eaForro.id_forro > 0)
                            {

                                //Registramos en el histórico
                                Datos.Utilitarios.Historico.DHistorico.RegistraHistorico("Diseño", "Catálogo de forros", "Actualizar forro", valorAnteriorActualizacion, valorNuevoActualizacion, "");

                                refrescar.Invoke();
                                if (pbImagen.Image != null)
                                {
                                    //Es una actualización, debemos asegurarnos que la ruta existe ya que se sobre escribe la imagen
                                    if (rutaImagen == null)
                                    {
                                        rutaImagen = ruta_temp + _eaForro.imagen;
                                    }

                                    if (!Utilitarios.ftp.SubirImagen(rutaImagen, _eaForro.imagen))
                                    {
                                        // No se subió la imagen, avisamos al usuario 
                                        MessageBoxEx.Show(
                                            "La imagen no pudo ser cargada al servidor\r\nPor favor comunique al Departamento de TI.",
                                            "Error de carga de imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                }

                                MessageBoxEx.Show("Forro registrado correctamente", "Nuevo forro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
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

        private EForros CargaDatosForro()
        {
            EForros f = new EForros();
            f.nombre = txtNombre.Text.Trim();
            f.descripcion = txtDescripcion.Text.Trim();
            f.ancho = txtAncho.Value;
            f.id_color = Convert.ToInt32(cmbColor.SelectedValue);
            f.color = cmbColor.Text;
            f.id_proveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
            f.clave_proveedor = txtClaveProveedor.Text.Trim();
            if (pbImagen.Image != null)
            {
                string nombre = txtNombre.Text.Trim();
                nombre = nombre.Replace(" ", "_");
                nombre = nombre + extension;
                f.imagen = nombre;
            }
            else
            {
                f.imagen = string.Empty;
            }

            f.clave_forro = txtClaveForro.Text;

            //Creamos la lista de composiciones que tendrá el forro 
            f.composiciones = CreaListaComposiciones();

            return f;
        }


        private bool ValidaCampos()
        {
            //Validamos que el total de composiciones sea igual al 100% 
            double totalComposiciones = 0d;
            foreach (ListViewItem item in lvComposiciones.Items)
            {
                totalComposiciones += Convert.ToDouble(item.SubItems[2].Text);
            }

            if (totalComposiciones != 100)
            {
                MessageBoxEx.Show("El porcentaje de las composiciones debe ser igual al 100%", "Total de composiciones no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbComposicion.Focus();
                return false;
            }
            else if (txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el nombre del forro", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            else if (lvComposiciones.Items.Count == 0)
            {
                MessageBoxEx.Show("La lista de composiciones no puede estar vacía", "Sin composiciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbComposicion.Focus();
                return false;
            }
            else if (cmbColor.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione el color del forro", "Sin color", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbColor.Focus();
                return false;
            }
            else if (cmbProveedor.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione un proveedor", "Sin proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProveedor.Focus();
                return false;
            }
            else if (txtClaveProveedor.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture la clave del proveedor", "Clave no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClaveProveedor.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            switch (movimiento)
            {
                case Movimiento.agregar:
                    if (pbImagen.Image != null)
                    {
                        pbImagen.Image = null;
                    }
                    break;
                case Movimiento.modificar:
                    if (pbImagen.Image != null)
                    {
                        pbImagen.Image.Dispose();
                        pbImagen.Image = null;

                        if (File.Exists(@"C:\Reportes\" + eForro.imagen))
                        {
                            File.Delete(@"C:\Reportes\" + eForro.imagen);
                        }
                    }
                    else if (eForro.imagen != string.Empty && pbImagen.Image != null)
                    {
                        ftp.EliminarImagen(eForro.imagen);
                        eForro.imagen = string.Empty;
                        pbImagen.Image = null;
                    }
                    else if (pbImagen.Image != null && eForro.imagen == string.Empty)
                    {
                        pbImagen.Image = null;
                    }
                    else if (eForro.imagen != string.Empty)
                    {
                        eForro.imagen = string.Empty;
                    }

                    break;
            }
        }

        private List<EForrosComposiciones> CreaListaComposiciones()
        {
            List<EForrosComposiciones> lfc = new List<EForrosComposiciones>();
            foreach (ListViewItem item in lvComposiciones.Items)
            {
                lfc.Add(new EForrosComposiciones
                {
                    id_composicion = Convert.ToInt32(item.Text),
                    porcentaje = Convert.ToDecimal(item.SubItems[2].Text)
                });
            }

            return lfc;
        }


    }
}
