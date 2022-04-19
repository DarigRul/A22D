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

namespace ALTIMA_ERP_2022.Diseno.Produccion.ProcesosProduccion
{
    public partial class ProcesosProduccionAM : Office2007Form
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public EProcesos eProcesos;
        public ProcesosProduccionAM()
        {
            InitializeComponent();
        }

        private void ProcesosProduccionAM_Load(object sender, EventArgs e)
        {
            if (movimiento == Movimiento.modificar)
            {
                txtNombre.Text = eProcesos.nombre;
                cmbTipoProceso.Text = eProcesos.tipo;
                btnAceptar.Text = "Modificar";
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validacampos()== false)
            {
  
                switch (movimiento)
                {
                    case Movimiento.agregar:
                        //Creamos la entidad a guardar 

                        EProcesos ProcesoGuardar = new EProcesos {
                        nombre = txtNombre.Text,
                        tipo = cmbTipoProceso.Text,
                        departamento = "Diseño",
                        id_departamento = 1
                        };
                        if (DProcesos.procesosProduccionAgrega(ProcesoGuardar)>0)
                        {
                            // Registramos el historico
                            DHistorico.RegistraHistorico("Diseno", "Procesos Produccion", "Agrega proceso", ProcesoGuardar.nombre);
                            MessageBoxEx.Show("Proceso agregado correctamente", "Proceso agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        }
                        break;
                    case Movimiento.modificar:
                        //Creamos la entidad a guardar 

                        EProcesos procesoModificar = new EProcesos
                        {
                            id_proceso= eProcesos.id_proceso,
                            nombre = txtNombre.Text,
                            tipo = cmbTipoProceso.Text,
                            departamento = "Diseño",
                            id_departamento = 1
                        };
                        DProcesos.procesosProduccionModifica(procesoModificar);
                        
                            // Registramos el historico
                            DHistorico.RegistraHistorico("Diseno", "Procesos Produccion", "modifica proceso", procesoModificar.nombre);
                            MessageBoxEx.Show("Proceso modificado correctamente", "Proceso modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        
                        break;
                    default:
                        break;
                }
            }
        }
        private bool validacampos()
        {
           
            if (txtNombre.Text == "" || txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el nombre del proceso", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return true;
            }
            else if(cmbTipoProceso.Text == "")
            {
                MessageBoxEx.Show("Seleccione el tipo de proceso", "Tipo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTipoProceso.Focus();
                return true;
            }
            //buscamos si el proceso ya esta registrado
            List<EProcesos> lista = DProcesos.ProcesosListar().Where(x => x.nombre.Contains(txtNombre.Text) && x.departamento == "Diseño" && x.tipo == cmbTipoProceso.Text).ToList();
            if (lista.Count > 0)
            {
                MessageBoxEx.Show("El proceso ya se encuentra registrado", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return true;
            }
            return false;

        }

        private void cmbTipoProceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
