using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LampEngine
{
    public class ColouredBulb : Bulb
    {
        public ColouredBulb()
            :base("192.168.1.164")
        {

        }

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
