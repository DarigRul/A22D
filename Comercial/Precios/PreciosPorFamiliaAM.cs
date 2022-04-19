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
using DevComponents.DotNetBar;
using Entidades.Diseno;
using Entidades.Comercial.Precios;
using Datos.Comercial;
using Datos.Utilitarios.Historico;


namespace ALTIMA_ERP_2022.Comercial.Precios
{
    public partial class PreciosPorFamiliaAM : OfficeForm
    {

        public Action refrescar;
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public  EPrecios ePrecios;
        List< EFamiliaComposicion> lstfamiliacomposicion;
        List<EFamiliaPrendas> lstfamiliaprendas;
        public PreciosPorFamiliaAM()
        {
            InitializeComponent();
        }

        private void PreciosPorFamilia_Load(object sender, EventArgs e)
        {

            lstfamiliacomposicion = DFamiliaComposicion.ListarFamilias();
            cmbFamiilaComposicion.DataSource = lstfamiliacomposicion;
            cmbFamiilaComposicion.DisplayMember = "nombre";
            cmbFamiilaComposicion.ValueMember = "id_familia_composicion";
            cmbFamiilaComposicion.SelectedIndex = -1;
            lstfamiliaprendas = DFamiliaPrendas.GetConsultaDisenoFamiliaPrendas();
            cmbFamiliaPreda.DataSource = lstfamiliaprendas;
            cmbFamiliaPreda.DisplayMember = "nombre";
            cmbFamiliaPreda.ValueMember = "id_familia_prenda";
            cmbFamiliaPreda.SelectedIndex = -1;
            if (movimiento == Movimiento.modificar)
            {
                cmbFamiilaComposicion.SelectedValue = ePrecios.id_familia_composicion;
                cmbFamiliaPreda.SelectedValue = ePrecios.id_familia_prenda;
                cmbFamiilaComposicion.Enabled = false;
                cmbFamiliaPreda.Enabled = false;
                idLocalActual.Value = ePrecios.local_actual;
                idLocalAnterior.Value = ePrecios.local_anterior;
                idForaeno.Value = ePrecios.foraneo_actual;
                idForaneoAnterior.Value = ePrecios.foraneo_anterior;
                idLELocal.Value = ePrecios.linea_expres_local_actual;
                idLEForaneo.Value = ePrecios.linea_expres_foraneo_actual;
                idLELocalAnterior.Value = ePrecios.linea_expres_local_anterior;
                idLEForaneoAnterior.Value = ePrecios.linea_expres_foraneo_anterior;
                idecommerce_anterior.Value = ePrecios.ecommerce_anterior;
                idMuestrario.Value = ePrecios.muestrario;
                idEcommerce_actual.Value = ePrecios.ecommerce_actual;
                idVentaInterna.Value = ePrecios.venta_interna;
                idExtra1.Value = ePrecios.extra1;
                idExtra2.Value = ePrecios.extra2;
                idExtra3.Value = ePrecios.extra3;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos() == false)
            {
                //creamos la entidad a guardar
                EPrecios precioGuardar = new EPrecios()
                {
                    familia_composicion = cmbFamiilaComposicion.Text,
                    familia_prenda = cmbFamiliaPreda.Text,
                    //Precios Actuales
                    id_familia_composicion = Convert.ToInt32(cmbFamiilaComposicion.SelectedValue),
                    id_familia_prenda = Convert.ToInt32(cmbFamiliaPreda.SelectedValue),
                    local_actual = idLocalActual.Value,
                    foraneo_actual = idForaeno.Value,
                    linea_expres_local_actual = idLELocal.Value,
                    linea_expres_foraneo_actual = idLEForaneo.Value,
                    ecommerce_actual = idEcommerce_actual.Value,
                    //Precios anteriores
                    local_anterior = idLocalAnterior.Value,
                    foraneo_anterior = idForaneoAnterior.Value,
                    linea_expres_local_anterior = idLELocalAnterior.Value,
                    linea_expres_foraneo_anterior = idLEForaneoAnterior.Value,
                    ecommerce_anterior = idecommerce_anterior.Value,
                    //Otros precios
                   
                    muestrario = idMuestrario.Value,
                    venta_interna = idVentaInterna.Value,
                    extra1 = idExtra1.Value,
                    extra2 = idExtra2.Value,
                    extra3 = idExtra3.Value

                };
               
                switch (movimiento)
                {
                    case Movimiento.agregar:
                        
                        if (DPreciosfamiliacomposicion.PreciosFamiliaComposicionGuardar(precioGuardar) > 0)
                        {
                            // Registramos el historico
                            DHistorico.RegistraHistorico("comercial", "precios familia composicion", "Agrega precios", precioGuardar.familia_composicion.ToString() + ' ' + precioGuardar.familia_prenda.ToString());
                            refrescar.Invoke();
                            MessageBoxEx.Show("Precios registrado correctamente", "Precios registrado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        }
                        break;
                    case Movimiento.modificar:
                        precioGuardar.id_precio = ePrecios.id_precio;
                        if (DPreciosfamiliacomposicion.PreciosFamiliaComposicionModifica(precioGuardar) > 0)
                        {
                            // Registramos el historico
                            DHistorico.RegistraHistorico("comercial", "precios familia composicion", "modifica precios", ePrecios.familia_composicion.ToString() + ' '+ ePrecios.familia_prenda.ToString());
                            refrescar.Invoke();
                            MessageBoxEx.Show("Precios actualizados correctamente", "Precios actualizados correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        }
                        break;
                    
                } ;
                //Creamos la entidad a guardar
                

            };
          

            
        }
        private bool ValidaCampos()
        {
            if (movimiento == Movimiento.modificar)
            {
                idLocalAnterior.Value = ePrecios.local_actual;
                idForaneoAnterior.Value = ePrecios.foraneo_actual;
                idLELocalAnterior.Value = ePrecios.linea_expres_local_actual;
                idLEForaneoAnterior.Value = ePrecios.linea_expres_foraneo_actual;
                idecommerce_anterior.Value = ePrecios.ecommerce_actual;
            }
            if (cmbFamiliaPreda.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Debes seleccionar una familia de prendas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFamiliaPreda.Focus();
                return true;

            }
            if (cmbFamiilaComposicion.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Debes seleccionar una familia de composición ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFamiilaComposicion.Focus();
                return true;

            }


            return false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }
    }
}
        