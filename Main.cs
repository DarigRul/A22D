using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ALTIMA_ERP_2022.Utilitarios;
using Datos.Utilitarios;
using DevComponents.DotNetBar;
using System.Threading;
using Datos.Notificaciones;
using DevComponents.DotNetBar.Controls;
using Renci.SshNet;
using Datos.Usuarios; 

namespace ALTIMA_ERP_2022
{
    public partial class Main : Form
    {

        private void poermisosUsuario()
        {
            //Se ocultan todos los botones del menú
            rtDiseno.Visible = false;
            rtComercial.Visible = false;
            rtProduccion.Visible = false;
            rtConfiguracion.Visible = false;
            rbPrendas.Visible = false;
            rbCatalogos.Visible = false;
            rbMaterial.Visible = false;
            btnPrendas.Visible = false;
            btnProduccionMuestras.Visible = false;
            btnCalidad.Visible = false;
            btnUnidadesMedida.Visible = false;
            btnPiezasTrazo.Visible = false;
            btnCalidad.Visible = false;
            btnInstruccionesCuidado.Visible = false;
            btnFamiliaPrendas.Visible = false;
            btnFamiliaGenero.Visible = false;
            btnFamiliaComposicion.Visible = false;
            btnComposiciones.Visible = false;
            btnMarcadores.Visible = false;
            btnTipoMaterial.Visible = false;
            btnTelas.Visible = false;
            btnForros.Visible = false;
            btnMateriales.Visible = false;
            rbComercial.Visible = false;
            btnPrecioFamiliaComposicion.Visible = false;
            rbProduccion.Visible = false;
            btnProcesos.Visible = false;
            btnRutasProduccion.Visible = false;
            btnCatalogoTallas.Visible = false;
            btnCatalogoLargos.Visible = false;
            rbUsuarios.Visible = false;
            btnUsuarios.Visible = false;
            btnRoles.Visible = false;
            btnPermisos.Visible = false;

            //Se inicializan los botones de accion en false
            ConfiguracionGlobal.pBtnAgregar = false;
            ConfiguracionGlobal.pBtnEditar = false;
            ConfiguracionGlobal.pBtnActivar = false;
            ConfiguracionGlobal.pBtnDesactivar = false;
            ConfiguracionGlobal.pBtnReporte = false;

            int id_perfil = ConfiguracionGlobal.usuario.id_perfil;
            var lstPermisosAcceso = DPermiso.getPermisos_por_perfil(id_perfil, 0, 0);
            var lstPermisosBotonesAcceso = DPermiso.getPermisos_por_perfil(id_perfil, 0, 1);

            foreach (var acceso in lstPermisosAcceso)
            {
                if (acceso.controller == "rtDiseno")
                {
                    rtDiseno.Visible = true;
                }
                if (acceso.controller == "rtComercial")
                {
                    rtComercial.Visible = true;
                }
                if (acceso.controller == "rtProduccion")
                {
                    rtProduccion.Visible = true;
                }
                if (acceso.controller == "rtConfiguracion")
                {
                    rtConfiguracion.Visible = true;
                }
                if (acceso.controller == "rbPrendas")
                {
                    rbPrendas.Visible = true;
                }
                if (acceso.controller == "rbCatalogos")
                {
                    rbCatalogos.Visible = true;
                }
                if (acceso.controller == "rbMaterial")
                {
                    rbMaterial.Visible = true;
                }
                if (acceso.controller == "btnPrendas")
                {
                    btnPrendas.Visible = true;
                }
                if (acceso.controller == "btnProduccionMuestras")
                {
                    btnProduccionMuestras.Visible = true;
                }
                if (acceso.controller == "btnCalidad")
                {
                    btnCalidad.Visible = true;
                }
                if (acceso.controller == "btnUnidadesMedida")
                {
                    btnUnidadesMedida.Visible = true;
                }
                if (acceso.controller == "btnPiezasTrazo")
                {
                    btnPiezasTrazo.Visible = true;
                }
                if (acceso.controller == "btnCalidad")
                {
                    btnCalidad.Visible = true;
                }
                if (acceso.controller == "btnInstruccionesCuidado")
                {
                    btnInstruccionesCuidado.Visible = true;
                }
                if (acceso.controller == "btnFamiliaPrendas")
                {
                    btnFamiliaPrendas.Visible = true;
                }
                if (acceso.controller == "btnFamiliaGenero")
                {
                    btnFamiliaGenero.Visible = true;
                }
                if (acceso.controller == "btnFamiliaComposicion")
                {
                    btnFamiliaComposicion.Visible = true;
                }
                if (acceso.controller == "btnComposiciones")
                {
                    btnComposiciones.Visible = true;
                }
                if (acceso.controller == "btnMarcadores")
                {
                    btnMarcadores.Visible = true;
                }
                if (acceso.controller == "btnTipoMaterial")
                {
                    btnTipoMaterial.Visible = true;
                }
                if (acceso.controller == "btnTelas")
                {
                    btnTelas.Visible = true;
                }
                if (acceso.controller == "btnForros")
                {
                    btnForros.Visible = true;
                }
                if (acceso.controller == "btnMateriales")
                {
                    btnMateriales.Visible = true;
                }
                if (acceso.controller == "rbComercial")
                {
                    rbComercial.Visible = true;
                }
                if (acceso.controller == "btnPrecioFamiliaComposicion")
                {
                    btnPrecioFamiliaComposicion.Visible = true;
                }
                if (acceso.controller == "rbProduccion")
                {
                    rbProduccion.Visible = true;
                }
                if (acceso.controller == "btnProcesos")
                {
                    btnProcesos.Visible = true;
                }
                if (acceso.controller == "btnRutasProduccion")
                {
                    btnRutasProduccion.Visible = true;
                }
                if (acceso.controller == "btnCatalogoTallas")
                {
                    btnCatalogoTallas.Visible = true;
                }
                if (acceso.controller == "btnCatalogoLargos")
                {
                    btnCatalogoLargos.Visible = true;
                }
                if (acceso.controller == "rbUsuarios")
                {
                    rbUsuarios.Visible = true;
                }
                if (acceso.controller == "btnUsuarios")
                {
                    btnUsuarios.Visible = true;
                }
                if (acceso.controller == "btnRoles")
                {
                    btnRoles.Visible = true;
                }
                if (acceso.controller == "btnPermisos")
                {
                    btnPermisos.Visible = true;
                }
            }

            foreach (var item in lstPermisosBotonesAcceso)
            {
                if (item.controller == "btnAgregar")
                {
                    ConfiguracionGlobal.pBtnAgregar = true;
                }
                if (item.controller == "btnEditar")
                {
                    ConfiguracionGlobal.pBtnEditar = true;
                }
                if (item.controller == "btnActivar")
                {
                    ConfiguracionGlobal.pBtnActivar = true;
                }
                if (item.controller == "btnDesactivar")
                {
                    ConfiguracionGlobal.pBtnDesactivar = true;
                }
                if (item.controller == "btnReporte")
                {
                    ConfiguracionGlobal.pBtnReporte = true;
                }
            }
        }


        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Por defecto siempre se cargará el ribon tab de diseño
            rtDiseno.Select();
            tNotificaciones.Interval = 300000;
            tNotificaciones.Start();
            ProcesosInicio();
        }

        private void tNotificaciones_Tick(object sender, EventArgs e)
        {
            ProcesosInicio();
        }

        private async void ProcesosInicio()
        {
            int resultado = await DProcesosInicio.VerificaNotificaciones(ConfiguracionGlobal.usuario);

            if (resultado > 0)
            {
                string texto = $"Notificaciones ({resultado})";
                btnNotificaciones.ForeColor = Color.Yellow;
                btnNotificaciones.FontBold = true; 
                btnNotificaciones.Text = texto;
                btnNotificaciones.Refresh();
                MuestraMensaje(resultado);
            }
            else
            {
                btnNotificaciones.Text = "Notificaciones";
                btnNotificaciones.Refresh();
            }
            
        }

        private void MuestraMensaje(int cantidadNotificaciones)
        {
            long _RunningAlertId = 0; 
            eDesktopAlertColor color = eDesktopAlertColor.DarkBlue;
            eAlertPosition position = eAlertPosition.BottomRight;
            string mensaje = string.Empty;
            if (cantidadNotificaciones > 1)
            {
                mensaje = $"Tiene {cantidadNotificaciones} nuevas notificaciones sin leer"; 
            }
            else
            {
                mensaje = $"Tiene una nueva notificación sin leer";
            }
            DesktopAlert.Show(mensaje, "\uf003",eSymbolSet.Awesome, Color.Empty, color, position, 5, _RunningAlertId, (x)=>{btnNotificaciones_Click(this, EventArgs.Empty);});
        }



        private void lblSitio_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.uniformes-altima.com.mx");
        }

        private void btnColores_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatColores.CatalogoColores);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatColores.CatalogoColores();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Utilitarios.Historico.Historico);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Utilitarios.Historico.Historico();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnFamiliaGenero_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatFamiliaGenero.CatalogoFamiliaGenero);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatFamiliaGenero.CatalogoFamiliaGenero();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnUnidadesMedida_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatUnidadesMedida.CatalogoUnidadesMedida);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatUnidadesMedida.CatalogoUnidadesMedida();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnPiezasTrazo_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatPiezasTrazo.CatPiezasTrazo);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatPiezasTrazo.CatPiezasTrazo();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnInstruccionesCuidado_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatInstruccionesCuidado.CatInstruccionesCuidado);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatInstruccionesCuidado.CatInstruccionesCuidado();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnComposiciones_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatComposiciones.CatComposiciones);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatComposiciones.CatComposiciones();
                frm.MdiParent = this;
                frm.Show();
            }
        }


        private void btnFamiliaComposicion_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatFamiliaComposicion.CatalogoFamiliaComposicion);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatFamiliaComposicion.CatalogoFamiliaComposicion();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnFamiliaPrendas_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatFamiliaPrendas.CatalogoFamiliaPrendas);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatFamiliaPrendas.CatalogoFamiliaPrendas();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnMarcadores_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatMarcadores.CatalogoMarcadores);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatMarcadores.CatalogoMarcadores();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnPrecioFamiliaComposicion_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Comercial.Precios.CatalogoPreciosFamiliaComposicion);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Comercial.Precios.CatalogoPreciosFamiliaComposicion();
                frm.MdiParent = this;
                frm.Show();
            }
        }

       

        private void btnTelas_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatTelas.CatalogTelas);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatTelas.CatalogTelas();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnForros_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatForros.CatForros);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatForros.CatForros();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnMateriales_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatMaterial.CatalogoMaterial);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatMaterial.CatalogoMaterial();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnProduccionMuestras_Click(object sender, EventArgs e)
        {

        }

       

       

        private void btnTipoMaterial_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatTipoMaterial.CatTipoMaterial);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatTipoMaterial.CatTipoMaterial();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            var frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Notificaciones.Notificaciones);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                var formulario = new Notificaciones.Notificaciones();
                formulario.MdiParent = this; 
                formulario.refreshing += ProcesosInicio;
                formulario.Show();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnProcesos_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.Produccion.ProcesosProduccion.CatalogoProcesosProduccion);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.Produccion.ProcesosProduccion.CatalogoProcesosProduccion();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnRutasProduccion_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.Produccion.CatRutasProduccion.CatalogoRutasProduccion);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.Produccion.CatRutasProduccion.CatalogoRutasProduccion();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnCatalogoTallas_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Produccion.CatTallas.CatTallas);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Produccion.CatTallas.CatTallas();
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void btnCatalogoLargos_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Produccion.CatLargos.CatalogoLargos);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Produccion.CatLargos.CatalogoLargos();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Usuarios.CatalogoUsuarios);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Usuarios.CatalogoUsuarios();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnSalirSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Usuarios.Roles.CatalogoRoles);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Usuarios.Roles.CatalogoRoles();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Usuarios.Permisos.CatalogoRolesPermisos);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Usuarios.Permisos.CatalogoRolesPermisos();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnCatalogoProveedores_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Compras.CatProveedores.CatalogoProveedores);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Compras.CatProveedores.CatalogoProveedores();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnCatalogoMaquileros_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Produccion.CatMaquileros.CatalogoMaquileros);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Produccion.CatMaquileros.CatalogoMaquileros();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnCatalogoEnsambles_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.Cast<Form>().FirstOrDefault(x => x is Diseno.CatEnsambles.CatalogoEnsables);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new Diseno.CatEnsambles.CatalogoEnsables();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
