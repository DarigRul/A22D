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

namespace ALTIMA_ERP_2022.Diseno.CatPiezasTrazo
{
    public partial class PiezasTrazoAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2};
        public Movimiento movimiento;
        public EPiezasTrazo ePieza;
        public Action refrescar; 

        public PiezasTrazoAM()
        {
            InitializeComponent();
        }

        private void PiezasTrazoAM_Load(object sender, EventArgs e)
        {
            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtNombre.Focus(); 
                    break;
                case Movimiento.modificar:
                    txtNombre.Text = ePieza.nombre;
                    txtNombre.Focus();
                    txtNombre.SelectAll(); 
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
                if (txtNombre.Text.Trim() == string.Empty)
                {
                    MessageBoxEx.Show("Capture el nombre de la pieza de trazo", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus(); 
                }
                else
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            var pieza = new EPiezasTrazo 
                            {
                                nombre = txtNombre.Text.Trim()
                            };
                            
                            if(DPiezasTrazo.AgregarPieza(pieza)>0)
                            {
                                DHistorico.RegistraHistorico("Diseño", "Piezas Trazo", "Agregar", "", pieza.nombre);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Pieza de trazo registrada correctamente", "Nueva pieza de trazo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }
                            break;
                        case Movimiento.modificar:
                            string valor_anterior = "Nombre: " + ePieza.nombre; 
                            string valor_nuevo = "Nombre: " + txtNombre.Text.Trim();

                            ePieza.nombre = txtNombre.Text.Trim();
                            if (DPiezasTrazo.ModificarPieza(ePieza)>0)
                            {
                                DHistorico.RegistraHistorico("Diseño", "Piezas Trazo", "Modificar", valor_anterior, valor_nuevo, "");
                                refrescar.Invoke();
                                MessageBoxEx.Show("Pieza de trazo actualizada correctamente", "Pieza de trazo actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void PiezasTrazoAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(this, EventArgs.Empty);
            }
            else if(e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(this, EventArgs.Empty);
            }
        }
    }
}
