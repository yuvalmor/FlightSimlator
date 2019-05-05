using FlightSimulator.Communication;
using FlightSimulator.Model;
using System;
using System.Threading;
using System.Windows.Input;
using FlightSimulator.Utils;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        private string textCommand;
        public string TextCommand
        {
            get => textCommand;
            set
            {
                if (textCommand != value)
                {
                    textCommand = value;
                    NotifyPropertyChanged("textCommand");
                    // Update the length of the text
                    Length = textCommand.Length;
                }
            }
        }

        private int length;
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
                // Checks if the line isnt empty
                if (lines[i] != Consts.EMPTY_STRING)
                {
                    lines[i] += Consts.NEW_LINE;
                    client.writeDataToSimulator(lines[i]);
                    Thread.Sleep(Consts.SLEEP_TIME);
                }
            }
        }

        private void SendCommands()
        {
            Length = 0;
            Task autoPilotTask = new Task(AutoPilot);
            autoPilotTask.Start();
        }
    }
}
