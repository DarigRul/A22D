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
using Entidades.Utilitarios.Historico;
using Datos.Utilitarios.Historico;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace ALTIMA_ERP_2022.Utilitarios.Historico
{
    public partial class Historico : OfficeForm
    {
        List<EHistorico> lstHistorico = new List<EHistorico>();
        GridPanel panel;

        public Historico()
        {
            InitializeComponent();
            
        }

        private void Historico_Load(object sender, EventArgs e)
        {
            panel = sgcHistorico.PrimaryGrid;

            //Cargamos el Datetime Picker con el día 1 del mes actual 
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            dtiFechaInicial.Value = new DateTime(year, month, 1);

            // La fecha final con el día actual de la búsqueda
            dtiFechaFinal.Value = DateTime.Now; 
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (ValidaFechas()) panel.DataSource = DHistorico.ImportarHistorico(dtiFechaInicial.Value, dtiFechaFinal.Value);
        }

        private bool ValidaFechas()
        {
            DateTime fechaInicial = dtiFechaInicial.Value;
            DateTime fechaFinal = dtiFechaFinal.Value;

            if (fechaInicial < new DateTime(2022, 01, 01))
            {
                MessageBoxEx.Show("La fecha inicial no puede ser menor al 1 de enero del 2022", "Fecha inicial no válida", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false; 
            }
            else if (fechaFinal < new DateTime(2022,01,01))
            {
                MessageBoxEx.Show("La fecha final no puede ser menor al 1 de enero del 2022", "Fecha final no válida", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false;
            }
            else if(fechaInicial > fechaFinal)
            {
                MessageBoxEx.Show("La fecha inicial no puede ser mayor que la fecha final", "Error en fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
            else
            {
                return true; 
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ConfiguracionGlobal.GeneraReporte(sgcHistorico, "historico");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose(); 
        }

        private void sgcHistorico_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            panel.Footer.Text = "Total de registros : " + panel.VisibleRowCount;
        }
        private void sgcHistorico_DataFilteringComplete(object sender, GridDataFilteringCompleteEventArgs e)
        {
            if (panel != null)
            {
                panel.Footer.Text = "Total de registros : " + panel.VisibleRowCount;
            }
        }
    }
}
