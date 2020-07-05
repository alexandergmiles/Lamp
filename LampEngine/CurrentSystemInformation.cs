using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class CurrentSystemInformation
    {
        [JsonProperty("get_sysinfo")]
        public SystemInfo BulbInfo { get; set; }
    }
}
