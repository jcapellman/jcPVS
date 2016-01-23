using System.Web;
using System.Web.Mvc;
using jcPVS.Library;

namespace jcPVS.Tests.WebAPI {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
