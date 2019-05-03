using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.ViewModels;
using FlightSimulator.Model.EventArgs;
using System.ComponentModel;
using FlightSimulator.Communication;
using System.Net.Sockets;
using FlightSimulator.Utils;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for JoystickController.xaml
    /// </summary>
    public partial class JoystickController : UserControl
    {

        private JoystickViewModel vm;

        public JoystickController()
        {
            InitializeComponent();
            
            vm = new JoystickViewModel(VirtualJoystickEventArgs.Instance);
            this.DataContext = vm;


            Joystick.Move += new Joystick.OnScreenJoystickEventHandler(this.Vm_JoystickPropertyChanged);
            
        }
       

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ThrottleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VirtualJoystickEventArgs.Instance.Throttle = ThrottleSlider.Value;

            string throttleData = "set " + Consts.THROTTLE_XML + " " + ThrottleSlider.Value.ToString();
            byte[] throttleBuffer = ASCIIEncoding.ASCII.GetBytes(throttleData);

            Client client = Client.Instance;
            //client.writeDataToSimulator(throttleBuffer);
            
        }

        private void RudderSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VirtualJoystickEventArgs.Instance.Throttle = RudderSlider.Value;

            string rudderData = "set " + Consts.RUDDER_XML + " " + RudderSlider.Value.ToString();
            byte[] rudderBuffer = ASCIIEncoding.ASCII.GetBytes(rudderData);

            Client client = Client.Instance;
            //client.writeDataToSimulator(rudderBuffer);
        }


        public void Vm_JoystickPropertyChanged(Joystick sender, VirtualJoystickEventArgs e)
        {
            this.vm.Aileron = e.Aileron;
            this.vm.Elevator = e.Elevator;

            string aileronData = "set " + Consts.AILERON_XML + " " + this.vm.Aileron.ToString();
            string elevatorData = "set " + Consts.ELEVATOR_XML + " " + this.vm.Elevator.ToString();

            byte[] aileronBuffer = ASCIIEncoding.ASCII.GetBytes(aileronData);
            byte[] elevatorBuffer = ASCIIEncoding.ASCII.GetBytes(elevatorData);

            Client client = Client.Instance;
            //client.writeDataToSimulator(aileronBuffer);
            //client.writeDataToSimulator(elevatorBuffer);
        }

    }
}
