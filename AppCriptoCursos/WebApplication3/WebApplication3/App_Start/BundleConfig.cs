using System.Web;
using System.Web.Optimization;

namespace WebApplication3
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Recuerda añadir validate.js para que unobstrusive pueda funcionar correctamente
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1.js"));
                        //"~/Scripts/globalize.js",
                        //"~/Scripts/jquery.validate.globalize.js",
                        //"~/Scripts/globalize/globalize.culture.es-ES.js",
                        //"~/Scripts/globalize/date.js",
                        //"~/Scripts/globalize/number.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                 "~/Scripts/globalize.js",
                 "~/Scripts/jquery.validate.globalize.js",
                 "~/Scripts/globalize/date.js",
                 "~/Scripts/globalize/number.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                 "~/Scripts/jquery.validate.js",
                 "~/Scripts/jquery.validate.unobtrusive.js",
                 "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
            //           "~/Scripts/globalize/*.js",
            //           "~/Scripts/locale/es.js",
            //           "~/Scripts/globalize.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/defaults-es_ES.js",
                "~/Scripts/tempusdominus-bootstrap-4.js"));

            //bundles.Add(new ScriptBundle("~/bundles/fontawesome").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/selectpicker").Include(
                       "~/Scripts/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js"));


            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //Recuerda añadir popper
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/umd/popper.js",
                      "~/Scripts/bootstrap.js"));
            //"~/Scripts/fontawesome.js"));

            bundles.Add(new ScriptBundle("~/bundles/fontawesome").Include(
                       "~/Scripts/fontawesome/fontawesome.js"));



            /*
             * 
             *   ESTILOS
             *   ESTILOS
             *   ESTILOS
             *   ESTILOS
             *   ESTILOS
             *   ESTILOS
             *   ESTILOS
             *   ESTILOS
            */

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/fontawesome-all.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/datepickercss").Include(
                      "~/Content/tempusdominus-bootstrap-4.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/Content/fontawesome-all.css"));

            bundles.Add(new StyleBundle("~/Content/selectpicker").Include(
                     "~/Content/bootstrap-select.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                     "~/Content/DataTables/css/jquery.dataTables.css"));
        }
    }
}
