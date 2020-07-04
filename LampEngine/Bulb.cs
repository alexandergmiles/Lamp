using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LampEngine
{
    public sealed class Bulb
    {
        public bool powerState { get; private set; }
        public IPAddress networkAddress { get; set; }
        public Bulb(IPAddress network) => (networkAddress) = (network);
        public bool TurnOn()
        {
            return true;
        }

        public bool SendQuery(BulbCommand command)
        {
            try
            {
                command.EncryptCommand();
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint endPoint = new IPEndPoint(networkAddress, 9999);
                var dataToSend = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("ISO-8859-1"), Encoding.UTF8.GetBytes(command.ParsedCommandString));
                socket.SendTo(dataToSend, endPoint);
                byte[] buffer = new byte[1024];

                var result = socket.Receive(buffer);
                var resultString = Encoding.GetEncoding("ISO-8859-1").GetString(buffer, 0, result);

                command.DecryptResponse(resultString);
                Console.WriteLine(command.Response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool isNetworked() => new Ping().Send(networkAddress.ToString()).Status == IPStatus.Success ?  true : false;
    }
}
