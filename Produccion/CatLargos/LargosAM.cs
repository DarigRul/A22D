using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Produccion;
using DevComponents.DotNetBar;
using Entidades.Produccion;
using Datos.Utilitarios.Historico;

namespace ALTIMA_ERP_2022.Produccion.CatLargos
{
    public partial class LargosAM : OfficeForm
    {
        public enum Movimiento : byte { agregar = 1, modificar = 2};
        public Movimiento movimiento;
        public ELargos lm;
        public Action refrescar; 

        public LargosAM()
        {
            InitializeComponent();
        }

        private void LargosAM_Load(object sender, EventArgs e)
        {
            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtNomenclatura.Focus();
                    break;
                case Movimiento.modificar:
                    txtNomenclatura.Text = lm.nomenclatura;
                    txtDescripcion.Text = lm.descripcion;
                    txtNomenclatura.Focus();
                    txtNomenclatura.SelectAll();
                    break;
                default:
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaDatos())
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:
                            var eLargo = new ELargos(); 
                            eLargo.nomenclatura = txtNomenclatura.Text;
                            eLargo.descripcion = txtDescripcion.Text;

                            string valorNuevo = $"Nomenclatura: {txtNomenclatura.Text}\r\n Descripción: {txtDescripcion.Text}";

                            if (DLargos.Agregar(eLargo)>0)
                            {
                                DHistorico.RegistraHistorico("Producción", "Catálogo de largos", valorNuevo);
                                refrescar.Invoke();
                                MessageBoxEx.Show("Largo registrado correctamente", "Nuevo largo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }

                            break;
                        case Movimiento.modificar:
                            string lmValorAnterior = $"Nomenclatura: {lm.nomenclatura} / Descripción: {lm.descripcion}";
                            lm.nomenclatura = txtNomenclatura.Text;
                            lm.descripcion = txtDescripcion.Text;
                            string lmValorNuevo = $"Nomenclatura: {lm.nomenclatura} / Descripción: {lm.descripcion}";

                            if (DLargos.Actualizar(lm)>0)
                            {
                                DHistorico.RegistraHistorico("Producción", "Catálogo de largos", lmValorAnterior, lmValorNuevo, "");
                                refrescar.Invoke();
                                MessageBoxEx.Show("Largo actualizado correctamente", "Actualizar largo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidaDatos()
        {
            if (txtNomenclatura.Text.Trim() == String.Empty)
            {
                MessageBoxEx.Show("Capture la nomenclatura", "Nomenclatura no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomenclatura.Focus();
                return false;
            }
            else if (txtDescripcion.Text.Trim() == String.Empty)
            {
                MessageBoxEx.Show("Descripción no válida", "Descripción no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Focus();
                return false;
            }
            else 
            {
                return true; 
            }
        }
    }
}
