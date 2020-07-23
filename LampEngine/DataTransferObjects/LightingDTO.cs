using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace LampEngine
{
    public class LightingDTO<T>
    {
        //We use generics here so we can set this to be something
        //different each time we need its
        [JsonProperty("smartlife.iot.smartbulb.lightingservice")]
        public T LightingService { get; set; }
    }

    internal class GetLightStateDTO
    {
        [JsonProperty("get_light_state")]
        public LightStateDTO LightStateDTO { get; set; }
    }

    internal class LightTransitionState
    {
        [JsonProperty("transition_light_state")]
        public LightStateDTO LightStateDTO { get; set; }
    }
}
