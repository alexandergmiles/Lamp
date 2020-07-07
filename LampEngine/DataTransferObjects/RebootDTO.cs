using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace LampEngine
{
    class RebootCommandDTO : DTO
    {
        [JsonProperty("smartlife.iot.common.system")]
        public CommonSystemDTO commonSystem { get; set; }
    }
    internal class CommonSystemDTO : DTO
    {
        [JsonProperty("reboot")]
        public RebootDTO reboot { get; set; }
    }

    internal class RebootDTO : DTO
    {
        [JsonProperty("err_code")]
        public int ErrorCode { get; }
    }
}
