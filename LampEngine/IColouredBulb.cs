using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public interface IColouredBulb : IBulb
    {
        public OperationResult SetColour(LightState colour);
    }
}
