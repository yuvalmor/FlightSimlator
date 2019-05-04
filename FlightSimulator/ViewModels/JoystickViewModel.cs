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
using System.ComponentModel;
using FlightSimulator.Utils;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    public class JoystickViewModel
    {
        private double rudder;
        public double Rudder{
            private get
            {
                return rudder;
            }
            set {

                double newRudder = value;
                if (newRudder - rudder > 0)
                {
                    rudder = newRudder;
                    NotifyPropertyChanged("Rudder");
                }
                else
                {
                    rudder = value;
                }
            }
        }
        private double throttle;
        public double Throttle {
            private get
            {
                return throttle;
            }
            set
            {
                double newThrottle = value;
                if (newThrottle - throttle > 0)
                {
                    throttle = newThrottle;
                    NotifyPropertyChanged("Throttle");
                }
                else
                {
                    throttle = value;
                }
            }
        }
        private double elevator;
        public double Elevator {
            private get
            {
                return elevator;
            }
            set
            {
                double newElevator = value;
                if (newElevator - elevator > 0)
                {
                    elevator = newElevator;
                    NotifyPropertyChanged("Elevator");
                }
                else
                {
                    elevator = value;
                }
            }
        }
        private double aileron;
        public double Aileron {
            private get
            {
                return aileron;
            }
            set
            {
                double newAileron = value;
                if (newAileron - aileron > 0)
                {
                    aileron = newAileron;
                    NotifyPropertyChanged("Aileron");
                }
                else
                {
                    aileron = value;
                }
            }
        }
        
        public void NotifyPropertyChanged(string propName)
        {

            string data = "set ";

            switch (propName)
            {
                case "Rudder":
                    data += Consts.RUDDER_XML + " " + this.Rudder.ToString() + Consts.NEW_LINE;
                    break;
                case "Elevator":
                    data += Consts.ELEVATOR_XML + " " + this.Elevator.ToString() + Consts.NEW_LINE;
                    break;
                case "Aileron":
                    data += Consts.AILERON_XML + " " + this.Aileron.ToString() + Consts.NEW_LINE;
                    break;
                case "Throttle":
                    data += Consts.THROTTLE_XML + " " + this.Throttle.ToString() + Consts.NEW_LINE;
                    break;
                default:
                    return;


            }

            Client client = Client.Instance;
            client.writeDataToSimulator(data);
            
        }


    }
}
