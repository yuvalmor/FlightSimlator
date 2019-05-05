using FlightSimulator.Communication;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        public double Lon {get; }
        public double Lat { get; }

        #region Commands
        // connect commad - send to creation of server and client linking
        #region ConnectCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            set { }
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));
            }
        }

        private void OnConnect()
        {
            Client client = Client.Instance;
            client.connect();
        }

        #endregion
        // settings command - change settings data
        #region SettingsCommand

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            set { }
            get
            {
                return _settingsCommand ?? (_settingsCommand = new CommandHandler(() => OnSettings()));
            }
        }

        private void OnSettings()
        {
            Settings window = new Settings();
            window.ShowDialog();
        }

        #endregion
        // disconnect command - close the sockets
        #region DisConnectCommand

        private ICommand _disconnectCommand;
        public ICommand DisConnectCommand
        {
            set { }
            get
            {
                return _disconnectCommand ?? (_disconnectCommand = new CommandHandler(() => OnDisConnect()));
            }
        }

        private void OnDisConnect()
        {
            Server server = Server.Instance;
            server.closeStream();
            Client client = Client.Instance;
            client.closeStream();
        }

        #endregion
        #endregion
    }
}
