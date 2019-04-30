﻿using System;
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
            // we open our server (details - channel info -  so the simultor connects as client)
            Server server = Server.Instance;

            // here we wait for a client to arrive at the ip and infoport speceified (we needs to open simulator and run)
            // when we run the simulator also opens it's on server
            server.listen();

            /*
            while (true)
            {
                // here we connet as clients to the simultor server, channel command
                sender.Connect(server.Settings.FlightServerIP, server.Settings.FlightCommandPort);
            }
            */
        }

    }



}
