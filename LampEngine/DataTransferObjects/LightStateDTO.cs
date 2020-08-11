using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LampEngine
{
    internal class LightStateDTO : DTO
    {
        [JsonProperty("on_off")]
        private int OnOff { get; set; }

        [JsonProperty("mode")]
        private string Mode { get; set; }

        [JsonProperty("hue")]
        private int Hue { get; set; }

        [JsonProperty("saturation")]
        private int Saturation { get; set; }

        [JsonProperty("color_temp")]
        private int ColourTemperature { get; set; }

        [JsonProperty("brightness")]
        private int Brightness { get; set; }

        [JsonProperty("err_code")]
        private int ErrorCode { get; set; }

        public LightState AsLightState() =>  new LightState(1, 5, "normal", OnOff, Hue, Saturation, ColourTemperature, Brightness);
       
    }
}
