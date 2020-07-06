using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace LampEngine
{
    public class BulbSystemDTO : DTO
    {
        [JsonProperty("system")]
        CurrentSystemInformationDTO systemInformation { get; set; }
        public BulbInformation AsBulbInformation()
        {
            return new BulbInformation(systemInformation.BulbInfo.SoftwareVersion,
                systemInformation.BulbInfo.HardwareVersion,
                systemInformation.BulbInfo.Model,
                systemInformation.BulbInfo.Description,
                systemInformation.BulbInfo.Alias,
                systemInformation.BulbInfo.IsDimmable.Equals(1) ? true : false,
                systemInformation.BulbInfo.lightState.LightState());
        }
    }
}
