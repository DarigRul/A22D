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
using Entidades.Diseno;
using Datos.Diseno;
using Datos.Compras;
using Datos.Utilitarios.Historico;
using Entidades.Utilitarios.Historico;
using Entidades.Compras; 

namespace ALTIMA_ERP_2022.Diseno.CatColores
{
    public partial class ColorAM : OfficeForm
    {
        public enum Movimiento : byte { agegar = 1, modificar = 2};
        public Movimiento movimiento;

        public Action refrescar;
        public EColor colorModificar;

        public ColorAM()
        {
            InitializeComponent();
        }

        private void ColorAM_Load(object sender, EventArgs e)
        {
            DProveedor dp = new DProveedor();

            switch (movimiento)
            {
                case Movimiento.agegar:
                    txtNombre.Focus();
                    break;
                case Movimiento.modificar:

                    txtNombre.Text = colorModificar.nombre;
            
                    //Aplicamos el color 
                    int r, g, b;
                    string[] codigos = colorModificar.codigo_color.Split(',');
                    r = Convert.ToInt32(codigos[0]);
                    g = Convert.ToInt32(codigos[1]);
                    b = Convert.ToInt32(codigos[2]);

                    Color c = Color.FromArgb(r, g, b);
                    cpColor.SelectedColor = c;
                    break;
                default:
                    break;
            }
        }

       
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                try
                {

                    switch (movimiento)
                    {
                        case Movimiento.agegar:

                            var c = new EColor
                            {
                                nombre = txtNombre.Text.Trim(),
                                codigo_color = ObtieneCodigoColor(),
                            };

                            var dColor = new DColor();
                            if(dColor.AgregarColor(c)>0)
                            {

                                DHistorico.RegistraHistorico("Diseño", "Catálogo de colores", "Agregar color","", c.nombre + "/" + c.codigo_color); 

                                //Invocando al delegado para refrescar el catálogo de colores
                                refrescar.Invoke(); 

                                MessageBoxEx.Show("Color agregado correctamente", "Nuevo color", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }

                            break;
                        case Movimiento.modificar:

                            //Obtenemos el nombre del proveedor anterior

                            string valor_anterior = "Nombre: " + colorModificar.nombre + " / Código color: " + colorModificar.codigo_color;

                            string valor_nuevo = "Nombre: " + txtNombre.Text.Trim() + " / Código color: " + ObtieneCodigoColor();
                            
                            colorModificar.nombre = txtNombre.Text.Trim();
                            colorModificar.codigo_color = ObtieneCodigoColor();

                            var dcm = new DColor();
                            if (dcm.ModificaColor(colorModificar)>0)
                            {
                                DHistorico.RegistraHistorico("Diseño", "Catálogo de colores", "Modifica color", valor_anterior, valor_nuevo, ""); 

                                //Invocando al delegado para refrescar el catálogo de colores
                                refrescar.Invoke();

                                MessageBoxEx.Show("Color actualizado correctamente", "Color actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }

                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show($"{ex.Message}\n\r{ex.InnerException}\n\r{ex.StackTrace}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();

        }

        #region utilidades
        private bool ValidaCampos()
        {
            string color = cpColor.SelectedColor.ToString();
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el nombre del color", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            else if (color == string.Empty)
            {
                MessageBoxEx.Show("Seleccione un color", "Color no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cpColor.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private string ObtieneCodigoColor()
        {
            string r, g, b;
            r = cpColor.SelectedColor.R.ToString();
            g = cpColor.SelectedColor.G.ToString();
            b = cpColor.SelectedColor.B.ToString();

            string rgb = r + "," + g + "," + b;

            return rgb;
        }
        private void ColorAM_KeyDown(object sender, KeyEventArgs e)
        {
            // Asignamos las teclas (shortcuts)
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
