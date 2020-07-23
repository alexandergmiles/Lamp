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
            IBulb lamp = new Bulb("192.168.1.164");

            Console.WriteLine($"Is the lamp on? {lamp.isNetworked()} connected at {lamp.GetNetworkAddress()}");

            var systemInfo = lamp.GetBulbInfo();
            var result = lamp.SetBrightness(100);
            
            Console.WriteLine(result);
            Console.WriteLine(systemInfo.IsDimmable);
            Console.WriteLine(systemInfo.Model);

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
                    default:
                        var localResult = lamp.SetBrightness(Convert.ToInt32(input));
                        Console.WriteLine(localResult.Brightness);
                        break;
                }
            } while (keepLooping);
            Console.ReadLine();
        }
    }
}
