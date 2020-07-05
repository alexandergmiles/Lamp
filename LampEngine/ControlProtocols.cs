using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace LampEngine
{
    public class ControlProtocols
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
