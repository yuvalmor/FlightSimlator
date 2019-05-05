using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    class LengthToBackgtoundConverter : IValueConverter
    {
        /*
         * The converter return pink brush if the accepten value is larger then zero,
         * And white brush otherwise.
         */
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BrushConverter converter = new BrushConverter();
            if ((int)value > 0) 
                    return converter.ConvertFromString("#ffc5d6") as Brush;
                else
                    return converter.ConvertFromString("#FFFFFF") as Brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
