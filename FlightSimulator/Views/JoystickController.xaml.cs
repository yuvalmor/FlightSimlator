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
        JoystickViewModel vm;
        public JoystickController()
        {
            InitializeComponent();
            vm = new JoystickViewModel();
            this.DataContext = vm;

            joystick.Moved += vm.NotifyJoystickChanged;
            joystick.Released += vm.backToPlace;
        }

    }
}
