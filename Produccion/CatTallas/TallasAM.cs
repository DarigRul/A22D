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
using Entidades.Produccion;
using Datos.Produccion;
using Datos.Utilitarios.Historico; 

namespace ALTIMA_ERP_2022.Produccion.CatTallas
{
    public partial class TallasAM : OfficeForm
    {
        public enum Movimiento : byte { agegar = 1, modificar = 2 };
        public Movimiento movimiento;
        public ETallas tm;
        public List<EFamiliaGenero> lstGenero = new List<EFamiliaGenero>();

        public Action refrescar;

        public TallasAM()
        {
            InitializeComponent();
        }

        private void TallasAM_Load(object sender, EventArgs e)
        {
            lstGenero = DFamiliaGenero.ListarGeneros();
            cmbGenero.DataSource = lstGenero;
            cmbGenero.DisplayMember = "nombre";
            cmbGenero.ValueMember = "id_familia_genero";
            cmbGenero.SelectedIndex = -1;

            switch (movimiento)
            {
                case Movimiento.agegar:
                    txtTalla.Focus();
                    break;
                case Movimiento.modificar:
                    txtTalla.Value = tm.talla;
                    cmbGenero.SelectedValue = tm.id_genero; 
                    break;
                default:
                    Close();
                    Dispose(); 
                    break; 
            }
        }

        private void TallasAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(this, EventArgs.Empty);
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
                        case Movimiento.agegar:
                            ETallas _et = new ETallas() {
                                id_genero =  Convert.ToInt32(cmbGenero.SelectedValue), 
                                talla = txtTalla.Value
                            };

                            string valorNuevo = $"Talla: {_et.talla} / " +
                                $"Genero: {cmbGenero.Text}";

                            if (DTallas.Agregar(_et)>0)
                            {
                                DHistorico.RegistraHistorico("Producción", "Catálogo de tallas", "", valorNuevo, "");
                                refrescar.Invoke();
                                MessageBoxEx.Show("Talla registrada correctamente", "Nueva Tala", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }

                            break;
                        case Movimiento.modificar:
                            string tmValorAnterior = $"Talla: {tm.talla} / Género: {tm.genero}"; 
                            
                            tm.talla = txtTalla.Value;
                            tm.id_genero = Convert.ToInt32(cmbGenero.SelectedValue);

                            string tmValorNuevo = $"Talla: {tm.talla} / Género: {cmbGenero.Text}";

                            if (DTallas.Actualizar(tm)>0)
                            {
                                DHistorico.RegistraHistorico("Producción", "Catálogo de tallas", "Modificar talla", tmValorAnterior, tmValorNuevo, "");
                                refrescar.Invoke();
                                MessageBoxEx.Show("Talla actualizada correctamente", "Actualización de talla", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MensajeError($"{ex.Message}\n\r{ex.InnerException}\n\r{ex.StackTrace}", "Error inesperado!!!");
            }
        }

        private bool ValidaCampos()
        {
            if (txtTalla.Text == string.Empty)
            {
                MensajeError("Capture la talla", "Error en talla");
                txtTalla.Focus();
                return false;
            }
            else if (cmbGenero.SelectedIndex == -1)
            {
                MensajeError("Seleccione un género", "Género no válido");
                cmbGenero.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void MensajeError(string message, string caption)
        {
            MessageBoxEx.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
