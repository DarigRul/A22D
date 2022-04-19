using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Diseno;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Diseno;

namespace ALTIMA_ERP_2022.Diseno.Produccion.CatRutasProduccion
{
    public partial class RutasProduccionAM : OfficeForm
    {
        List<EProcesos> lsteProcesos;
        public ERutasProduccion rutaModificar;
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public RutasProduccionAM()
        {
            InitializeComponent();
        }

        private void RutasProduccionAM_Load(object sender, EventArgs e)
        {
            if (movimiento == Movimiento.modificar)
            {
                txtNombre.Text = rutaModificar.nombre;
                foreach (EProcesos item in rutaModificar.procesos)
                {
                    ListViewItem lvi = new ListViewItem(item.id_proceso.ToString());
                    lvi.SubItems.Add(item.nombre);
                    lvi.SubItems.Add(item.tipo);
                    lvProcesos.Items.Add(lvi);
                }
                btnAceptar.Text = "Actualizar";
            }
            lsteProcesos = DProcesos.ProcesosListar().Where(x => x.departamento == "    ").ToList();
            cmbprocesostree.DataSource = lsteProcesos;
            cmbprocesostree.ValueMember = "id_proceso";
            cmbprocesostree.SelectedIndex = -1;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbprocesostree.SelectedIndex > -1)
            {
                string id, nombre_seleccionado, tipo_seleccionado;
                id = cmbprocesostree.SelectedValue.ToString();
                nombre_seleccionado = lsteProcesos.Where(x => x.id_proceso == Convert.ToInt32(id)).First().nombre;
                tipo_seleccionado = lsteProcesos.Where(x => x.id_proceso == Convert.ToInt32(id)).First().tipo;
                int existe = 0;
                foreach (ListViewItem item in lvProcesos.Items)
                {
                    if (item.Text == id)
                    {
                        existe++;
                    }
                }
                if (existe == 0)
                {
                    ListViewItem lvi = new ListViewItem(id);
                    lvi.SubItems.Add(nombre_seleccionado);
                    lvi.SubItems.Add(tipo_seleccionado);
                    lvProcesos.Items.Add(lvi);
                    cmbprocesostree.SelectedIndex = -1;
                    cmbprocesostree.Focus();
                }
                else
                {

                    MessageBoxEx.Show("El proceso ya se encuenta en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbprocesostree.SelectedIndex = -1;
                    cmbprocesostree.Focus();
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item = lvProcesos.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            lvProcesos.Items.Remove(item);
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validacampos() == false)
            {
                if (movimiento == Movimiento.agregar)
                {
                    //creamos la lista de procesos a guardar
                    ERutasProduccion rutaGuardar = new ERutasProduccion()
                    {
                        nombre = txtNombre.Text,
                        id_departamento = 2,

                    };
                    foreach (ListViewItem item in lvProcesos.Items)
                    {
                        EProcesos procesos = new EProcesos()
                        {
                            id_proceso = Convert.ToInt32(item.Text),

                        };
                        rutaGuardar.procesos.Add(procesos);

                    }
                    DRutasProduccion guarda = new DRutasProduccion();
                    if (guarda.rutasAgregar(rutaGuardar) == true)
                    {
                        // Registramos el historico
                        DHistorico.RegistraHistorico("Diseño", "Ruta de producción", "Agrega Ruta producción", rutaGuardar.nombre);

                        MessageBoxEx.Show("Ruta de producción registrada correctamente", "Ruta de producción registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        Dispose();
                    }
                }
                else
                {
                    //creamos la lista de procesos a guardar
                    ERutasProduccion rutaGuardar = new ERutasProduccion()
                    {
                        id_ruta = rutaModificar.id_ruta,
                        nombre = txtNombre.Text,
                        id_departamento = 2,

                    };
                    foreach (ListViewItem item in lvProcesos.Items)
                    {
                        EProcesos procesos = new EProcesos()
                        {
                            id_proceso = Convert.ToInt32(item.Text),

                        };
                        rutaGuardar.procesos.Add(procesos);

                    }
                    DRutasProduccion guarda = new DRutasProduccion();
                    if (guarda.ActualizaRutaPrincipal(rutaGuardar) == true)
                    {
                        // Registramos el historico
                        DHistorico.RegistraHistorico("Diseño", "Ruta de producción", "Actualizar Ruta producción", rutaGuardar.nombre);

                        MessageBoxEx.Show("Ruta de producción actualizada correctamente", "Ruta de actualizada registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        Dispose();
                    }
                }
     


            }
        }
        private bool validacampos()
        {
            if (txtNombre.Text == "" || txtNombre.Text == String.Empty)
            {
                MessageBoxEx.Show("Falta nombre de ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return true;
            }
            else if (lvProcesos.Items.Count == 0)
            {
                MessageBoxEx.Show("Faltan procesos para la  ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbprocesostree.Focus();
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
