using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.ViewModels;
using FlightSimulator.Utils;
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
        private NetworkStream stream;
        private Task listenTask;

        public SettingsWindowViewModel Settings
        { get; private set; }

        public Server()
        {
            settings = ApplicationSettingsModel.Instance;
            listener = new TcpListener(IPAddress.Parse(settings.FlightServerIP), settings.FlightInfoPort);       
        }

        // wait for client and open task of reading data from client
        public void listen()
        {
            listener.Start();
            client = listener.AcceptTcpClient();
            listenTask = new Task(readDataFromSimulator);
            listenTask.Start();
        }
        
        // read the bytes from the simulator client and notify properties changed
        private void readDataFromSimulator()
        {
            this.stream = this.client.GetStream();
            int numBytes = 0;
            byte[] buffer = new byte[Consts.BUFFER_SIZE];
            byte[] str = new byte[Consts.BUFFER_SIZE];
            string data = "";
            // reading bytes while there is no error
            while (numBytes != Consts.READ_FAILED)
            {
                try
                {
                    // read byes from socket
                    numBytes = stream.Read(buffer, 0, buffer.Length);
                } catch {
                    return;
                }

                // create string from bytes
                data = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                // create array of line data
                string[] filtered = data.Split('\n');
                // sending each line for update
                foreach (string s in filtered)
                {
                    if (String.IsNullOrEmpty(s) || s[0] == '\0' || s.Length == 0 || s == null)
                    {
                        continue;
                    }
                    NotifyPropertyChanged(s);
                }
                // prepare for next iteration
                Array.Clear(buffer, 0, buffer.Length);
                data = "";
            }
        }

        // close connection when we want to disconnect
        public void closeStream()
        {
            this.stream.Close();
            this.client.Close();
            this.listener.Stop();
        }
    }
}
