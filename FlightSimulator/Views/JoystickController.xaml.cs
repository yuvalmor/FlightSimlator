using System.Windows.Controls;
using FlightSimulator.ViewModels;

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
            // data contex to the binding fields in the xaml
            this.DataContext = vm;
            // subscribe to both events 
            joystick.Moved += vm.NotifyJoystickChanged;
            joystick.Released += vm.backToPlace;
        }
    }
}
