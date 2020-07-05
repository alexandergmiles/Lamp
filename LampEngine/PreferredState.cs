using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class PreferredState
    {
        [JsonProperty("index")]
        public int Index { get; set; }
        
        [JsonProperty("hue")]
        public int Hue { get; set; }

        [JsonProperty("saturation")]
        public int Saturation { get; set; }

        [JsonProperty("color_temp")]
        public int ColourTemperature { get; set; }

        [JsonProperty("brightness")]
        public int Brightness { get; set; }
    }
}
