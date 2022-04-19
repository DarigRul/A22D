using Datos.Diseno;
using DevComponents.DotNetBar;
using Entidades.Diseno;
using Entidades.Diseno.Calidad;
using Entidades.Diseno.Marcadores;
using Entidades.Diseno.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALTIMA_ERP_2022.Diseno.CatCalidad
{
    public partial class Calidad : OfficeForm
    {
        public Action refrescar;
        public String mov;
        public Calidad(ECalidad obj, string movimiento)
        {
            InitializeComponent();
            mov = movimiento;
            Cargar();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if (ValidaCampoEncogimiento() == true)
            {
                if (mov == "Alta")
                {

                }
            }
            else
            {
                MessageBoxEx.Show("Error, ocurrio un error inesperado en la validacion verifique.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidaCampoEncogimiento()
        {
           
            try
            {
                if (Txt1Adherenciaencogimiento.Text == "" && Txt1Temperaturaencogimiento.Text == "" && Txt1Tiempoencogimiento.Text == "" && Txt1Presionencogimiento.Text == "" && Txt1FinalHiloVaporencogimiento.Text == "" &&
                    Txt1Finaltramavaporencogimiento.Text == "" && Txt1DifHiloResultadoencogimiento.Text == "" && Txt1DifHilocmencogimiento.Text == "" && Txt1Diferenciatramaencogimiento.Text == "" && Txt1Diferenciatramacmencogimiento.Text == ""
                    && txt1observacionesvaporencogimiento.Text == "" && Txt1MedidaFinalHiloFisionencogimiento.Text == "" && Txt1MedidaFinalTramaFisionencogimiento.Text == "" &&
                    Txt1DiferenciaHiloFisionencogimiento.Text == "" &&  Txt1CMFisionencogimiento.Text == "" && Txt1TramaFisionencogimiento.Text == "" &&Txt1CMfisionPruebaencogimiento.Text == "" &&Txt1Observacionesfisionencogimiento.Text == "" &&Txt1MedidaFinalHiloVaporencogimiento.Text == "" &&
                    Txt1MedidafinaltramaVaporencogimiento.Text == "" &&   Txtdiferenciahilovaporencogimiento.Text == "" &&   Txt1CMHiloVaporencogimiento.Text == "" &&   Txt1DiferenciaTramaVaporencogimiento.Text == "" &&   Txt1CMTramaVaporencogimiento.Text == "" &&  Txt1ObservacionesplanchaVaporencogimiento.Text == ""
                    )
                {
                    return false;
                }

                try
                {
                    if (Cbo1Telaencogimiento.SelectedValue != null && Cbo1Operarioencogimiento.SelectedValue != null && cbo1Entretelaencogimiento.SelectedValue != null && cbo1proveedorencogimiento.SelectedValue != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception)
                {

                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Cargar()
        {
            if(mov =="Alta")
            {
                cargarcombos();
            }
            else if(mov =="Modificacion")
            {
                cargarcombos();
            }
        }
        public void cargarcombos()
        {
            List<ETelas> lsttelasencogimiento = new List<ETelas>();
            lsttelasencogimiento = DTelas.GetConsultaDisenoTelas();
            Cbo1Telaencogimiento.DataSource = lsttelasencogimiento;
            Cbo1Telaencogimiento.SelectedIndex = -1;
            Cbo1Telaencogimiento.DisplayMember = "descripcion";
            Cbo1Telaencogimiento.ValueMember = "id_tela";
            List<EComprasProveedores> lstProveedor = new List<EComprasProveedores>();
            lstProveedor = DTelas.GetLlenarComboComprasProveedores();
            cbo1proveedorencogimiento.DataSource = lstProveedor;
            cbo1proveedorencogimiento.SelectedIndex = -1;
            cbo1proveedorencogimiento.DisplayMember = "auxdescrip";
            cbo1proveedorencogimiento.ValueMember = "id_proveedor";
            List<EOperariocombo> lstOperario = new List<EOperariocombo>();
            lstOperario = DCalidad.GetLlenarComboOperario();
            Cbo1Operarioencogimiento.DataSource = lstOperario;
            Cbo1Operarioencogimiento.SelectedIndex = -1;
            Cbo1Operarioencogimiento.DisplayMember = "descripcion";
            Cbo1Operarioencogimiento.ValueMember = "id_operario";
            List<EEntretelacombo> lstentretela = new List<EEntretelacombo>();
            lstentretela = DCalidad.GetLlenarComboEntretela();
            cbo1Entretelaencogimiento.DataSource = lstentretela;
            cbo1Entretelaencogimiento.SelectedIndex = -1;
            cbo1Entretelaencogimiento.DisplayMember = "descripcion";
            cbo1Entretelaencogimiento.ValueMember = "id_entretela";

            List<ETelas> lsttelaslavado = new List<ETelas>();
            lsttelaslavado = DTelas.GetConsultaDisenoTelas();
            cbo2telalavado.DataSource = lsttelaslavado;
            cbo2telalavado.SelectedIndex = -1;
            cbo2telalavado.DisplayMember = "descripcion";
            cbo2telalavado.ValueMember = "id_tela";

            List<EOperariocombo> lstoperariolavado = new List<EOperariocombo>();
            lstoperariolavado = DCalidad.GetLlenarComboOperario();
            cbo2operariolavado.DataSource = lstoperariolavado;
            cbo2operariolavado.SelectedIndex = -1;
            cbo2operariolavado.DisplayMember = "descripcion";
            cbo2operariolavado.ValueMember = "id_operario";



            string[] calidad = {"Buena","Regular","Mala"};
            cbo2colorescalidadpilling.DataSource = calidad;
            cbo2colorescalidadpilling.SelectedIndex = 0;



            string[] resultado_piling = { "Si", "No"};
            cbo2resultadopilling.DataSource = resultado_piling;
            cbo2resultadopilling.SelectedIndex = 0;


        }

     
    }
}
