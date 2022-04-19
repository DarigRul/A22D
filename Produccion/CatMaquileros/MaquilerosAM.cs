using Datos.Diseno;
using Datos.Produccion;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Diseno;
using Entidades.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALTIMA_ERP_2022.Produccion.CatMaquileros
{
    public partial class MaquilerosAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public EMaquileros maquileromodificar;
        
        DMaquileros datos = new DMaquileros();
        GridPanel panel;
        public List<EFamiliaPrendas> FamiliasAgregadas = new List<EFamiliaPrendas>();
        public MaquilerosAM()
        {
            InitializeComponent();
        }

        private void MaquilerosAM_Load(object sender, EventArgs e)
        {
            panel = sgcFamiliaPrendas.PrimaryGrid;
            cmbFamiliaPrendas.DataSource = DFamiliaPrendas.GetConsultaDisenoFamiliaPrendas();
            cmbFamiliaPrendas.DisplayMember = "nombre";
            cmbFamiliaPrendas.ValueMember = "id_familia_prenda";
            cmbFamiliaPrendas.SelectedIndex = -1;
            switch (movimiento)
            {
                case Movimiento.agregar:

                    break;
                case Movimiento.modificar:
                    txtnombre.Text = maquileromodificar.nombre;
                    txtPaterno.Text = maquileromodificar.paterno;
                    txtMaterno.Text = maquileromodificar.materno;
                    txtCorreo.Text = maquileromodificar.email;
                    txtDireccion.Text = maquileromodificar.direccion;
                    txtCP.Text = maquileromodificar.cp;
                    txtTelefono.Text = maquileromodificar.telefono;
                    txtCelular.Text = maquileromodificar.celular;
                    txtRazonSocial.Text = maquileromodificar.razon_social;
                    txtDireccionFacturacion.Text = maquileromodificar.direccion_facturacion;
                    txtCPFacturacion.Text = maquileromodificar.cp_facturacion;
                    txtRFC.Text = maquileromodificar.rfc;
                    panel.DataSource = FamiliasAgregadas;
                    btnAceptar.Text = "Modificar";


                    break;
                default:
                    break;
            }
        

        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            //crea  una lista con las familias de prendas seleccionadas
            switch (btnAgregarFamilia.Text)
            {
                case "Actualizar":
                    GridRow rw = panel.ActiveRow as GridRow;
                    rw[capacidad_semanal].Value = iiCapacidadSemanal.Value;
                    break;
                case "Agregar":
                    EFamiliaPrendas agregafamilia = new EFamiliaPrendas
                    {
                        id_familia_prenda = (int)cmbFamiliaPrendas.SelectedValue,
                        nombre = cmbFamiliaPrendas.Text,
                        capacidad_semanal = iiCapacidadSemanal.Value
                    };
                    EFamiliaPrendas i = FamiliasAgregadas.Find(x => x.id_familia_prenda == agregafamilia.id_familia_prenda);

                    if (i == null)
                    {
                        FamiliasAgregadas.Add(agregafamilia);
                        panel.DataSource = FamiliasAgregadas;
                        iiCapacidadSemanal.Value = 0;
                        iiCapacidadSemanal.Text = String.Empty;
                        cmbFamiliaPrendas.SelectedIndex = -1;

                    }
                    else
                    {
                        MessageBoxEx.Show("La familia ya se encuentra en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

            }


        }
        //private class lista
        //{
        //    public int id_familia { get; set; }
        //    public string nombre_familia { get; set; }
        //    public int capacidad_semanal { get; set; }
        //}

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            if (FamiliasAgregadas.Count() == 1)
            {
                MessageBoxEx.Show("Debe existir al menos una familia de prendas asignada al maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFamiliaPrendas.Focus();
            }
            else
            {
                GridRow row = panel.ActiveRow as GridRow;
                EFamiliaPrendas buscarlista = row.DataItem as EFamiliaPrendas;
                FamiliasAgregadas.Remove(buscarlista);
                panel.DataSource = FamiliasAgregadas;
            }

        }

        private void sgcFamiliaPrendas_SelectionChanged(object sender, GridEventArgs e)
        {

            GridRow row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                EFamiliaPrendas buscarlista = row.DataItem as EFamiliaPrendas;
                cmbFamiliaPrendas.SelectedValue = buscarlista.id_familia_prenda;
                cmbFamiliaPrendas.Text = buscarlista.nombre;
                iiCapacidadSemanal.Value = buscarlista.capacidad_semanal;
                btnAgregarFamilia.Text = "Actualizar";
            }




        }

        private void cmbFamiliaPrendas_Click(object sender, EventArgs e)
        {
            btnAgregarFamilia.Text = "Agregar";
            btnAgregarFamilia.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == false)
            {
                DMaquileros d = new DMaquileros();
                switch (movimiento)
                {

                    case Movimiento.agregar:
                        //creamos la entidad a guardar
                        EMaquileros eMaquileros = new EMaquileros()
                        {
                            nombre = txtnombre.Text,
                            paterno = txtPaterno.Text,
                            materno = txtMaterno.Text,
                            email = txtCorreo.Text,
                            direccion = txtDireccion.Text,
                            cp = txtCP.Text,
                            telefono = txtTelefono.Text,
                            celular = txtCelular.Text,
                            razon_social = txtRazonSocial.Text,
                            direccion_facturacion = txtDireccionFacturacion.Text,
                            rfc = txtRFC.Text,
                            cp_facturacion = txtCPFacturacion.Text,

                        };
                        //creamos la lista de familia de prendas

                     
                        if (d.GuardaMaquilero(eMaquileros, FamiliasAgregadas) == true)
                        {
                            MessageBoxEx.Show("El maquilero se registro correctamente", "Agregar maquilero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        }
                        break;
                    case Movimiento.modificar:
                        //creamos la entidad a guardar
                        EMaquileros eMaquilerosactualizar = new EMaquileros()
                        {
                            id_maquilero = maquileromodificar.id_maquilero,
                            nombre = txtnombre.Text,
                            paterno = txtPaterno.Text,
                            materno = txtMaterno.Text,
                            email = txtCorreo.Text,
                            direccion = txtDireccion.Text,
                            cp = txtCP.Text,
                            telefono = txtTelefono.Text,
                            celular = txtCelular.Text,
                            razon_social = txtRazonSocial.Text,
                            direccion_facturacion = txtDireccionFacturacion.Text,
                            rfc = txtRFC.Text,
                            cp_facturacion = txtCPFacturacion.Text,

                        };
                        if (d.ActualizaMaquilero(eMaquilerosactualizar, FamiliasAgregadas) == true)
                        {
                            MessageBoxEx.Show("El maquilero se actualizo correctamente", "Actualizar maquilero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        }
                        break;
                    
                }
               
         

            }
        }
        private bool ValidaCampos()
        {

            if (txtnombre.Text == "" || txtnombre.Text == String.Empty)
            {
                MessageBoxEx.Show("Falta nombre del maquilero","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnombre.Focus();
                return true;
            }
            if (txtPaterno.Text == "" || txtPaterno.Text == String.Empty)
            {
                MessageBoxEx.Show("Falta apellido paterno del maquilero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaterno.Focus();
                return true;
            }

            if (txtMaterno.Text == "" || txtMaterno.Text == String.Empty)
            {
                MessageBoxEx.Show("Falta apellido materno del maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtMaterno.Focus();
                return true;
            }
            if (txtCorreo.Text == "" || txtCorreo.Text == String.Empty)
            {
                MessageBoxEx.Show("Falta correo de maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCorreo.Focus();
                return true;
            }
            if (txtDireccion.Text == "" || txtDireccion.Text == String.Empty)
            {
                MessageBoxEx.Show("Falta dirección del maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDireccion.Focus();
                return true;
            }
            if (txtCP.Text == "" || txtCP.Text == String.Empty)
            {
                MessageBoxEx.Show("falta código postal del maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCP.Focus();
                return true;
            }
            if (txtTelefono.Text == "" || txtTelefono.Text == String.Empty)
            {
                MessageBoxEx.Show("Falta Telefono del maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtTelefono.Focus();
                return true;
            }
            if (txtCelular.Text == "" || txtCelular.Text == String.Empty)
            {
                MessageBoxEx.Show("Falta celular en maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtCelular.Focus();
                return true;
            }
            if (FamiliasAgregadas.Count ==0)
            {
                MessageBoxEx.Show("Debes agregar al menos una familia de prendas al maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFamiliaPrendas.Focus();
                return true;
            }
            //if (txtRazonSocial.Text == "" || txtRazonSocial.Text == String.Empty)
            //{
            //    MessageBoxEx.Show("Falta razón social", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    txtRazonSocial.Focus();
            //    return true;
            //}
            //if (txtDireccionFacturacion.Text == "" || txtDireccionFacturacion.Text == String.Empty)
            //{
            //    MessageBoxEx.Show("Falta dirección de facturaciòn del maquilero", "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    txtDireccionFacturacion.Focus();
            //    return true;
            //}


            //foreach (Control grupo in this.Controls)
            //{
            //    if (grupo.GetType() == typeof(GroupBox))
            //    {
            //        foreach (Control item in grupo.Controls)
            //        {
            //            if (item.GetType() == typeof(TextBoxX))
            //            {

            //                TextBoxX caja = (TextBoxX)item;
            //                if (caja.Text == "" || caja.Text == String.Empty)
            //                {
            //                    MessageBoxEx.Show("Información incompleta, por favor verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    caja.Focus();
            //                    return true;
            //                }
            //            }
            //        }

            //    }

            //}

            return false;

        }
        private void txtCorreo_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtCorreo.Text != "" || txtCorreo.Text != String.Empty)
                {
                    MailAddress correo = new MailAddress(txtCorreo.Text.Trim());
           
                }

            }
            catch (Exception ex)
            {

                MessageBoxEx.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
            }

        }

       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
