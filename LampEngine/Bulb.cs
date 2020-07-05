using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using LampEngine.Commands;
namespace LampEngine
{
    public sealed class Bulb
    {
        public BulbInformation BulbInformation { get; set; }
        public bool powerState { get; private set; }
        public IPAddress networkAddress { get; set; }

        public Bulb(string ipaddress) 
        {
            var address = ipaddress.Split('.');
            networkAddress = new System.Net.IPAddress(new byte[] { 
                Convert.ToByte(address[0]), 
                Convert.ToByte(address[1]),
                Convert.ToByte(address[2]), 
                Convert.ToByte(address[3])});   
        }
        
        public Bulb(IPAddress ipAddress) => (networkAddress, BulbInformation) = (ipAddress, GetBulbInfo());

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

        public T SendQuery<T>(BulbCommand command)
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

                //Return the deseralized object from the request
                return JsonConvert.DeserializeObject<T>(command.DecryptResponse(resultString));
            }
            catch (Exception e)
            {
                //What a crude way of handling this
                Console.WriteLine(e);
            }
            return default(T);
        }

        public BulbInformation GetBulbInfo()
        {
            //Execute the command to get the bulb info
            var getSystemInfo = new BulbCommand(GetSystemInfo.SystemInfoEndpoint);
            var result = SendQuery<BulbSystemDTO>(getSystemInfo);
            
            //Cache the bulb information
            BulbInformation = result.AsBulbInformation();
            
            //Return the bulb information
            return BulbInformation;
        }

        public bool isNetworked() => new Ping().Send(networkAddress.ToString()).Status == IPStatus.Success ?  true : false;
    }
}
