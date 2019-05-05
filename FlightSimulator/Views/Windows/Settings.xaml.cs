using System.Windows;
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.Model;

namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            // inserting the app model to the vm instance
            DataContext=new SettingsWindowViewModel(new ApplicationSettingsModel());
        }

        // closing the settings window after saving the data
        private void OKCommand_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // closing the settings window after cancel click
        private void CancleCommand_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
