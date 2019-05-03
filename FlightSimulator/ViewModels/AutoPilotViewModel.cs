using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void SendCommands()
        {
            Length = 0;
        }

    }
}
