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
using Datos.Usuarios;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Usuarios;

namespace ALTIMA_ERP_2022.Usuarios
{
    public partial class CatalogoUsuarios : OfficeForm
    {
        private List<EUsuarios> lstUsuario = new List<EUsuarios>();
        private GridPanel panel;

        public CatalogoUsuarios()
        {
            InitializeComponent();
        }

        private void CatalogoUsuarios_Load(object sender, EventArgs e)
        {
            //Se obtienen los permisos de los botones
            btnAgregar.Visible = ConfiguracionGlobal.pBtnAgregar;
            btnActivar.Visible = ConfiguracionGlobal.pBtnActivar;
            btnDesactivar.Visible = ConfiguracionGlobal.pBtnDesactivar;
            btnEditar.Visible = ConfiguracionGlobal.pBtnEditar;
            btnReporte.Visible = ConfiguracionGlobal.pBtnReporte;

            //Instanciamos la capa de datos y obtenemos la lista que será fuente de datos para el supergrid
            lstUsuario = DUsuario.getUsuarios();

            // Asignamos el gridpanel al PrimaryGrid y asignamos la fuente de datos
            panel = sgcUsuarios.PrimaryGrid;
            panel.DataSource = lstUsuario;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var ntm = new CatalogoUsuariosAM();
            ntm.refrescar += () => CatalogoUsuarios_Load(this, EventArgs.Empty);
            ntm.movimiento = CatalogoUsuariosAM.Movimiento.agregar;
            ntm.ShowDialog();
        }

        #region utilitarios

        #endregion

        private void sgcUsuarios_SelectionChanged(object sender, GridEventArgs e)
        {
            // En este evento activamos o desactivamos los botones "Activar" o "Desactivar"
            var row = panel.ActiveRow as GridRow;

            //Si el estatus está activado 
            if (Estatus(row))
            {
                btnActivar.Enabled = false;
                btnDesactivar.Enabled = true;
                btnEditar.Enabled = true;
            }
            else //Estatus desactivado
            {
                btnActivar.Enabled = true;
                btnDesactivar.Enabled = false;
                btnEditar.Enabled = false;
            }
        }

        private bool Estatus(GridRow row)
        {
            int estatus = Convert.ToInt32(row["id_estatus"].Value);
            if (estatus == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void sgcUsuarios_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int id_estatus = Convert.ToInt32(row["id_estatus"].Value);

                //Si el estatus es 0, coloreamos la fila completa en rojo y el texto en blanco 
                if (id_estatus == 2)
                {
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;

                    //Configuramos el tipo y color de las letras
                    FontFamily family = new FontFamily("Microsoft Sans Serif");
                    Font f = new Font(family, 8.5f, FontStyle.Bold);

                    row.CellStyles.Default.Font = f;
                    row.CellStyles.Default.TextColor = Color.White;

                    //El estatus en la base de datos es cero y uno, por lo cual agregamos el texto en forma manual 
                    row["estatus"].Value = "DESACTIVADO";
                }
                else
                {
                    row["estatus"].Value = "ACTIVO";
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la fila seleccionada
            GridRow row = panel.ActiveRow as GridRow;

            //Obtenemos el id_usuario y lo buscamos en la lista de Usuarios (es la fuente del supegrid)
            int id_usuario = Convert.ToInt32(row["id_usuario"].Value);
            var usuarioModificar = lstUsuario.Find(x => x.id_usuario == id_usuario);

            //Instanciamos el formulario y asignamos sus valores
            var ctm = new CatalogoUsuariosAM();
            ctm.eUsuarioModificar = usuarioModificar;
            ctm.movimiento = CatalogoUsuariosAM.Movimiento.modificar;

            //Escuchamos el delegado para refrescar la pantalla del catálogo
            ctm.refrescar += () => CatalogoUsuarios_Load(this, EventArgs.Empty);

            //Mostramos el formulario con los datos pasados 
            ctm.ShowDialog();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar el usuario 
            DialogResult dr = MessageBoxEx.Show("Se activará el Usuario, ¿Está seguro?", "Activar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_usuario
                var row = panel.ActiveRow as GridRow;
                int id_usuario = Convert.ToInt32(row["id_usuario"].Value);

                //Activamos el usuario
                DUsuario.ActivarUsuario(id_usuario);
                CatalogoUsuarios_Load(this, EventArgs.Empty);

            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar el usuario 
            DialogResult dr = MessageBoxEx.Show("Se desactivará el Usuario, ¿Está seguro?", "desactivar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_usuario
                var row = panel.ActiveRow as GridRow;
                int id_usuario = Convert.ToInt32(row["id_usuario"].Value);

                //Activamos el Usuario
                DUsuario.DesactivarUsuario(id_usuario);
                CatalogoUsuarios_Load(this, EventArgs.Empty);

            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("REPORTE PENDIENTE POR PROGRAMAR", "REPORTE PENDIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcUsuarios, "catalogo_usuarios");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        //Metodo para configurar los shortcuts
        private void CatalogoUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            //Shortcuts
            if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(this, EventArgs.Empty);
            }
            else if (e.Control && e.KeyCode == Keys.A) //Combinacion de teclas Control + A
            {
                btnAgregar_Click(this, EventArgs.Empty);
            }
            else if (e.Control && e.KeyCode == Keys.E) // Combinacion Control + E 
            {
                btnEditar_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnDesactivar_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                btnActivar_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(this, EventArgs.Empty);
            }

        }
    }
}
