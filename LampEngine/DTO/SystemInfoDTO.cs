using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    internal class SystemInfoDTO : DTO
    {
        [JsonProperty("sw_ver")]
        public string SoftwareVersion { get; set; }
        
        [JsonProperty("hw_ver")]
        public string HardwareVersion { get; set; }

        [JsonProperty("model")]
        public string Model { get; set;  }

        [JsonProperty("description")]
        public string Description { get; set;  }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("mic_type")]
        public string MicType { get; set;  }

        [JsonProperty("dev_state")]
        public string DevState { get; set;  }

        [JsonProperty("mic_mac")]
        public string MicMAC { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceID { get; set; }

        [JsonProperty("oemId")]
        public string OEMID { get; set; }

        [JsonProperty("hwId")]
        public string HardwareID { get; set; }

        [JsonProperty("is_factory")]
        public string isFactory { get; set; }

        [JsonProperty("disco_ver")]
        public string DiscoVersion { get; set; }

        [JsonProperty("ctrl_protocols")]
        public ControlProtocolsDTO controlProtocols { get; set; }

        [JsonProperty("light_state")]
        public LightStateDTO lightState { get; set; }

        [JsonProperty("is_dimmable")]
        public int IsDimmable { get; set; }

        [JsonProperty("is_color")]
        public int IsColour { get; set; }

        [JsonProperty("is_variable_color_temp")]
        public int IsVariableColourTemp { get; set; }

        [JsonProperty("preferred_state")]
        public List<PreferredStateDTO> preferredStates { get; set; }

        [JsonProperty("rssi")]
        public int RSSI { get; set; }

        [JsonProperty("active_mode")]
        public string ActiveMode { get; set; }

        [JsonProperty("heapsize")]
        public int HeapSize { get; set; }

        [JsonProperty("err_code")]
        public int ErrorCode { get; set; }
    }
}
