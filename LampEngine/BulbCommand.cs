using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LampEngine
{
    public class BulbCommand
    {
        /// <summary>
        /// The command string being sent to the bulb
        /// </summary>
        public String CommandString { get; set; }
        public string ParsedCommandString { get; private set; }
        public string Response { get; set; }

        public BulbCommand(string command) => (CommandString) = (command);

        /// <summary>
        /// The commands sent to the bulb need to be XOR'd using the previous byte
        /// </summary>
        /// <returns></returns>
        public void EncryptCommand()
        {
            int key = 0xAB;
            StringBuilder commandToSendToDevice = new StringBuilder();
            var encoded = Encoding.GetEncoding("ISO-8859-1").GetString(Encoding.GetEncoding("ISO-8859-1").GetBytes(CommandString));
            for(int i = 0; i < CommandString.Length; i++)
            {
                var intCommand = Convert.ToInt32(CommandString[i]);
                commandToSendToDevice.Append(Convert.ToChar(intCommand ^ key));
                key = Convert.ToInt32(Convert.ToChar(intCommand ^ key));
            }
            ParsedCommandString = commandToSendToDevice.ToString();
        }

        public void DecryptResponse(string responseString)
        {
            int key = 0xAB;
            StringBuilder response = new StringBuilder();
            for (int i = 0; i < responseString.Length; i++)
            {
                response.Append(Convert.ToChar(responseString[i] ^ key));
                key = Convert.ToChar(responseString[i]);
            }
            Response = response.ToString();
        }
    }
}
