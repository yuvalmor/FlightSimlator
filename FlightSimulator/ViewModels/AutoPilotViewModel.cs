using FlightSimulator.Communication;
using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        private int length; 
        private string textCommand;
        public string TextCommand
        {
            get=> textCommand; 
            set
            {
                if (textCommand != value)
                {
                    textCommand = value;
                    NotifyPropertyChanged("textCommand");
                    Length = textCommand.Length;
                }
            }
        }

        public int Length
        {
            get => length;
            set
            {
                length = value;
                NotifyPropertyChanged("length");
            }
        }
        private ICommand _clearCommand;
        public ICommand ClearCommand {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClearText()));
            }
        }

        private void ClearText()
        {
            TextCommand = "";
        }

        private ICommand _okCommand;
        public ICommand OKCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => SendCommands()));
            }
        }


        private void AutoPilot()
        {
            Client client = Client.Instance;
            string[] lines = textCommand.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    lines[i] += "\r\n";
                    client.writeDataToSimulator(lines[i]);
                    Thread.Sleep(2000);
                }
            }
        }

        private void SendCommands()
        {
            Length = 0;
            Thread thread = new Thread(AutoPilot);
            thread.Start();
        }
    }
}
