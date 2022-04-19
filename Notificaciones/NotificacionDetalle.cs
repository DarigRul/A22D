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
using Entidades.Notificaciones;
using Datos.Notificaciones;
using Datos.Utilitarios;

namespace ALTIMA_ERP_2022.Notificaciones
{
    public partial class NotificacionDetalle : OfficeForm
    {
        public ENotificacion _eNotificacion;
        public Action refrescar; 

        public NotificacionDetalle()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //El usuario seleccionó poner en visto la notificación
                if (chbVisto.Checked && chbVisto.Enabled)
                {
                    DialogResult dr = MessageBoxEx.Show("Cambiará el estatus de la notificación a VISTO\r\n¿Está seguro?",
                            "Cambio de estátus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        DNotificaciones.CambiarEstatusVisto(_eNotificacion.id_notificacion);
                        
                        refrescar.Invoke();
                        MessageBoxEx.Show("La notificación fue actualizada a \"VISTO\"", "Notificación actualizada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        Dispose();
                    }
                    else
                    {
                        chbVisto.Checked = false; 
                        btnAceptar_Click(this, EventArgs.Empty);
                    }
                }
                else
                {
                    Close();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.StackTrace}\r\n{ex.InnerException}", "Error inesperado!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NotificacionDetalle_Load(object sender, EventArgs e)
        {
            dtiFechaCreacion.Value = _eNotificacion.fecha_creacion;
            dtiFechaVisto.Text = _eNotificacion.fecha_visto == Convert.ToDateTime("01/01/1900") ? string.Empty : _eNotificacion.fecha_visto.ToString();
            lblEstatus.Text = _eNotificacion.estatus == 0 ? "NUEVA" : "VISTO";
            txtDescripcion.Text = _eNotificacion.descripcion;

            if (_eNotificacion.estatus==0)
            {
                chbVisto.Enabled = true;
            }
            else
            {
                chbVisto.Checked = true;
                chbVisto.Enabled = false; 
            }
        }
    }
}
