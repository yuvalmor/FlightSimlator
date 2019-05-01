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
using static FlightSimulator.Views.Joystick;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    public class JoystickViewModel : BaseNotify
    {
        private VirtualJoystickEventArgs model;
        private string info;

        public JoystickViewModel(VirtualJoystickEventArgs model)
        {
            this.model = model;
        }

        public double Rudder
        {
            get { return model.Rudder; }
            set
            {
                model.Rudder = value;
                //info = "Rudder," + model.Rudder.ToString(); 
                //NotifyPropertyChanged(info);
                //info = "";
            }
        }

        public double Throttle
        {
            get { return model.Throttle; }
            set
            {
                model.Throttle = value;
            }
        }

        public double Elevator
        {
            get { return model.Elevator; }
            set
            {
                model.Elevator = value;
            }
        }

        public double Aileron
        {
            get { return model.Aileron; }
            set
            {
                model.Aileron = value;
            }
        }

        public void Vm_JoystickPropertyChanged(Joystick sender, VirtualJoystickEventArgs e)
        {

            this.Aileron = e.Aileron;
            this.Elevator = e.Elevator;

            string aileronData = "set " + Consts.AILERON_XML + " " + this.Aileron.ToString();
            string elevatorData = "set " + Consts.ELEVATOR_XML + " " + this.Elevator.ToString();

            byte[] aileronBuffer = ASCIIEncoding.ASCII.GetBytes(aileronData);
            byte[] elevatorBuffer = ASCIIEncoding.ASCII.GetBytes(elevatorData);

            Client client = Client.Instance;
            //client.writeDataToSimulator(aileronBuffer);
            //client.writeDataToSimulator(elevatorBuffer);

        }


    }
}
