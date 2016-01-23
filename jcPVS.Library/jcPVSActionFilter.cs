using System.Web;
using System.Web.Http.Filters;

namespace jcPVS.Library {
    public class jcPVSActionFilter : ActionFilterAttribute {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext) {
            actionExecutedContext.Response?.Content.Headers.Add(Constants.API_KEY, HttpContext.Current.Request.Headers[Constants.API_KEY]);
        }
    }
}