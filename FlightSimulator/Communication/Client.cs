using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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
                    sender.Connect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort);
                    break;
                } catch
                {
                    continue;
                }
            }
            
        }

        public void writeDataToSimulator(string data)
        {
            try
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] buffer = asen.GetBytes(data);
                NetworkStream stream = sender.GetStream();
                stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                // print a message?
            }

        }
    }
}
