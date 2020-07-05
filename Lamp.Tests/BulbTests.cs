using LampEngine;
using System;
using System.Net;
using Xunit;

namespace Lamp.Tests
{
    public class BulbTests
    {
        [Fact]
        public void doTheConstructorsWork()
        {
            var bulb = new Bulb("192.168.1.139");
            var secondBulb = new Bulb(new IPAddress(new byte[] { 192, 168, 1, 110 }));
            Assert.True(bulb is Bulb, "First bulb is a bulb");
            Assert.True(secondBulb is Bulb, "Second bulb is a bulb");
        }
    }
}
    