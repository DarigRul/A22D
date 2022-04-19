using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Web;
using DevComponents.DotNetBar;
using Renci.SshNet;
using System.Configuration;

namespace ALTIMA_ERP_2022.Utilitarios
{
    public static class ftp
    {
        private static string host = ConfigurationManager.AppSettings.GetValues("host")[0];
        private static string ruta_temp = ConfigurationManager.AppSettings.GetValues("ruta_temp")[0];
        private static string username = ConfigurationManager.AppSettings.GetValues("username")[0];
        private static string password = ConfigurationManager.AppSettings.GetValues("password")[0];
        private static int puerto = System.Convert.ToInt16(ConfigurationManager.AppSettings.GetValues("puerto")[0]);

        public static bool SubirImagen(string ruta, string nombreImagen)
        {
            string path = host + "/" + nombreImagen;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);

            //Asignamos las credenciales 
            request.Credentials = new NetworkCredential(username, password);

            //Asignamos las propiedades
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            //Leemos el archivo en un stream para escribilor en el stream del FTP 
            using (Stream streamFile = File.OpenRead(ruta))
            {
                //Obtenemos el stream sobre la comunicación FTP
                using (Stream streamFTP = request.GetRequestStream())
                {
                    byte[] arrBytBuffer = new byte[7000];
                    int intRead;

                    // Lee y escribe el archivo en el stream de comunicaciones
                    while ((intRead = streamFile.Read(arrBytBuffer, 0, 5000)) != 0)
                    {
                        streamFTP.Write(arrBytBuffer, 0, intRead);
                    }

                    // Cierra el stream FTP
                    streamFTP.Close();

                    return true;
                }
            }
        }

        public static bool EliminarImagen(string nombre_archivo)
        {
            //Elimina el archivo
            string path = host + "/" + nombre_archivo;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Credentials = new NetworkCredential(username, password);
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
            return true;
        }

        public static void DescargarImagen(string nombreImagen)
        {
            if (nombreImagen != "")
            {
                if (existe_archivo(nombreImagen))
                {
                    FtpWebRequest req;
                    req = (FtpWebRequest)FtpWebRequest.Create(host + nombreImagen);
                    req.Credentials = new NetworkCredential(username, password);
                    req.KeepAlive = false;
                    req.Method = WebRequestMethods.Ftp.DownloadFile;
                    req.UseBinary = true;
                    req.UsePassive = true;

                    FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                    Stream responseStream = response.GetResponseStream();

                    FileStream writeStream = new FileStream(ruta_temp + nombreImagen, FileMode.Create);
                    int Length = 70000;
                    byte[] buffer = new byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);
                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }
                    writeStream.Close();
                    response.Close();
                }
            }
        }

        private static bool existe_archivo(string archivo)
        {
            try
            {
                // Crea la conexión al servidor.
                bool existe_archivo = false;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                // Se ingresan las credenciales del servidor.
                request.Credentials = new NetworkCredential(username, password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream());

                List<string> strList = new List<string>();
                string str = sr.ReadLine();
                while (str != null)
                {
                    strList.Add(str);
                    if (archivo == str)
                    {
                        existe_archivo = true;
                    }
                    str = sr.ReadLine();
                }

                // Cierra la conexión.
                response.Close();
                return existe_archivo;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
