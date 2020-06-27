using System;
using System.Globalization;
using System.Windows.Data;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class AngToPlPriorityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }

            Priority priority = (Priority) Enum.Parse(typeof(Priority), value.ToString());
            switch (priority)
            {
                case Priority.LowPriority:
                    return "Niski";
                case Priority.MiddlePriority:
                    return "Średni";
                case Priority.HighPriority:
                    return "Wysoki";
                case Priority.UlitimatePriority:
                    return "Bardzo Wysoki";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}