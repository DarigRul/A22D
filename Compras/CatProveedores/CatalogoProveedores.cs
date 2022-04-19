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
using Entidades.Compras;
using Datos.Compras;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace ALTIMA_ERP_2022.Compras.CatProveedores
{
    public partial class CatalogoProveedores : OfficeForm
    {
        List<EProveedor> lstProveedores = new List<EProveedor>();
        List<EProveedorContacto> lstContactos = new List<EProveedorContacto> ();
            
        GridPanel panel;
        GridPanel panelContactos;

        public CatalogoProveedores()
        {
            InitializeComponent();
        }
        private void CatalogoProveedores_Load(object sender, EventArgs e)
        {
            panel = sgcProveedores.PrimaryGrid;
            lstProveedores = DProveedor.ListarProveedores();
            panel.DataSource = lstProveedores;
            panelContactos = sgcContactos.PrimaryGrid;
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var np = new ProveedoresAM();
            np.movimiento = ProveedoresAM.Movimiento.agregar;
            np.refrescar += () => CatalogoProveedores_Load(this, EventArgs.Empty);
            np.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                var p = row.DataItem as EProveedor;
                var frm = new ProveedoresAM();
                frm.movimiento = ProveedoresAM.Movimiento.modificar;
                frm.pm = p;
                frm.refrescar += () => CatalogoProveedores_Load(this, EventArgs.Empty);
                frm.ShowDialog();
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                var row = panel.ActiveRow as GridRow;
                if (row != null)
                {
                    var proveedor = row.DataItem as EProveedor;
                    DialogResult dr = MessageBoxEx.Show($"¿Está seguro de activar el proveedor {proveedor.nombre_comercial}?", "Activar proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        proveedor.estatus = 1;
                        DProveedor.Estatus(proveedor);
                        CatalogoProveedores_Load(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                var row = panel.ActiveRow as GridRow;
                if (row != null)
                {
                    var proveedor = row.DataItem as EProveedor;
                    DialogResult dr = MessageBoxEx.Show($"¿Está seguro de desactivar el proveedor {proveedor.nombre_comercial}?", "Desctivar proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        proveedor.estatus = 0;
                        DProveedor.Estatus(proveedor);
                        CatalogoProveedores_Load(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void sgc_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panel.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus"].Value);
                if (estatus == 0) //Desactivado
                {
                    row["estatus_texto"].Value = "DESACTIVADO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                }
                else
                {
                    row["estatus_texto"].Value = "ACTIVO";
                }
            }
        }

        private void sgcProveedores_SelectionChanged(object sender, GridEventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                int estatus = Convert.ToInt32(row.Cells["estatus"].Value);
                var proveedor = row.DataItem as EProveedor;
                if (estatus == 0) //Desactivado
                {
                    btnDesactivar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnActivar.Enabled = true;
                    panelMenuContactos.Enabled = false;
                    ImportarContactos(proveedor);
                    sgcContactos.Enabled = false;
                }
                else
                {
                    btnDesactivar.Enabled = true;
                    btnEditar.Enabled = true;
                    btnActivar.Enabled = false;
                    panelMenuContactos.Enabled = true;
                    
                    ImportarContactos(proveedor);
                    sgcContactos.Enabled = true;

                    //Si el proveedor no tiene contactos, únicamente estará habilitado el botón de agregar contacto 
                    if (lstContactos.Count == 0)
                    {
                        btnContactosEditar.Enabled = false;
                        btnContactosActivar.Enabled = false;
                        btnContactosDesactivar.Enabled = false;
                        
                    }
                }
            }
        }

        private void ImportarContactos(EProveedor proveedor)
        {
            lstContactos.Clear();
            lstContactos = DProveedorContacto.Listar(proveedor);
            panelContactos.DataSource = lstContactos;

        }

        private void sgcContactos_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            foreach (GridRow row in panelContactos.Rows)
            {
                int estatus = Convert.ToInt32(row["estatus_contacto"].Value);
                if (estatus == 0) //Desactivado
                {
                    row["estatus_contacto_texto"].Value = "DESACTIVADO";
                    row.CellStyles.Default.Background.Color1 = Color.DarkRed;
                    row.CellStyles.Default.TextColor = Color.White;
                }
                else
                {
                    row["estatus_contacto_texto"].Value = "ACTIVO";
                }
            }
        }

        private void btnConctactosAgregar_Click(object sender, EventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                var proveedor = row.DataItem as EProveedor;
                
                var nuevo = new ProveedorContactosAM();
                nuevo.movimiento = ProveedorContactosAM.Movimiento.agregar;
                nuevo.proveedor = proveedor;
                nuevo.refrescar += () => ImportarContactos(proveedor);
                nuevo.ShowDialog();

                
            }
        }

        private void btnContactosEditar_Click(object sender, EventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            if (row != null)
            {
                var rowContact = panelContactos.ActiveRow as GridRow; 
                if (rowContact != null)
                {
                    var proveedor = row.DataItem as EProveedor;
                    var contacto = rowContact.DataItem as EProveedorContacto; 

                    var cm = new ProveedorContactosAM();
                    cm.movimiento = ProveedorContactosAM.Movimiento.modificar;
                    cm.proveedor = proveedor;
                    cm.contacto = contacto;
                    cm.refrescar += () => ImportarContactos(proveedor); 
                    cm.ShowDialog();
                }
            }
        }

        private void sgcContactos_SelectionChanged(object sender, GridEventArgs e)
        {
            var row = panelContactos.ActiveRow as GridRow;
            if (row != null)
            {
                int estatus = Convert.ToInt32(row.Cells["estatus_contacto"].Value); 
                if (estatus == 0) //Desactivado
                {
                    btnContactosDesactivar.Enabled = false;
                    btnContactosEditar.Enabled = false;
                    btnContactosActivar.Enabled = true;
                }
                else
                {
                    btnContactosActivar.Enabled=false;
                    btnContactosEditar.Enabled=true;
                    btnContactosDesactivar.Enabled=true;
                }
            }
        }

        private void btnContactosActivar_Click(object sender, EventArgs e)
        {
            var row = panelContactos.ActiveRow as GridRow;
            if (row != null)
            {
                var contacto = row.DataItem as EProveedorContacto;
                DialogResult dr = MessageBoxEx.Show($"Se activará el contacto: {contacto.nombre_contacto}\r\n¿Está seguro?", "Activar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    contacto.estatus_contacto = 1; 
                    DProveedorContacto.Estatus(contacto);
                    var fila = panel.ActiveRow as GridRow;
                    var proveedor = fila.DataItem as EProveedor;
                    ImportarContactos(proveedor);
                }
            }
        }

        private void btnContactosDesactivar_Click(object sender, EventArgs e)
        {
            var row = panelContactos.ActiveRow as GridRow;
            if (row != null)
            {
                var contacto = row.DataItem as EProveedorContacto;
                DialogResult dr = MessageBoxEx.Show($"Se desactivará el contacto: {contacto.nombre_contacto}\r\n¿Está seguro?", "Desactivar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    contacto.estatus_contacto = 0;
                    DProveedorContacto.Estatus(contacto);
                    var fila = panel.ActiveRow as GridRow;
                    var proveedor = fila.DataItem as EProveedor;
                    ImportarContactos(proveedor);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            
                try
                {
                    DataTable dt = Utilitarios.supergridToDataTable.ObtenerTabla(sgcProveedores);
                    string ruta = Utilitarios.ConfiguracionGlobal.RutaReporte("catalogo_proveedores");
                    DataTable dtContactos = DProveedorContacto.ReporteContactos(); 

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables.Add(dtContactos);


                    ReportDocument rp = new ReportDocument();
                    rp.Load(ruta);
                    //rp.SetDataSource(dt);
                    rp.SetDataSource(ds);
                
                    //rp.Subreports["contactos"].SetDataSource(lstContactos);

                    Reportes reporte = new Reportes();
                    reporte.crv.ReportSource = rp;
                    reporte.ShowDialog();

                    //Eliminamos el archivo de la compu del usuario
                    File.Delete(ruta);
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show($"{ex.Message}\r\n{ex.StackTrace}\r\n{ex.InnerException}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

      
        private void CatalogoProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(this, EventArgs.Empty);
            }
        }

        private void sgcProveedores_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            int estatus = Convert.ToInt32(row.Cells["estatus"].Value); 
            if (estatus == 1)
            {
                btnEditar_Click(this, EventArgs.Empty);
            }
            
        }

        private void sgcContactos_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            var row = panel.ActiveRow as GridRow;
            int estatus = Convert.ToInt32(row.Cells["estatus"].Value);
            if (estatus == 1)
            {
                btnContactosEditar_Click(this, EventArgs.Empty); 
            }
        }
    }
}
