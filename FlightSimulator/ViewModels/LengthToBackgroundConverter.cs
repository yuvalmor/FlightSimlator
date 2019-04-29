using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    class LengthToBackgtoundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BrushConverter converter = new BrushConverter();
            string s = value as string;
            if (value == null)
                return converter.ConvertFromString("#FFFFFF") as Brush;
            else
            {
                int i = s.Length;
                if (i > 0)
                    return converter.ConvertFromString("#ffc5d6") as Brush;
                else
                    return converter.ConvertFromString("#FFFFFF") as Brush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
