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
using Datos.Utilitarios.Historico; 

namespace ALTIMA_ERP_2022.Diseno.CatFamiliaGenero
{
    public partial class FamliaGeneroAM : OfficeForm
    {
        public Action refrescar; 
        public enum Movimiento : byte { agregar = 1, modificar = 2};
        public Movimiento movimiento;

        public EFamiliaGenero genero; 

        public FamliaGeneroAM()
        {
            InitializeComponent();
        }

        private void FamliaGeneroAM_Load(object sender, EventArgs e)
        {
            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtNombre.Focus(); 
                    break;
                case Movimiento.modificar:
                    txtNombre.Text = genero.nombre;
                    txtNombre.Focus(); 
                    break;
                default:
                    break;
            }
        }

        private bool ValidaCampo()
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Captue el nombre del género", "Género no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
            else
            {
                return true; 
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaCampo())
            {
                try
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            var g = new EFamiliaGenero()
                            {
                                nombre = txtNombre.Text.Trim()
                            };

                            if (DFamiliaGenero.AgregaGenero(g)>0)
                            {
                                // Registramos el historico
                                DHistorico.RegistraHistorico("Diseno", "Famlia Género", "Agregar género");
                                refrescar.Invoke();
                                MessageBoxEx.Show("Género registrado correctamente", "Género registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }

                            break;
                        case Movimiento.modificar:
                            string valor_anterior = genero.nombre;
                            string valor_nuevo = txtNombre.Text.Trim();

                            genero.nombre = txtNombre.Text.Trim(); 

                            if (DFamiliaGenero.ModificaGenero(genero) > 0)
                            {
                                // Registramos el historico
                                DHistorico.RegistraHistorico("Diseno", "Famlia Género", "Modificar género", valor_anterior, valor_nuevo, "");
                                refrescar.Invoke();
                                MessageBoxEx.Show("Género modificado correctamente", "Género modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }
    }
}
