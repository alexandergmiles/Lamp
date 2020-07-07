using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public interface IColouredBulb : IBulb
    {
        public string SetColour(LightState colour);

        public LightState GetColour();

        public OperationResult TogglePower();
    }
}
