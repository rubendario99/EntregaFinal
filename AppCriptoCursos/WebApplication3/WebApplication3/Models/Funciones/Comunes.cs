using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace WebApplication3.Models.Funciones
{

    public static class ViewExtensions
    {
        //Método para convertir vistas a string 
        public static string RenderToString(this PartialViewResult partialView)
        {
            var httpContext = HttpContext.Current;

            if (httpContext == null)
            {
                throw new NotSupportedException("An HTTP context is required to render the partial view to a string");
            }

            var controllerName = httpContext.Request.RequestContext.RouteData.Values["controller"].ToString();

            var controller = (ControllerBase)ControllerBuilder.Current.GetControllerFactory().CreateController(httpContext.Request.RequestContext, controllerName);

            var controllerContext = new ControllerContext(httpContext.Request.RequestContext, controller);

            var view = ViewEngines.Engines.FindPartialView(controllerContext, partialView.ViewName).View;

            var sb = new StringBuilder();

            using (var sw = new StringWriter(sb))
            {
                using (var tw = new HtmlTextWriter(sw))
                {
                    view.Render(new ViewContext(controllerContext, view, partialView.ViewData, partialView.TempData, tw), tw);
                }
            }

            return sb.ToString();
        }
    }
    public class Func_Comunes
    {
        //Función para guardar los log
        static public void GuardarLog(string texto)
        {
            //Creamos la string con la ruta donde guardaremos los log
            string directorio = Path.GetFullPath(Path.Combine(HttpContext.Current.Server.MapPath("~/"), @"..")) + @"\Archivos\Logs\";

            //Si no existe la ruta, la crea
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            //Creamos un log con la fecha
            string archivo = directorio + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            try
            {
                //Se escribe en el log creado
                var sw = new System.IO.StreamWriter(archivo, true);
                sw.WriteLine(DateTime.Now.ToString() + " - " + texto);
                sw.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}