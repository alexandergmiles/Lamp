using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace LampEngine
{
    public class LightingDTO<T>
    {
        [JsonProperty("smartlife.iot.smartbulb.lightingservice")]
        public T LightingService { get; set; }
    }

    internal class GetLightStateDTO
    {
        [JsonProperty("get_light_state")]
        public LightStateDTO LightStateDTO { get; set; }
    }
}
