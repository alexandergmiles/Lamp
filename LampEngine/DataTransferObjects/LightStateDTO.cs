using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LampEngine
{
    internal class LightStateDTO : DTO
    {
        [JsonProperty("on_off")]
        public int OnOff { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("hue")]
        public int Hue { get; set; }

        [JsonProperty("saturation")]
        public int Saturation { get; set; }

        [JsonProperty("color_temp")]
        public int ColourTemperature { get; set; }

        [JsonProperty("brightness")]
        public int Brightness { get; set; }

        [JsonProperty("err_code")]
        public int ErrorCode { get; set; }

        public LightState AsLightState() =>  new LightState(1, 5, "normal", OnOff, Hue, Saturation, ColourTemperature, Brightness);
       
    }
}
