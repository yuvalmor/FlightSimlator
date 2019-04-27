using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.ViewModels;
using FlightSimulator.Utils;
using System.Windows.Input;
using System.ComponentModel;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Communication
{
    public class Server : BaseNotify
    {
        #region Singleton
        private static Server s_Instance = null;
        public static Server Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new Server();
                }
                return s_Instance;
            }
        }
        #endregion

        private TcpListener listener;
        private ISettingsModel settings;

        public SettingsWindowViewModel Settings
        { get; private set; }

        public Server()
        {
            settings = ApplicationSettingsModel.Instance;
            listener = new TcpListener(IPAddress.Parse(settings.FlightServerIP), settings.FlightInfoPort);
        }

        public void listen()
        {
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            Thread listenThread = new Thread(new ParameterizedThreadStart(readDataFromSimulator));
            listenThread.Start();
        }
        
        public void readDataFromSimulator(object client)
        {
            NetworkStream stream = ((TcpClient)client).GetStream();
            int numBytes = 0;
            byte[] buffer = new byte[Consts.BUFFER_SIZE];
            byte[] str = new byte[Consts.BUFFER_SIZE];

            while (numBytes != -1)
            {
                numBytes = stream.Read(buffer, (int)stream.Length, Consts.BUFFER_SIZE);
                if (str.Length > 0 && str != null)
                {
                    str = str.Concat(buffer).ToArray();
                }
                else
                {
                    str = buffer;
                }


                string info = System.Text.Encoding.UTF8.GetString(str, 0, str.Length);
                NotifyPropertyChanged(info);
                
                Array.Clear(buffer, 0, buffer.Length);
            }
        }


    }
}
