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
using Datos.Diseno;
using Entidades.Diseno;
using Datos.Utilitarios.Historico; 

namespace ALTIMA_ERP_2022.Diseno.CatUnidadesMedida
{
    public partial class UnidadesAM : OfficeForm
    {
        public Action refrescar; 
        public enum Movimiento : byte { agregar = 1, modificar = 2};
        public Movimiento movimiento;

        public EUnidadesMedida eUnidad;
        private DUnidadesMedida dUnidad = new DUnidadesMedida(); 

        public UnidadesAM()
        {
            InitializeComponent();
        }
        private void UnidadesAM_Load(object sender, EventArgs e)
        {
            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtNombre.Focus();
                    break;
                case Movimiento.modificar:
                    txtNombre.Text = eUnidad.nombre;
                    txtSimbolo.Text = eUnidad.simbolo; 
                    break;
                default:
                    break;
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
                            var um = new EUnidadesMedida
                            {
                                nombre = txtNombre.Text.Trim(),
                                simbolo = txtSimbolo.Text.Trim()
                            };

                            if (dUnidad.VerificaUnidad(um)==0)
                            {
                                dUnidad.AgregarUnidad(um);
                                DHistorico.RegistraHistorico("Diseño", "Unidades de Medida", "Agregar", "", "Nombre: " + um.nombre + " / Símbolo: " + um.simbolo);
                                refrescar.Invoke(); 
                                MessageBoxEx.Show("Unidad registrada correctamente", "Nueva unidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show($"La unidad de medida o su símbolo ya se encuentra registrado", "Duplicidad", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                            }
                            break;
                        case Movimiento.modificar:
                            string valor_anterior = "Nombre: " + eUnidad.nombre + " / " + "Símbolo: " +eUnidad.simbolo;
                            string valor_nuevo = "Nombre :" + txtNombre.Text + " / " + "Símbolo: " + txtSimbolo.Text; 
                            
                            eUnidad.nombre = txtNombre.Text.Trim();
                            eUnidad.simbolo = txtSimbolo.Text.Trim();
                            dUnidad.ModificarUnidad(eUnidad);
                            DHistorico.RegistraHistorico("Diseño", "Unidades de Medida", "Modificar", valor_anterior, valor_nuevo, ""); 
                            refrescar.Invoke(); 
                            MessageBoxEx.Show("Unidad moficiada correctamente", "Unidad modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose(); 
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private bool ValidaCampos()
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el nombre de la unidad de medida", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            else if (txtSimbolo.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el símbolo de la unidad de medida", "Símbolo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSimbolo.Focus();
                return false; 
            }
            else
            {
                return true; 
            }
        }

        private void UnidadesAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(this, EventArgs.Empty);
            }
        }

    }
}
