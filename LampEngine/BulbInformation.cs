using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class BulbInformation
    {
        public BulbInformation(string softVer, string hardVer, string model, string desc, string alias,  LightState lstate, bool dimmable, bool isColour, bool isVarColourTemp, bool isOn)
            => (SoftwareVersion, HardwareVersion, Model, Description, Alias, LightState, IsDimmable, IsColour, IsVariableColourTemp, IsOn) = (softVer, hardVer, model, desc, alias, lstate, dimmable, isColour, isVarColourTemp, isOn);
        public string SoftwareVersion { get; private set; }
        public string HardwareVersion { get; private set; }
        public string Model { get; private set; }
        public string Description { get; private set; }
        public string Alias { get; private set; }
        public LightState LightState { get; private set; }
        public bool IsDimmable { get; private set; }
        public bool IsColour { get; private set; }
        public bool IsVariableColourTemp { get; private set; }
        public bool IsOn { get; set; }

    }
}
