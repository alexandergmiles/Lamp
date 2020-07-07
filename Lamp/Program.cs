using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using LampEngine;



namespace Lamp
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Let's test a coloured bulb
            IColouredBulb bulb = new ColouredBulb("192.168.1.139");
            
            //Normal bulb tbh
            IBulb lamp = new Bulb("192.168.1.139");

            //Let's make sure we're connected
            Console.WriteLine($"Is the lamp on? {lamp.isNetworked()} connected at {lamp.GetNetworkAddress()}");

            //Running the operation and getting the values from these
            //var systemInfo = lamp.GetBulbInfo();
            //var rebootResult = lamp.Reboot(5);
            //var aliasResult = lamp.SetAlias("New name");

            var bulbColour = bulb.GetColour();
            
            //Get the current Hue
            Console.WriteLine(bulbColour.Hue);

            //Set the bulb to green
            //var result = bulb.SetColour(new LightState(1, 5, "normal", 1, 120, 100, 0, 100));

            //Get the colour of the bulb
            //var newBulbColour = bulb.GetColour();

            //Console.WriteLine(newBulbColour.Hue);
            bulb.TogglePower();

            //Let's print out to the console
            //Console.WriteLine(result);
            //Console.WriteLine(rebootResult.ErrorCode);
            //Console.WriteLine(systemInfo.Alias);
            Console.ReadLine();
        }
    }
}
