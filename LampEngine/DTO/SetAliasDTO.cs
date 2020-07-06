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
        public string GetDeviceAlias() => DevAlias.Alias?.DeviceAlias;
    }

    public class SetAliasResultDTO
    {

    }

    internal class SetDevAlias
    {
        [JsonProperty("set_dev_alias")]
        public Alias Alias { get; set; }
    }

    internal class Alias
    {
        [JsonProperty("alias")]
        public string DeviceAlias { get; set; }

        [JsonProperty("err_code")]
        public int ErrorCode { get; set; }
    }
}
