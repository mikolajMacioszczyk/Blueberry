using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Blueberry.DLL.Models;
using Blueberry.WPF.Enums;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.UserControls
{
    public partial class ColoredCalendar : UserControl
    {
        private ColoredCalendarItem[][] _items;
        private DateTime ActualDate;
        private ObservableCollection<Order> Orders;
        public ColoredCalendar(DateTime startDate, ObservableCollection<Order> orders)
        {
            ActualDate = startDate;
            Orders = orders;
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            Header.Text = ((MonthPolishNames) ActualDate.Month).ToString();

            CalendarGrid.Children.Clear();

            var amounts = GetAmountPerEachDay();
            var brushes = GetBrushesPerEachDay(amounts);
            
            CreateItems(amounts, brushes);
        }

        private void CreateItems(float[] amounts, SolidColorBrush[] brushes)
        {
            _items = new ColoredCalendarItem[CalendarGrid.RowDefinitions.Count][];
            int counter = 0;
            _items[0] = new ColoredCalendarItem[CalendarGrid.ColumnDefinitions.Count];
            var firstDayOfMonth = new DateTime(ActualDate.Year, ActualDate.Month, 1);
            for (int i = (int) firstDayOfMonth.DayOfWeek; i < _items[0].Length; i++)
            {
                InsertDayItem(0, i, counter+1, amounts[counter], brushes[counter++]);
            }
            for (int i = 1; i < _items.Length; i++)
            {
                _items[i] = new ColoredCalendarItem[CalendarGrid.ColumnDefinitions.Count];
                for (int j = 0; j < _items[i].Length  && counter<DateTime.DaysInMonth(ActualDate.Year, ActualDate.Month); j++)
                {
                    InsertDayItem(i, j, counter+1, amounts[counter], brushes[counter++]);
                }
            }
        }

        private void InsertDayItem(int rowIndex, int columnIndex, int dayNumber, float amount, SolidColorBrush brush)
        {
            _items[rowIndex][columnIndex] = new ColoredCalendarItem(
                new ColoredCalendarViewModel(){Day = dayNumber, Amount = amount, Color = brush});
            Grid.SetRow(_items[rowIndex][columnIndex], rowIndex);
            Grid.SetColumn(_items[rowIndex][columnIndex], columnIndex);
            CalendarGrid.Children.Add(_items[rowIndex][columnIndex]);
        }
        
        public float[] GetAmountPerEachDay()
        {
            var data = Orders.Where(o => o.DateOfRealization.Month == ActualDate.Month)
                .Where(o => o.Status == OrderStatus.Waiting)
                .OrderBy(o => o.DateOfRealization).ToList();

            float[] output = new float[DateTime.DaysInMonth(ActualDate.Year, ActualDate.Month)];

            var investigatedDate = new DateTime(ActualDate.Year, ActualDate.Month, 1);

            int outputIndex = 0;
            
            for (int i = 0; i < data.Count; i++)
            {
                while (investigatedDate.Day != data[i].DateOfRealization.Day)
                {
                    output[outputIndex++] = 0;
                    investigatedDate = investigatedDate.AddDays(1);
                }

                float sum = 0;
                while (i < data.Count && investigatedDate.Day == data[i].DateOfRealization.Day)
                {
                    sum += data[i].Amount;
                    i++;
                }
                if (sum > 0.01)
                {
                    i--;
                }
                output[outputIndex++] = sum;

                investigatedDate = investigatedDate.AddDays(1);
            }
            return output;
        }

        public SolidColorBrush[] GetBrushesPerEachDay(float[] amounts)
        {

            SolidColorBrush[] output = new SolidColorBrush[amounts.Length];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = GetBrush(amounts[i]);
            }
            return output;
        }

        private SolidColorBrush GetBrush(float amountPerDay)
        {
            if (Math.Abs(amountPerDay) < 0.01)
            {
                return Brushes.White;
            }

            if (amountPerDay < 10)    
            {
                return Brushes.Green;
            }

            if (amountPerDay < 20)
            {
                return Brushes.DeepSkyBlue;
            }

            if (amountPerDay < 35)
            {
                return Brushes.Yellow;
            }

            if (amountPerDay < 50)
            {
                return Brushes.DarkOrange;
            }

            return Brushes.Red;
        }

        private void PreviousOnClick(object sender, RoutedEventArgs e)
        {
            ActualDate = ActualDate.AddMonths(-1);
            Refresh();
        }
        
        private void NextOnClick(object sender, RoutedEventArgs e)
        {
            ActualDate = ActualDate.AddMonths(1);
            Refresh();
        }
    }
}