using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class LightState
    {
        public LightState(int ignoreDefault, int transitionPeriod, string mode, int onOff, int hue, int saturation, int colourTemp, int brightness) => 
            (IgnoreDefault, TransitionPeriod, Mode, OnOff, Hue, Saturation, ColourTemperature, Brightness) = (ignoreDefault, transitionPeriod, mode, onOff, hue, saturation, colourTemp, brightness);
        public int IgnoreDefault { get; set; }
        public int TransitionPeriod { get; set; }
        public string Mode { get; set; }
        public int OnOff { get; set; }
        public int Hue { get; set; }
        public int Saturation { get; set; }
        public int ColourTemperature{ get; set; }
        public int Brightness { get; set; }
    }
}
