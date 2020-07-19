using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.UserControls.ColoredCalendarDir
{
    public class ColoredCalendarVM : INotifyPropertyChanged
    {
        private static int itemsColumnLength = 7;
        private static int itemsRowLength = 5;

        #region Properties

        private DateTime _actualDate;
        private ICommand _previousCommand;
        private ICommand _nextCommand;
        private bool _isLastWeekVisible;

        public bool IsLastWeekVisible
        {
            get => _isLastWeekVisible;
            set
            {
                _isLastWeekVisible = value;
                OnPropertyChanged(nameof(IsLastWeekVisible));
            }
        }

        #region Weeks

        private CCWeekVM[] items = new CCWeekVM[6];

        public CCWeekVM Week1
        {
            get => items[0];
            set
            {
                items[0] = value;
                OnPropertyChanged(nameof(Week1));
            }
        }

        public CCWeekVM Week2
        {
            get => items[1];
            set
            {
                items[1] = value;
                OnPropertyChanged(nameof(Week2));
            }
        }

        public CCWeekVM Week3
        {
            get => items[2];
            set
            {
                items[2] = value;
                OnPropertyChanged(nameof(Week3));
            }
        }

        public CCWeekVM Week4
        {
            get => items[3];
            set
            {
                items[3] = value;
                OnPropertyChanged(nameof(Week4));
            }
        }

        public CCWeekVM Week5
        {
            get => items[4];
            set
            {
                items[4] = value;
                OnPropertyChanged(nameof(Week5));
            }
        }

        public CCWeekVM Week6
        {
            get => items[5];
            set
            {
                items[5] = value;
                OnPropertyChanged(nameof(Week6));
            }
        }

        #endregion

        public ICommand PreviousCommand
        {
            get
            {
                if (_previousCommand == null)
                {
                    _previousCommand = new RelayCommand(
                        p => true,
                        p => ActualDate = ActualDate.AddMonths(-1));
                }

                return _previousCommand;
            }
        }

        public ICommand NextCommand
        {
            get
            {
                if (_nextCommand == null)
                {
                    _nextCommand = new RelayCommand(
                        p => true,
                        p => ActualDate = ActualDate.AddMonths(1)
                    );
                }

                return _nextCommand;
            }
        }

        public string MonthName { get; set; }

        public DateTime ActualDate
        {
            get => _actualDate;
            set
            {
                _actualDate = value;
                OnPropertyChanged(nameof(ActualDate));
                MonthName = ((MonthPolishNames) ActualDate.Month).ToString();
                OnPropertyChanged(nameof(MonthName));
                Refresh();
            }
        }

        #endregion

        public ColoredCalendarVM()
        {
            ActualDate = DateTime.Now;
            DBConnector.GetInstance().OrdersChanged += Refresh;
        }

        private void Refresh()
        {
            Clear();
            var amounts = GetAmountPerEachDay();
            var brushes = GetBrushesPerEachDay(amounts);
            CreateItems(amounts, brushes);
        }

        private void Clear()
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new CCWeekVM();
            }
            IsLastWeekVisible = false;
        }

        private void CreateItems(float[] amounts, SolidColorBrush[] brushes)
        {
            int counter = 0;
            var firstDayOfMonth = new DateTime(ActualDate.Year, ActualDate.Month, 1);
            var week = items[0];
            for (int i = 0; i < (int) firstDayOfMonth.DayOfWeek - 1; i++)
            {
                week.Add(new CCItemVM(0, Brushes.White, 0));
            }

            for (int i = (int) firstDayOfMonth.DayOfWeek - 1; i < itemsColumnLength; i++)
            {
                week.Add(new CCItemVM(counter + 1, brushes[counter], amounts[counter++]));
            }

            OnPropertyChanged(nameof(Week1));
            for (int i = 1; i < itemsRowLength; i++)
            {
                AddWeek(i, ref counter, brushes, amounts);
            }
        }

        private void AddWeek(int weekIdx, ref int counter, SolidColorBrush[] brushes, float[] amounts)
        {
            for (int j = 0;
                j < itemsColumnLength && counter < DateTime.DaysInMonth(ActualDate.Year, ActualDate.Month);
                j++)
            {
                items[weekIdx].Add(new CCItemVM(counter + 1, brushes[counter], amounts[counter++]));
                if (weekIdx == 5 && !_isLastWeekVisible)
                    IsLastWeekVisible = true;
            }
            switch (weekIdx)
            {
                case 1:
                    OnPropertyChanged(nameof(Week2));
                    break;
                case 2:
                    OnPropertyChanged(nameof(Week3));
                    break;
                case 3:
                    OnPropertyChanged(nameof(Week4));
                    break;
                case 4:
                    OnPropertyChanged(nameof(Week5));
                    break;
                case 5:
                    OnPropertyChanged(nameof(Week6));
                    break;
            }
        }

        #region ItemsData

        private float[] GetAmountPerEachDay()
        {
            var orders = DBConnector.GetInstance().GetOrders();
            var data = orders.Where(o => o.DateOfRealization.Month == ActualDate.Month)
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

        private SolidColorBrush[] GetBrushesPerEachDay(float[] amounts)
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

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}