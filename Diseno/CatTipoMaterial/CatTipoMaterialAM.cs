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

namespace ALTIMA_ERP_2022.Diseno.CatTipoMaterial
{
    public partial class CatTipoMaterialAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2 };
        public Movimiento movimiento;
        public Action refrescar;
        public EMaterialTipo materialTipoModificar;

        public CatTipoMaterialAM()
        {
            InitializeComponent();
        }

        private void TipoMaterialAM_Load(object sender, EventArgs e)
        {
            //Se crea la lista de tipos
            List<Tipo> listTipos = new List<Tipo>();
            Tipo tipo1 = new Tipo();
            tipo1.id_tipo = 1;
            tipo1.tipo = "Material general";
            listTipos.Add(tipo1);
            Tipo tipo2 = new Tipo();
            tipo2.id_tipo = 2;
            tipo2.tipo = "Material principal";
            listTipos.Add(tipo2);

            cmbTipo.DataSource = listTipos;
            cmbTipo.DisplayMember = "tipo";
            cmbTipo.ValueMember = "id_tipo";

            //Se crea la lista de Clasificacion
            List<Clasificacion> listClasificacion = new List<Clasificacion>();
            Clasificacion clasificacion1 = new Clasificacion();
            clasificacion1.id_clasificacion = 1;
            clasificacion1.clasificacion = "Habilitación";
            listClasificacion.Add(clasificacion1);
            Clasificacion clasificacion2 = new Clasificacion();
            clasificacion2.id_clasificacion = 2;
            clasificacion2.clasificacion = "Materia prima";
            listClasificacion.Add(clasificacion2);

            cmbClasificacion.DataSource = listClasificacion;
            cmbClasificacion.DisplayMember = "clasificacion";
            cmbClasificacion.ValueMember = "id_clasificacion";


            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtNombre.Text = "";
                    txtNomenclatura.Text = "";
                    cmbTipo.SelectedIndex = -1;
                    cmbClasificacion.SelectedIndex = -1;
                    txtNombre.Focus();
                    break;
                case Movimiento.modificar:

                    txtNombre.Text = materialTipoModificar.descripcion;
                    txtNomenclatura.Text = materialTipoModificar.nomenclatura;
                    switch (materialTipoModificar.tipo_material)
                    {
                        case "Material general":
                            cmbTipo.SelectedValue = 1;
                            break;
                        case "Material principal":
                            cmbTipo.SelectedValue = 2;
                            break;
                        default:
                            break;
                    }

                    switch (materialTipoModificar.clasificacion)
                    {
                        case "Habilitación":
                            cmbClasificacion.SelectedValue = 1;
                            break;
                        case "Materia prima":
                            cmbClasificacion.SelectedValue = 2;
                            break;
                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    DMaterialTipo dMaterialTipo = new DMaterialTipo();
                    int id_material_tipo = 0;
                    string valor_nuevo = "";
                    string valor_anterior = "";
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            EMaterialTipo mt = new EMaterialTipo();
                            mt.descripcion = txtNombre.Text.Trim();
                            mt.nomenclatura = txtNomenclatura.Text.Trim();
                            mt.tipo_material = cmbTipo.Text;
                            mt.clasificacion = cmbClasificacion.Text;

                            valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                            valor_nuevo += "Nomenclatura: " + txtNomenclatura.Text + " / ";
                            valor_nuevo += "Tipo: " + txtNomenclatura.Text + " / ";
                            valor_nuevo += "Clasificación: " + cmbClasificacion.Text + " / ";

                            //Registramos el MaterialTipo
                            id_material_tipo = dMaterialTipo.AgregarMaterialTipo(mt);
                            if (id_material_tipo > 0)
                            {
                                DHistorico.RegistraHistorico("Diseño", "Catálogo Material Tipo", "Agregar Material Tipo", "", valor_nuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Material tipo registrado correctamente", "Nuevo Material Tipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case Movimiento.modificar:
                            EMaterialTipo materialTipoActualizar = new EMaterialTipo();

                            valor_anterior += "Nombre: " + materialTipoActualizar.descripcion + " / ";
                            valor_anterior += "Nomenclatura: " + materialTipoActualizar.nomenclatura + " / ";
                            valor_anterior += "Tipo: " + materialTipoActualizar.tipo_material + " / ";
                            valor_anterior += "Clasificación: " + materialTipoActualizar.clasificacion + " / ";

                            materialTipoActualizar.descripcion = txtNombre.Text.Trim();
                            materialTipoActualizar.nomenclatura = txtNomenclatura.Text.Trim();
                            materialTipoActualizar.tipo_material = cmbTipo.Text;
                            materialTipoActualizar.clasificacion = cmbClasificacion.Text;
                            materialTipoActualizar.id_material_tipo = materialTipoModificar.id_material_tipo;
                            materialTipoActualizar.estatus = materialTipoModificar.estatus;

                            valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                            valor_nuevo += "Nomenclatura: " + txtNomenclatura.Text + " / ";
                            valor_nuevo += "Tipo: " + txtNomenclatura.Text + " / ";
                            valor_nuevo += "Clasificación: " + cmbClasificacion.Text + " / ";

                            

                            //Registramos el MaterialTipo

                            id_material_tipo = dMaterialTipo.ModificaMaterialTipo(materialTipoActualizar);
                            if (id_material_tipo > 0)
                            {
                                DHistorico.RegistraHistorico("Diseño", "Catálogo Material Tipo", "Modificar Material Tipo", valor_anterior, valor_nuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Material tipo registrado correctamente", "Nuevo Material Tipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de forros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidaCampos()
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture el nombre del material", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (txtNomenclatura.Text == string.Empty)
            {
                MessageBoxEx.Show("Capture la nomenclatura", "Nomenclatura no valida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomenclatura.Focus();
                return false;
            }
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione el tipo de material", "Sin Tipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTipo.Focus();
                return false;
            }
            if (cmbClasificacion.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Seleccione una clasificación", "Sin Clasificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClasificacion.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private class Tipo
        {
            public int id_tipo { get; set; }
            public string tipo { get; set; }
        }

        private class Clasificacion
        {
            public int id_clasificacion { get; set; }
            public string clasificacion { get; set; }
        }
    }
}
