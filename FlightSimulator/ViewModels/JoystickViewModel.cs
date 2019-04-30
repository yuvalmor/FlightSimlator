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
        private string info;

        public JoystickViewModel(VirtualJoystickEventArgs model)
        {
            this.model = model;
            info = "";
        }

        public double Rudder
        {
            get { return model.Rudder; }
            set
            {
                model.Rudder = value;
                info = "Rudder," + model.Rudder.ToString(); 
                NotifyPropertyChanged(info);
                info = "";
            }
        }

        public double Throttle
        {
            get { return model.Throttle; }
            set
            {
                model.Throttle = value;
                info = "Throttle," + model.Throttle.ToString();
                NotifyPropertyChanged(info);
                info = "";
            }
        }

        public double Elevator
        {
            get { return model.Elevator; }
            set
            {
                model.Elevator = value;
                info = "Rudder," + model.Elevator.ToString();
                NotifyPropertyChanged(info);
                info = "";
            }
        }


    }
}
