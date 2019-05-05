﻿using System.Windows.Controls;
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
            this.DataContext = vm;
            joystick.Moved += vm.NotifyJoystickChanged;
        }




    }
}
