using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Usuarios;
using Entidades.Usuarios;
using Datos.Utilitarios.Historico;

namespace ALTIMA_ERP_2022.Usuarios
{
    public partial class CatalogoUsuariosAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public Action refrescar;
        public EUsuarios eUsuarioModificar;

        public CatalogoUsuariosAM()
        {
            InitializeComponent();
        }

        private void CatalogoUsuariosAM_Load(object sender, EventArgs e)
        {
            //Se crea la lista de permisos
            List<ERol> eRoles = new List<ERol>();
            eRoles = DRol.getRoles();
            cmbPerfil.DataSource = eRoles;
            cmbPerfil.DisplayMember = "Nombre";
            cmbPerfil.ValueMember = "Id_perfil";

            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtUsuario.Text = "";
                    txtNombre.Text = "";
                    txtPaterno.Text = "";
                    txtMaterno.Text = "";
                    txtCorreo.Text = "";
                    txtTelefono.Text = "";
                    txtContraena.Text = "";
                    cmbPerfil.SelectedIndex = -1;
                    txtUsuario.Focus();
                    break;
                case Movimiento.modificar:
                    txtUsuario.Text = eUsuarioModificar.usuario;
                    txtNombre.Text = eUsuarioModificar.nombre;
                    txtPaterno.Text = eUsuarioModificar.paterno;
                    txtMaterno.Text = eUsuarioModificar.materno;
                    txtCorreo.Text = eUsuarioModificar.correo;
                    txtTelefono.Text = eUsuarioModificar.telefono;
                    cmbPerfil.SelectedValue = eUsuarioModificar.id_perfil;
                    txtContraena.Text = eUsuarioModificar.contrasena;
                    txtUsuario.Focus();
                    break;
                default:
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EUsuarios eUsuarios = new EUsuarios();
                int id_usuario = 0;
                string valor_nuevo = "";
                string valor_anterior = "";
                if (ValidaCampos())
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            EUsuarios usu = new EUsuarios();
                            usu.usuario = txtUsuario.Text;
                            usu.nombre = txtNombre.Text;
                            usu.paterno = txtPaterno.Text;
                            usu.materno = txtMaterno.Text;
                            usu.correo = txtCorreo.Text;
                            usu.telefono = txtTelefono.Text;
                            usu.id_perfil = (int)cmbPerfil.SelectedValue;
                            usu.contrasena = txtContraena.Text;

                            id_usuario = DUsuario.AgregarUsuario(usu);

                            valor_nuevo += "Usuario: " + txtUsuario.Text + " / ";
                            valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                            valor_nuevo += "Apellido paterno: " + txtPaterno.Text + " / ";
                            valor_nuevo += "Apellido Materno: " + txtMaterno.Text + " / ";
                            valor_nuevo += "Correo: " + txtCorreo.Text + " / ";
                            valor_nuevo += "Teléfono: " + txtTelefono.Text + " / ";
                            valor_nuevo += "Perfil: " + cmbPerfil.Text + " / ";

                            if (id_usuario > 0)
                            {
                                DHistorico.RegistraHistorico("Usuarios", "Catálogo Usuarios", "Nuevo Usuario", valor_anterior, valor_nuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Usuario registrado correctamente", "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;
                        case Movimiento.modificar:

                            EUsuarios usuMod = new EUsuarios();
                            usuMod.id_usuario = eUsuarioModificar.id_usuario;
                            usuMod.usuario = txtUsuario.Text;
                            usuMod.nombre = txtNombre.Text;
                            usuMod.paterno = txtPaterno.Text;
                            usuMod.materno = txtMaterno.Text;
                            usuMod.correo = txtCorreo.Text;
                            usuMod.telefono = txtTelefono.Text;
                            usuMod.id_perfil = (int)cmbPerfil.SelectedValue;
                            usuMod.contrasena = txtContraena.Text;

                            id_usuario = DUsuario.ModificarUsuario(usuMod);

                            valor_nuevo += "Usuario: " + txtUsuario.Text + " / ";
                            valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                            valor_nuevo += "Apellido paterno: " + txtPaterno.Text + " / ";
                            valor_nuevo += "Apellido Materno: " + txtMaterno.Text + " / ";
                            valor_nuevo += "Correo: " + txtCorreo.Text + " / ";
                            valor_nuevo += "Teléfono: " + txtTelefono.Text + " / ";
                            valor_nuevo += "Perfil: " + cmbPerfil.Text + " / ";

                            valor_anterior += "Usuario: " + eUsuarioModificar.usuario + " / ";
                            valor_anterior += "Nombre: " + eUsuarioModificar.nombre + " / ";
                            valor_anterior += "Apellido paterno: " + eUsuarioModificar.paterno + " / ";
                            valor_anterior += "Apellido Materno: " + eUsuarioModificar.materno + " / ";
                            valor_anterior += "Correo: " + eUsuarioModificar.correo + " / ";
                            valor_anterior += "Teléfono: " + eUsuarioModificar.telefono + " / ";
                            valor_anterior += "Perfil: " + eUsuarioModificar.perfil + " / ";

                            if (id_usuario > 0)
                            {
                                DHistorico.RegistraHistorico("Usuarios", "Catálogo Usuarios", "Modificar Usuario", valor_anterior, valor_nuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Usuario registrado correctamente", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtUsuario.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el usuario", "Usuario no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return false;
            }

            if (txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el nombre", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }

            if (txtPaterno.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el apellido paterno", "Apellido parterno no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaterno.Focus();
                return false;
            }

            if (txtCorreo.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el correo", "Correo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                return false;
            }

            if (txtTelefono.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el teléfono", "Teléfono no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return false;
            }

            if (cmbPerfil.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione el rol", "Rol no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return false;
            }

            if (txtContraena.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture la contraseña", "Contraseña no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraena.Focus();
                return false;
            }

            return true;
        }
    }
}
