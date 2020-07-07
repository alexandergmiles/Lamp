using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace LampEngine
{
    public class SetAliasDTO
    {
        [JsonProperty("smartlife.iot.common.system")]
        SetDevAlias DevAlias { get; set; }

        public int? GetErrorCode() => DevAlias.Alias?.ErrorCode;
    }
    internal class SetDevAlias
    {
        [JsonProperty("set_dev_alias")]
        public Alias Alias { get; set; }
    }

    internal class Alias
    {
        [JsonProperty("err_code")]
        public int ErrorCode { get; set; }
    }
}
