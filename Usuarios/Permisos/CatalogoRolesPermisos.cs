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

namespace ALTIMA_ERP_2022.Usuarios.Permisos
{
    public partial class CatalogoRolesPermisos : OfficeForm
    {
        private List<ERol> lstRoles = new List<ERol>();
        private GridPanel panel;

        public CatalogoRolesPermisos()
        {
            InitializeComponent();
        }

        private void CatalogoRoles_Load(object sender, EventArgs e)
        {
            //Se obtienen los permisos de los botones
            btnAgregar.Visible = ConfiguracionGlobal.pBtnAgregar;
            btnActivar.Visible = ConfiguracionGlobal.pBtnActivar;
            btnDesactivar.Visible = ConfiguracionGlobal.pBtnDesactivar;
            btnEditar.Visible = ConfiguracionGlobal.pBtnEditar;
            btnReporte.Visible = ConfiguracionGlobal.pBtnReporte;

            //Instanciamos la capa de datos y obtenemos la lista que será fuente de datos para el supergrid
            lstRoles = DRol.getRoles();

            // Asignamos el gridpanel al PrimaryGrid y asignamos la fuente de datos
            panel = sgcRoles.PrimaryGrid;
            panel.DataSource = lstRoles;

            btnAgregar.Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnReporte.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var ntm = new CatologoPermisosAM();
            ntm.refrescar += () => CatalogoRoles_Load(this, EventArgs.Empty);
            ntm.movimiento = CatologoPermisosAM.Movimiento.agregar;
            ntm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la fila seleccionada
            GridRow row = panel.ActiveRow as GridRow;

            //Obtenemos el Id_perfil y lo buscamos en la lista de Roles (es la fuente del supegrid)
            int Id_perfil = Convert.ToInt32(row["Id_perfil"].Value);
            var rolModificar = lstRoles.Find(x => x.Id_perfil == Id_perfil);

            //Instanciamos el formulario y asignamos sus valores
            var cr = new CatologoPermisosAM();
            cr.rolModificar = rolModificar;
            cr.movimiento = CatologoPermisosAM.Movimiento.modificar;

            //Escuchamos el delegado para refrescar la pantalla del catálogo
            cr.refrescar += () => CatalogoRoles_Load(this, EventArgs.Empty);

            //Mostramos el formulario con los datos pasados 
            cr.ShowDialog();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar el rol 
            DialogResult dr = MessageBoxEx.Show("Se activará el rol, ¿Está seguro?", "Activar rol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_perfil
                var row = panel.ActiveRow as GridRow;
                int Id_perfil = Convert.ToInt32(row["Id_perfil"].Value);

                //Activamos el rol
                DRol.ActivarRol(Id_perfil);
                CatalogoRoles_Load(this, EventArgs.Empty);

            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar el rol 
            DialogResult dr = MessageBoxEx.Show("Se desactivará el rol, ¿Está seguro?", "Desactivar rol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el Id_perfil
                var row = panel.ActiveRow as GridRow;
                int Id_perfil = Convert.ToInt32(row["Id_perfil"].Value);

                //Activamos el rol
                DRol.DesactivarRol(Id_perfil);
                CatalogoRoles_Load(this, EventArgs.Empty);

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

        private void sgcRoles_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int id_estatus = Convert.ToInt32(row["id_estatus"].Value);

                //Si el estatus es 0, coloreamos la fila completa en rojo y el texto en blanco 
                if (id_estatus == 0)
                {
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;

                    //Configuramos el tipo y color de las letras
                    FontFamily family = new FontFamily("Microsoft Sans Serif");
                    Font f = new Font(family, 8.5f, FontStyle.Bold);

                    row.CellStyles.Default.Font = f;
                    row.CellStyles.Default.TextColor = Color.White;

                    //El estatus en la base de datos es cero y uno, por lo cual agregamos el texto en forma manual 
                    row["estatus_texto"].Value = "DESACTIVADO";
                }
                else
                {
                    row["estatus_texto"].Value = "ACTIVO";
                }
            }
        }

        private void sgcRoles_SelectionChanged(object sender, GridEventArgs e)
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
    }
}
