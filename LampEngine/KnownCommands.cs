using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public static class KnownCommands
    {
        /// <summary>
        /// Returns the info of the bulb that it is passed to
        /// </summary>
        public static string GetSystemInfo = "{\"system\":{\"get_sysinfo\":\"\"}}";
        
        /// <summary>
        /// Reboots the with a delay provided defined by {delay}
        /// </summary>        
        public static string Reboot = "{\"smartlife.iot.common.system\":{\"reboot\":{\"delay\":{delay}}}}";

        /// <summary>
        /// Used to set the Alias of the device defined by {alias}
        /// </summary>
        public static string Alias = "{\"smartlife.iot.common.system\":{\"set_dev_alias\":{\"alias\":\"{alias}\"}}}";

        public static string SetColour = "{\"smartlife.iot.smartbulb.lightingservice\":{\"transition_light_state\":{\"ignore_default\":{ignore_default},\"transition_period\":{transition_period},\"mode\":\"{mode}\",\"hue\":{hue},\"on_off\":{on_off},\"saturation\":{saturation},\"color_temp\":{colour_temp},\"brightness\":{brightness}}}}";
    }
}



