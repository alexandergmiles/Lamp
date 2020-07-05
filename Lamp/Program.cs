using System;
using System.Threading.Tasks;
using LampEngine;

namespace Lamp
{
    class Program
    {
        public static void Main(string[] args)
        {
            //System info
            var jsonString = "{\"system\":{\"get_sysinfo\":\"\"}}";

            //reboot
            var reboot = "{\"smartlife.iot.common.system\":{\"reboot\":{\"delay\":1}}}";
            
            Console.WriteLine("Starting the bulb management service...");
            
            Bulb lamp = new Bulb("192.168.1.110");
            
            Console.WriteLine($"Is the lamp on? {lamp.isNetworked()}");

            BulbCommand command = new BulbCommand(jsonString);
            lamp.SendQuery(command);

            Console.ReadLine();
        }
    }
}
