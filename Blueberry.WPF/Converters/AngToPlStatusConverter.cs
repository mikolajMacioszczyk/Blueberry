using System;
using System.Globalization;
using System.Windows.Data;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.Converters
{
    [ValueConversion(typeof(OrderStatus), typeof(OrderStatusPolishNames))]
    public class AngToPlStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value is OrderStatus ? (OrderStatus) value : OrderStatus.Waiting;
            switch (status)
            {
                case OrderStatus.Waiting:
                    return OrderStatusPolishNames.Oczekujący;
                case OrderStatus.Realized:
                    return OrderStatusPolishNames.Zrealizowany;
                case OrderStatus.Cancelled:
                    return OrderStatusPolishNames.Anulowany;
                case OrderStatus.Postponed:
                    return OrderStatusPolishNames.Przełożony;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value is OrderStatusPolishNames ? (OrderStatusPolishNames) value : OrderStatusPolishNames.Oczekujący;
            switch (status)
            {
                case OrderStatusPolishNames.Oczekujący:
                    return OrderStatus.Waiting;
                case OrderStatusPolishNames.Zrealizowany:
                    return OrderStatus.Realized;
                case OrderStatusPolishNames.Anulowany:
                    return OrderStatus.Cancelled;
                case OrderStatusPolishNames.Przełożony:
                    return OrderStatus.Postponed;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}