using Datos.Diseno;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using Entidades.Diseno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Compras;
using Entidades.Utilitarios.Historico;
using Entidades.Compras;

namespace ALTIMA_ERP_2022.Diseno.CatFamiliaPrendas
{
    public partial class FamiliaPrendas : OfficeForm
    {

        public Action refrescar;
        public string Movimiento;
        EFamiliaPrendas obj = new EFamiliaPrendas();
        public FamiliaPrendas(int id_familia_prenda, string nombre, string codigo, string ubicacion,string tipo)
        {
            InitializeComponent();
            obj.id_familia_prenda = id_familia_prenda;
            obj.nombre = nombre;
            obj.codigo = codigo;
            obj.ubicacion = ubicacion;
            Movimiento = tipo;
            Llenado();

        }
        private void FamiliaPrendas_Load(object sender, EventArgs e)
        {
            Llenado();
        }
            private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try 
            { 
            if (Movimiento == "Alta")
            {
                //condicion para validar que los campos tengan informacion para procesarla
                if (ValidaCampo())
                {
                    EFamiliaPrendas inserta = new EFamiliaPrendas();
                    inserta.nombre = txtNombre.Text;
                    inserta.codigo = TxtCodigo.Text;
                    inserta.ubicacion = CboUbicacion.SelectedValue.ToString();
                    //llamada a metodo para insertar nuevo registro a la tabla familia prenda
                    DFamiliaPrendas.SetInsertarFamiliaPrenda(inserta);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de familia prendas", "Agregar familia prenda", "", inserta.nombre + "/" + inserta.codigo+ "/" + inserta.ubicacion);
                    //se acciona el evento refrescar, el cuál actualizara el super grid de la ventana principal de familia prendas
                    refrescar.Invoke();
                    MessageBoxEx.Show("Prenda registrada correctamente", "Prenda registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
            else if (Movimiento == "Modificacion")
            {
                if (ValidaCampo())
                {
                    EFamiliaPrendas actualiza = new EFamiliaPrendas();
                    actualiza.id_familia_prenda = obj.id_familia_prenda;
                    actualiza.nombre = txtNombre.Text;
                    actualiza.codigo = TxtCodigo.Text;
                    actualiza.ubicacion = CboUbicacion.SelectedValue.ToString();
                    //llamada a metodo para actualizacion de informacion de la tabla familia prendas
                    DFamiliaPrendas.SetActualizaFamiliaPrenda(actualiza);
                    DHistorico.RegistraHistorico("Diseño", "Catálogo de familia prendas", "Modificar familia prenda", obj.nombre + "/" + obj.codigo + "/" + obj.ubicacion, actualiza.nombre + "/" + actualiza.codigo + "/" + actualiza.ubicacion);
                    //se acciona el evento refrescar, el cuál actualizara el super grid de la ventana principal de familia prendas
                    refrescar.Invoke();
                    MessageBoxEx.Show("Prenda actualizada correctamente", "Prenda actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }

            }
            catch(Exception)
            {
                MessageBoxEx.Show("Error, al procesar", "Ocurrio un error inesperado.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidaCampo()
        {
            //validamos que el registro no sea nulo
            if (txtNombre.Text == string.Empty && TxtCodigo.Text == string.Empty)
            {
                 MessageBoxEx.Show("Verifique todos los campos", "Los campos no pueden estar vacíos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //validamos que el combo de ubicacion tenga seleccionado un valor correcto
            else if (CboUbicacion.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione la ubicación", "Ubicación no válida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CboUbicacion.Focus();
                return false; 
            }
            else
            {
                //validamos que los campos nombre y codigo estén en vacío
                if (txtNombre.Text == ""  || TxtCodigo.Text == "")
                {
                    MessageBoxEx.Show("Verifique todos los campos", "Los campos no pueden estar vacíos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }
        public void Llenado()
        {
            string [] lista = {"Superior","Inferior" };
            CboUbicacion.DataSource = lista;
           
         //condicion para limpiar los campos en dado caso de alta, si es para modificacion llenar los campos de nombre y codigo del registro seleccionado previamente
         switch (Movimiento)
            {
                case "Alta":
                    txtNombre.Text = "";
                    TxtCodigo.Text = "";
                    CboUbicacion.SelectedIndex = 0;
                    txtNombre.Focus();
                    break;
                case "Modificacion":
                    txtNombre.Text = obj.nombre.ToString();
                    TxtCodigo.Text = obj.codigo;
                    if (obj.ubicacion == "Superior")
                    {
                        CboUbicacion.SelectedIndex = 0;
                    }
                    else
                    {
                        CboUbicacion.SelectedIndex = 1;
                    }
                    txtNombre.Focus();
                    break;
                default:
                    break;
            }
        }

        
    }
}
