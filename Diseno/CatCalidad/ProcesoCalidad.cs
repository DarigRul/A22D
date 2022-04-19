using DevComponents.DotNetBar;
using Entidades.Diseno.Calidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Diseno;
using Entidades.Diseno.Marcadores;
using Datos.Diseno;
namespace ALTIMA_ERP_2022.Diseno.CatCalidad
{
    public partial class ProcesoCalidad : Form
    {
        public Action refrescar;
        public String mov;
        public ProcesoCalidad(ECalidad obj, string movimiento)
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
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (validatab1() == true && validatab2() == true && validatab3() == true && validatab4() == true)
            {
                string valida1 = validatab1txtbox();
                string valida2 = validatab2txtbox();
                string valida3 = validatab3txtbox();
                string valida4 = validatab4txtbox();
                if (valida1 != "" && valida2 != "" && valida3 != "" && valida4 != "")
                {

                }
                else
                {
                    if (valida1 == "")
                    {
                        MessageBoxEx.Show(valida1, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (valida2 == "")
                    {
                        MessageBoxEx.Show(valida2, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (valida3 == "")
                    {
                        MessageBoxEx.Show(valida3, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (valida4 == "")
                    {
                        MessageBoxEx.Show(valida4, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                if (validatab1() == false)
                {
                    MessageBoxEx.Show("Error, el pre llenado de los combos de la pestaña 1 no tienen registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (validatab2() == false)
                {
                    MessageBoxEx.Show("Error, el pre llenado de los combos de la pestaña 2 no tienen registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (validatab3() == false)
                {
                    MessageBoxEx.Show("Error, el pre llenado de los combos de la pestaña 3 no tienen registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (validatab4() == false)
                {
                    MessageBoxEx.Show("Error, el pre llenado de los combos de la pestaña 4 no tienen registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public Boolean validatab1()
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
        public Boolean validatab2()
        {
            if (cbo2telalavado.SelectedValue != null && cbo2operariolavado.SelectedValue != null && cbo2colorescalidadpilling.SelectedValue != null && cbo2resultadopilling.SelectedValue != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean validatab3()
        {
            if (Cbo3telapruebacostura.SelectedValue != null && cbo3deslizamiento.SelectedValue != null && Cbo3operariopruebacostura.SelectedValue != null && cbo3rasgadotela.SelectedValue != null && Cbo3TipoAguja.SelectedValue != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean validatab4()
        {
            if (cbo4calidadcontaminante.SelectedValue != null && cbo4operariocontaminante.SelectedValue != null && cbo4telacontaminacion.SelectedValue != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string validatab1txtbox()
        {
            string cadena = "";
            double adherencia1;
            double temperatura1;
            double tiempo1;
            double presion1;
            double medidafinal1;
            double trama1;
            if (DT1Fechaencogimiento.MonthCalendar == null)
            {
                cadena += "Error en capturar fecha.";
            }
            if (!double.TryParse(Txt1Adherenciaencogimiento.Text, out adherencia1))
            {
                cadena += "  Error, validación en campo Adherencia, verifique.";
            }
            if (!double.TryParse(Txt1Temperaturaencogimiento.Text, out temperatura1))
            {
                cadena += "  Error, validación en campo temperatura, verifique.";
            }
            if (!double.TryParse(Txt1Tiempoencogimiento.Text, out tiempo1))
            {
                cadena += "  Error, validación en campo temperatura, verifique.";
            }
            if (!double.TryParse(Txt1Presionencogimiento.Text, out presion1))
            {
                cadena += "  Error, validación en campo presión, verifique.";
            }
            if (!double.TryParse(Txt1MedidaFinalHiloVaporencogimiento.Text, out medidafinal1))
            {
                cadena += "  Error, validación en campo presión, verifique.";
            }
            if (!double.TryParse(Txt1MedidafinaltramaVaporencogimiento.Text, out trama1))
            {
                cadena += "  Error, validación en campo presión, verifique.";
            }

            return cadena;
        }
        public string validatab2txtbox()
        {
            string cadena = "";
            double finalhilo2;
            double trama2;
            double hilolavado2;
            double cmlavado2;
            double tramalavado2;
            double cmtramalavado2;
            if (dp2fechalavado.MonthCalendar == null)
            {
                cadena += "Error en capturar fecha.";
            }
            if (!double.TryParse(txt2FinalHilolavado.Text, out finalhilo2))
            {
                cadena += "  Error, validación en campo Adherencia, verifique.";
            }
            if (!double.TryParse(txt2medidatramalavado.Text, out trama2))
            {
                cadena += "  Error, validación en campo temperatura, verifique.";
            }
            if (!double.TryParse(txt2diferenciahilolavado.Text, out hilolavado2))
            {
                cadena += "  Error, validación en campo temperatura, verifique.";
            }
            if (!double.TryParse(txt2cmhilolavado.Text, out cmlavado2))
            {
                cadena += "  Error, validación en campo presión, verifique.";
            }
            if (!double.TryParse(txt2tramalavado.Text, out tramalavado2))
            {
                cadena += "  Error, validación en campo presión, verifique.";
            }
            if (!double.TryParse(txt2cmtramalavado.Text, out cmtramalavado2))
            {
                cadena += "  Error, validación en campo presión, verifique.";
            }
            return cadena;
        }
        public string validatab3txtbox()
        {
            string cadena = "";
            if (dt3pruebacalidad.MonthCalendar == null)
            {
                cadena += "Error en capturar fecha.";
            }
            return cadena;
        }
        public string validatab4txtbox()
        {
            string cadena = "";
            if (dt4fechacontaminante.MonthCalendar == null)
            {
                cadena += "Error en capturar fecha.";
            }
            return cadena;
        }
        private bool ValidaCampoEncogimiento()
        {

            try
            {
                if (Txt1Adherenciaencogimiento.Text == "" && Txt1Temperaturaencogimiento.Text == "" && Txt1Tiempoencogimiento.Text == "" && Txt1Presionencogimiento.Text == "" && Txt1FinalHiloVaporencogimiento.Text == "" &&
                    Txt1Finaltramavaporencogimiento.Text == "" && Txt1DifHiloResultadoencogimiento.Text == "" && Txt1DifHilocmencogimiento.Text == "" && Txt1Diferenciatramaencogimiento.Text == "" && Txt1Diferenciatramacmencogimiento.Text == ""
                    && txt1observacionesvaporencogimiento.Text == "" && Txt1MedidaFinalHiloFisionencogimiento.Text == "" && Txt1MedidaFinalTramaFisionencogimiento.Text == "" &&
                    Txt1DiferenciaHiloFisionencogimiento.Text == "" && Txt1CMFisionencogimiento.Text == "" && Txt1TramaFisionencogimiento.Text == "" && Txt1CMfisionPruebaencogimiento.Text == "" && Txt1Observacionesfisionencogimiento.Text == "" && Txt1MedidaFinalHiloVaporencogimiento.Text == "" &&
                    Txt1MedidafinaltramaVaporencogimiento.Text == "" && Txtdiferenciahilovaporencogimiento.Text == "" && Txt1CMHiloVaporencogimiento.Text == "" && Txt1DiferenciaTramaVaporencogimiento.Text == "" && Txt1CMTramaVaporencogimiento.Text == "" && Txt1ObservacionesplanchaVaporencogimiento.Text == ""
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
            if (mov == "Alta")
            {
                cargarcombos();
            }
            else if (mov == "Modificacion")
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



            string[] calidad = { "Buena", "Regular", "Mala" };
            cbo2colorescalidadpilling.DataSource = calidad;
            cbo2colorescalidadpilling.SelectedIndex = 0;



            string[] resultado_piling = { "Si", "No" };
            cbo2resultadopilling.DataSource = resultado_piling;
            cbo2resultadopilling.SelectedIndex = 0;


        }


    }
}