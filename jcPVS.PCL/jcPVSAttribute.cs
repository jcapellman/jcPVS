using System;

namespace jcPVS.PCL {
    public class jcPVSAttribute : Attribute {
        private string minVersion;

        public jcPVSAttribute(string MinVersion) {
            minVersion = MinVersion;
        }
    }
}