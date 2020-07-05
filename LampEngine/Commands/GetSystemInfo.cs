using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine.Commands
{
    public class GetSystemInfo
    {
        /// <summary>
        /// Returns the info of the bulb that it is passed to
        /// </summary>
        public static string SystemInfoEndpoint = "{\"system\":{\"get_sysinfo\":\"\"}}";
    }
}
