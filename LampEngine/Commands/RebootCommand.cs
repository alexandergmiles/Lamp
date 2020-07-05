using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace LampEngine
{
    public class RebootCommand
    {
        [JsonProperty("smartlife.iot.common.system")]
        public CommonSystemDTO commonSystem { get; set; }
    }

    public class Reboot
    {
        [JsonProperty("delay")]
        public int Delay { get; set; }

        [JsonProperty("err_code")]
        public int ErrorCode { get; }
    }
}
