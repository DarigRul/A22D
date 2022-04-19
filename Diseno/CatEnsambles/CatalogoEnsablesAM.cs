using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using Entidades.Diseno;
using Datos.Diseno;
using Datos.Utilitarios.Historico;

namespace ALTIMA_ERP_2022.Diseno.CatEnsambles
{
    public partial class CatalogoEnsablesAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public Action refrescar;
        public EEnsambles ensamblesModificar;

        public CatalogoEnsablesAM()
        {
            InitializeComponent();
        }

        private void CatalogoEnsablesAM_Load(object sender, EventArgs e)
        {
            //Se crea la lista de tipos
            List<Tipo> listTipos = new List<Tipo>();
            Tipo tipo1 = new Tipo();
            tipo1.id_tipo = 0;
            tipo1.tipo = "Cerrado";
            listTipos.Add(tipo1);
            Tipo tipo2 = new Tipo();
            tipo2.id_tipo = 1;
            tipo2.tipo = "Abierto";
            listTipos.Add(tipo2);

            cmbTipo.DataSource = listTipos;
            cmbTipo.DisplayMember = "tipo";
            cmbTipo.ValueMember = "id_tipo";

            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtDescripcion.Text = "";
                    txtConsumo.Text = "";
                    cmbTipo.SelectedIndex = -1;
                    break;
                case Movimiento.modificar:
                    txtDescripcion.Text = ensamblesModificar.descripcion;
                    txtConsumo.Text = ensamblesModificar.consumo;
                    switch (ensamblesModificar.tipo)
                    {
                        case "Abierto":
                            cmbTipo.SelectedValue = 1;
                            break;
                        case "Cerrado":
                            cmbTipo.SelectedValue = 0;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private bool ValidaCampos()
        {
            if (txtDescripcion.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture la descripción", "Descripción no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return false;
            }
            if (txtConsumo.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el consumo", "Consumo no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConsumo.Focus();
                return false;
            }
            return true;
        }

        private class Tipo
        {
            public int id_tipo { get; set; }
            public string tipo { get; set; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    string valor_nuevo = "";
                    string valor_anterior = "";
                    string mensaje = "";
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            EEnsambles eEnsamble = new EEnsambles();
                            eEnsamble.descripcion = txtDescripcion.Text;
                            eEnsamble.consumo = txtConsumo.Text;
                            eEnsamble.tipo = cmbTipo.Text;

                            valor_nuevo += "Descripción: " + txtDescripcion.Text + " / ";
                            valor_nuevo += "Consumo: " + txtConsumo.Text + " / ";
                            valor_nuevo += "Tipo: " + cmbTipo.Text + " / ";

                            mensaje = DEnsambles.insertarEnsambles(eEnsamble);

                            if(mensaje == "")
                            {
                                DHistorico.RegistraHistorico("Diseño", "Catálogo de Ensambles", "Agregar Ensamble", "", valor_nuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Ensamble registrado correctamente", "Nuevo Ensamble", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique\n" + mensaje, "Error de registro de ensamble: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case Movimiento.modificar:

                            EEnsambles eEnsambleModificar = new EEnsambles();
                            eEnsambleModificar.id_ensamble = ensamblesModificar.id_ensamble;
                            eEnsambleModificar.descripcion = txtDescripcion.Text;
                            eEnsambleModificar.consumo = txtConsumo.Text;
                            eEnsambleModificar.tipo = cmbTipo.Text;

                            valor_nuevo += "Descripción: " + txtDescripcion.Text + " / ";
                            valor_nuevo += "Consumo: " + txtConsumo.Text + " / ";
                            valor_nuevo += "Tipo: " + cmbTipo.Text + " / ";

                            valor_anterior += "Descripción: " + ensamblesModificar.descripcion + " / ";
                            valor_anterior += "Consumo: " + ensamblesModificar.consumo + " / ";
                            valor_anterior += "Tipo: " + ensamblesModificar.tipo + " / ";

                            mensaje = DEnsambles.modificaEnsambles(eEnsambleModificar);

                            if (mensaje == "")
                            {
                                DHistorico.RegistraHistorico("Diseño", "Catálogo de Ensambles", "Modificar Ensamble", valor_anterior, valor_nuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Ensamble modificado correctamente", "Modificar Ensamble", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique\n" + mensaje, "Error de registro de ensamble:", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
