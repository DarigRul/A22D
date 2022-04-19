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

namespace ALTIMA_ERP_2022.Diseno.CatForros
{
    public partial class ForrosPruebasCalidad : OfficeForm
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

       

        public ForrosPruebasCalidad()
        {
            InitializeComponent();
        }

        private void ForrosPruebasCalidad_Load(object sender, EventArgs e)
        {
            try
            {
                lblNombre.Text = forro.nombre;
                lblDescripcion.Text = forro.descripcion;
                lblProveedor.Text = forro.proveedor;
                lblClaveProveedor.Text = forro.clave_proveedor;
                lblClaveProspecto.Text = forro.clave_prospecto;

                //Importar las entretelas 
                dtEntretelaEncogimiento = DForros.ImportaEntretelas();
                dtEntretelaLavado = DForros.ImportaEntretelas();
                dtEntretelaContaminacion= DForros.ImportaEntretelas();
                dtEntretelaCostura = DForros.ImportaEntretelas();

                cmbTelaEncogimiento.DataSource = dtEntretelaEncogimiento;
                cmbTelaEncogimiento.DisplayMember = "nombre";
                cmbTelaEncogimiento.ValueMember = "id_material";
                cmbTelaEncogimiento.SelectedIndex = -1;

                cmbLavadoEntretela.DataSource = dtEntretelaLavado;
                cmbLavadoEntretela.DisplayMember = "nombre";
                cmbLavadoEntretela.ValueMember = "id_material"; 
                cmbLavadoEntretela.SelectedIndex = -1;

                cmbCosturaEntretela.DataSource = dtEntretelaCostura;
                cmbCosturaEntretela.DisplayMember = "nombre";
                cmbCosturaEntretela.ValueMember = "id_material"; 
                cmbCosturaEntretela.SelectedIndex = -1;

                cmbContaminacionEntretela.DataSource= dtEntretelaContaminacion;
                cmbContaminacionEntretela.DisplayMember = "nombre";
                cmbContaminacionEntretela.ValueMember = "id_material"; 
                cmbContaminacionEntretela.SelectedIndex= -1;

                //Importar operarios y asignamos a los combos
                dtOperariosEncogimiento = DForros.ImportaOperarios();
                dtOperariosLavado = DForros.ImportaOperarios();
                dtOperariosContaminacion = DForros.ImportaOperarios();
                dtOperariosCostura = DForros.ImportaOperarios();
                
                cmbOperarioEncogimiento.DataSource = dtOperariosEncogimiento;
                cmbOperarioEncogimiento.DisplayMember = "Nombre";
                cmbOperarioEncogimiento.ValueMember = "ClaveEmpleado";
                cmbOperarioEncogimiento.SelectedIndex = -1; 

                cmbContaminacionOperario.DataSource = dtOperariosContaminacion;
                cmbContaminacionOperario.DisplayMember = "Nombre";
                cmbContaminacionOperario.ValueMember = "ClaveEmpleado";
                cmbContaminacionOperario.SelectedIndex = -1; 

                cmbLavadoOperario.DataSource = dtOperariosLavado;
                cmbLavadoOperario.DisplayMember = "Nombre";
                cmbLavadoOperario.ValueMember = "ClaveEmpleado";
                cmbLavadoOperario.SelectedIndex = -1;

                cmbCosturaOperario.DataSource = dtOperariosCostura;
                cmbCosturaOperario.DisplayMember = "Nombre";
                cmbCosturaOperario.ValueMember = "ClaveEmpleado";
                cmbCosturaOperario.SelectedIndex = -1; 


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
            int encogimiento = 0;
            int lavado = 0;
            int costura = 0;
            int contaminacion = 0; 

            string mensaje = string.Empty;

            //ENCOGIMIENTO
            if (ValidaEncogimiento())
            {
                //Si existe la prueba de encogimiento, se trata de una actualización
                if (pEnc > 0)
                {
                    encogimiento = DForrosEncogimiento.Actualiza(DatosEncogimiento());

                    mensaje += "Prueba de encogimiento actualizado correctamente\r\n";
                }
                else //La prueba de encogimiento no existe, se trata de una nueva prueba
                {
                    encogimiento = DForrosEncogimiento.Registra(DatosEncogimiento());

                    mensaje += "Prueba de encogimiento registrado correctamente\r\n"; 
                }
            }


            //LAVADO Y PILLING




            // COSTURA




            //CONTAMINACIÓN EN COMBINACIÓN DE TELAS


            // Para información del usuario
            if(encogimiento == 0)
            {
                MessageBoxEx.Show(mensaje, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBoxEx.Show(mensaje, "Pruebas de Calidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose(); 
            }
        }

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



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
