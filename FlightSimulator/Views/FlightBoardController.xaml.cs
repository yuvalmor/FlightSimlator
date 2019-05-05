using FlightSimulator.ViewModels;
using System.Windows.Controls;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for FlightBoardController.xaml
    /// </summary>
    public partial class FlightBoardController : UserControl
    {
        private FlightBoardViewModel vm;
        public FlightBoardController()
        {
            InitializeComponent();
            vm = new FlightBoardViewModel();
            // data contex to the binding fields in the xaml
            this.DataContext = vm;
        }
    }
}
