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
using Entidades.Compras;
using Datos.Compras;
using Datos.Utilitarios.Historico;
using System.Text.RegularExpressions;
using System.Net.Mail; 

namespace ALTIMA_ERP_2022.Compras.CatProveedores
{
    public partial class ProveedoresAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2};
        public Movimiento movimiento;
        public Action refrescar;

        public EProveedor pm;

        List<string> tipos = new List<string>(); 

        public ProveedoresAM()
        {
            InitializeComponent();
        }

        private void ProveedoresAM_Load(object sender, EventArgs e)
        {
            try
            {
                tipos.Add("Proveedor de telas");
                tipos.Add("Proveedor de forros");
                tipos.Add("Otros materiales");
                cmbTipo.DataSource = tipos; 

                switch (movimiento)
                {
                    case Movimiento.agregar:
                        txtNombreComercial.Focus();
                        cmbTipo.SelectedIndex = -1;
                        break;
                    case Movimiento.modificar:
                        txtNombreComercial.Text = pm.nombre_comercial;
                        txtRazonSocial.Text = pm.razon_social;
                        txtRFC.Text = pm.rfc;
                        txtNomenclatura.Text = pm.nomenclatura;
                        txtCalle.Text = pm.calle;
                        txtNumeroExterior.Text = pm.numero_exterior;
                        txtNumeroInterior.Text = pm.numero_interior;
                        txtColonia.Text = pm.colonia;
                        txtMunicipio.Text = pm.municipio;
                        txtEstado.Text = pm.estado;
                        txtCodigoPostal.Text = pm.codigo_postal;
                        txtPais.Text = pm.pais;
                        txtTelefono.Text = pm.telefono;
                        txtEmail.Text = pm.email;
                        txtPaginaWeb.Text = pm.pagina_web;
                        txtWhatsapp.Text = pm.whatsapp;
                        txtFacebook.Text = pm.facebook;
                        txtInstagram.Text = pm.instagram;
                        txtTickTock.Text = pm.tik_tok; 
                        txtTwitter.Text = pm.twitter;
                        txtOtrasRedes.Text = pm.otras_redes;

                        //Foco en el nombre comercial
                        txtNombreComercial.Focus(); 

                        cmbTipo.Text = pm.tipo;

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            var proveedor = new EProveedor();
                            proveedor.nombre_comercial = txtNombreComercial.Text.Trim(); 
                            proveedor.razon_social = txtRazonSocial.Text.Trim();
                            proveedor.rfc = txtRFC.Text.Trim();
                            proveedor.nomenclatura = txtNomenclatura.Text.Trim();
                            proveedor.tipo = cmbTipo.Text.Trim();

                            proveedor.calle = txtCalle.Text.Trim();
                            proveedor.numero_exterior = txtNumeroExterior.Text.Trim();
                            proveedor.numero_interior = txtNumeroInterior.Text.Trim();
                            proveedor.colonia = txtColonia.Text.Trim();
                            proveedor.municipio = txtMunicipio.Text.Trim();
                            proveedor.estado = txtEstado.Text.Trim();
                            proveedor.codigo_postal = txtCodigoPostal.Text.Trim();
                            proveedor.pais = txtPais.Text.Trim();
                            proveedor.telefono = txtTelefono.Text.Trim();
                            proveedor.email = txtEmail.Text.Trim();

                            proveedor.pagina_web = txtPaginaWeb.Text.Trim();
                            proveedor.email = txtEmail.Text.Trim(); 
                            proveedor.whatsapp = txtWhatsapp.Text.Trim();
                            proveedor.facebook = txtFacebook.Text.Trim();
                            proveedor.instagram = txtInstagram.Text.Trim();
                            proveedor.tik_tok = txtTickTock.Text.Trim();
                            proveedor.twitter = txtTwitter.Text.Trim();
                            proveedor.otras_redes = txtOtrasRedes.Text.Trim();

                            string valorNuevo = proveedor.nombre_comercial + " / " +
                                proveedor.razon_social + " / " +
                                proveedor.rfc + " / " +
                                proveedor.nomenclatura + " / " +
                                proveedor.tipo;


                            if (DProveedor.Agregar(proveedor)>0)
                            {
                                DHistorico.RegistraHistorico("Compras", "Proveedores", "Agregar", "",valorNuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Proveedor registrado correctamente", "Nuevo proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }

                            break;
                        case Movimiento.modificar:

                            string pmValorAnterior = pm.nombre_comercial + " / " +
                                pm.razon_social + " / " +
                                pm.rfc + " / " +
                                pm.nomenclatura + " / " +
                                pm.tipo;

                            pm.nombre_comercial = txtNombreComercial.Text.Trim();
                            pm.razon_social = txtRazonSocial.Text.Trim();
                            pm.rfc = txtRFC.Text.Trim();
                            pm.nomenclatura = txtNomenclatura.Text.Trim();
                            pm.tipo = cmbTipo.Text.Trim();
                             
                            pm.calle = txtCalle.Text.Trim();
                            pm.numero_exterior = txtNumeroExterior.Text.Trim();
                            pm.numero_interior = txtNumeroInterior.Text.Trim();
                            pm.colonia = txtColonia.Text.Trim();
                            pm.municipio = txtMunicipio.Text.Trim();
                            pm.estado = txtEstado.Text.Trim();
                            pm.codigo_postal = txtCodigoPostal.Text.Trim();
                            pm.pais = txtPais.Text.Trim();
                            pm.telefono = txtTelefono.Text.Trim();
                            pm.email = txtEmail.Text.Trim();
                            
                            pm.pagina_web = txtPaginaWeb.Text.Trim();
                            pm.email = txtEmail.Text.Trim();
                            pm.whatsapp = txtWhatsapp.Text.Trim();
                            pm.facebook = txtFacebook.Text.Trim();
                            pm.instagram = txtInstagram.Text.Trim();
                            pm.tik_tok = txtTickTock.Text.Trim();
                            pm.twitter = txtTwitter.Text.Trim();
                            pm.otras_redes = txtOtrasRedes.Text.Trim();

                            string pmValorNuevo = pm.nombre_comercial + " / " +
                                pm.razon_social + " / " +
                                pm.rfc + " / " +
                                pm.nomenclatura + " / " +
                                pm.tipo;

                            if (DProveedor.Modificar(pm)>0)
                            {
                                DHistorico.RegistraHistorico("Compras", "Proveedores", "Modificar", pmValorAnterior, pmValorNuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Proveedor actualizado correctamente", "Proveedor actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }


                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreComercial.Focus(); 
            }
        }

        private bool ValidaCampos()
        {
            if (txtNombreComercial.Text.Trim() == String.Empty)
            {
                MessageBoxEx.Show("Capture el nombre comercial del proveedor", "Nombre comercial no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreComercial.Focus(); 
                return false; 
            }
            else if(txtRazonSocial.Text.Trim() == String.Empty)
            {
                MessageBoxEx.Show("Capture la razón social", "Razón social no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazonSocial.Focus();
                return false; 
            }
            else if(txtNomenclatura.Text.Trim() == String.Empty)
            {
                MessageBoxEx.Show("Capture la nomenclatura", "Nomenclaturá no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomenclatura.Focus(); 
                return false; 
            }
            else if(cmbTipo.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione un tipo de proveedor", "Proveedor no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTipo.Focus();
                return false; 
            }
            else
            {
                return true; 
            }
        }

        private void ProveedoresAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(this, EventArgs.Empty);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                MailAddress correo = new MailAddress(txtEmail.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}","Correo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                txtEmail.Focus();
                txtEmail.SelectAll();
            }
        }
    }
}
