using System;

namespace jcPVS.Library {
    public class jcPVSAttribute : Attribute {
        private readonly int minAPIVersion;

        public jcPVSAttribute(int MinAPIVersion) {
            minAPIVersion = MinAPIVersion;
        }

        public int GetMinAPIVersion() => minAPIVersion;
    }
}