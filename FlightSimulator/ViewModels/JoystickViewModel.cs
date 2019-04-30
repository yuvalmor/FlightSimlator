using FlightSimulator.Communication;
using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model.EventArgs;

namespace FlightSimulator.ViewModels
{
    public class JoystickViewModel : BaseNotify
    {
        private VirtualJoystickEventArgs model;
        private string var;

        public JoystickViewModel(VirtualJoystickEventArgs model)
        {
            this.model = model;
            var = "";
        }

        public double Rudder
        {
            get { return model.Rudder; }
            set
            {
                model.Rudder = value;
                var = "Rudder," + model.Rudder.ToString(); 
                NotifyPropertyChanged(var);
                var = "";
            }
        }

        public double Throttle
        {
            get { return model.Throttle; }
            set
            {
                model.Throttle = value;
                var = "Throttle," + model.Throttle.ToString();
                NotifyPropertyChanged(var);
                var = "";
            }
        }

        public double Elevator
        {
            get { return model.Elevator; }
            set
            {
                model.Elevator = value;
                var = "Rudder," + model.Elevator.ToString();
                NotifyPropertyChanged(var);
                var = "";
            }
        }


    }
}
