using Datos.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALTIMA_ERP_2022.Utilitarios;
using DevComponents.DotNetBar;
using Datos;
using Entidades.Usuarios;
using System.Runtime.InteropServices;

namespace ALTIMA_ERP_2022
{
    public partial class LoginT : Form
    {
        public LoginT()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "")
            {
                if(txtPass.Text != "")
                {
                    DConexion.conexionLocal = tipoConexion.Value;
                    try
                    {
                        var usuario = DUsuario.login(txtUsuario.Text, txtPass.Text);
                        if (usuario.id_usuario != 0)
                        {
                            Main main = new Main();
                            ConfiguracionGlobal.usuario = usuario;
                            main.lblMensajes.Text = usuario.nombre; 
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            mensajeError("El usuario y/o contraseña es incorrecto");
                        }
                    }
                    catch (Exception ex)
                    {
                        mensajeError(ex.Message);
                    }
                }
                else
                {
                    mensajeError("Ingrese su contraseña");
                }
            }
            else
            {
                mensajeError("Ingrese su usuario");
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAcceder_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
                Dispose();
                Application.Exit();
            }
        }

        private void mensajeError(string mensaje)
        {
            MessageBoxEx.Show(mensaje, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginT_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void labelX1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnMinimizar.Cursor = Cursors.Hand;
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.Cursor = Cursors.Default;
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnCerrar.Cursor = Cursors.Hand;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.Cursor = Cursors.Default;
        }

        private void LoginT_Load(object sender, EventArgs e)
        {
            //Valores precargados para desarrollo 
            txtUsuario.Text = "Admin";
            txtPass.Text = "Cdmx100*";
            tipoConexion.Value = true; 
        }
    }
}
