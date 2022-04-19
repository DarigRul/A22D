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
using Entidades.Diseno;

namespace ALTIMA_ERP_2022.Diseno.CatFamiliaComposicion
{
    public partial class FamiliaComposicionAM : Office2007Form
    {
        public Action refrescar;
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public EFamiliaComposicion familiaComposicion;
        public List<EComposicion> lstComposicion;
        public List<EInstruccionesCuidado> lstInstruccionesCuidado;
        public FamiliaComposicionAM()
        {
            InitializeComponent();
        }

        private void FamiliaComposicionAM_Load(object sender, EventArgs e)
        {

            lstInstruccionesCuidado = DInstruccionesCuidado.ListarInstrucciones();
            cmbInstruccionesCuidado.DataSource = lstInstruccionesCuidado;
            cmbInstruccionesCuidado.DisplayMember = "nombre";
            cmbInstruccionesCuidado.ValueMember = "id_instruccion_cuidado";
            cmbInstruccionesCuidado.SelectedIndex = -1;
            lvInstruccionesCuidado.Items.Clear();

            lstComposicion = DComposicion.ListarComposiciones();
            cmbComposiciones.DataSource = lstComposicion;
            cmbComposiciones.DisplayMember = "nombre";
            cmbComposiciones.ValueMember = "id_composicion";
            cmbComposiciones.SelectedIndex = -1;




            if (movimiento == Movimiento.modificar)
            {
                txtNombre.Text = familiaComposicion.nombre;
                foreach (EComposicion composicion in familiaComposicion.eComposiciones)
                {
                    LvComposiciones.Items.Add(composicion.nombre);
                }
                foreach (EInstruccionesCuidado instruccionesCuidado in familiaComposicion.eInstruccionesCuidados)
                {
                    lvInstruccionesCuidado.Items.Add(instruccionesCuidado.nombre);
                }
                btnAceptar.Text = "Actualizar";
            }

        }
        private bool validaCampos()
        {
            if (txtNombre.Text == "" || txtNombre.Text == String.Empty)
            {
                MessageBoxEx.Show("Ingresa el nombre de la familia", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtNombre.Select();
                return true;
            }
            else
            {
                if (lvInstruccionesCuidado.Items.Count == 0)
                {
                    MessageBoxEx.Show("Selecciona instrucciones de cuidado", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return true;
                }
                else
                {
                    if (LvComposiciones.Items.Count == 0)
                    {
                        MessageBoxEx.Show("Selecciona composiciones", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (movimiento)
            {
                case Movimiento.agregar:
                    if (validaCampos() == false)
                    {
                        //se crea la entidad a guardar
                        EFamiliaComposicion FCGuardar = new EFamiliaComposicion();
                        FCGuardar.nombre = txtNombre.Text;
                        //Se crea la lista de instrucciones de cuidado
                        foreach (ListViewItem item in lvInstruccionesCuidado.Items)
                        {
                            FCGuardar.eInstruccionesCuidados.Add(lstInstruccionesCuidado.First(x => x.nombre == item.Text));
                        }
                        //Se crea la lista de composiciones
                        foreach (ListViewItem c in LvComposiciones.Items)
                        {
                            FCGuardar.eComposiciones.Add(lstComposicion.First(x => x.nombre == c.Text));
                        }
                        DFamiliaComposicion guarda = new DFamiliaComposicion();
                        if (guarda.GuardaFamiliaComposicion(FCGuardar) == 0)
                        {
                            // Registramos el historico
                            DHistorico.RegistraHistorico("Diseno", "Familia de Composiciones", "Agrega composición", FCGuardar.nombre);
                            refrescar.Invoke();
                            MessageBoxEx.Show("Familia de composición registrada correctamente", "Familia de Composición registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        }

                    }
                    break;
                case Movimiento.modificar:
                    if (validaCampos() == false)
                    {
                        //se crea la entidad a actualizar
                        EFamiliaComposicion FCActualizar = new EFamiliaComposicion();
                        FCActualizar.nombre = txtNombre.Text;
                        FCActualizar.id_familia_composicion = familiaComposicion.id_familia_composicion;
                        //Se crea la lista de instrucciones de cuidado
                        //Se crea la lista de instrucciones de cuidado
                        foreach (ListViewItem item in lvInstruccionesCuidado.Items)
                        {
                            FCActualizar.eInstruccionesCuidados.Add(lstInstruccionesCuidado.First(x => x.nombre == item.Text));
                        }
                        //Se crea la lista de composiciones
                        foreach (ListViewItem c in LvComposiciones.Items)
                        {
                            FCActualizar.eComposiciones.Add(lstComposicion.First(x => x.nombre == c.Text));
                        }
                        DFamiliaComposicion guarda = new DFamiliaComposicion();
                        if (guarda.ActualizaFamiliaComposicion(FCActualizar) == 0)
                        {
                            // Registramos el historico
                            DHistorico.RegistraHistorico("Diseno", "Familia de Composiciones", "modificar composición", FCActualizar.nombre);
                            refrescar.Invoke();
                            MessageBoxEx.Show("Familia de composición actualizada correctamente", "Familia de Composición actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        }
                    }
                    break;

            }








        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }



        private void btnAgregaIc_Click(object sender, EventArgs e)
        {
            int existe = 0;
            EInstruccionesCuidado ic = cmbInstruccionesCuidado.SelectedItem as EInstruccionesCuidado;
            if (ic != null)
            {

                foreach (ListViewItem item in lvInstruccionesCuidado.Items)
                {
                    if (item.Text == ic.nombre)
                    {
                        existe++;
                    }
                }

                if (existe > 0)
                {

                    MessageBoxEx.Show("La instrucción de cuidado ya se encuenta en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbInstruccionesCuidado.SelectedIndex = -1;
                    cmbInstruccionesCuidado.Focus();
                }
                else
                {
                    lvInstruccionesCuidado.Items.Add(ic.nombre);
                    cmbInstruccionesCuidado.SelectedIndex = -1;
                    cmbInstruccionesCuidado.Focus();
                }


            }
            else
            {
                MessageBoxEx.Show("Debes seleccionar una instrucción de cuidado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbInstruccionesCuidado.Focus();
            }

        }

        private void btnEliminaric_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item = lvInstruccionesCuidado.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            lvInstruccionesCuidado.Items.Remove(item);

        }

        private void btnComposicionAgregar_Click(object sender, EventArgs e)
        {
            int existe = 0;
            EComposicion c = cmbComposiciones.SelectedItem as EComposicion;
            if (c != null)
            {

                foreach (ListViewItem item in LvComposiciones.Items)
                {
                    if (item.Text == c.nombre)
                    {
                        existe++;
                    }
                }
                    if (existe > 0)
                    {
                        MessageBoxEx.Show("La composición ya se encuenta en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbComposiciones.SelectedIndex = -1;
                        cmbComposiciones.Focus();
                       
                    }
                    else
                    {
                        LvComposiciones.Items.Add(c.nombre);
                        cmbComposiciones.SelectedIndex = -1;
                        cmbComposiciones.Focus();
                    }
                



            }
            else
            {
                MessageBoxEx.Show("Debes seleccionar una composición", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbComposiciones.Focus();
            }
        }

        private void btnComposicionEliminar_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item = LvComposiciones.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            LvComposiciones.Items.Remove(item);
        }
    }
}
