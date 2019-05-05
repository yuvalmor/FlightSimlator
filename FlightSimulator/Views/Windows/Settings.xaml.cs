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
        private SettingsWindowViewModel vm;
        public Settings()
        {
            InitializeComponent();
            //vm = new SettingsWindowViewModel(ApplicationSettingsModel.Instance);
            //this.DataContext = vm;
            DataContext=new SettingsWindowViewModel(new ApplicationSettingsModel());
        }

        private void OKCommand_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();*/
            Close();
        }

        private void CancleCommand_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();*/
            Close();
        }
    }
}
