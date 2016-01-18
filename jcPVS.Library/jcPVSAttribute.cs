using System;

namespace jcPVS.Library {
    public class jcPVSAttribute : Attribute {
        private string minVersion;

        public jcPVSAttribute(string MinVersion) {
            minVersion = MinVersion;
        }

        public string GetMinVersion() => minVersion;
    }
}