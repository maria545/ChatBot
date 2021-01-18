using System;
using System.Globalization;
using System.Windows.Data;

namespace ChatBot
{
    class ConvertidorIcono : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "Usuario")
            {
                return "/Imagenes/hombre.png";
            }
            else return "/Imagenes/robot.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
