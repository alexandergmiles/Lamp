using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    interface IColouredBulb : IBulb
    {
        public BulbInformation SetColour(LightState colour);
    }
}
