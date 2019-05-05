using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using FlightSimulator.Communication;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        ObservableDataSource<Point> planeLocations = null;

        public FlightBoard()
        {
            InitializeComponent();

            Server server = Server.Instance;
            server.PropertyChanged += this.Vm_PropertyChanged;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);
            plotter.AddLineGraph(planeLocations,2,"Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string check = e.PropertyName;
            string[] fields = e.PropertyName.Split(',');
            double lon = Double.Parse(fields[0]);
            double lat = Double.Parse(fields[1]);
            Point p1 = new Point(lat, lon);
            planeLocations.AppendAsync(Dispatcher, p1);
        }

    }

}

