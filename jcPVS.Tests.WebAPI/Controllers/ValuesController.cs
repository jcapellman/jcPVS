using System.Collections.Generic;

using jcPVS.Tests.WebAPI.Objects;
using Microsoft.AspNet.Mvc;

namespace jcPVS.Tests.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class ValuesController : Controller {
        [HttpGet]
        public IEnumerable<TestObject> Get() {
            return new List<TestObject> {new TestObject {ID = 1, Name = "Test"}};
        }
    }
}