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
using Entidades.Compras;
using Datos.Compras;
using Datos.Utilitarios.Historico;
using System.Text.RegularExpressions;

namespace ALTIMA_ERP_2022.Compras.CatProveedores
{
    public partial class ProveedorContactosAM : OfficeForm
    {
        public EProveedor proveedor;
        public EProveedorContacto contacto; 

        public enum Movimiento : byte { agregar = 1, modificar = 2};
        public Movimiento movimiento;

        public Action refrescar; 

        public ProveedorContactosAM()
        {
            InitializeComponent();
        }

        private void ProveedorContactosAM_Load(object sender, EventArgs e)
        {
            try
            {
                switch (movimiento)
                {
                    case Movimiento.agregar:
                        txtNombre.Focus(); 
                        break;
                    case Movimiento.modificar:
                        txtNombre.Text = contacto.nombre_contacto; 
                        txtTelefono.Text = contacto.telefono_contacto;
                        txtExtension.Text = contacto.extension_contacto;
                        txtCelular.Text = contacto.celular_contacto;
                        txtPuesto.Text = contacto.puesto_contacto;
                        txtObservaciones.Text = contacto.observaciones;

                        txtNombre.Focus(); 
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}","Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valida())
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            var nuevo = CargaDatos(); 
                            string valor = $"Nombre contacto: {nuevo.nombre_contacto} / Teléfono: {nuevo.telefono_contacto} / Celular: {nuevo.celular_contacto} / Email: {nuevo.email_contacto}"; 


                            if(DProveedorContacto.Agregar(nuevo)>0)
                            {
                                DHistorico.RegistraHistorico("Compras", "Proveedor Contacto", "Agregar", "", valor);
                                refrescar.Invoke();
                                MessageBoxEx.Show($"El contacto {nuevo.nombre_contacto} se registro correctamente", "Contacto registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }

                            break;
                        case Movimiento.modificar:
                            var cm = CargaDatos();
                            cm.id_contacto = contacto.id_contacto;
                            cm.id_proveedor_contacto = contacto.id_proveedor_contacto; 

                            string valorAnterior = $"Nombre contacto: {contacto.nombre_contacto} / Teléfono: {contacto.telefono_contacto} / Celular: {contacto.celular_contacto} / Email: {contacto.email_contacto}";
                            string valorNuevo = $"Nombre contacto: {cm.nombre_contacto} / Teléfono: {cm.telefono_contacto} / Celular: {cm.celular_contacto} / Email: {cm.email_contacto}";

                            if (DProveedorContacto.Modificar(cm)>0)
                            {
                                DHistorico.RegistraHistorico("Compras", "Proveedor Contacto", "Modificar", valorAnterior, valorNuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show($"El contacto {cm.nombre_contacto} se actualizó correctamente", "Contacto actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }


                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private EProveedorContacto CargaDatos()
        {
            var nuevo = new EProveedorContacto();
            nuevo.id_proveedor_contacto = proveedor.id_proveedor;
            nuevo.nombre_contacto = txtNombre.Text.Trim();
            nuevo.telefono_contacto = txtTelefono.Text.Trim();
            nuevo.extension_contacto = txtExtension.Text.Trim();
            nuevo.celular_contacto = txtCelular.Text.Trim();
            nuevo.email_contacto = txtEmail.Text.Trim();
            nuevo.puesto_contacto = txtPuesto.Text.Trim();
            nuevo.observaciones = txtObservaciones.Text.Trim();

            return nuevo; 
        }


        private bool Valida()
        {
            if (txtNombre.Text.Trim() == String.Empty)
            {
                MessageBoxEx.Show("Capture el nombre completo del contacto", "Nombre de contacto no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus(); 
                return false; 
            }
            else
            {
                return true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }

        private void ProveedorContactosAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(this, EventArgs.Empty); 
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //El campo email ha sido capturado
            if (txtEmail.Text.Trim() != String.Empty)
            {
                string email = txtEmail.Text.Trim();
                string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                if (Regex.Replace(email, expresion, String.Empty).Length != 0)
                {
                    MessageBoxEx.Show("Capture un correo electrónico válido", "Email no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                }
            }
        }
    }
}
