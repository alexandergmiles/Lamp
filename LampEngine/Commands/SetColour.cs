using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class SetColour : BulbCommand
    {
        private static string SetColourEndpoint = "{\"smartlife.iot.smartbulb.lightingservice\":{\"transition_light_state\":{\"ignore_default\":{ignoredefault},\"transition_period\":{transitionperiod},\"mode\":\"{mode}\",\"hue\":{hue},\"on_off\":{onoff},\"saturation\":{saturation},\"color_temp\":{colourtemperature},\"brightness\":{brightness}}}}";
        
        public LightState Colour { get; set; }

        public SetColour(LightState light)
            : base() 
        {
            Colour = light;
            var parameters = GetParameters(SetColourEndpoint, Colour);
            CommandString = CreateCommandWithParameters(parameters, SetColourEndpoint);
        }
    }
}
