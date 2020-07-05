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

        ///<summary>
        ///We're caching our response, but we only want it to be seen internally
        ///</summary>
        private string CachedResponse { get; set; }

        ///<summary>
        ///We need our constructor for the object, and by using expression bodied members we can make it
        ///</summary>
        public BulbCommand(string command) => (CommandString) = (command);

        public BulbCommand(string command, Dictionary<String, object> parameterValues)
        {
            CommandString = CreateCommandWithParameters(parameterValues, command);
        }

        public string GetCachedResponse => CachedResponse;

        /// <summary>
        /// Uses the command defined at object instantiation
        /// </summary>
        /// <returns>The encrypted command</returns>
        public string EncryptCommand()
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

            return ParsedCommandString;
        }

        ///<summary>
        ///Used when you want to pass a new command, maybe you want to reuse the command object
        ///</summary>
        ///<returns>THe encrypted command that was supplied</returns>
        public string EncryptCommand(string command)
        {
            //Our initial key value - I wonder where TP-LINK grabbed this from
            int key = 0xAB;

            //Where we're going to store the encrypted message
            StringBuilder commandToSendToDevice = new StringBuilder();
            
            //String needs to be in Latin1 encoding
            var encoded = Encoding.GetEncoding("ISO-8859-1").GetString(Encoding.GetEncoding("ISO-8859-1").GetBytes(CommandString));
            
            //We need to encode every character in the command string
            for(int i = 0; i < CommandString.Length; i++)
            {
                //Take the current character and convert it to its int representation
                var intCommand = Convert.ToInt32(CommandString[i]);

                //XOR the int value of the character with the key
                commandToSendToDevice.Append(Convert.ToChar(intCommand ^ key));

                //Set the key to the Char value of the intCommand XOR'd with the previous key
                key = Convert.ToInt32(Convert.ToChar(intCommand ^ key));
            }

            //Store the result
            ParsedCommandString = commandToSendToDevice.ToString();

            //Return the result of the encryption
            return ParsedCommandString;
        }

        ///<summary>
        ///Decodes the response, storing it locally and returning it
        ///</summary>
        public string DecryptResponse(string responseString)
        {
            //The magic number again
            int key = 0xAB;

            //Where we store the response value
            StringBuilder response = new StringBuilder();

            //For every character in the response
            for (int i = 0; i < responseString.Length; i++)
            {
                //Do our conversion as we did before
                response.Append(Convert.ToChar(responseString[i] ^ key));
                key = Convert.ToChar(responseString[i]);
            }
            //Cache the result
            CachedResponse = response.ToString();
            //Return the decrypted value
            return CachedResponse;
        }

        /// <summary>
        /// Takes the KnownCommand and throws in the parameter values
        /// </summary>
        /// <param name="parameterValues">KeyValue dict containing the parameters and their values</param>
        /// <param name="commandToParameterise">The known command to parameterise</param>
        /// <returns></returns>
        private string CreateCommandWithParameters(Dictionary<string, object> parameterValues, string commandToParameterise)
        {
            foreach (var parameter in parameterValues)
            {
                commandToParameterise = commandToParameterise.Replace(parameter.Key.ToString(), parameter.Value.ToString());
            }

            return commandToParameterise;
        }
    }
}
