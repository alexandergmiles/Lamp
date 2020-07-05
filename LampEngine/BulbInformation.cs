using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class BulbInformation
    {
        public BulbInformation(string softVer, string hardVer, string model, string desc, string alias, bool dimmable, LightState lstate)
            => (SoftwareVersion, HardwareVersion, Model, Description, Alias, IsDimmable, LightState) = (softVer, hardVer, model, desc, alias, true, lstate);
        public string SoftwareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public bool IsDimmable { get; set; }
        public LightState LightState { get; set; }
    }
}
