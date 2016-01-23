using System.Web.Http;

namespace jcPVS.Library {
    [jcPVSActionFilter]
    public class jcPVSAPIController : ApiController {
        public T Return<T>(T obj) {
            return obj;
        }
    }
}