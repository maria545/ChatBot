using System;
using System.Globalization;
using System.Windows.Data;

namespace ChatBot
{
    class ConvertidorFondo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "Usuario")
            {
                return "PaleGreen";
            }
            else return "Aquamarine";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
