using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    internal class CurrentSystemInformationDTO : DTO
    {
        [JsonProperty("get_sysinfo")]
        public SystemInfoDTO BulbInfo { get; set; }
    }
}
