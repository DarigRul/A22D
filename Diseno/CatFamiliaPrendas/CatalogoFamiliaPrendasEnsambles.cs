using Datos.Diseno;
using Datos.Utilitarios.Historico;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
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

namespace ALTIMA_ERP_2022.Diseno.CatFamiliaPrendas
{
    public partial class CatalogoFamiliaPrendasEnsambles : OfficeForm
    {
        private List<EEnsambles> lstEnsambles = new List<EEnsambles>();
        private List<EEnsambles> lstEnsamblesCmb = new List<EEnsambles>();
        private GridPanel panel;
        public Action refrescar;
        public EFamiliaPrendas prendaModificar;

        public CatalogoFamiliaPrendasEnsambles()
        {
            InitializeComponent();
        }

        private void CatalogoFamiliaPrendasEnsambles_Load(object sender, EventArgs e)
        {
            //Se llena el combo de Ensambles
            lstEnsamblesCmb = DEnsambles.getEnsambles();
            cmbEnsambles.DataSource = lstEnsamblesCmb;
            cmbEnsambles.DisplayMember = "descripcion";
            cmbEnsambles.ValueMember = "id_ensamble";
            cmbEnsambles.SelectedIndex = -1;

            //Instanciamos la capa de datos y obtenemos la lista que será fuente de datos para el supergrid
            lstEnsambles = DEnsambles.getFamilia_predna_Ensambles(prendaModificar.id_familia_prenda);

            // Asignamos el gridpanel al PrimaryGrid y asignamos la fuente de datos
            panel = sgcEnsambles.PrimaryGrid;
            panel.DataSource = lstEnsambles;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Preguntamos al usuario si quiere agregar el ensamble 
                DialogResult dr = MessageBoxEx.Show("Se agregará este estandar, ¿Está seguro?", "Agregar Ensamble", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int id_ensamble = Convert.ToInt32(cmbEnsambles.SelectedValue);
                    int id_familia_prenda = prendaModificar.id_familia_prenda;
                    string valor_nuevo = "";

                    foreach (var ensamble in lstEnsamblesCmb)
                    {
                        if (ensamble.id_ensamble == id_ensamble)
                        {
                            valor_nuevo += "Familia prenda: " + prendaModificar.nombre + " / ";
                            valor_nuevo += "Ensamble descripción: " + ensamble.descripcion + " / ";
                            valor_nuevo += "Ensamble consumo: " + ensamble.consumo + " / ";
                            valor_nuevo += "Ensamble tipo: " + ensamble.tipo + " / ";
                        }
                    }

                    string mensaje = DEnsambles.familia_predna_Ensambles_inserta(id_familia_prenda, id_ensamble);
                    if (mensaje == "")
                    {
                        DHistorico.RegistraHistorico("Diseño", "Catálogo de familia prendas", "Agregar Ensambles", "", valor_nuevo);
                        CatalogoFamiliaPrendasEnsambles_Load(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique\n" + mensaje, "Error de registro de ensamble: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique", "Error de registro de ensamble: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBoxEx.Show("Se eliminará este estandar, ¿Está seguro?", "Eliminar Ensamble", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Obtenemos la fila seleccionada
                    GridRow row = panel.ActiveRow as GridRow;

                    //Obtenemos el id_color y lo buscamos en la lista de colores (es la fuente del supegrid)
                    int id_ensamble = Convert.ToInt32(row["id_ensamble"].Value);

                    string valor_anterior = "";

                    foreach (var ensamble in lstEnsamblesCmb)
                    {
                        if (ensamble.id_ensamble == id_ensamble)
                        {
                            valor_anterior += "Familia prenda: " + prendaModificar.nombre + " / ";
                            valor_anterior += "Ensamble descripción: " + ensamble.descripcion + " / ";
                            valor_anterior += "Ensamble consumo: " + ensamble.consumo + " / ";
                            valor_anterior += "Ensamble tipo: " + ensamble.tipo + " / ";
                        }
                    }

                    int id_familia_prenda = prendaModificar.id_familia_prenda;

                    string mensaje = DEnsambles.familia_predna_Ensambles_eliminar(id_familia_prenda, id_ensamble);
                    if (mensaje == "")
                    {
                        DHistorico.RegistraHistorico("Diseño", "Catálogo de familia prendas", "Agregar Ensambles", valor_anterior, "");
                        CatalogoFamiliaPrendasEnsambles_Load(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBoxEx.Show("Hubo un error al eliminar el registro en la base de datos, por favor verifique\n" + mensaje, "Error al eliminar: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Hubo un error de registro en la base de datos, por favor verifique" + ex.Message.ToString(), "Error eliminar: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
