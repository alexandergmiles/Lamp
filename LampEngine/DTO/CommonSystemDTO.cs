using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class CommonSystemDTO
    {
        [JsonProperty("reboot")]
        public Reboot reboot { get; set; }
    }
}
