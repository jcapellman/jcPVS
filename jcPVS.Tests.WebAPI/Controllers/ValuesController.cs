using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using jcPVS.Tests.WebAPI.Objects;

namespace jcPVS.Tests.WebAPI.Controllers {
    public class ValuesController : ApiController {
        [HttpGet]
        public IEnumerable<TestObject> Get()
        {
            return new List<TestObject> {new TestObject {ID = 124, Name = "Test"}};
        }
    }
}
