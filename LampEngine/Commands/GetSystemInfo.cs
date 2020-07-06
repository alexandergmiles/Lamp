using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LampEngine.Commands
{
    public sealed class GetSystemInfo : BulbCommand
    {
        /// <summary>
        /// Returns the info of the bulb that it is passed to
        /// </summary>
        private const string SystemInfoEndpoint = "{\"system\":{\"get_sysinfo\":\"\"}}";

        public GetSystemInfo() : base(SystemInfoEndpoint) {}
    }
}
