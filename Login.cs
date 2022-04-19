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

namespace ALTIMA_ERP_2022
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "")
            {
                if(txtPass.Text != "")
                {
                    var usuario = DUsuario.login(txtUsuario.Text, txtPass.Text);
                    if(usuario.id_usuario != 0)
                    {
                        Main main = new Main();
                        ConfiguracionGlobal.usuario = usuario;
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        mensajeError("El usuario y/o contraseña es incorrecto");
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
    }
}
