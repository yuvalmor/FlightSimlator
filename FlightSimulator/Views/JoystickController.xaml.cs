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
        private JoystickViewModel vm;
        public JoystickController()
        {
            InitializeComponent();
            vm = new JoystickViewModel(VirtualJoystickEventArgs.Instance);
            this.DataContext = vm;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            Server server = Server.Instance;
            TcpClient client = new TcpClient(server.Settings.FlightServerIP, server.Settings.FlightCommandPort);
            NetworkStream stream = client.GetStream();

            string[] parser = e.PropertyName.Split(',');
            string data = "set ";
            
            switch (parser[0])
            {
                case "Rudder":
                    data += Consts.RUDDER_XML;
                    break;
                case "Throttle":
                    data += Consts.THROTTLE_XML;
                    break;
                case "Aileron":
                    data += Consts.AILERON_XML;
                    break;
                case "Elevator":
                    data += Consts.ELEVATOR_XML;
                    break;
                default:
                    return;

            }

            data+= " " + parser[1];
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(data);

            stream.Write(buffer, 0, buffer.Length);
       
        }
    }
}
