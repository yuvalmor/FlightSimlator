using System.Net.Sockets;
using System.Text;
using FlightSimulator.Model;

namespace FlightSimulator.Communication
{
    public class Client
    {
        #region Singleton
        private static Client c_Instance = null;
        public static Client Instance
        {
            get
            {
                if (c_Instance == null)
                {
                    c_Instance = new Client();
                }
                return c_Instance;
            }
        }
        #endregion

        private TcpClient sender;
        private NetworkStream stream;

        public Client()
        {
            sender = new TcpClient();
        }

        public void connect()
        {
            // we open our server (details - channel info -  so the simultor connects as client)
            Server server = Server.Instance;

            // here we wait for a client to arrive at the ip and infoport speceified (we needs to open simulator and run)
            // when we run the simulator also opens it's on server
            server.listen();

            // here we connet as clients to the simultor server, channel command       
            while (true)
            {
                try
                {
                    sender.Connect(ApplicationSettingsModel.Instance.FlightServerIP,
                                    ApplicationSettingsModel.Instance.FlightCommandPort);
                    break;
                } catch
                {
                    continue;
                }
            }
        }

        // send data via command channel
        public void writeDataToSimulator(string data)
        {
            try
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] buffer = asen.GetBytes(data);
                this.stream = sender.GetStream();
                stream.Write(buffer, 0, buffer.Length);
            }
            catch{}
        }

        // close connection when disconnect is hit
        public void closeStream()
        {
            this.stream.Close();
            this.sender.Close();
        }
    }
}
