using System.Windows.Controls;
using FlightSimulator.ViewModels;

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
            DataContext = new JoystickViewModel();
        }
    }
}
