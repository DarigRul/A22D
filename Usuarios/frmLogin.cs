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

namespace ALTIMA_ERP_2022.Usuarios
{
    public partial class frmLogin : OfficeForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
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

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Ingresando al sistema", "Acceso autorizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
        }
    }
}
