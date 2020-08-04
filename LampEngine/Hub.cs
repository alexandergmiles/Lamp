using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LampEngine
{
    /// <summary>
    /// The Hub is responsible for dealing with bulbs. It will create the commands, execute commands on bulbs, and store information
    /// </summary>
    public class Hub
    {
        //A private list of all the bulbs, how are they set? We don't know yet.
        public List<IBulb> bulbs { get; private set; }

        public void GenerateBulbs()
        {
            IBulb whiteBulb = new Bulb("192.168.1.166");
            IColouredBulb colouredBulb = new ColouredBulb("192.168.1.165");
            bulbs.Add(whiteBulb);
            bulbs.Add(colouredBulb);
            Console.WriteLine($"The hub currently contains {bulbs.Count} bulbs");
        }

        public void ExecuteCommand(IBulb bulb, BulbCommand command)
        {

        }

        public void AttachBulb(IBulb bulb)
        {
            //Add the bulb
            bulbs.Add(bulb);
        }

        public void LoadFromDatastore()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send the current bulb command, returning the response as a JSON string
        /// </summary>
        /// <param name="command">The command to be sent to the bulb</param>
        /// <returns>JSON response from the device</returns>
        private string SendQuery(BulbCommand command, Bulb bulb)
        {
            try
            {
                //Let's encrypt the command
                var encryptedCommand = command.EncryptCommand();

                //Setup the socket that'll be used for communication
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //Create the EndPoint from the IPAddress
                IPEndPoint endPoint = new IPEndPoint(bulb.networkAddress, 9999);

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
                return command.DecryptResponse(resultString);
            }
            catch (Exception e)
            {
                //What a crude way of handling this
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
