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
using DevComponents.DotNetBar.SuperGrid;
using Entidades.Diseno;
using Datos.Diseno; 

namespace ALTIMA_ERP_2022.Diseno.CatInstruccionesCuidado
{
    public partial class CatInstruccionesCuidado : OfficeForm
    {
        GridPanel panel;
        List<EInstruccionesCuidado> lstInstrucciones = DInstruccionesCuidado.ListarInstrucciones();

        public CatInstruccionesCuidado()
        {
            InitializeComponent();
        }

        private void CatInstruccionesCuidado_Load(object sender, EventArgs e)
        {
            lstInstrucciones = DInstruccionesCuidado.ListarInstrucciones();
            panel = sgcInstruccionesCuidado.PrimaryGrid;
            panel.DataSource = lstInstrucciones;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var ic = new InstruccionesCuidadoAM();
            ic.movimiento = InstruccionesCuidadoAM.Movimiento.agregar;
            ic.refrescar += () => CatInstruccionesCuidado_Load(this, EventArgs.Empty); 
            ic.ShowDialog(); 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Obtenemos la fila seleccionada
            GridRow row = panel.ActiveRow as GridRow;

            //Obtenemos el id_color y lo buscamos en la lista de colores (es la fuente del supegrid)
            int id_instruccion_cuidado = Convert.ToInt32(row["id_instruccion_cuidado"].Value);
            var instruccionCuidado = lstInstrucciones.Find(x => x.id_instruccion_cuidado == id_instruccion_cuidado);

            //Instanciamos el formulario y asignamos sus valores
            var cic = new InstruccionesCuidadoAM();
            cic.instruccion = instruccionCuidado;
            cic.movimiento = InstruccionesCuidadoAM.Movimiento.modificar;

            //Escuchamos el delegado para refrescar la pantalla del catálogo
            cic.refrescar += () => CatInstruccionesCuidado_Load(this, EventArgs.Empty);

            //Mostramos el formulario con los datos pasados 
            cic.ShowDialog();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere activar
            DialogResult dr = MessageBoxEx.Show("Se activará la instrucción de cuidado, ¿Está seguro?", "Activar instrucción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_instruccion_cuidado
                var row = panel.ActiveRow as GridRow;
                int id_instruccion_cuidado = Convert.ToInt32(row["id_instruccion_cuidado"].Value);

                //Activamos la Instruccion
                DInstruccionesCuidado.ActivarInstruccion(id_instruccion_cuidado);
                CatInstruccionesCuidado_Load(this, EventArgs.Empty);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            //Preguntamos al usuario si quiere desactivar
            DialogResult dr = MessageBoxEx.Show("Se desactivará la instrucción de cuidado, ¿Está seguro?", "Desactivar instrucción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Obtenemos el id_instruccion_cuidado
                var row = panel.ActiveRow as GridRow;
                int id_instruccion_cuidado = Convert.ToInt32(row["id_instruccion_cuidado"].Value);

                //Activamos la Instruccion
                DInstruccionesCuidado.DesactivarInstruccion(id_instruccion_cuidado);
                CatInstruccionesCuidado_Load(this, EventArgs.Empty);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Utilitarios.ConfiguracionGlobal.GeneraReporte(sgcInstruccionesCuidado, "catalogo_instrucciones_cuidado");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }

        private void sgcInstruccionesCuidado_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            //Obtenemos el estatus 
            foreach (GridRow row in panel.Rows)
            {
                if (Convert.ToInt32(row["estatus"].Value) == 1)
                {
                    row["estatus_texto"].Value = "ACTIVADO";
                }
                else
                {
                    row["estatus_texto"].Value = "DESACTIVADO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White; 
                }
            }
        }

        private bool Estatus(GridRow row)
        {
            int estatus = Convert.ToInt32(row["estatus"].Value);
            if (estatus == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Cuando la selccion ha cambiado
        private void sgcInstruccionesCuidado_SelectionChanged(object sender, GridEventArgs e)
        {
            // En este evento activamos o desactivamos los botones "Activar" o "Desactivar"
            var row = panel.ActiveRow as GridRow;

            //Si el estatus está activado 
            if (Estatus(row))
            {
                btnActivar.Enabled = false;
                btnDesactivar.Enabled = true;
                btnEditar.Enabled = true;
            }
            else //Estatus desactivado
            {
                btnActivar.Enabled = true;
                btnDesactivar.Enabled = false;
                btnEditar.Enabled = false;
            }
        }
    }
}
