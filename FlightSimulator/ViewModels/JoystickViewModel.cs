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
                rudder = value;
                this.NotifySliderChanged("Rudder");
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
                throttle = value;
                this.NotifySliderChanged("Throttle");
            }
        }
        private double elevator;
        public double Elevator {
            private get { return elevator; }
            set {elevator = value; }
        }
        private double aileron;
        public double Aileron {
            private get { return aileron; }
            set { aileron = value; }
        }
        
        public void NotifyJoystickChanged(Joystick sender, VirtualJoystickEventArgs args)
        {
            string dataAileron = "set ";
            string dataElevator = "set ";

            dataAileron += Consts.AILERON_XML + " " + args.Aileron + Consts.NEW_LINE;
            dataElevator += Consts.ELEVATOR_XML + " " + args.Elevator + Consts.NEW_LINE;
            
            Client client = Client.Instance;
            client.writeDataToSimulator(dataAileron);
            client.writeDataToSimulator(dataElevator);
        }

        public void NotifySliderChanged(string param)
        {
            string data = "set ";
            if (param.Equals("Rudder"))
            {
                data += Consts.RUDDER_XML + " " + this.rudder + Consts.NEW_LINE;
            } else
            {
                data += Consts.THROTTLE_XML + " " + this.throttle + Consts.NEW_LINE;
            }
            Client client = Client.Instance;
            client.writeDataToSimulator(data);
        }
    }
}
