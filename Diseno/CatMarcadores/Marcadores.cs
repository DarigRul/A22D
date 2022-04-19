using Datos.Diseno;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using Entidades.Diseno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALTIMA_ERP_2022.Diseno.CatMarcadores
{
    public partial class Marcadores : OfficeForm
    {
        public Action refrescar;
        public string Movimiento;
        EMarcadores obj = new EMarcadores();
        public Marcadores(int id_marcador, string nombre, string mov)
        {
            InitializeComponent();
            obj.id_marcador = id_marcador;
            obj.nombre = nombre;
            Movimiento = mov;
            Llenado();
        }

        private void FamiliaPrendas_Load(object sender, EventArgs e)
        {
            Llenado();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Movimiento == "Alta")
            {

                if (ValidaCampo())
                {
                    EMarcadores inserta = new EMarcadores();
                    inserta.nombre = txtNombre.Text;
                    DMarcadores.SetInsertarMarcadores(inserta);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de marcadores", "Agregar marcador", "", inserta.nombre);
                    refrescar.Invoke();
                    MessageBoxEx.Show("Marcador registrado correctamente", "Marcador registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
            else if (Movimiento == "Modificacion")
            {
                if (ValidaCampo())
                {
                    EMarcadores actualiza = new EMarcadores();
                    actualiza.id_marcador = obj.id_marcador;
                    actualiza.nombre = txtNombre.Text;
                    DMarcadores.SetActualizaMarcadores(actualiza);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de marcadores", "Modificar marcador", obj.nombre, actualiza.nombre);
                     refrescar.Invoke();
                    MessageBoxEx.Show("Marcador actualizado correctamente", "Marcador actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }


        }
        private bool ValidaCampo()
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Verifique los campos", "Los campos no pueden estar vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (txtNombre.Text == "")
                {
                    MessageBoxEx.Show("Verifique todos los campos", "Los campos no pueden estar vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
                return true;
            }
        }
        public void Llenado()
        {
            switch (Movimiento)
            {
                case "Alta":
                    txtNombre.Text = "";
                    txtNombre.Focus();
                    break;
                case "Modificacion":
                    txtNombre.Text = obj.nombre.ToString();
                    txtNombre.Focus();
                    break;
                default:
                    break;
            }
        }

    }
}
