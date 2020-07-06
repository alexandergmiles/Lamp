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

            Bulb lamp = new Bulb("192.168.1.139");

            Console.WriteLine($"Is the lamp on? {lamp.isNetworked()}");
            
            
            BulbCommand reboot = new BulbCommand(KnownCommands.Reboot, new Dictionary<string, object>() { { "{delay}", 1 } });
            //BulbCommand getSystemInfo = new BulbCommand(KnownCommands.GetSystemInfo);
            
            BulbCommand aliasCommand = new BulbCommand(KnownCommands.Alias, new Dictionary<string, object>() { { "{alias}", "DebugBulb" } });
            var colour = new Dictionary<string, object>();
            colour.Add("{ignore_default}", 1);
            colour.Add("{mode}", "normal");
            colour.Add("{hue}", 160);
            colour.Add("{on_off}", 0);
            colour.Add("{saturation}", 65);
            colour.Add("{colour_temp}", 0);
            colour.Add("{brightness}", 10);
            colour.Add("{transition_period}", 150);

            BulbCommand setColour = new BulbCommand(KnownCommands.SetColour, colour);
          
            var systemInfo = lamp.GetBulbInfo();
            lamp.SendQuery(setColour);


            Console.WriteLine(systemInfo.Alias);
            Console.ReadLine();
        }
    }
}
