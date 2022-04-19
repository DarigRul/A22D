using Datos.Diseno;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using Entidades.Diseno;
using Entidades.Diseno.Marcadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALTIMA_ERP_2022.Diseno.CatTelas
{
    public partial class Telas : OfficeForm
    {

        public Action refrescar;
        public string Movimiento;
        public ETelas VarGeneral;
       //EMateriales obj = new EMateriales();

        public Telas(ETelas obj, string mov)
        {
            InitializeComponent();
            VarGeneral = obj;
            Movimiento = mov;
            Llenado();
        }
        private void Material_Load(object sender, EventArgs e)
        {
            Llenado();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        //private void btnAceptar_Click(object sender, EventArgs e)
        //{
        //    if (Movimiento == "Alta")
        //    {

        //        if (ValidaCampo())
        //        {
        //            EMarcadores inserta = new EMarcadores();
        //            inserta.nombre = txtNombre.Text;
        //            DMarcadores.SetInsertarMarcadores(inserta);
        //            DHistorico.RegistraHistorico("Diseño", "Catálogo de marcadores", "Agregar marcador", "", inserta.nombre);
        //            refrescar.Invoke();
        //            MessageBoxEx.Show("Marcador registrado correctamente", "Marcador registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            Close();
        //            Dispose();
        //        }
        //    }
        //    else if (Movimiento == "Modificacion")
        //    {
        //        if (ValidaCampo())
        //        {
        //            EMarcadores actualiza = new EMarcadores();
        //            actualiza.id_marcador = obj.id_marcador;
        //            actualiza.nombre = txtNombre.Text;
        //            DMarcadores.SetActualizaMarcadores(actualiza);
        //            DHistorico.RegistraHistorico("Diseño", "Catálogo de marcadores", "Modificar marcador", obj.nombre, actualiza.nombre);
        //            refrescar.Invoke();
        //            MessageBoxEx.Show("Marcador actualizado correctamente", "Marcador actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            Close();
        //            Dispose();
        //        }
        //    }


        //}
        private bool ValidaCampo()
        {
            if (TxtNombre.Text == string.Empty ||  TxtUso.Text == string.Empty || TxtTamano.Text == string.Empty || TxtObservaciones.Text == string.Empty ||  TxtPruebaCalidad.Text == string.Empty || TxtPrecio.Text == string.Empty)
            {
                return false;
            }
            else
            {
                if (TxtNombre.Text == "" && TxtUso.Text == "" && TxtTamano.Text == "" && TxtObservaciones.Text == "" && TxtPruebaCalidad.Text == "" && TxtPrecio.Text == "")
                {
                    return false;
                }
                try
                {

                    if (CboUnidadMedida.SelectedValue.ToString() == null || CboTipoMaterial.SelectedValue.ToString() == null || CboColor.SelectedValue.ToString() == null || CboProceso.SelectedValue.ToString() == null || CboProveedor.SelectedValue.ToString() == null)
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
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
                    TxtNombre.Text = "";
                    TxtObservaciones.Text = "";
                    TxtPrecio.Text = "";
                    TxtPruebaCalidad.Text = "";
                    TxtTamano.Text = "";
                    TxtUso.Text = "";
                    cargarcbos();
                    CboTipoMaterial.Focus();
                    
                    break;
                case "Modificacion":
                    TxtNombre.Text = "";
                    TxtObservaciones.Text = "";
                    TxtPrecio.Text = "";
                    TxtPruebaCalidad.Text = "";
                    TxtTamano.Text = "";
                    TxtUso.Text = "";
                    //TxtNombre.Text = VarGeneral.nombre;
                    //TxtObservaciones.Text = VarGeneral.observaciones;
                    //TxtPrecio.Text = VarGeneral.precio_unitario.ToString();
                    //TxtPruebaCalidad.Text = VarGeneral.hacer_prueba_calidad.ToString();
                    //TxtTamano.Text = VarGeneral.tamano.ToString();
                    //TxtUso.Text = VarGeneral.uso;
                    cargarcbosmodificacion();

                   break;
                default:
                    break;
            }
        }

        public void cargarcbos()
        {
            List<EMaterialTipoTela> lstMaterialTipo = new List<EMaterialTipoTela>();
            lstMaterialTipo = DTelas.GetLlenarComboMaterialTipo();
            CboTipoMaterial.DataSource = lstMaterialTipo;
            CboTipoMaterial.SelectedIndex = -1;
            CboTipoMaterial.DisplayMember = "auxdescrip";
            CboTipoMaterial.ValueMember = "id_material_tipo";
            List<EComprasProveedores> lstProveedor= new List<EComprasProveedores>();
            lstProveedor = DTelas.GetLlenarComboComprasProveedores();
            CboProveedor.DataSource = lstProveedor;
            CboProveedor.SelectedIndex = -1;
            CboProveedor.DisplayMember = "auxdescrip";
            CboProveedor.ValueMember = "id_proveedor";
            List<EColores> lstColores = new List<EColores>();
            lstColores = DTelas.GetLlenarComboDisenoColores();
            CboColor.DataSource = lstColores;
            CboColor.SelectedIndex = -1;
            CboColor.DisplayMember = "auxdescrip";
            CboColor.ValueMember = "id_color";
            List<EMaterialesProcesosTela> lstmaterialesprocesos = new List<EMaterialesProcesosTela>();
            lstmaterialesprocesos=DTelas.GetLlenarComboMaterialesProcesos();
            CboProceso.DataSource = lstmaterialesprocesos;
            CboProceso.SelectedIndex = -1;
            CboProceso.DisplayMember = "auxdescrip";
            CboProceso.ValueMember = "id_material_proceso";

            List<EUnidadesMedidas> lstUnidadesmedida = new List<EUnidadesMedidas>();
            lstUnidadesmedida = DTelas.GetLlenarComboUnidadMedida();
            CboUnidadMedida.DataSource = lstUnidadesmedida;
            CboUnidadMedida.SelectedIndex = -1;
            CboUnidadMedida.DisplayMember = "auxdescrip";
            CboUnidadMedida.ValueMember = "id_unidad_medida";


        }
        public void cargarcbosmodificacion()
        {
            List<EMaterialTipoTela> lstMaterialTipo = new List<EMaterialTipoTela>();
            lstMaterialTipo = DTelas.GetLlenarComboMaterialTipo();
            CboTipoMaterial.DataSource = lstMaterialTipo;
            CboTipoMaterial.DisplayMember = "auxdescrip";
            CboTipoMaterial.ValueMember = "id_material_tipo";
            int cont1 = 0;
            foreach(EMaterialTipoTela itm in lstMaterialTipo)
            {
                cont1 += 1;
                //if(VarGeneral.id_material_tipo == itm.id_material_tipo)
                //{
                //    CboTipoMaterial.SelectedIndex = cont1 -1;
                //}
            }
            List<EComprasProveedores> lstProveedor = new List<EComprasProveedores>();
            lstProveedor = DTelas.GetLlenarComboComprasProveedores();
            CboProveedor.DataSource = lstProveedor;
            CboProveedor.SelectedIndex = -1;
            CboProveedor.DisplayMember = "auxdescrip";
            CboProveedor.ValueMember = "id_proveedor";
            int cont2 = 0;
            foreach (EComprasProveedores itm in lstProveedor)
            {
                cont2 += 1;
                if (VarGeneral.id_proveedor == itm.id_proveedor)
                {
                    CboProveedor.SelectedIndex = cont2 - 1;
                }
            }


            List<EColores> lstColores = new List<EColores>();
            lstColores = DTelas.GetLlenarComboDisenoColores();
            CboColor.DataSource = lstColores;
            CboColor.DisplayMember = "auxdescrip";
            CboColor.ValueMember = "id_color";
            int cont3 = 0;
            foreach (EColores itm in lstColores)
            {
                cont3 += 1;
                if (VarGeneral.id_color == itm.id_color)
                {
                    CboColor.SelectedIndex = cont3 - 1;
                }
            }

            List<EMaterialesProcesosTela> lstmaterialesprocesos = new List<EMaterialesProcesosTela>();
            lstmaterialesprocesos = DTelas.GetLlenarComboMaterialesProcesos();
            CboProceso.DataSource = lstmaterialesprocesos;
            CboProceso.DisplayMember = "auxdescrip";
            CboProceso.ValueMember = "id_material_proceso";
            int cont4= 0;
            foreach (EMaterialesProcesosTela itm in lstmaterialesprocesos)
            {
                cont4+= 1;
                //if (VarGeneral.id_material_proceso == itm.id_material_proceso)
                //{
                //    CboProceso.SelectedIndex =  cont4 -1;
                //}
            }


            List<EUnidadesMedidas> lstUnidadesmedida = new List<EUnidadesMedidas>();
            lstUnidadesmedida = DTelas.GetLlenarComboUnidadMedida();
            CboUnidadMedida.DataSource = lstUnidadesmedida;
            CboUnidadMedida.DisplayMember = "auxdescrip";
            CboUnidadMedida.ValueMember = "id_unidad_medida";
            int cont5 = 0;
            foreach (EUnidadesMedidas itm in lstUnidadesmedida)
            {
                cont5 += 1;
                //if (VarGeneral.id_unidad_medida == itm.id_unidad_medida)
                //{
                //    CboUnidadMedida.SelectedIndex = cont5 - 1;
                //}
            }
        }

        private void Cancelar_Click_1(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
         {
            Boolean resultadovalidacion;
            resultadovalidacion = ValidaCampo();
          if (resultadovalidacion == true)
          {
               if (Movimiento == "Alta")
               {
                    //ETelas inserta = new ETelas();
                    //inserta.id_material_tipo = Convert.ToInt32(CboTipoMaterial.SelectedValue);
                    //inserta.id_proveedor = Convert.ToInt32(CboProveedor.SelectedValue);
                    //inserta.id_material_proceso = Convert.ToInt32(CboProceso.SelectedValue);
                    //inserta.id_unidad_medida = Convert.ToInt32(CboUnidadMedida.SelectedValue);
                    //inserta.nombre = TxtNombre.Text;
                    //inserta.id_color = Convert.ToInt32(CboColor.SelectedValue);
                    //inserta.uso = TxtUso.Text;
                    //inserta.clave_proveedor = Convert.ToString(CboProveedor.SelectedValue);
                    //inserta.tamano = Convert.ToDecimal(TxtTamano.Text);
                    //inserta.observaciones = TxtObservaciones.Text;
                    //inserta.imagen = "";
                    //inserta.hacer_prueba_calidad = Convert.ToInt32(TxtPruebaCalidad.Text);
                    //inserta.precio_unitario =  Convert.ToDecimal(TxtPrecio.Text);
                    //DTelas.SetInsertarMateriales(inserta);
                    //DHistorico.RegistraHistorico("Diseño", "Catálogo de materiales", "Agregar material", "", inserta.nombre + "/" + inserta.nombre + "/");
                    //refrescar.Invoke();
                    //MessageBoxEx.Show("Marcador registrado correctamente", "Marcador registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Close();
                    //Dispose();
                }
          }
          else
          {
                MessageBoxEx.Show("Verifique todos los campos", "Los campos no pueden estar vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

        }

    }
}


