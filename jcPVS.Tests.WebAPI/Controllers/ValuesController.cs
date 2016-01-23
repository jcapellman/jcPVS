using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using jcPVS.Library;
using jcPVS.Tests.WebAPI.Objects;

namespace jcPVS.Tests.WebAPI.Controllers {
    public class ValuesController : jcPVSAPIController {
        [HttpGet]
        public TestObject Get()
        {
            return Return(new TestObject {ID = 124, Name = "Test"});
        }
    }
}
