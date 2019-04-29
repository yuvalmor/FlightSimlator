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
        #endregion
    }
}
