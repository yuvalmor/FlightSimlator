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
        // Holds the commands in the autoPilot text box
        private string textCommand;
        public string TextCommand
        {
            get => textCommand;
            set
            {
                // Checks that the property changed
                if (textCommand != value)
                {
                    // Update the property value
                    textCommand = value;
                    NotifyPropertyChanged("textCommand");
                    // Update the length of the text
                    Length = textCommand.Length;
                }
            }
        }
        // Holds the length of the text in the text box
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

        // clear the content in the textbox using the function ClearText
        private ICommand _clearCommand;
        public ICommand ClearCommand {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClearText()));
            }
        }
        // clear the context
        private void ClearText(){TextCommand = Consts.EMPTY_STRING;}
        /*
         * send the commands that written in the textbox to the simulator,
         * using the function SendCommands
        */
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
            // Split all the commands into lines
            string[] lines = textCommand.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                // Checks if the line isnt empty
                if (lines[i] != Consts.EMPTY_STRING)
                {
                    // Add the windows enter suffix to the line ("\r\n")
                    lines[i] += Consts.NEW_LINE;
                    // Write the command to the simulator using the function: writeDataToSimulator
                    client.writeDataToSimulator(lines[i]);
                    // The thread is sleep for 2 seconds
                    Thread.Sleep(Consts.SLEEP_TIME);
                }
            }
        }

        /*
         * Send the commands from the textbox to the simulator
         */
        private void SendCommands()
        {
            // Initial the length of the text to zero
            Length = 0;
            // create new task that points to the autoPilor function
            Task autoPilotTask = new Task(AutoPilot);
            // Start the task
            autoPilotTask.Start();
        }
    }
}
