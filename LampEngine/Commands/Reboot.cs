using System;

namespace LampEngine
{
    internal class Reboot : BulbCommand
    {
        private const string SystemInfoEndpoint = "{\"smartlife.iot.common.system\":{\"reboot\":{\"delay\":{delay}}}}";

        public int Delay { get; set; }

        internal Reboot(int delay) : base(){
            Delay = delay;
            var parameters = GetParameters(SystemInfoEndpoint, this);
            CommandString = CreateCommandWithParameters(parameters, SystemInfoEndpoint);
        }
    }
}