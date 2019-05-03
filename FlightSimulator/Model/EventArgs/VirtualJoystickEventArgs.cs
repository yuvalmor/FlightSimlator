using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.EventArgs
{
    public class VirtualJoystickEventArgs
    {
        
        #region Singleton
        private static VirtualJoystickEventArgs j_Instance = null;
        public static VirtualJoystickEventArgs Instance
        {
            get
            {
                if (j_Instance == null)
                {
                    j_Instance = new VirtualJoystickEventArgs();
                }
                return j_Instance;
            }
        }
        #endregion
        

        public double Aileron { get; set; }
        public double Elevator { get; set; }
        public double Rudder { get; set; }
        public double Throttle { get; set; }
    }
}
