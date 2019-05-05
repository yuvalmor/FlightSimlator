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
                this.NotifySliderChanged(Consts.RUDDER);
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
                this.NotifySliderChanged(Consts.THROTTLE);
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
        
        public string prepareStringOfData(string param, double value)
        {
            string data = "set ";
            switch (param)
            {
                case Consts.RUDDER:
                    data += Consts.RUDDER_XML + " " + value + Consts.NEW_LINE;
                    break;
                case Consts.THROTTLE:
                    data += Consts.THROTTLE_XML + " " + value + Consts.NEW_LINE;
                    break;
                case Consts.ELEVATOR:
                    data += Consts.ELEVATOR_XML + " " + value + Consts.NEW_LINE;
                    break;
                case Consts.AILERON:
                    data += Consts.AILERON_XML + " " + value + Consts.NEW_LINE;
                    break;
                default:
                    return "";
            }
            return data;
        }

        public void backToPlace(Joystick sender)
        {
            string dataAileron = this.prepareStringOfData(Consts.AILERON, sender.Aileron);
            string dataElevator = this.prepareStringOfData(Consts.ELEVATOR, sender.Elevator);

            Client client = Client.Instance;
            client.writeDataToSimulator(dataAileron);
            client.writeDataToSimulator(dataElevator);
        }

        public void NotifyJoystickChanged(Joystick sender, VirtualJoystickEventArgs args)
        {
            string dataAileron = this.prepareStringOfData(Consts.AILERON, args.Aileron);
            string dataElevator = this.prepareStringOfData(Consts.ELEVATOR, args.Elevator);
            
            Client client = Client.Instance;
            client.writeDataToSimulator(dataAileron);
            client.writeDataToSimulator(dataElevator);
        }

        public void NotifySliderChanged(string param)
        {
            string data = "";
            Client client = Client.Instance;

            if (param.Equals("Rudder"))
            {
                data = this.prepareStringOfData("Rudder", this.rudder);
                client.writeDataToSimulator(data);
                return;
            }
            data = this.prepareStringOfData("Throttle", this.throttle);
            client.writeDataToSimulator(data);
        }
       
    }
}
