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
using Entidades.Diseno.Calidad;
using Entidades.Diseno.Telas;
using Entidades.Diseno.Marcadores;

namespace ALTIMA_ERP_2022.Diseno.CatCalidad
{
    public partial class Calidad : OfficeForm
    {
        public EForros forro;
        DataTable dtOperariosEncogimiento;
        DataTable dtOperariosLavado;
        DataTable dtOperariosContaminacion;
        DataTable dtOperariosCostura;

        DataTable dtEntretelaEncogimiento;
        DataTable dtEntretelaLavado;
        DataTable dtEntretelaContaminacion;
        DataTable dtEntretelaCostura; 

        int pEnc, pLav, pCost, pCont = 0;
        public ETelas TelasGenarl;
       

        public Calidad(ETelas tela)
        {
            InitializeComponent();
            TelasGenarl = tela;
            Cargar();
        }

        private void Calidad_Load(object sender, EventArgs e)
        {
            try
            {
               


                //Verificamos que exista la prueba de encogimiento 
                pEnc = DForrosEncogimiento.Contar(forro.id_forro);
                if (pEnc > 0)
                {
                    //Existe una prueba de encogimiento, procedemos a importarla
                    var enc = DForrosEncogimiento.Importar(forro.id_forro);

                    //Asignamos el id_encogimiento para las actualizaciones
                    pEnc = enc.id_encogimiento; 

                    //Cargamos la información en los campos de prueba de encogimiento
                    txtVaporAdherencia.Value = enc.adherencia;
                    txtVaporTiempo.Value = enc.tiempo;
                    txtVaporTemperatura.Value = enc.temperatura;
                    txtVaporPresion.Value = enc.presion;
                    dtiFechaEncogimiento.Value = enc.fecha_hora;
                    txtVaporHiloFinal.Value = enc.vapor_hilo_final;
                    txtVaporTramaFinal.Value = enc.vapor_trama_final;
                    txtVaporHiloDiferencia.Value = enc.vapor_hilo_diferencia;
                    txtVaporTramaDiferencia.Value = enc.vapor_trama_diferencia;
                    txtVaporObservaciones.Text = enc.vapor_observaciones; 

                    txtFusionHiloFinal.Value = enc.fusion_hilo_final;
                    txtFusionTramaFinal.Value = enc.fusion_trama_final;
                    txtFusionHiloDiferencia.Value = enc.fusion_hilo_diferencia;
                    txtFusionTramaDiferencia.Value = enc.fusion_trama_diferencia;
                    txtFusionObservaciones.Text = enc.fusion_observaciones; 

                    txtPlanchaHiloFinal.Value = enc.plancha_hilo_final;
                    txtPlanchaTramaFinal.Value = enc.plancha_trama_final;
                    txtPlanchaHiloDiferencia.Value = enc.plancha_hilo_diferencia;
                    txtPlanchaTramaDiferencia.Value = enc.plancha_trama_diferencia;
                    txtPlanchaObservaciones.Text = enc.plancha_observaciones;

                    cmbOperarioEncogimiento.SelectedValue = enc.id_operario;
                    cmbTelaEncogimiento.SelectedValue = enc.id_entretela; 
                }





            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ ex.StackTrace}", "Error Inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validatab1() == true && validatab2() == true && validatab3() == true && validatab4() == true)
            {
                string valida1 = validatab1txtbox();
                string valida2 = validatab2txtbox();
                //string valida3 = validatab3txtbox();
                //string valida4 = validatab4txtbox();
                //if (valida1 != "" && valida2 != "" && valida3 != "" && valida4 != "")
                //{

                //}
                //else
                //{
                //    if (valida1 == "")
                //    {
                //        MessageBoxEx.Show(valida1, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    if (valida2 == "")
                //    {
                //        MessageBoxEx.Show(valida2, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    if (valida3 == "")
                //    {
                //        MessageBoxEx.Show(valida3, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    if (valida4 == "")
                //    {
                //        MessageBoxEx.Show(valida4, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

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
            if (cmbTelaEncogimiento.SelectedValue != null && cmbOperarioEncogimiento.SelectedValue != null && CboEntretela.SelectedValue != null)
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
            if (cmbLavadoEntretela.SelectedValue != null && cmbLavadoOperario.SelectedValue != null && cmbSolidezCalidad.SelectedValue != null && cboresultadopilling.SelectedValue != null)
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
            if (cmbCosturaEntretela.SelectedValue != null && cmbCosturaOperario.SelectedValue != null && cmbCosturaAguja.SelectedValue != null && cmbDeslizamiento.SelectedValue != null && comboBoxEx4.SelectedValue != null)
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
            if (cmbContaminacionEntretela.SelectedValue != null && cmbContaminacionOperario.SelectedValue != null && cmbContaminacionCalidad.SelectedValue != null)
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
            //if (DT1Fechaencogimiento.MonthCalendar == string.Empty)
            //{
            //    cadena += "Error en capturar fecha.";
            //}
            //if (!double.TryParse(Txt1Adherenciaencogimiento.Text, out adherencia1))
            //{
            //    cadena += "  Error, validación en campo Adherencia, verifique.";
            //}
            //if (!double.TryParse(Txt1Temperaturaencogimiento.Text, out temperatura1))
            //{
            //    cadena += "  Error, validación en campo temperatura, verifique.";
            //}
            //if (!double.TryParse(Txt1Tiempoencogimiento.Text, out tiempo1))
            //{
            //    cadena += "  Error, validación en campo temperatura, verifique.";
            //}
            //if (!double.TryParse(Txt1Presionencogimiento.Text, out presion1))
            //{
            //    cadena += "  Error, validación en campo presión, verifique.";
            //}
            //if (!double.TryParse(Txt1MedidaFinalHiloVaporencogimiento.Text, out medidafinal1))
            //{
            //    cadena += "  Error, validación en campo presión, verifique.";
            //}
            //if (!double.TryParse(Txt1MedidafinaltramaVaporencogimiento.Text, out trama1))
            //{
            //    cadena += "  Error, validación en campo presión, verifique.";
            //}

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
            //if (dp2fechalavado.MonthCalendar == null)
            //{
            //    cadena += "Error en capturar fecha.";
            //}
            //if (!double.TryParse(txt2FinalHilolavado.Text, out finalhilo2))
            //{
            //    cadena += "  Error, validación en campo Adherencia, verifique.";
            //}
            //if (!double.TryParse(txt2medidatramalavado.Text, out trama2))
            //{
            //    cadena += "  Error, validación en campo temperatura, verifique.";
            //}
            //if (!double.TryParse(txt2diferenciahilolavado.Text, out hilolavado2))
            //{
            //    cadena += "  Error, validación en campo temperatura, verifique.";
            //}
            //if (!double.TryParse(txt2cmhilolavado.Text, out cmlavado2))
            //{
            //    cadena += "  Error, validación en campo presión, verifique.";
            //}
            //if (!double.TryParse(txt2tramalavado.Text, out tramalavado2))
            //{
            //    cadena += "  Error, validación en campo presión, verifique.";
            //}
            //if (!double.TryParse(txt2cmtramalavado.Text, out cmtramalavado2))
            //{
            //    cadena += "  Error, validación en campo presión, verifique.";
            //}
            return cadena;
        }
        //public string validatab3txtbox()
        //{
        //    string cadena = "";
        //    if (dt3pruebacalidad.MonthCalendar == null)
        //    {
        //        cadena += "Error en capturar fecha.";
        //    }
        //    return cadena;
        //}
        //public string validatab4txtbox()
        //{
        //    string cadena = "";
        //    if (dt4fechacontaminante.MonthCalendar == null)
        //    {
        //        cadena += "Error en capturar fecha.";
        //    }
        //    return cadena;
        //}
        //private bool ValidaCampoEncogimiento()
        //{

        //    try
        //    {
        //        if (Txt1Adherenciaencogimiento.Text == "" && Txt1Temperaturaencogimiento.Text == "" && Txt1Tiempoencogimiento.Text == "" && Txt1Presionencogimiento.Text == "" && Txt1FinalHiloVaporencogimiento.Text == "" &&
        //            Txt1Finaltramavaporencogimiento.Text == "" && Txt1DifHiloResultadoencogimiento.Text == "" && Txt1DifHilocmencogimiento.Text == "" && Txt1Diferenciatramaencogimiento.Text == "" && Txt1Diferenciatramacmencogimiento.Text == ""
        //            && txt1observacionesvaporencogimiento.Text == "" && Txt1MedidaFinalHiloFisionencogimiento.Text == "" && Txt1MedidaFinalTramaFisionencogimiento.Text == "" &&
        //            Txt1DiferenciaHiloFisionencogimiento.Text == "" && Txt1CMFisionencogimiento.Text == "" && Txt1TramaFisionencogimiento.Text == "" && Txt1CMfisionPruebaencogimiento.Text == "" && Txt1Observacionesfisionencogimiento.Text == "" && Txt1MedidaFinalHiloVaporencogimiento.Text == "" &&
        //            Txt1MedidafinaltramaVaporencogimiento.Text == "" && Txtdiferenciahilovaporencogimiento.Text == "" && Txt1CMHiloVaporencogimiento.Text == "" && Txt1DiferenciaTramaVaporencogimiento.Text == "" && Txt1CMTramaVaporencogimiento.Text == "" && Txt1ObservacionesplanchaVaporencogimiento.Text == ""
        //            )
        //        {
        //            return false;
        //        }

        //        try
        //        {
        //            if (Cbo1Telaencogimiento.SelectedValue != null && Cbo1Operarioencogimiento.SelectedValue != null && cbo1Entretelaencogimiento.SelectedValue != null && cbo1proveedorencogimiento.SelectedValue != null)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }

        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        private bool ValidaEncogimiento()
        {
            if (cmbOperarioEncogimiento.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione el operario", "Operario no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbOperarioEncogimiento.Focus();
                return false; 
            }
            else if(dtiFechaEncogimiento.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture la fecha de prueba de encogimiento", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtiFechaEncogimiento.Focus();
                return false; 
            }
            else if(cmbTelaEncogimiento.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione el material", "Tela no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTelaEncogimiento.Focus();
                return false; 
            }
            else
            {
                return true; 
            }
        }

        private EForrosEncogimiento DatosEncogimiento()
        {
            EForrosEncogimiento enc = new EForrosEncogimiento();
            enc.id_operario = Convert.ToInt32(cmbOperarioEncogimiento.SelectedValue); 
            enc.id_entretela = Convert.ToInt32(cmbTelaEncogimiento.SelectedValue);
            enc.fecha_hora = dtiFechaEncogimiento.Value;
            enc.adherencia = txtVaporAdherencia.Value;
            enc.tiempo = txtVaporTiempo.Value; 
            enc.temperatura = txtVaporTemperatura.Value;
            enc.presion = txtVaporPresion.Value;
            enc.vapor_hilo_final = txtVaporHiloFinal.Value; 
            enc.vapor_trama_final = txtVaporTramaFinal.Value;
            enc.vapor_hilo_diferencia = txtVaporHiloDiferencia.Value;
            enc.vapor_trama_diferencia = txtVaporTramaDiferencia.Value;
            enc.vapor_observaciones = txtVaporObservaciones.Text;

            enc.fusion_hilo_diferencia = txtFusionHiloDiferencia.Value;
            enc.fusion_trama_diferencia = txtFusionTramaDiferencia.Value;
            enc.fusion_hilo_final = txtFusionHiloFinal.Value; 
            enc.fusion_trama_final = txtFusionTramaFinal.Value;
            enc.fusion_observaciones = txtFusionObservaciones.Text;

            enc.plancha_hilo_diferencia = txtPlanchaHiloDiferencia.Value;
            enc.plancha_trama_diferencia = txtPlanchaTramaDiferencia.Value;
            enc.plancha_hilo_final = txtPlanchaHiloFinal.Value;
            enc.plancha_trama_final = txtPlanchaTramaFinal.Value;
            enc.plancha_observaciones = txtPlanchaObservaciones.Text;

            enc.id_encogimiento = pEnc;
            enc.id_forro = forro.id_forro; 

            return enc;
        }


        public void Cargar()
        {
           
                cargarcombos();
            limpiartextbox();
        }

   

        public void cargarcombos()
        {
            lblDescripcion.Text = TelasGenarl.descripcion;
            lblProveedor.Text = TelasGenarl.auxid_proveedor;
            lblClaveProveedor.Text = TelasGenarl.clave_proveedor;

            //Importar las entretelas 

            List<ETelas> lsttelasencogimiento = new List<ETelas>();
            lsttelasencogimiento = DTelas.GetConsultaDisenoTelas();
            cmbTelaEncogimiento.DataSource = lsttelasencogimiento;
            cmbTelaEncogimiento.SelectedIndex = -1;
            cmbTelaEncogimiento.DisplayMember = "descripcion";
            cmbTelaEncogimiento.ValueMember = "id_tela";
           
            List<EOperariocombo> lstOperario = new List<EOperariocombo>();
            lstOperario = DCalidad.GetLlenarComboOperario();
            cmbOperarioEncogimiento.DataSource = lstOperario;
            cmbOperarioEncogimiento.SelectedIndex = -1;
            cmbOperarioEncogimiento.DisplayMember = "descripcion";
            cmbOperarioEncogimiento.ValueMember = "id_operario";
            List<EEntretelacombo> lstentretela = new List<EEntretelacombo>();
            lstentretela = DCalidad.GetLlenarComboEntretela();
            CboEntretela.DataSource = lstentretela;
            CboEntretela.SelectedIndex = -1;
            CboEntretela.DisplayMember = "descripcion";
            CboEntretela.ValueMember = "id_entretela";

            List<ETelas> lsttelaslavado = new List<ETelas>();
            lsttelaslavado = DTelas.GetConsultaDisenoTelas();
            cmbLavadoEntretela.DataSource = lsttelaslavado;
            cmbLavadoEntretela.SelectedIndex = -1;
            cmbLavadoEntretela.DisplayMember = "descripcion";
            cmbLavadoEntretela.ValueMember = "id_tela";

            List<EOperariocombo> lstoperariolavado = new List<EOperariocombo>();
            lstoperariolavado = DCalidad.GetLlenarComboOperario();
            cmbLavadoOperario.DataSource = lstoperariolavado;
            cmbLavadoOperario.SelectedIndex = -1;
            cmbLavadoOperario.DisplayMember = "descripcion";
            cmbLavadoOperario.ValueMember = "id_operario";



            string[] calidad = { "Buena", "Regular", "Mala" };
            cmbSolidezCalidad.DataSource = calidad;
            cmbSolidezCalidad.SelectedIndex = 0;



            string[] resultado_piling = { "Si", "No" };
            cboresultadopilling.DataSource = resultado_piling;
            cboresultadopilling.SelectedIndex = 0;



                  lsttelasencogimiento = DTelas.GetConsultaDisenoTelas();
            cmbCosturaEntretela.DataSource = lsttelasencogimiento;
            cmbCosturaEntretela.SelectedIndex = -1;
            cmbCosturaEntretela.DisplayMember = "descripcion";
            cmbCosturaEntretela.ValueMember = "id_tela";
            List<EOperariocombo> lstcostura = new List<EOperariocombo>(); 
          
            lstcostura = DCalidad.GetLlenarComboOperario();
            cmbCosturaOperario.DataSource = lstcostura;
            cmbCosturaOperario.SelectedIndex = -1;
            cmbCosturaOperario.DisplayMember = "descripcion";
            cmbCosturaOperario.ValueMember = "id_operario";
            //dtEntretelaEncogimiento = DForros.ImportaEntretelas();
            //dtEntretelaLavado = DForros.ImportaEntretelas();
            //dtEntretelaContaminacion = DForros.ImportaEntretelas();
            //dtEntretelaCostura = DForros.ImportaEntretelas();

            //cmbTelaEncogimiento.DataSource = dtEntretelaEncogimiento;
            //cmbTelaEncogimiento.DisplayMember = "nombre";
            //cmbTelaEncogimiento.ValueMember = "id_material";
            //cmbTelaEncogimiento.SelectedIndex = 0;

            //cmbLavadoEntretela.DataSource = dtEntretelaLavado;
            //cmbLavadoEntretela.DisplayMember = "nombre";
            //cmbLavadoEntretela.ValueMember = "id_material";
            //cmbLavadoEntretela.SelectedIndex = 0;

            //cmbCosturaEntretela.DataSource = dtEntretelaCostura;
            //cmbCosturaEntretela.DisplayMember = "nombre";
            //cmbCosturaEntretela.ValueMember = "id_material";
            //cmbCosturaEntretela.SelectedIndex =0;

            //cmbContaminacionEntretela.DataSource = dtEntretelaContaminacion;
            //cmbContaminacionEntretela.DisplayMember = "nombre";
            //cmbContaminacionEntretela.ValueMember = "id_material";
            //cmbContaminacionEntretela.SelectedIndex =0;

            ////Importar operarios y asignamos a los combos
            //dtOperariosEncogimiento = DForros.ImportaOperarios();
            //dtOperariosLavado = DForros.ImportaOperarios();
            //dtOperariosContaminacion = DForros.ImportaOperarios();
            //dtOperariosCostura = DForros.ImportaOperarios();

            //cmbOperarioEncogimiento.DataSource = dtOperariosEncogimiento;
            //cmbOperarioEncogimiento.DisplayMember = "Nombre";
            //cmbOperarioEncogimiento.ValueMember = "ClaveEmpleado";
            //cmbOperarioEncogimiento.SelectedIndex = 0;

            //cmbContaminacionOperario.DataSource = dtOperariosContaminacion;
            //cmbContaminacionOperario.DisplayMember = "Nombre";
            //cmbContaminacionOperario.ValueMember = "ClaveEmpleado";
            //cmbContaminacionOperario.SelectedIndex = 0;

            //cmbLavadoOperario.DataSource = dtOperariosLavado;
            //cmbLavadoOperario.DisplayMember = "Nombre";
            //cmbLavadoOperario.ValueMember = "ClaveEmpleado";
            //cmbLavadoOperario.SelectedIndex =0;

            //cmbCosturaOperario.DataSource = dtOperariosCostura;
            //cmbCosturaOperario.DisplayMember = "Nombre";
            //cmbCosturaOperario.ValueMember = "ClaveEmpleado";
            //cmbCosturaOperario.SelectedIndex = 0;


        }

        public void limpiartextbox()
        {
            txtVaporAdherencia.Text = "0.00";
            txtVaporTiempo.Text = "0.00";
            txtVaporTemperatura.Text = "0.00";
            txtVaporPresion.Text = "0.00";
            txtVaporHiloFinal.Text = "0.00";
            txtVaporHiloDiferencia.Text = "0.00";
            txtVaporTramaDiferencia.Text = "0.00";
            txtFusionTramaFinal.Text = "0.00";
            txtFusionHiloDiferencia.Text = "0.00";
            txtFusionTramaDiferencia.Text = "0.00";
            txtPlanchaHiloFinal.Text = "0.00";
            txtPlanchaHiloFinal.Text = "0.00";
            txtPlanchaHiloDiferencia.Text = "0.00";
            txtPlanchaTramaFinal.Text = "0.00";
            txtPlanchaTramaDiferencia.Text = "0.00";
            txtFusionHiloFinal.Text = "0.00";
            txtVaporTramaFinal.Text = "0.00";
            txtLavadoHiloFinal.Text = "0.00";
            txtLavadoHiloDiferencia.Text = "0.00";

            txtLavadoTramaFinal.Text = "0.00";
            txtLavadoTramaDiferencia.Text = "0.00";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
