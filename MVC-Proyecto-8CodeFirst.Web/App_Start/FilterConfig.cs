using System.Web;
using System.Web.Mvc;

namespace MVC_Proyecto_8CodeFirst.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
