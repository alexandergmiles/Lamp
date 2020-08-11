using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    internal class CurrentSystemInformationDTO : DTO
    {
        [JsonProperty("get_sysinfo")]
        internal SystemInfoDTO BulbInfo { get; private set; }
    }
    internal class SystemInfoDTO : DTO
    {
        [JsonProperty("sw_ver")]
        internal string SoftwareVersion { get; private set; }

        [JsonProperty("hw_ver")]
        internal string HardwareVersion { get; private set; }

        [JsonProperty("model")]
        internal string Model { get; private set; }

        [JsonProperty("description")]
        internal string Description { get; private set; }

        [JsonProperty("alias")]
        internal string Alias { get; private set; }

        [JsonProperty("mic_type")]
        internal string MicType { get; private set; }

        [JsonProperty("dev_state")]
        internal string DevState { get; private set; }

        [JsonProperty("mic_mac")]
        internal string MicMAC { get; private set; }

        [JsonProperty("deviceId")]
        internal string DeviceID { get; private set; }

        [JsonProperty("oemId")]
        internal string OEMID { get; private set; }

        [JsonProperty("hwId")]
        internal string HardwareID { get; private set; }

        [JsonProperty("is_factory")]
        internal string isFactory { get; private set; }

        [JsonProperty("disco_ver")]
        internal string DiscoVersion { get; private set; }

        [JsonProperty("ctrl_protocols")]
        internal ControlProtocolsDTO controlProtocols { get; private set; }

        [JsonProperty("light_state")]
        internal LightStateDTO lightState { get; private set; }

        [JsonProperty("is_dimmable")]
        internal int IsDimmable { get; private set; }

        [JsonProperty("is_color")]
        internal int IsColour { get; private set; }

        [JsonProperty("is_variable_color_temp")]
        internal int IsVariableColourTemp { get; private set; }

        [JsonProperty("preferred_state")]
        internal List<PreferredStateDTO> preferredStates { get; private set; }

        [JsonProperty("rssi")]
        internal int RSSI { get; private set; }

        [JsonProperty("active_mode")]
        internal string ActiveMode { get; private set; }

        [JsonProperty("heapsize")]
        internal int HeapSize { get; private set; }

        [JsonProperty("err_code")]
        internal int ErrorCode { get; private set; }
    }

        internal class PreferredStateDTO : DTO
    {
        [JsonProperty("index")]
        internal int Index { get; private set; }
        
        [JsonProperty("hue")]
        internal int Hue { get; private set; }

        [JsonProperty("saturation")]
        internal int Saturation { get; private set; }

        [JsonProperty("color_temp")]
        internal int ColourTemperature { get; private set; }

        [JsonProperty("brightness")]
        internal int Brightness { get; private set; }
    }

    internal class ControlProtocolsDTO : DTO
    {
        [JsonProperty("name")]
        internal string Name { get; private set; }

        [JsonProperty("version")]
        internal string Version { get; private set; }
    }
}
