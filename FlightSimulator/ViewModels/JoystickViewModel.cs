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
            set {
                rudder = value;
            }
        }
        private double throttle;
        public double Throttle {
            set
            {
                throttle = value;
            }
        }
        private double elevator;
        public double Elevator {
            set
            {
                elevator = value;
            }
        }
        private double aileron;
        public double Aileron {
            set
            {
                aileron = value;
            }
        }
    }
}
