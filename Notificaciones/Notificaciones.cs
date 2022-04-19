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
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Notificaciones;
using Datos.Notificaciones;
using Datos.Utilitarios;

namespace ALTIMA_ERP_2022.Notificaciones
{
    public partial class Notificaciones : OfficeForm
    {
        public delegate void refreshNotifications();
        public event refreshNotifications refreshing; 


        private List<ENotificacion> lstNotificaciones = new List<ENotificacion>();
        private GridPanel panel;

        public Notificaciones()
        {
            InitializeComponent();
        }
        private void Notificaciones_Load(object sender, EventArgs e)
        {
            dtiFechaInicial.Value = DateTime.Today - TimeSpan.FromDays(60);
            dtiFechaFinal.Value = DateTime.Today;

            btnImportar_Click(this, EventArgs.Empty);
            
        }

        private void sgcNotificaciones_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            //Abrimos la pantalla de detalles de notificación 
            var detalle = new NotificacionDetalle();
            GridRow  row = panel.ActiveRow as GridRow;
            var _enotificacion = (ENotificacion) row.DataItem;
            detalle._eNotificacion = _enotificacion;
            detalle.refrescar += () => btnImportar_Click(this, EventArgs.Empty);
            detalle.refrescar += () => refreshing.Invoke(); 
            detalle.Show();

        }

        private void sgcNotificaciones_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                if (Convert.ToInt32(row.Cells["estatus"].Value)==0 )
                {
                    row.Cells["fecha_visto"].Value = "01/01/1900";
                    row.Cells["estatus_texto"].Value = "NUEVA";
                }
                else
                {
                    row.CellStyles.Default.Background.Color1 = Color.LightGreen;
                    row.Cells["estatus_texto"].Value = "VISTO"; 
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                lstNotificaciones = DNotificaciones.ListarNotificaciones(ConfiguracionGlobal.usuario.id_usuario, dtiFechaInicial.Value, dtiFechaFinal.Value + TimeSpan.FromDays(1));
                panel = sgcNotificaciones.PrimaryGrid;
                panel.DataSource = lstNotificaciones;
                

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "¡Error de conexión con la Base de Datos!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
