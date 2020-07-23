using LampEngine.Commands;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace LampEngine
{
    public class Bulb : IBulb
    {
        public BulbInformation BulbInformation { get; set; }
        public bool powerState { get; private set; }
        public IPAddress networkAddress { get; set; }

        public string GetNetworkAddress() => networkAddress.ToString();

        /// <summary>
        /// Constructor taking a string instead of IPAddress object
        /// </summary>
        /// <param name="ipaddress">IPAddress string</param>
        public Bulb(string ipaddress)
        {
            var address = ipaddress.Split('.');
            networkAddress = new System.Net.IPAddress(new byte[] {
                Convert.ToByte(address[0]),
                Convert.ToByte(address[1]),
                Convert.ToByte(address[2]),
                Convert.ToByte(address[3])});
        }
        /// <summary>
        /// Constructor that takes an IPAddress object already created
        /// </summary>
        /// <param name="ipAddress"></param>
        public Bulb(IPAddress ipAddress) => (networkAddress, BulbInformation) = (ipAddress, GetBulbInfo());

        /// <summary>
        /// Send the current bulb command, returning the response as a JSON string
        /// </summary>
        /// <param name="command">The command to be sent to the bulb</param>
        /// <returns>JSON response from the device</returns>
        public string SendQuery(BulbCommand command)
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
                return command.DecryptResponse(resultString);
            }
            catch (Exception e)
            {
                //What a crude way of handling this
                Console.WriteLine(e);
            }
            return null;
        }

        /// <summary>
        /// Returns an object of type T which is the parsed result of the query
        /// </summary>
        /// <typeparam name="T">Type which the result will parse into</typeparam>
        /// <param name="command">The command to be sent to the bulb</param>
        /// <returns>Result of </returns>
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
                byte[] buffer = new byte[2048];

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

        public async Task<T> SendQueryAsync<T>(BulbCommand command)
        {
            var encryptedCommand = command.EncryptCommand();
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(networkAddress, 9999);

            socket.SendToAsync(new SocketAsyncEventArgs());
            return default(T);
        }

        public BulbInformation GetBulbInfo()
        {
            var getSystemInfo = new GetSystemInfo();
            var result = SendQuery<BulbSystemDTO>(getSystemInfo);

            //Cache the bulb information
            BulbInformation = result.AsBulbInformation();

            //Return the bulb information
            return BulbInformation;
        }

        public bool isNetworked() => new Ping().Send(networkAddress.ToString()).Status == IPStatus.Success ? true : false;

        public OperationResult SetAlias(string AliasToSet)
        {
            var setAlias = new SetAlias(AliasToSet);
            var result = SendQuery<SetAliasDTO>(setAlias);
            return new OperationResult(result.GetErrorCode().Value);
        }

        public OperationResult Reboot(int delay)
        {
            var reboot = new Reboot(delay);
            var result = SendQuery<RebootDTO>(reboot);
            return new OperationResult(result.ErrorCode);
        }
        /// <summary>
        /// Sets the brightness of the bulb
        /// </summary>
        /// <param name="colour">A lightstate containing the desired colour</param>
        /// <returns></returns>
        public LightState SetBrightness(int brightness)
        {
            var currentLight = GetColour();
            currentLight.Brightness = brightness;
            var command = new SetColour(currentLight);
            var result = SendQuery(command);

            //Take result and convert it to a result object
            return JsonConvert.DeserializeObject<LightingDTO<LightTransitionState>>(result).LightingService.LightStateDTO.AsLightState();
        }

        /// <summary>
        /// Gets the current colour of the bulb
        /// </summary>
        /// <returns>A LightState containing bulb colour information</returns>
        public LightState GetColour()
        {
            var command = new GetColour();
            return SendQuery<LightingDTO<GetLightStateDTO>>(command).LightingService.LightStateDTO.AsLightState();
        }

        public OperationResult TogglePower()
        {
            var currentLightState = GetColour();
            var toggle = (currentLightState.OnOff.Equals(0) ? 1 : 0);
            var oldColourNewPower = currentLightState;
            oldColourNewPower.OnOff = toggle;
            Console.WriteLine($"Result of operation: {SetColour(oldColourNewPower)}");
            return new OperationResult(0);
        }

        /// <summary>
        /// Sets the colour of the bulb. For a non coloured bulb a Hue value will be ignored
        /// </summary>
        /// <returns>A LightState containing bulb colour information</returns>
        private String SetColour(LightState colour)
        {
            var command = new SetColour(colour);
            var result = SendQuery(command);

            return result;
        }
    }
}