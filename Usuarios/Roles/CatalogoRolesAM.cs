using Datos.Diseno;
using Datos.Usuarios;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALTIMA_ERP_2022.Usuarios.Roles
{
    public partial class CatalogoRolesAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public Action refrescar;
        public ERol rolModificar;

        public CatalogoRolesAM()
        {
            InitializeComponent();
        }

        private void CatalogoRolesAM_Load(object sender, EventArgs e)
        {
            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    txtNombre.Focus();
                    break;
                case Movimiento.modificar:

                    txtNombre.Text = rolModificar.Nombre;
                    txtDescripcion.Text = rolModificar.Descripcion;
                    break;
                default:
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    string mensaje = "";
                    string valor_nuevo = "";
                    string valor_anterior = "";
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            ERol rol = new ERol();
                            rol.Nombre = txtNombre.Text.Trim();
                            rol.Descripcion = txtDescripcion.Text.Trim();
                            
                            valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                            valor_nuevo += "Descripción: " + txtDescripcion.Text + " / ";

                            //Registramos el Rol
                            mensaje = DRol.AgregarRol(rol);
                            if (mensaje == "")
                            {
                                DHistorico.RegistraHistorico("Rol", "Catálogo Roles", "Agregar Rol", "", valor_nuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Rol registrado correctamente", "Nuevo Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique, " + mensaje, "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case Movimiento.modificar:
                            ERol rolActualizar = new ERol();

                            valor_anterior += "Nombre: " + rolModificar.Nombre + " / ";
                            valor_anterior += "Descripción: " + rolModificar.Descripcion + " / ";

                            rolActualizar.Id_perfil = rolModificar.Id_perfil;
                            rolActualizar.Nombre = txtNombre.Text.Trim();
                            rolActualizar.Descripcion = txtDescripcion.Text.Trim();

                            valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                            valor_nuevo += "Descripción: " + txtDescripcion.Text + " / ";

                            //Registramos el Rol
                            mensaje = DRol.ModificarRol(rolActualizar);
                            if (mensaje == "")
                            {
                                DHistorico.RegistraHistorico("Rol", "Catálogo Roles", "Modificar Rol", valor_anterior, valor_nuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Rol registrado correctamente", "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique, " + mensaje, "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBoxEx.Show("Capture el nombre del rol", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (txtDescripcion.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture la descripción", "Descripción no valida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
