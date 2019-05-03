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
                }
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
    }
}
