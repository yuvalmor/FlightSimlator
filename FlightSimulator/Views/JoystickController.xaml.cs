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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for JoystickController.xaml
    /// </summary>
    public partial class JoystickController : UserControl
    {

        public JoystickController()
        {
            InitializeComponent();

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
    }
}
