using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LampEngine
{
    /// <summary>
    /// As not all bulbs are the same, we should use an interface to specify 
    /// our base behaviour. We want our bulbs to have default behaviour, and
    /// then implement the specalised controls elsehwere
    /// </summary>
    public interface IBulb
    {
        public IPAddress networkAddress { get; set; }
        public bool isNetworked();
        public string GetNetworkAddress();
        public OperationResult PowerOn();
        public OperationResult PowerOff();
        public BulbInformation GetBulbInfo();
        public OperationResult SetAlias(string AliasToSet);
        public LightState GetColour();
        public LightState SetBrightness(int brightness);
    }
}
