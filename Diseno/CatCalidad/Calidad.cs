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

            string valida1 = validatab1txtbox();
            string valida2 = validatab2txtbox();
            Boolean combo1 = validatab1();
            Boolean combo2 = validatab2();
            Boolean combo3 = validatab3();
            Boolean combo4 = validatab4();
            int bandera = 0;
            string mensaje = "";
            if (valida1 != "" || combo1 == false)//proceso para validar si el tab 1 es correcto para actualizar informacion
            {
                bandera += 1;
                mensaje += "La pestaña prueba encogimiento no ha sido completada, contiene errores por favor verifique.\n";
            }
            if (valida2 != "" || combo2 == false)//proceso para validar si el tab 2 es correcto para actualizar informacion
            {
                bandera += 1;
                mensaje += "La pestaña prueba lavado y pilling no ha sido completada, contiene errores por favor verifique.\n";
            }
            if (combo3 == false)
            {
                bandera += 1;
                mensaje += "La pestaña prueba costura no ha sido completada, contiene errores por favor verifique.\n";
            }
            if (combo4 == false)
            {
                bandera += 1;
                mensaje += "La pestaña prueba contaminación en combinación de telas no ha sido completada, contiene errores por favor verifique.\n";
            }
            if (dtiFechaEncogimiento.Text == string.Empty && dtiLavadoFecha.Text == string.Empty && dtiCosturaFecha.Text == string.Empty && dtiContaminacionFecha.Text == string.Empty)
            {
                mensaje += "Los campos de fechas no tienen el formato correcot, por favor verifique.\n";
                MessageBoxEx.Show(mensaje, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (bandera >= 1)
                {
                    MessageBoxEx.Show(mensaje, "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    List<ERegistroTelasCalidad> lstregistrotelacalidad = new List<ERegistroTelasCalidad>();
                    lstregistrotelacalidad = DCalidad.GetConsultaConregistroCalidad(TelasGenarl);
                    string Movimiento = "";
                    int id_encogimiento = 0;
                    int id_lavado = 0;
                    int id_costura = 0;
                    int id_contaminacion = 0;
                    if (lstregistrotelacalidad.Count == 0)
                    {
                        Movimiento = "Alta";
                    }
                    else
                    {
                        foreach (ERegistroTelasCalidad itm in lstregistrotelacalidad)
                        {
                            id_encogimiento = itm.id_prueba_encogimiento;
                            id_lavado = itm.id_prueba_lavado_pilling;
                            id_costura = itm.id_prueba_costura;
                            id_contaminacion = itm.id_prueba_contaminacion_telas;
                        }

                        Movimiento = "Modificacion";
                    }

                    EPruebaEncogimiento encogimiento = new EPruebaEncogimiento();//asignacion a objeto con componentes  para insercion de encogimiento
                    encogimiento.id_tela = Convert.ToInt16(cmbTelaEncogimiento.SelectedValue);
                    encogimiento.id_operario = Convert.ToInt16(cmbOperarioEncogimiento.SelectedValue);
                    encogimiento.fecha_hora = Convert.ToDateTime(dtiFechaEncogimiento.Text);
                    encogimiento.id_entretela = Convert.ToInt16(CboEntretela.SelectedValue);
                    encogimiento.adherencia = Convert.ToDouble(txtVaporAdherencia.Text);
                    encogimiento.id_proveedor = TelasGenarl.id_proveedor;
                    encogimiento.temperatura = Convert.ToDouble(txtVaporTemperatura.Text);
                    encogimiento.tiempo = Convert.ToInt16(txtVaporTiempo.Text);
                    encogimiento.presion = Convert.ToDouble(txtVaporPresion.Text);
                    encogimiento.vapor_hilo_final = Convert.ToDouble(txtVaporHiloFinal.Text);
                    encogimiento.vapor_trama_final = Convert.ToDouble(txtVaporTramaFinal.Text);
                    encogimiento.vapor_hilo_diferencia = Convert.ToDouble(txtVaporHiloDiferencia.Text);
                    encogimiento.vapor_trama_diferencia = Convert.ToDouble(txtVaporTramaDiferencia.Text);
                    encogimiento.vapor_observaciones = txtVaporObservaciones.Text;
                    encogimiento.fusion_hilo_final = Convert.ToDouble(txtFusionHiloFinal.Text);
                    encogimiento.fusion_trama_final = Convert.ToDouble(txtFusionTramaFinal.Text);
                    encogimiento.fusion_hilo_diferencia = Convert.ToDouble(txtFusionHiloDiferencia.Text);
                    encogimiento.fusion_trama_diferencia = Convert.ToDouble(txtFusionTramaDiferencia.Text);
                    encogimiento.fusion_observaciones = txtFusionObservaciones.Text;
                    encogimiento.plancha_hilo_final = Convert.ToDouble(txtPlanchaHiloFinal.Text);
                    encogimiento.plancha_trama_final = Convert.ToDouble(txtPlanchaTramaFinal.Text);
                    encogimiento.plancha_hilo_diferencia = Convert.ToDouble(txtPlanchaHiloDiferencia.Text);
                    encogimiento.plancha_trama_diferencia = Convert.ToDouble(txtPlanchaTramaDiferencia.Text);
                    encogimiento.plancha_obvservaciones = txtPlanchaObservaciones.Text;

                    EPruebaLavadoPilling lavado = new EPruebaLavadoPilling(); //asignacion a objeto con componentes  para insercion de lavado y pilling

                    lavado.id_tela = Convert.ToInt16(cmbLavadoEntretela.SelectedValue);
                    lavado.id_operario = Convert.ToInt16(cmbLavadoOperario.SelectedValue);
                    lavado.fecha = Convert.ToDateTime(dtiLavadoFecha.Text);
                    lavado.lavado_hilo_final = Convert.ToInt16(txtLavadoHiloFinal.Text);
                    lavado.lavado_trama_final = Convert.ToInt16(txtLavadoTramaFinal.Text);
                    lavado.lavado_hilo_diferencia = Convert.ToInt16(txtLavadoHiloDiferencia.Text);
                    lavado.lavado_trama_diferencia = Convert.ToInt16(txtLavadoTramaDiferencia.Text);
                    lavado.lavado_observaciones = txtLavadoObservaciones.Text;
                    lavado.solidez_observaciones = txtSolidezObservaciones.Text;
                    lavado.solidez_calidad = Convert.ToString(cmbSolidezCalidad.SelectedValue);
                    lavado.pilling = Convert.ToString(cboresultadopilling.SelectedValue);
                    lavado.pilling_observacion = txtPillingObservaciones.Text;

                    EPruebaCostura costura = new EPruebaCostura(); //asignacion a objeto con componentes  para insercion de prueba costura
                    costura.id_operario = Convert.ToInt16(cmbCosturaOperario.SelectedValue);
                    costura.fecha = Convert.ToDateTime(dtiCosturaFecha.Text);
                    costura.aguja = Convert.ToString(cmbCosturaAguja.SelectedValue);
                    costura.deslizamiento = Convert.ToString(cmbDeslizamiento.SelectedValue);
                    costura.deslizamientoobservaciones = Convert.ToString(txtDeslizamientoObservaciones.Text);
                    costura.rasgado = Convert.ToString(cborasgadotela.SelectedValue);
                    costura.rasgadoobservaciones = Convert.ToString(txtRasgadoObservaciones.Text);

                    EPruebaContaminacion contaminacion = new EPruebaContaminacion(); //asignacion a objeto con componentes  para insercion de prueba contaminacion en combinacion telas
                    contaminacion.id_operario = Convert.ToInt16(cmbCosturaOperario.SelectedValue);
                    contaminacion.fecha = Convert.ToDateTime(dtiContaminacionFecha.Text);
                    contaminacion.contaminacion = Convert.ToString(cmbContaminacionCalidad.SelectedValue);
                    contaminacion.observaciones = Convert.ToString(txtContaminacionObservaciones.Text);

                    if (Movimiento == "Modificacion")
                    {
                        encogimiento.id_encogimiento = id_encogimiento;
                        lavado.id_lavado = id_lavado;
                        costura.id_costura = id_costura;
                        contaminacion.id_contaminacion = id_contaminacion;
                    }
                    if (Movimiento == "Alta")
                    {
                        try
                        {
                            DCalidad.SetInsertarCalidad(TelasGenarl, encogimiento, lavado, costura, contaminacion);

                        }
                        catch
                        {

                        }
                    }
                    if (Movimiento == "Modificacion")
                    {
                        ERegistroTelasCalidad obj = new ERegistroTelasCalidad();
                        foreach (ERegistroTelasCalidad itm in lstregistrotelacalidad)
                        {
                            obj.id_tela = itm.id_tela;
                            obj.id_prueba_contaminacion_telas = itm.id_prueba_contaminacion_telas;
                            obj.id_prueba_costura = itm.id_prueba_costura;
                            obj.id_prueba_encogimiento = itm.id_prueba_encogimiento;
                            obj.id_prueba_lavado_pilling = itm.id_prueba_lavado_pilling;
                            break;
                        }
                        try
                        {
                            DCalidad.SetActualizarDisenoCalidad(obj, encogimiento, lavado, costura, contaminacion);
                        }
                        catch
                        {

                        }
                    }

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
            if (cmbCosturaEntretela.SelectedValue != null && cmbCosturaOperario.SelectedValue != null && cmbCosturaAguja.SelectedValue != null && cmbDeslizamiento.SelectedValue != null && cborasgadotela.SelectedValue != null)
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
            double medidafusionhilofinal;
            double medidafusiontramafinal;
            double medidafusionhilodiferencia;
            double medidafusionobservaciones;
            double medidaplanchahilofinal;
            double medidaplanchatramafinal;
            double medidaplanchahilodiferencia;
            double medidaplanchatramadiferencia;
            double medidaplanchaobservaciones;
            if (!double.TryParse(txtVaporAdherencia.Text, out adherencia1))
            {
                cadena += "  Error, validación en campo Adherencia, verifique.\n";
            }
            if (!double.TryParse(txtVaporTemperatura.Text, out temperatura1))
            {
                cadena += "  Error, validación en campo temperatura, verifique.\n";
            }
            if (!double.TryParse(txtVaporTiempo.Text, out tiempo1))
            {
                cadena += "  Error, validación en campo tiempo, verifique.\n";
            }
            if (!double.TryParse(txtVaporPresion.Text, out presion1))
            {
                cadena += "  Error, validación en campo presión, verifique.\n";
            }

            if (!double.TryParse(txtFusionHiloFinal.Text, out medidafusionhilofinal))
            {
                cadena += "  Error, validación en campo fusión hilo final, verifique.\n";
            }
            if (!double.TryParse(txtFusionTramaFinal.Text, out medidafusiontramafinal))
            {
                cadena += "  Error, validación en campo fusión trama final, verifique.\n";
            }
            if (!double.TryParse(txtFusionHiloDiferencia.Text, out medidafusionhilodiferencia))
            {
                cadena += "  Error, validación en campo fusión hilo diferencia, verifique.\n";
            }
            if (!double.TryParse(txtFusionTramaDiferencia.Text, out medidafusiontramafinal))
            {
                cadena += "  Error, validación en campo fusión trama diferencia, verifique.\n";
            }
            if (!double.TryParse(txtPlanchaHiloFinal.Text, out medidaplanchahilofinal))
            {
                cadena += "  Error, validación en campo fusión hilo final, verifique.\n";
            }
            if (!double.TryParse(txtPlanchaTramaFinal.Text, out medidaplanchatramafinal))
            {
                cadena += "  Error, validación en campo plancha trama final, verifique.\n";
            }
            if (!double.TryParse(txtPlanchaHiloDiferencia.Text, out medidaplanchahilodiferencia))
            {
                cadena += "  Error, validación en campo plancha hilo diferencia, verifique.\n";
            }
            if (!double.TryParse(txtPlanchaTramaDiferencia.Text, out medidaplanchatramadiferencia))
            {
                cadena += "  Error, validación en campo plancha trama diferencia, verifique.\n";
            }
            return cadena;
        }
        public string validatab2txtbox()
        {
            string cadena = "";
            double finallavado;
            double finaltrama;
            double hilodiferencia;
            double lavadotramadidiferencia;
            double lavadoobservaciones;
            double solidezobservacion;
            double pillingobservacion;

            if (!double.TryParse(txtLavadoHiloFinal.Text, out finallavado))
            {
                cadena += "  Error, validación en campo lavado hilo final, verifique.\n";
            }
            if (!double.TryParse(txtLavadoTramaFinal.Text, out finaltrama))
            {
                cadena += "  Error, validación en campo lavado trama final, verifique.\n";
            }
            if (!double.TryParse(txtLavadoHiloDiferencia.Text, out hilodiferencia))
            {
                cadena += "  Error, validación en campo lavado hilo diferencia, verifique.\n";
            }
            if (!double.TryParse(txtLavadoTramaDiferencia.Text, out lavadotramadidiferencia))
            {
                cadena += "  Error, validación en campo lavado trama diferencia, verifique.\n";
            }
            return cadena;
        }





        private bool ValidaEncogimiento()
        {
            if (cmbOperarioEncogimiento.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione el operario", "Operario no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbOperarioEncogimiento.Focus();
                return false;
            }
            else if (dtiFechaEncogimiento.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture la fecha de prueba de encogimiento", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtiFechaEncogimiento.Focus();
                return false;
            }
            else if (cmbTelaEncogimiento.SelectedIndex == -1)
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
            List<ERegistroTelasCalidad> lstregistrotelacalidad = new List<ERegistroTelasCalidad>();
            lstregistrotelacalidad = DCalidad.GetConsultaConregistroCalidad(TelasGenarl);
            string Movimiento = "";
            if (lstregistrotelacalidad.Count == 0)
            {
                Movimiento = "Alta";
            }
            else
            {
                Movimiento = "Modificacion";
            }

            List<ETelas> lsttelasencogimiento = new List<ETelas>();
            lsttelasencogimiento = DTelas.GetConsultaDisenoTelas();
            cmbTelaEncogimiento.DataSource = lsttelasencogimiento;
            cmbTelaEncogimiento.DisplayMember = "descripcion";
            cmbTelaEncogimiento.ValueMember = "id_tela";

            List<EOperariocombo> lstOperario = new List<EOperariocombo>();
            lstOperario = DCalidad.GetLlenarComboOperario();
            cmbOperarioEncogimiento.DataSource = lstOperario;
            cmbOperarioEncogimiento.SelectedIndex = 0;
            cmbOperarioEncogimiento.DisplayMember = "descripcion";
            cmbOperarioEncogimiento.ValueMember = "id_operario";
            List<EEntretelacombo> lstentretela = new List<EEntretelacombo>();
            lstentretela = DCalidad.GetLlenarComboEntretela();
            CboEntretela.DataSource = lstentretela;
            CboEntretela.SelectedIndex = 0;
            CboEntretela.DisplayMember = "descripcion";
            CboEntretela.ValueMember = "id_entretela";

            List<ETelas> lsttelaslavado = new List<ETelas>();
            lsttelaslavado = DTelas.GetConsultaDisenoTelas();
            cmbLavadoEntretela.DataSource = lsttelaslavado;
            cmbLavadoEntretela.DisplayMember = "descripcion";
            cmbLavadoEntretela.ValueMember = "id_tela";

            List<EOperariocombo> lstoperariolavado = new List<EOperariocombo>();
            lstoperariolavado = DCalidad.GetLlenarComboOperario();
            cmbLavadoOperario.DataSource = lstoperariolavado;
            cmbLavadoOperario.SelectedIndex = 0;
            cmbLavadoOperario.DisplayMember = "descripcion";
            cmbLavadoOperario.ValueMember = "id_operario";



            string[] calidad = { "Buena", "Regular", "Mala" };
            cmbSolidezCalidad.DataSource = calidad;
            cmbSolidezCalidad.SelectedIndex = 0;



            string[] resultado_piling = { "Si", "No" };
            cboresultadopilling.DataSource = resultado_piling;
            cboresultadopilling.SelectedIndex = 0;



            List<ETelas> lstcosturatela = new List<ETelas>();
            lstcosturatela = DTelas.GetConsultaDisenoTelas();
            cmbCosturaEntretela.DataSource = lstcosturatela;
            cmbCosturaEntretela.DisplayMember = "descripcion";
            cmbCosturaEntretela.ValueMember = "id_tela";


            List<EOperariocombo> lstcostura = new List<EOperariocombo>();

            lstcostura = DCalidad.GetLlenarComboOperario();
            cmbCosturaOperario.DataSource = lstcostura;
            cmbCosturaOperario.DisplayMember = "descripcion";
            cmbCosturaOperario.ValueMember = "id_operario";
            cmbCosturaOperario.SelectedIndex = 0;



            string[] costuradeslizamiento = { "Si", "No" };
            cmbDeslizamiento.DataSource = costuradeslizamiento;
            cmbDeslizamiento.SelectedIndex = 0;
            string[] costurarasgado = { "Si", "No" };
            cborasgadotela.DataSource = costurarasgado;
            cborasgadotela.SelectedIndex = 0;
            string[] costuraaguja = { "Grande", "Mediana", "Chica" };
            cmbCosturaAguja.DataSource = costuraaguja;
            cmbCosturaAguja.SelectedIndex = 0;


            List<ETelas> lsttelascontaminacion = new List<ETelas>();
            lsttelascontaminacion = DTelas.GetConsultaDisenoTelas();
            cmbContaminacionEntretela.DataSource = lsttelascontaminacion;
            cmbContaminacionEntretela.DisplayMember = "descripcion";
            cmbContaminacionEntretela.ValueMember = "id_tela";


            List<EOperariocombo> lstoperariocontaminacion = new List<EOperariocombo>();
            lstoperariocontaminacion = DCalidad.GetLlenarComboOperario();
            cmbContaminacionOperario.DataSource = lstoperariocontaminacion;
            cmbContaminacionOperario.SelectedIndex = 0;
            cmbContaminacionOperario.DisplayMember = "descripcion";
            cmbContaminacionOperario.ValueMember = "id_operario";



            string[] calidadcontamiancion = { "Buena", "Regular", "Mala" };
            cmbContaminacionCalidad.DataSource = calidadcontamiancion;
            cmbContaminacionCalidad.SelectedIndex = 0;

            //seleccionar index de tela
            int telatab1 = 0;
            int telatab2 = 0;
            int telatab3 = 0;
            int telatab4 = 0;
            foreach (ETelas itm in lsttelasencogimiento)
            {
                telatab1 += 1;
                if (itm.id_tela == TelasGenarl.id_tela)
                {
                    cmbTelaEncogimiento.SelectedIndex = telatab1 - 1;
                }
            }

            foreach (ETelas itm2 in lsttelaslavado)
            {
                telatab2 += 1;
                if (itm2.id_tela == TelasGenarl.id_tela)
                {
                    cmbLavadoEntretela.SelectedIndex = telatab2 - 1;
                }

            }
            foreach(ETelas itm3 in lstcosturatela)
            {
                telatab3 += 1;
                if (itm3.id_tela == TelasGenarl.id_tela)
                {
                    cmbCosturaEntretela.SelectedIndex = telatab3 - 1;
                }
            }

            foreach (ETelas itm4 in lsttelascontaminacion)
            {
                telatab4 += 1;
                if (itm4.id_tela == TelasGenarl.id_tela)
                {
                    cmbContaminacionEntretela.SelectedIndex = telatab4 - 1;
                }
            }
            if (Movimiento == "Modificacion")
            {
                List<ERegistroTelasCalidad> lst = new List<ERegistroTelasCalidad>();
                ERegistroTelasCalidad obj = new ERegistroTelasCalidad();
                lst = DCalidad.GetConsultaConregistroCalidad(TelasGenarl);
                foreach(ERegistroTelasCalidad itm in lst)
                {
                    obj.id_tela = itm.id_tela;
                    obj.id_prueba_encogimiento = itm.id_prueba_encogimiento;    
                    obj.id_prueba_costura = itm.id_prueba_costura;
                    obj.id_prueba_lavado_pilling = itm.id_prueba_lavado_pilling;    
                    obj.id_prueba_contaminacion_telas=itm.id_prueba_contaminacion_telas;
                    obj.encogimiento = itm.encogimiento;
                    obj.lavadoPilling = itm.lavadoPilling; 
                    obj.costura=itm.costura;
                    obj.contaminacion = itm.contaminacion;
                    break;
                }
                txtVaporAdherencia.Text =Convert.ToString(obj.encogimiento.adherencia);

            }
            else
            {
                limpiartextbox();
            }    
            
           
        }

        public void limpiartextbox()
        {
            txtVaporAdherencia.Text = "0.00";
            txtVaporTiempo.Text = "0.00";
            txtVaporTemperatura.Text = "0.00";
            txtVaporPresion.Text = "0.00";
            txtVaporHiloFinal.Text = "0.00";
            txtVaporTramaFinal.Text = "0.00";
            txtVaporHiloDiferencia.Text = "0.00";
            txtVaporTramaDiferencia.Text = "0.00";
            txtVaporObservaciones.Text = "";
            txtFusionHiloFinal.Text = "0.00";
            txtFusionTramaFinal.Text = "0.00";
            txtFusionHiloDiferencia.Text = "0.00";
            txtFusionTramaDiferencia.Text = "0.00";
            txtFusionObservaciones.Text = "";
            txtPlanchaHiloFinal.Text = "0.00";
            txtPlanchaHiloDiferencia.Text = "0.00";
            txtPlanchaTramaFinal.Text = "0.00";
            txtPlanchaTramaDiferencia.Text = "0.00";
            txtPlanchaObservaciones.Text = "";

            txtLavadoHiloFinal.Text = "0.00";
            txtLavadoHiloDiferencia.Text = "0.00";

            txtLavadoHiloFinal.Text = "0.00";
            txtLavadoHiloDiferencia.Text = "0.00";
            txtLavadoTramaFinal.Text = "0.00";
            txtLavadoTramaDiferencia.Text = "0.00";
            txtLavadoObservaciones.Text = "";
            txtSolidezObservaciones.Text = "";
            txtPillingObservaciones.Text = "";

            txtDeslizamientoObservaciones.Text = "";
            txtRasgadoObservaciones.Text = "";
            txtContaminacionObservaciones.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
