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

namespace ALTIMA_ERP_2022.Diseno.CatComposiciones
{
    public partial class ComposicionesAM : Office2007Form
    {
        public Action refrescar;
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public EComposicion ce;
        public ComposicionesAM()
        {
            InitializeComponent();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
        private void ComposicionesAM_Load(object sender, EventArgs e)
        {
            if (movimiento == Movimiento.modificar)
            {
                txtnombre.Text = ce.nombre;
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
                            var g = new EComposicion()
                            {
                            
                                nombre = txtnombre.Text.Trim()
                            };

                            if (DComposicion.AgregaComposicion(g) > 0)
                            {
                                // Registramos el historico
                                DHistorico.RegistraHistorico("Diseno", "Composiciones", "Agregar composición");
                                refrescar.Invoke();
                                MessageBoxEx.Show("Composición registrada correctamente", "Composición registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }

                            break;
                        case Movimiento.modificar:
                            var g2 = new EComposicion()
                            {
                                id_composicion = ce.id_composicion,
                                nombre = txtnombre.Text.Trim()
                            };
                            if (DComposicion.ModificaComposicion(g2) > 0)
                            {
                                // Registramos el historico
                                DHistorico.RegistraHistorico("Diseno", "Composiciones", "Modificar composición",ce.nombre,txtnombre.Text );
                                refrescar.Invoke();
                                MessageBoxEx.Show("Composición actualizada correctamente", "Composición actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }

                            break;

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        private bool ValidaCampo()
        {
            if (txtnombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el nombre de la composición", "Composición no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                //VALIDA QUE NO ESTE DUPLICADA
                List<EComposicion> eComposicion = new List<EComposicion>();
                eComposicion = DComposicion.ListarComposiciones();
                EComposicion duplicada = (EComposicion)eComposicion.Where(x => x.nombre == txtnombre.Text.ToString()).FirstOrDefault();
                if (duplicada != null)
                {
                    MessageBoxEx.Show($"La composición {txtnombre.Text} ya se encuentra registrada", "Registro duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }


            }
        }


    }
}
