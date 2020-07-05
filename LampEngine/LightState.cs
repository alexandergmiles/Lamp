using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class LightState
    {
        public LightState(int hue, int saturation, int colourTemp, int brightness) => 
            (Hue, Saturation, ColourTemperature, Brightness) = (hue, saturation, colourTemp, brightness);
        public int Hue { get; set; }
        public int Saturation { get; set; }
        public int ColourTemperature{ get; set; }
        public int Brightness { get; set; }
    }
}
