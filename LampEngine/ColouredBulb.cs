using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LampEngine
{
    class ColouredBulb :Bulb, IColouredBulb
    {
        public ColouredBulb(string address)
            : base(address) { }
        public ColouredBulb(IPAddress address)
            : base(address) { }

        public T SendQuery<T>(BulbCommand command)
        {
            throw new NotImplementedException();
        }

        public BulbInformation SetColour(LightState colour)
        {
            throw new NotImplementedException();
        }
    }
}
