using Datos.Usuarios;
using DevComponents.DotNetBar;
using Entidades.Usuarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ALTIMA_ERP_2022.Usuarios.Permisos
{
    public partial class CatologoPermisosAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public Action refrescar;
        public ERol rolModificar;
        public List<EPermiso> lstPermisos = new List<EPermiso>();
        public List<EPermiso> lstPermisosAcceso = new List<EPermiso>();
        public List<EPermiso> lstPermisosAccesoCopy = new List<EPermiso>();
        public List<EPermiso> lstPermisosBotones = new List<EPermiso>();
        public List<EPermiso> lstPermisosBotonesAcceso = new List<EPermiso>();
        public List<EPermiso> lstPermisosBotonesAccesoCopy = new List<EPermiso>();

        public CatologoPermisosAM()
        {
            InitializeComponent();
        }

        private void CatologoPermisosAM_Load(object sender, EventArgs e)
        {
            // Se llenana la lista de combos con los permisos
            lstPermisos = DPermiso.getPermisos_por_perfil(rolModificar.Id_perfil, 1, 0);
            lstPermisosAcceso = DPermiso.getPermisos_por_perfil(rolModificar.Id_perfil, 0, 0);
            lstPermisosBotones = DPermiso.getPermisos_por_perfil(rolModificar.Id_perfil, 1, 1);
            lstPermisosBotonesAcceso = DPermiso.getPermisos_por_perfil(rolModificar.Id_perfil, 0, 1);

            lstPermisosAccesoCopy = lstPermisosAcceso;
            lstPermisosBotonesAccesoCopy = lstPermisosBotonesAcceso;

            //Combo de permisos
            lcmbPermisos.DataSource = lstPermisos;
            lcmbPermisos.DisplayMember = "descripcion";
            lcmbPermisos.ValueMember = "id_opcion";

            //Combo de Acceso
            lcmbAcceso.DataSource = lstPermisosAcceso;
            lcmbAcceso.DisplayMember = "descripcion";
            lcmbAcceso.ValueMember = "id_opcion";

            //Combo de Acceso
            lcmbBotones.DataSource = lstPermisosBotones;
            lcmbBotones.DisplayMember = "descripcion";
            lcmbBotones.ValueMember = "id_opcion";

            //Combo de Acceso
            lcmbAccesoBotones.DataSource = lstPermisosBotonesAcceso;
            lcmbAccesoBotones.DisplayMember = "descripcion";
            lcmbAccesoBotones.ValueMember = "id_opcion";

            habilitarDeshabilitarBotonesPermiso();
            habilitarDeshabilitarBotonesBotones();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (movimiento)
                {
                    case Movimiento.agregar:
                        break;
                    case Movimiento.modificar:
                        int id_perfil = rolModificar.Id_perfil;
                        var jsonSerialiser = new JavaScriptSerializer();
                        var jsonPermisos = jsonSerialiser.Serialize(lstPermisosAcceso);
                        var jsonSerialiser1 = new JavaScriptSerializer();
                        var jsonBotones = jsonSerialiser1.Serialize(lstPermisosBotonesAcceso);
                        string usuario = Utilitarios.ConfiguracionGlobal.usuario.usuario;

                        string result = DPermiso.AgregarPermisos_por_perfil(id_perfil, jsonPermisos, jsonBotones, usuario);

                        Close();
                        Dispose();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                var list = lcmbPermisos.SelectedValues.ToList();
                var newLstPermisos = lstPermisos;
                var newLstPermisosAcceso = lstPermisosAcceso;

                foreach (var id_opcion in list)
                {
                    var itemToAdd = newLstPermisos.Single(r => r.Id_opcion == (int)id_opcion);
                    newLstPermisosAcceso.Add(itemToAdd);

                    var itemToRemove = newLstPermisos.Single(r => r.Id_opcion == (int)id_opcion);
                    newLstPermisos.Remove(itemToRemove);
                }

                lstPermisos = newLstPermisos;
                lstPermisosAcceso = newLstPermisosAcceso;

                lstPermisos = lstPermisos.OrderBy(x => x.descripcion).ToList();
                lstPermisosAcceso = lstPermisosAcceso.OrderBy(x => x.descripcion).ToList();

                lcmbPermisos.DataSource = lstPermisos;
                lcmbAcceso.DataSource = lstPermisosAcceso;

                habilitarDeshabilitarBotonesPermiso();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                var list = lcmbAcceso.SelectedValues.ToList();
                var newLstPermisos = lstPermisos;
                var newLstPermisosAcceso = lstPermisosAcceso;

                foreach (var id_opcion in list)
                {
                    var itemToAdd = newLstPermisosAcceso.Single(r => r.Id_opcion == (int)id_opcion);
                    newLstPermisos.Add(itemToAdd);

                    var itemToRemove = newLstPermisosAcceso.Single(r => r.Id_opcion == (int)id_opcion);
                    newLstPermisosAcceso.Remove(itemToRemove);
                }

                lstPermisos = newLstPermisos;
                lstPermisosAcceso = newLstPermisosAcceso;

                lstPermisos = lstPermisos.OrderBy(x => x.descripcion).ToList();
                lstPermisosAcceso = lstPermisosAcceso.OrderBy(x => x.descripcion).ToList();

                lcmbPermisos.DataSource = lstPermisos;
                lcmbAcceso.DataSource = lstPermisosAcceso;
                habilitarDeshabilitarBotonesPermiso();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAgregarBoton_Click(object sender, EventArgs e)
        {
            try
            {
                var list = lcmbBotones.SelectedValues.ToList();
                var newLstPermisosBotones = lstPermisosBotones;
                var newLstPermisosBotonesAcceso = lstPermisosBotonesAcceso;

                foreach (var id_opcion in list)
                {
                    var itemToAdd = newLstPermisosBotones.Single(r => r.Id_opcion == (int)id_opcion);
                    newLstPermisosBotonesAcceso.Add(itemToAdd);

                    var itemToRemove = newLstPermisosBotones.Single(r => r.Id_opcion == (int)id_opcion);
                    newLstPermisosBotones.Remove(itemToRemove);
                }

                lstPermisosBotones = newLstPermisosBotones;
                lstPermisosBotonesAcceso = newLstPermisosBotonesAcceso;

                lstPermisosBotones = lstPermisosBotones.OrderBy(x => x.descripcion).ToList();
                lstPermisosBotonesAcceso = lstPermisosBotonesAcceso.OrderBy(x => x.descripcion).ToList();

                lcmbBotones.DataSource = lstPermisosBotones;
                lcmbAccesoBotones.DataSource = lstPermisosBotonesAcceso;

                habilitarDeshabilitarBotonesBotones();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarBoton_Click(object sender, EventArgs e)
        {
            try
            {
                var list = lcmbAccesoBotones.SelectedValues.ToList();
                var newLstPermisosBotones = lstPermisosBotones;
                var newLstPermisosBotonesAcceso = lstPermisosBotonesAcceso;

                foreach (var id_opcion in list)
                {
                    var itemToAdd = newLstPermisosBotonesAcceso.Single(r => r.Id_opcion == (int)id_opcion);
                    newLstPermisosBotones.Add(itemToAdd);

                    var itemToRemove = newLstPermisosBotonesAcceso.Single(r => r.Id_opcion == (int)id_opcion);
                    newLstPermisosBotonesAcceso.Remove(itemToRemove);
                }

                lstPermisosBotones = newLstPermisosBotones;
                lstPermisosBotonesAcceso = newLstPermisosBotonesAcceso;

                lstPermisosBotones = lstPermisosBotones.OrderBy(x => x.descripcion).ToList();
                lstPermisosBotonesAcceso = lstPermisosBotonesAcceso.OrderBy(x => x.descripcion).ToList();

                lcmbBotones.DataSource = lstPermisosBotones;
                lcmbAccesoBotones.DataSource = lstPermisosBotonesAcceso;

                habilitarDeshabilitarBotonesBotones();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void habilitarDeshabilitarBotonesPermiso()
        {
            if (lstPermisos.Count == 0)
            {
                btnAgregarPermiso.Enabled = false;
            }
            else
            {
                btnAgregarPermiso.Enabled = true;
            }

            if (lstPermisosAcceso.Count == 0)
            {
                btnQuitarPermiso.Enabled = false;
            }
            else
            {
                btnQuitarPermiso.Enabled = true;
            }
        }

        private void habilitarDeshabilitarBotonesBotones()
        {
            if (lstPermisosBotones.Count == 0)
            {
                btnAgregarBoton.Enabled = false;
            }
            else
            {
                btnAgregarBoton.Enabled = true;
            }

            if (lstPermisosBotonesAcceso.Count == 0)
            {
                btnQuitarBoton.Enabled = false;
            }
            else
            {
                btnQuitarBoton.Enabled = true;
            }
        }
    }
}
