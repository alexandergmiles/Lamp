using System;
using System.Collections.Generic;
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
        public string GetNetworkAddress();
        public BulbInformation GetBulbInfo();
        public OperationResult SetAlias(string AliasToSet);
        public bool isNetworked();
        public LightState GetColour();
        public OperationResult TogglePower();
        public String SetBrightness(int brightness);
    }
}
