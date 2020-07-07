using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    class GetColour : BulbCommand
    {
        private const string GetSystemColour = "{\"smartlife.iot.smartbulb.lightingservice\":{\"get_light_state\":\"\"}}";

        internal GetColour() 
            : base(GetSystemColour) {
        }
    }
}
