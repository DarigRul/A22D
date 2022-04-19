using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar.SuperGrid;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Entidades.Usuarios;

namespace ALTIMA_ERP_2022.Utilitarios
{
    public static class ConfiguracionGlobal
    {
        public static EUsuarios usuario;
        public static bool pBtnAgregar;
        public static bool pBtnEditar;
        public static bool pBtnActivar;
        public static bool pBtnDesactivar;
        public static bool pBtnReporte;

        public static string RutaReporte(string fileName)
        {
            DirectoryInfo df = Directory.CreateDirectory(@"c:\Reportes");
            WebClient wc = new WebClient();
            wc.DownloadFile("https://www.uniformes-altima.com.mx/arp/reportes/" + fileName + ".rpt", @"c:\Reportes\" + fileName + ".rpt");
            string ruta = @"c:\Reportes\" + fileName + ".rpt";
            return ruta;

        }

        public static void GeneraReporte(SuperGridControl supergrid, string nombreReporte)
        {
            try
            {
                DataTable dt = supergridToDataTable.ObtenerTabla(supergrid);
                string ruta = RutaReporte(nombreReporte);

                ReportDocument rp = new ReportDocument();
                rp.Load(ruta);
                rp.SetDataSource(dt);

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

        public static void GeneraInformes(List<SuperGridControl> supergrids, string nombreReporte)
        {
            try
            {
                if (supergrids.Count() == 1)
                {
                    GeneraReporte(supergrids[0], nombreReporte);
                }
                else if (supergrids.Count() > 1)
                {
                    List<DataTable> tablas = new List<DataTable>();

                    //Convertimos cada supergrid en tablas
                    foreach (SuperGridControl sg in supergrids)
                    {
                        tablas.Add(supergridToDataTable.ObtenerTabla(sg));
                    }

                    string ruta = RutaReporte(nombreReporte);
                    ReportDocument rp = new ReportDocument();
                    rp.Load(ruta);
                    rp.SetDataSource(tablas[0]);

                    //Se establecen las fuentes de datos en cada subreporte
                    for (int i = 1; i < tablas.Count(); i++)
                    {
                        rp.Subreports[i].SetDataSource(tablas[i]);
                    }

                    Reportes reporte = new Reportes(); 
                    reporte.crv.ReportSource = rp;
                    reporte.ShowDialog();

                    //Eliminamos el archivo de la computadora del usuario 
                    File.Delete(ruta); 
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show($"{ ex.Message}\r\n{ ex.InnerException}\r\n{ex.StackTrace}", "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
