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
        private TcpClient client;
        private Task listenTask;

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
            client = listener.AcceptTcpClient();
            listenTask = new Task(readDataFromSimulator);
            listenTask.Start();
            // join? detach?
        }
        
        private void readDataFromSimulator()
        {
            NetworkStream stream = this.client.GetStream();
            int numBytes = 0;
            byte[] buffer = new byte[Consts.BUFFER_SIZE];
            byte[] str = new byte[Consts.BUFFER_SIZE];
            
            string data = "";

            while (numBytes != Consts.READ_FAILED)
            {
                try
                {
                    numBytes = stream.Read(buffer, 0, buffer.Length);
                } catch {
                    return;
                }

                data = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

                string[] filtered = data.Split('\n');
                foreach (string s in filtered)
                {
                    if (String.IsNullOrEmpty(s) || s[0] == '\0' || s.Length == 0 || s == null)
                    {
                        continue;
                    }
                    NotifyPropertyChanged(s);
                }
                Array.Clear(buffer, 0, buffer.Length);
                data = "";
                 
            }
            
        }

        public void closeStream()
        {
            this.client.Close();
            this.listener.Stop();
        }

    }
}
