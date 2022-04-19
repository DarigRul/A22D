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
using X = System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ALTIMA_ERP_2022.UAService;
using ALTIMA_ERP_2022.Utilitarios;   
using System.Web;
using Entidades.Diseno.Telas;

namespace ALTIMA_ERP_2022.Diseno.CatTelas
{
    public partial class Telas : OfficeForm
    {

        public Action refrescar;
        public string Movimiento;
        public ETelas VarGeneral;
        public string rutaprecargada="";
        public byte[] archivoprecargado;
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
            //if (TxtNombre.Text == string.Empty ||  TxtUso.Text == string.Empty || TxtTamano.Text == string.Empty || TxtObservaciones.Text == string.Empty ||  TxtPruebaCalidad.Text == string.Empty || TxtPrecio.Text == string.Empty)
            //{
            //    return false;
            //}
            //else
            //{
            try
            {
                if (Txtancho.Text == "" && TxtAnchotela.Text == "" && TxtClaveProveedor.Text == "" && TxtLargo.Text == "" && TxtObservaciones.Text == "" && TxtClaveTela.Text == "" && TxtDescripcion.Text == "")
                {
                    return false;
                }
                
                try
                {
                    if (CboFamiliaComposicion.SelectedValue != null && CboEstampado.SelectedValue != null && CboColor.SelectedValue != null && CboProveedor.SelectedValue != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception)
                {

                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
            //}
        }
        public void Llenado()
        {
            switch (Movimiento)
            {
                case "Alta":
                    TxtAnchotela.Text = "";
                    TxtObservaciones.Text = "";
                    TxtClaveProveedor.Text = "";
                    TxtLargo.Text = "";
                    Txtancho.Text = "";
                    //se ejecutan las consultas para llenar los combos en index 0
                    cargarcbos();
                    CboFamiliaComposicion.Focus();
                    
                    break;
                case "Modificacion":
                    //del objeto seleccionado en la pantalla catalogo de telas, se llenan los combos y se hace un selected index con el valor almacenado
                    TxtAnchotela.Text = VarGeneral.ancho_tela.ToString();
                    TxtObservaciones.Text = VarGeneral.observaciones;
                    TxtClaveProveedor.Text = VarGeneral.clave_proveedor;
                    TxtLargo.Text = VarGeneral.prueba_encogimiento_largo.ToString();
                    Txtancho.Text = VarGeneral.prueba_encogimiento_ancho.ToString();
                    TxtClaveTela.Text = VarGeneral.clave_tela;
                    TxtDescripcion.Text= VarGeneral.descripcion;
                    llenarimagen();
                    cargarcbosmodificacion();
                    //si existe ruta en campo imagen, se visualizará en pantalla
                   
                   break;
                default:
                    break;
            }
        }

        public void cargarcbos()
        {
            List<EFamiliaComposicioncombo> lstcomposicion = new List<EFamiliaComposicioncombo>();
            lstcomposicion = DTelas.GetLlenarCombofamiliacomposicion();
            CboFamiliaComposicion.DataSource = lstcomposicion;
            CboFamiliaComposicion.SelectedIndex = -1;
            CboFamiliaComposicion.DisplayMember = "auxdescrip";
            CboFamiliaComposicion.ValueMember = "id_familia_composicion";
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
            List<EEstampados> lstestampados = new List<EEstampados>();
            lstestampados = DTelas.GetLlenarCombodisenoestampado();
            CboEstampado.DataSource = lstestampados;
            CboEstampado.SelectedIndex = -1;
            CboEstampado.DisplayMember = "auxdescrip";
            CboEstampado.ValueMember = "id_diseno_estampado";

            List<EMaterialTipocbo> lstmaterialtipo = new List<EMaterialTipocbo>();
            lstmaterialtipo = DTelas.GetLlenarComboMaterialTipo();
            cbotipomaterial.DataSource = lstmaterialtipo;
            cbotipomaterial.SelectedIndex = -1;
            cbotipomaterial.DisplayMember = "auxdescrip";
            cbotipomaterial.ValueMember = "id_material_tipo";

        }
        public void cargarcbosmodificacion()
        {
           
            List<EFamiliaComposicioncombo> lstfamiliacomposicion = new List<EFamiliaComposicioncombo>();
            lstfamiliacomposicion = DTelas.GetLlenarCombofamiliacomposicion();
            if (lstfamiliacomposicion.Count != 0)
            {
                CboFamiliaComposicion.DataSource = lstfamiliacomposicion;
                CboFamiliaComposicion.DisplayMember = "auxdescrip";
                CboFamiliaComposicion.ValueMember = "id_familia_composicion";
            }
            else
            {
                MessageBoxEx.Show("Error, el pre llenado del combo familia composiciòn no tiene registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int cont1 = 0;
            foreach(EFamiliaComposicioncombo itm in lstfamiliacomposicion)
            {
                cont1 += 1;
                if (VarGeneral.id_familia_composicion == itm.id_familia_composicion)
                {
                    CboFamiliaComposicion.SelectedIndex = cont1 - 1;
                    break;
                }
            }
            List<EComprasProveedores> lstProveedor = new List<EComprasProveedores>();
            lstProveedor = DTelas.GetLlenarComboComprasProveedores();
            if (lstProveedor.Count != 0)
            {
                CboProveedor.DataSource = lstProveedor;
                CboProveedor.SelectedIndex = -1;
                CboProveedor.DisplayMember = "auxdescrip";
                CboProveedor.ValueMember = "id_proveedor";
            }
            else
            {
                MessageBoxEx.Show("Error, el pre llenado del combo proveedores no tiene registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int cont2 = 0;
            foreach (EComprasProveedores itm in lstProveedor)
            {
                cont2 += 1;
                if (VarGeneral.id_proveedor == itm.id_proveedor)
                {
                    CboProveedor.SelectedIndex = cont2 - 1;
                    break;
                }
            }
            List<EColores> lstColores = new List<EColores>();
            lstColores = DTelas.GetLlenarComboDisenoColores();
            if (lstColores.Count != 0)
            {
                CboColor.DataSource = lstColores;
                CboColor.DisplayMember = "auxdescrip";
                CboColor.ValueMember = "id_color";
            }
            else
            {
                MessageBoxEx.Show("Error, el pre llenado del combo colores no tiene registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int cont3 = 0;
            foreach (EColores itm in lstColores)
            {
                cont3 += 1;
                if (VarGeneral.id_color == itm.id_color)
                {
                    CboColor.SelectedIndex = cont3 - 1;
                    break;
                }
            }

            List<EEstampados> lstestampados = new List<EEstampados>();
            lstestampados = DTelas.GetLlenarCombodisenoestampado();
            if (lstestampados.Count != 0)
            {
                CboEstampado.DataSource = lstestampados;
                CboEstampado.DisplayMember = "auxdescrip";
                CboEstampado.ValueMember = "id_diseno_estampado";
            }
            else
            {
                    MessageBoxEx.Show("Error, el pre llenado del combo estampados no tiene registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int cont4 = 0;
            foreach (EEstampados itm in lstestampados)
            {
                cont4+= 1;
                if (VarGeneral.id_estampado == itm.id_diseno_estampado)
                {
                    CboEstampado.SelectedIndex = cont4 - 1;
                    break;
                }
            }
            List<EMaterialTipocbo> lstmaterialtipo = new List<EMaterialTipocbo>();
            lstmaterialtipo = DTelas.GetLlenarComboMaterialTipo();
            if (lstmaterialtipo.Count != 0)
            {
                cbotipomaterial.DataSource = lstmaterialtipo;
                cbotipomaterial.DisplayMember = "auxdescrip";
                cbotipomaterial.ValueMember = "id_material_tipo";
            }
            else
            {
                MessageBoxEx.Show("Error, el pre llenado del combo material tipo no tiene registros, verifique antes de procesar.", "Error, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int cont6 = 0;
            foreach (EMaterialTipocbo itm in lstmaterialtipo)
            {
                cont6 += 1;
                if (VarGeneral.tipo == itm.id_material_tipo)
                {
                    cbotipomaterial.SelectedIndex = cont6 - 1;

                    break;
                }
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

                    ETelas inserta = new ETelas();
                    inserta.tipo = Convert.ToInt32(cbotipomaterial.SelectedValue);
                    inserta.clave_tela = Convert.ToString(TxtClaveTela.Text);
                    inserta.descripcion = Convert.ToString(TxtDescripcion.Text);
                    inserta.id_familia_composicion = Convert.ToInt32(CboFamiliaComposicion.SelectedValue);
                    inserta.id_proveedor = Convert.ToInt32(CboProveedor.SelectedValue);
                    inserta.id_estampado = Convert.ToInt32(CboEstampado.SelectedValue);
                    inserta.id_color = Convert.ToInt32(CboColor.SelectedValue);
                    inserta.clave_proveedor = Convert.ToString(TxtClaveProveedor.Text);
                    inserta.ancho_tela = Convert.ToDouble(TxtAnchotela.Text);
                    inserta.observaciones = TxtObservaciones.Text;
                    inserta.prueba_encogimiento_largo = Convert.ToDouble(TxtLargo.Text);
                    inserta.prueba_encogimiento_ancho = Convert.ToDouble(Txtancho.Text);
                    int bandera = 0;
                    try
                    {
                        if (archivoprecargado != null) 
                        {
                            if (archivoprecargado.Length > 0)
                            {
                                inserta.imagen = rutaprecargada;
                                bandera = 1;
                            }
                            else
                            {
                                bandera = 0;
                                inserta.imagen = "";
                            }
                        }
                        else
                        {
                            bandera = 0;
                            inserta.imagen = "";
                        }

                    }
                    catch (Exception)
                    {
                        inserta.imagen = "";
                    }
                    int id = 0;
                    id = DTelas.SetInsertaTelas(inserta);
                    if (id > 0)
                    {
                        if (bandera > 0)
                        {
                           // UAService.FilesClient _clientftp = new FilesClient();
                            string ruta = "C:\\DOCTOS\\Imagenes\\";
                            string extension = ".jpeg";
                            extension = id + extension;
                            Boolean resultado;
                           resultado = ftp.SubirImagen(rutaprecargada, id.ToString() + ".jpeg");
                            //resultado = _clientftp.Upload(ruta, archivoprecargado, extension);
                            if (resultado == true)
                            {
                                MessageBoxEx.Show("Éxito al procesar el archivo", "El archivo se ha almacenado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DHistorico.RegistraHistorico("Diseño", "Catálogo de telas", "Agregar tela", "", inserta.id_familia_composicion + "/" + inserta.id_proveedor + "/" +
                                inserta.id_estampado + "/" + inserta.id_color + "/" + inserta.id_proveedor + "/" + inserta.ancho_tela + "/" + inserta.observaciones + "/" +
                                inserta.prueba_encogimiento_largo + "/" + inserta.prueba_encogimiento_ancho + "/" + inserta.imagen);
                                refrescar.Invoke();
                                Close();
                                Dispose();
                            }
                            else
                            {
                                MessageBoxEx.Show("Error", "Error al procesar el archivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("Éxito al procesar", "El registro se ha almacenado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DHistorico.RegistraHistorico("Diseño", "Catálogo de telas", "Agregar tela", "", inserta.id_familia_composicion + "/" + inserta.id_proveedor + "/" +
                         inserta.id_estampado + "/" + inserta.id_color + "/" + inserta.id_proveedor + "/" + inserta.ancho_tela + "/" + inserta.observaciones + "/" +
                          inserta.prueba_encogimiento_largo + "/" + inserta.prueba_encogimiento_ancho + "/" + inserta.imagen);
                            refrescar.Invoke();
                            Close();
                            Dispose();
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Éxito al procesar", "El registro se ha almacenado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DHistorico.RegistraHistorico("Diseño", "Catálogo de telas", "Agregar tela", "", inserta.id_familia_composicion + "/" + inserta.id_proveedor + "/" +
                     inserta.id_estampado + "/" + inserta.id_color + "/" + inserta.id_proveedor + "/" + inserta.ancho_tela + "/" + inserta.observaciones + "/" +
                      inserta.prueba_encogimiento_largo + "/" + inserta.prueba_encogimiento_ancho + "/" + inserta.imagen);
                        refrescar.Invoke();
                        Close();
                        Dispose();
                    }
                }
                else
                {
                    string ruta = "C:\\DOCTOS\\Imagenes\\";
                    string extension = ".jpeg";
                    extension = VarGeneral.id_tela + extension;

                    ETelas actualiza = new ETelas();
                    actualiza.id_tela = VarGeneral.id_tela;
                    actualiza.tipo = Convert.ToInt32(cbotipomaterial.SelectedValue);
                    actualiza.clave_tela = Convert.ToString(TxtClaveTela.Text);
                    actualiza.descripcion = Convert.ToString(TxtDescripcion.Text);
                    actualiza.id_familia_composicion = Convert.ToInt32(CboFamiliaComposicion.SelectedValue);
                    actualiza.id_proveedor = Convert.ToInt32(CboProveedor.SelectedValue);
                    actualiza.id_estampado = Convert.ToInt32(CboEstampado.SelectedValue);
                    actualiza.id_color = Convert.ToInt32(CboColor.SelectedValue);
                    actualiza.clave_proveedor = Convert.ToString(TxtClaveProveedor.Text);
                    actualiza.ancho_tela = Convert.ToDouble(TxtAnchotela.Text);
                    actualiza.observaciones = TxtObservaciones.Text;
                    actualiza.prueba_encogimiento_largo = Convert.ToDouble(TxtLargo.Text);
                    actualiza.prueba_encogimiento_ancho = Convert.ToDouble(Txtancho.Text);
                    int bandera = 0;
                    try
                    {
                        if (archivoprecargado != null)
                        {
                            if (archivoprecargado.Length > 0)
                            {
                                bandera = 1;
                                actualiza.imagen =  extension;
                            }
                            else
                            {
                                bandera = 0;
                                actualiza.imagen = VarGeneral.imagen;
                            }
                        }
                        else
                        {
                            bandera = 0;
                            actualiza.imagen = VarGeneral.imagen;
                        }
                    }
                    catch(Exception)
                    {
                        bandera = 0;
                        actualiza.imagen = VarGeneral.imagen;
                    }
                    int id = 0;
                    id = DTelas.SetActualizaDisenoTelas(actualiza);
                    if (bandera > 0)
                    {
                        //  UAService.FilesClient _clientftp = new FilesClient();

                        Boolean resultado;
                        //resultado = _clientftp.Upload(ruta, archivoprecargado, extension);
                        resultado = ftp.SubirImagen(rutaprecargada, VarGeneral.id_tela.ToString()+".jpeg");

                        if (resultado == true)
                        {
                            MessageBoxEx.Show("Éxito al procesar el archivo", "El archivo se ha almacenado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DHistorico.RegistraHistorico("Diseño", "Catálogo de telas", "Actualizar tela", VarGeneral.id_tela + "/" + VarGeneral.id_familia_composicion + "/" + VarGeneral.id_proveedor + "/" +
                                 VarGeneral.id_estampado + "/" + VarGeneral.id_color + "/" + VarGeneral.id_proveedor + "/" + VarGeneral.ancho_tela + "/" + VarGeneral.observaciones + "/" +
                                  VarGeneral.prueba_encogimiento_largo + "/" + VarGeneral.prueba_encogimiento_ancho + "/" + VarGeneral.imagen

                                  , VarGeneral.id_tela + "/" +
                                actualiza.id_familia_composicion + "/" + actualiza.id_proveedor + "/" +
                                 actualiza.id_estampado + "/" + actualiza.id_color + "/" + actualiza.id_proveedor + "/" + actualiza.ancho_tela + "/" + actualiza.observaciones + "/" +
                                  actualiza.prueba_encogimiento_largo + "/" + actualiza.prueba_encogimiento_ancho + "/" + actualiza.imagen);
                            refrescar.Invoke();
                            MessageBoxEx.Show("Tela actualizada correctamente", "Tela actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            Dispose();
                        }
                        else
                        {
                            MessageBoxEx.Show("Error", "Error al procesar el archivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else 
                    {
                        DHistorico.RegistraHistorico("Diseño", "Catálogo de telas", "Actualizar tela", VarGeneral.id_tela + "/" + VarGeneral.id_familia_composicion + "/" + VarGeneral.id_proveedor + "/" +
                           VarGeneral.id_estampado + "/" + VarGeneral.id_color + "/" + VarGeneral.id_proveedor + "/" + VarGeneral.ancho_tela + "/" + VarGeneral.observaciones + "/" +
                            VarGeneral.prueba_encogimiento_largo + "/" + VarGeneral.prueba_encogimiento_ancho + "/" + VarGeneral.imagen

                            , VarGeneral.id_tela + "/" +
                          actualiza.id_familia_composicion + "/" + actualiza.id_proveedor + "/" +
                           actualiza.id_estampado + "/" + actualiza.id_color + "/" + actualiza.id_proveedor + "/" + actualiza.ancho_tela + "/" + actualiza.observaciones + "/" +
                            actualiza.prueba_encogimiento_largo + "/" + actualiza.prueba_encogimiento_ancho + "/" + actualiza.imagen);
                        refrescar.Invoke();
                        MessageBoxEx.Show("Tela actualizada correctamente", "Tela registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        Dispose();
                    }
                }
          }
          else
          {
                MessageBoxEx.Show("Verifique todos los campos", "Los campos no pueden estar vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog getimage = new OpenFileDialog();
            //getimage.Filter = "Archivos de Imagen (*.jpg)|(*.jpeg)";
            if (getimage.ShowDialog() == DialogResult.OK)
            {
                //txtNombre.Text = getimage.FileName;
                byte[] file = X.File.ReadAllBytes(getimage.FileName);
               if (file != null)
               {
                    if (file.Length > 0)
                    {
                        archivoprecargado = file;
                        rutaprecargada = getimage.FileName;

                        // UAService.FilesClient _clientftp = new FilesClient();
                        // string ruta = "C:\\DOCTOSGIOVANNI\\Imagenes\\";
                        // string extension = ".jpeg";
                        // string resultado;
                        //resultado = _clientftp.Upload(ruta, file,"1"+ extension);
                        // if (resultado == "OK")
                        // {
                        //     MessageBoxEx.Show("Éxito al procesar el archivo","El archivo se ha almacenado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // }
                        // else
                        // {
                        //     MessageBoxEx.Show("Error", "Error al procesar el archivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // }
                        MessageBoxEx.Show("Exito al precargar imagen","La imagen precargada ha sido validada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbImagen.Image = Image.FromFile(rutaprecargada);
                    }
                    else
                    {
                        MessageBoxEx.Show("Error", "Error, seleccione imagen valida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Error", "Error, seleccione imagen valida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBoxEx.Show("Error", "Error, seleccione imagen valida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (Movimiento != "Alta")
                {
                    //se elimina la imagen en el servidor
                    // UAService.FilesClient _clientftp = new FilesClient();
                  
                    ftp.EliminarImagen(VarGeneral.imagen);
                    //_clientftp.DeleteFile(VarGeneral.imagen);
                    //se ejecuta proceso para actualizar campo de imagen a vacio del registro previo seleccionado
                    DTelas.SetEliminarImagenTela(VarGeneral.id_tela);
                    MessageBoxEx.Show("Éxito al eliminar imágen", "Imágen eliminada correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show("Error al procesar la eliminación", "Error, la selección debe ser modificación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           catch(Exception re)
            {
                string res = "";
                res = re.InnerException.ToString();
                MessageBoxEx.Show("Error, ocurrio un problema al eliminar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void llenarimagen()
        {
            //UAService.FilesClient _clientftp = new FilesClient();
           // DDownload image = new DDownload();
           // string ruta = "C:\\DOCTOS\\Imagenes\\";
           // string extension = "1.jpeg";
            try
            {
                if(!X.File.Exists("C:\\Reportes\\" + VarGeneral.imagen))
                {
                    ftp.DescargarImagen(VarGeneral.imagen);
                }
                // image = _clientftp.Download(VarGeneral.imagen, VarGeneral.id_tela +".jpeg"); //traer la imagen en bits por medio del service
                //     image = _clientftp.Download(ruta, "1.jpeg");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());

                MessageBox.Show(e.InnerException.ToString());
            }


            //image =  _clientftp.Download(VarGeneral.imagen,"1.jpeg");
            try
            {

            
             
                 //   string rutas = "C:\\Images\\"; // proceso para traer la imagen e insertar en la ruta mencionada
                 //   if (!X.Directory.Exists(rutas))
                 //   {
                 //       X.Directory.CreateDirectory(rutas);
                 //   }
                 //   //escribe la imagen en la ruta establecida y asi mismo la visualiza en el panel de imagen
                 //if (!X.File.Exists(rutas + VarGeneral.id_tela + ".jpeg"))
                 //   { 
                 //       System.IO.File.WriteAllBytes(rutas+VarGeneral.id_tela+".jpeg", image.Files);
                 //   }
                    pbImagen.Image = Image.FromFile("C:\\Reportes\\"+VarGeneral.imagen);

                
            }
            catch(Exception)
            {
               // MessageBoxEx.Show("Error, la imágen no se puede descargar ó no existe. Intente subir una nueva.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // pbImagen.
        }

   }
}


