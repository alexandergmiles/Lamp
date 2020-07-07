using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using LampEngine;

namespace Lamp.Tests
{
    public class ColouredBulbTests
    {
        IColouredBulb bulb = new ColouredBulb("192.168.1.139");
        [Fact]
        public void getBulbInfo()
        {
            var bulbInfo = bulb.GetBulbInfo();
            Assert.True(bulbInfo.Alias == "New name");
        }
    }
}
