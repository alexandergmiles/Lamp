using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public interface IColouredBulb
    {
        public OperationResult SetColour(LightState colour);
    }
}
