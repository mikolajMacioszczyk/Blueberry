using System;
using System.Globalization;
using System.Windows.Data;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.Converters
{
    [ValueConversion(typeof(Address), typeof(string))]
    public class AddressToStringPConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Address address = value as Address;
            if (address != null) return $"Miasto: {address.City}, Ul: {address.Street}, Dom: {address.House}";
            return "";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}