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
using System.Windows.Shapes;
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.Model;
using System.ComponentModel;

namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        //private SettingsWindowViewModel vm;
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
