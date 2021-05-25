using System.Web;
using System.Web.Mvc;

namespace WebApplication3
{
    public class FilterConfig
    {
        //Aquí puedo crear filtros antes de que un controlador o método sea ejecutado.
        //Por ejemplo filtros de autenticación
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
