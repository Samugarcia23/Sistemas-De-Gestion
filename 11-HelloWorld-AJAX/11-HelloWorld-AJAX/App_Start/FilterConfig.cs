using System.Web;
using System.Web.Mvc;

namespace _11_HelloWorld_AJAX
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
