using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace LampEngine
{
    public class BulbSystem
    {
        [JsonProperty("system")]
        public CurrentSystemInformation systemInformation { get; set; }
    }
}
