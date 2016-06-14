using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SCAAD.APIs.Providers
{
    public static class SaveFiles
    {
        public static string SaveActividadesEvidencias(string Datos,int ActividadId)
        {
            byte[] bytes = Convert.FromBase64String(Datos);
            string filename = string.Format("Actividad_{0}_{1:yyyy-MM-dd_hh-mm-ss-tt}.pdf", ActividadId, DateTime.Now);
            string startupPath = System.Web.HttpContext.Current.Server.MapPath(string.Format("~/Uploads/{0}", filename));
            //string startupPath = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/" + ActividadId+".pdf");

            System.IO.FileStream stream = new FileStream(startupPath, FileMode.CreateNew);
            System.IO.BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
            return filename;
        }
    }
}