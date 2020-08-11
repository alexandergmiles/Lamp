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
            ColouredBulb lamp = new ColouredBulb("192.168.1.110");
            IBulb whiteLamp = new Bulb("192.168.1.75");

            Console.WriteLine($"Is the lamp connected {lamp.isNetworked()} connected at {lamp.GetNetworkAddress()}");

            var systemInfo = lamp.GetBulbInfo();

            var lampCOlour = lamp.GetColour();
            var whiteLampColour = whiteLamp.GetColour();

            var result = lamp.SetBrightness(100);
            lamp.SetColour(whiteLampColour);
            Console.WriteLine($"Is the bulb on? {systemInfo.IsOn}");

            if(systemInfo.IsOn == false)
            {
                lamp.PowerOn();
            }
            
            Console.WriteLine(result);
            Console.WriteLine(systemInfo.IsDimmable);
            Console.WriteLine(systemInfo.Model);
            Console.WriteLine(systemInfo.Alias);
            Console.WriteLine(systemInfo.IsDimmable);
            Console.WriteLine(systemInfo.IsColour);
            Console.WriteLine(systemInfo.IsVariableColourTemp);

            bool keepLooping = true;

            do
            {
                Console.WriteLine("Please input either a brightness value (int) or (E)xit");
                string input = Console.ReadLine();
                switch(input) {
                    case "E":
                    case "e":
                    case "exit":
                    case "Exit":
                        keepLooping = false;
                        break;

                    case "Turn on":
                        lamp.PowerOn();
                        break;
                    case "Turn off":
                        lamp.PowerOff();
                        break;
                    default:
                        var localResult = lamp.SetBrightness(Convert.ToInt32(input));
                        Console.WriteLine(localResult.Brightness);
                        break;
                }
            } while (keepLooping);
        }
    }
}
