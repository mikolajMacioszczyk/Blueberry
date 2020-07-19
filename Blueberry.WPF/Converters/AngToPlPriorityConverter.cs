using System;
using System.Globalization;
using System.Windows.Data;
using Blueberry.DLL.Enums;
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
                    return PriorityPolishNames.Niski;
                case Priority.MiddlePriority:
                    return PriorityPolishNames.Średni;
                case Priority.HighPriority:
                    return PriorityPolishNames.Wysoki;
                case Priority.UlitimatePriority:
                    return PriorityPolishNames.BardzoWysoki;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            PriorityPolishNames priority = (PriorityPolishNames) Enum.Parse(typeof(PriorityPolishNames), value.ToString());
            switch (priority)
            {
                case PriorityPolishNames.Niski:
                    return Priority.LowPriority;
                case PriorityPolishNames.Średni:
                    return Priority.MiddlePriority;
                case PriorityPolishNames.Wysoki:
                    return Priority.HighPriority;
                case PriorityPolishNames.BardzoWysoki:
                    return Priority.UlitimatePriority;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}