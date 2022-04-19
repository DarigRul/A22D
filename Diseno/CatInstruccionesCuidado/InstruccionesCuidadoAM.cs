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
using Datos.Diseno;
using Entidades.Diseno;
using Datos.Utilitarios.Historico;
using Datos.Utilitarios;
using System.IO;
using System.Net;
using System.Configuration;

namespace ALTIMA_ERP_2022.Diseno.CatInstruccionesCuidado
{
    public partial class InstruccionesCuidadoAM : OfficeForm
    {

        public enum Movimiento : byte { agregar = 1, modificar = 2};
        public Movimiento movimiento;
        public Action refrescar;
        public EInstruccionesCuidado instruccion;
        public string nombreArchivo;
        private static string ruta_temp = ConfigurationManager.AppSettings.GetValues("ruta_temp")[0];

        string rutaImagen, extension, nombreImagen;

        public InstruccionesCuidadoAM()
        {
            InitializeComponent();
        }
        private void InstruccionesCuidadoAM_Load(object sender, EventArgs e)
        {
            switch (movimiento)
            {
                case Movimiento.agregar:
                    txtNombre.Focus();
                    break;
                case Movimiento.modificar:
                    txtNombre.Text = instruccion.nombre;
                    Utilitarios.ftp.DescargarImagen(instruccion.simbolo);
                    string ruta_imagen = ruta_temp + instruccion.simbolo;
                    pbSimbolo.ImageLocation = ruta_imagen;
                    pbSimbolo.SizeMode = PictureBoxSizeMode.StretchImage;
                    nombreArchivo = "";
                    break;
                default:
                    break;
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.png";
            ofd.Multiselect = false;
            ofd.Title = "Seleccione la imagen del símbolo a utilizar";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = ofd.FileName;
                extension = Path.GetExtension(rutaImagen); 
                var imagen = Image.FromFile(ofd.FileName);
                pbSimbolo.Image = imagen;
                nombreArchivo = ofd.SafeFileName;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string valor_nuevo = "";
                string valor_anterior = "";
                //Validamos el campo de nombre 
                if (txtNombre.Text.Trim() == string.Empty)
                {
                    MessageBoxEx.Show("Capture el nombre del símbolo", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus(); 
                }
                else 
                {
                    switch (movimiento)
                    {
                        case Movimiento.agregar:

                            //Obtenemos el nombre del símbolo sin espacios y colocamos la extensión
                            nombreImagen = txtNombre.Text.Replace(" ", string.Empty) + extension;

                            var ic = new EInstruccionesCuidado
                            {
                                nombre = txtNombre.Text.Trim(),
                                simbolo = nombreImagen
                            };

                            var instruccionesCuidado = DInstruccionesCuidado.AgregaInstruccion(ic);
                            if (instruccionesCuidado.id_instruccion_cuidado > 0)
                            {
                                //Si el usuario seleccionó una imagen, la subimos al servidor 
                                if (pbSimbolo.Image != null)
                                { 
                                    Utilitarios.ftp.SubirImagen(rutaImagen, instruccionesCuidado.simbolo); 
                                }

                                valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                                valor_nuevo += "Simbolo: " + nombreImagen + " / ";

                                //Refrescamos el catálogo
                                refrescar.Invoke();

                                //Se registra en el historico el nuevo registro
                                DHistorico.RegistraHistorico("Diseño", "Catálogo Instrucciones de Cuidado", "Nueva instrucción de cuidado", valor_anterior, valor_nuevo);

                                //Informamos al usuario
                                MessageBoxEx.Show("Instrucción de Cuidado registrado correctamente", "Nueva instrucción de cuidado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                                Dispose(); 
                            }
                            break;
                        case Movimiento.modificar:
                            //Obtenemos el nombre del símbolo sin espacios y colocamos la extensión
                            nombreImagen = txtNombre.Text.Replace(" ", string.Empty) + extension;

                            if(nombreArchivo == "")
                            {
                                nombreImagen = "";
                            }

                            var icM = new EInstruccionesCuidado
                            {
                                nombre = txtNombre.Text.Trim(),
                                simbolo = nombreImagen,
                                id_instruccion_cuidado = instruccion.id_instruccion_cuidado
                            };

                            var instruccionesCuidadoM = DInstruccionesCuidado.ModificaInstruccion(icM);
                            if (instruccionesCuidadoM.id_instruccion_cuidado > 0)
                            {
                                //Si el usuario seleccionó una imagen, la subimos al servidor 
                                if (pbSimbolo.Image != null)
                                {
                                    if(nombreImagen != "")
                                    {
                                        Utilitarios.ftp.SubirImagen(rutaImagen, instruccionesCuidadoM.simbolo);
                                    }
                                    else
                                    {
                                        nombreImagen = instruccion.simbolo;
                                    }
                                }

                                valor_nuevo += "Nombre: " + txtNombre.Text + " / ";
                                valor_nuevo += "Simbolo: " + nombreImagen + " / ";

                                valor_anterior += "Nombre: " + txtNombre.Text + " / ";
                                valor_anterior += "Simbolo: " + instruccion.simbolo + " / ";

                                //Refrescamos el catálogo
                                refrescar.Invoke();

                                //Se registra en el historico el nuevo registro
                                DHistorico.RegistraHistorico("Diseño", "Catálogo Instrucciones de Cuidado", "Modificar instrucción de cuidado", valor_anterior, valor_nuevo);

                                //Informamos al usuario
                                MessageBoxEx.Show("Instrucción de Cuidado registrado correctamente", "Nueva instrucción de cuidado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBoxEx.Show($"{ex.Message}\r\n{ex.InnerException}\r\n{ex.StackTrace}", "Error inesperado!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
        private Bitmap RedimensionarImagen(Image imagenOriginal)
        {
            // Creación del bitmap con las nuevas dimensiones 
            var imagenRedimencionada = new Bitmap(200, 200);
            Graphics.FromImage(imagenRedimencionada).DrawImage(imagenOriginal, 0, 0, 200, 200);
            Bitmap imagenFinal = new Bitmap(imagenRedimencionada);
            return imagenFinal;
        }
    }
}
