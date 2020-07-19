using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Blueberry.WPF.Annotations;

namespace Blueberry.WPF.UserControls.ColoredCalendarDir
{
    public class CCItemVM : INotifyPropertyChanged
    {
        private int _day;
        public string Day
        {
            get
            {
                if (_day == 0) return "";
                return _day.ToString();
            }
            set
            {
                _day = Convert.ToInt32(value);
                OnPropertyChanged(nameof(Day));
            }
        }
        private SolidColorBrush _color;
        public SolidColorBrush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        private float _amount;
        public string Amount
        {
            get
            {
                if (Math.Abs(_amount) < 0.01) return "";
                return _amount.ToString();
            }
            set
            {
                _amount = (float) Convert.ToDouble(value);
                OnPropertyChanged(nameof(Amount));
            }
        }

        public CCItemVM(int day, SolidColorBrush color, float amount)
        {
            Day = day.ToString();
            Color = color;
            Amount = amount.ToString();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}