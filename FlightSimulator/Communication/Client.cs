using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
            Server server = Server.Instance;
            server.listen();
            sender.Connect(server.Settings.FlightServerIP, server.Settings.FlightInfoPort);
        }

    }



}
