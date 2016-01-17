using jcPVS.Library;

namespace jcPVS.Tests.WebAPI.Objects {
    public class TestObject {
        [jcPVS("1.5")]
        public string Name { get; set; }

        public int ID { get; set; }
    }
}