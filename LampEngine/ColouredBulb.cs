using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LampEngine
{
    public class ColouredBulb :Bulb, IColouredBulb
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
        public String SetColour(LightState colour)
        {
            var command = new SetColour(colour);
            var result = SendQuery(command);

            return result;
        }
        
        /// <summary>
        /// Gets the current colour of the bulb
        /// </summary>
        /// <returns>A LightState containing bulb colour information</returns>
        public LightState GetColour()
        {
            var command = new GetColour();
            return SendQuery<LightingDTO<GetLightStateDTO>>(command).LightingService.LightStateDTO.AsLightState();
        }

        public OperationResult TogglePower()
        {
            var currentLightState = GetColour();
            var toggle = (currentLightState.OnOff.Equals(0) ? 1 : 0);
            var oldColourNewPower = currentLightState;
            oldColourNewPower.OnOff = toggle;
            Console.WriteLine($"Result of operation: {SetColour(oldColourNewPower)}");
            return new OperationResult(0);
        }
    }
}
