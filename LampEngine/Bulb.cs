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
                //Let's encrypt the command
                var encryptedCommand = command.EncryptCommand();
                
                //Setup the socket that'll be used for communication
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                
                //Create the EndPoint from the IPAddress
                IPEndPoint endPoint = new IPEndPoint(networkAddress, 9999);
                
                //Prepare the data
                var dataToSend = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("ISO-8859-1"), Encoding.UTF8.GetBytes(command.ParsedCommandString));
                
                //Send the data byte[] to the endpoint we created previously
                socket.SendTo(dataToSend, endPoint);
                
                //The buffer we're going to read the data into
                byte[] buffer = new byte[1024];

                //Load the data from the response into the buffer
                //result holds the number of bits read
                var result = socket.Receive(buffer);

                //Get the resposne string from the string
                var resultString = Encoding.GetEncoding("ISO-8859-1").GetString(buffer, 0, result);

                //Print out the result of the query. In reality, we'll be returning a command result
                //based on the command sent
                Console.WriteLine(command.DecryptResponse(resultString));

                //let's just return true
                return true;
            }
            catch (Exception e)
            {
                //What a crude way of handling this
                Console.WriteLine(e);
            }
            return false;
        }

        public bool isNetworked() => new Ping().Send(networkAddress.ToString()).Status == IPStatus.Success ?  true : false;
    }
}
