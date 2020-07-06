using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class CommonSystemDTO : DTO
    { 
        [JsonProperty("reboot")]
        public RebootDTO reboot { get; set; }
    }
}
