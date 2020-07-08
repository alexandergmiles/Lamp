using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LampEngine
{
    public class ColouredBulb : Bulb, IColouredBulb
    {
        public ColouredBulb(string address)
            : base(address) { }
        public ColouredBulb(IPAddress address)
            : base(address) { }

        /// <summary>
        /// Sets the colour of the current bulb
        /// </summary>
        /// <param name="colour">A lightstate containing the desired colour</param>
        /// <returns></returns>
        public OperationResult SetColour(LightState colour)
        {
            var command = new SetColour(colour);
            var result = SendQuery(command);

            return new OperationResult(0);
        }
    }
}
