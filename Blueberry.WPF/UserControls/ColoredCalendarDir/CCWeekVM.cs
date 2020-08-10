using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Blueberry.WPF.Annotations;

namespace Blueberry.WPF.UserControls.ColoredCalendarDir
{
    public class CCWeekVM : INotifyPropertyChanged, IEnumerable<CCItemVM>
    {
        #region DayProperties
        public CCItemVM Day1
        {
            get => _days[0];
            set
            {
                _days[0] = value;
                OnPropertyChanged(nameof(Day1));
            }
        }
        public CCItemVM Day2
        {
            get => _days[1];
            set
            {
                _days[1]= value;
                OnPropertyChanged(nameof(Day2));
            }
        }
        public CCItemVM Day3
        {
            get => _days[2];
            set
            {
                _days[2] = value;
                OnPropertyChanged(nameof(Day3));
            }
        }
        public CCItemVM Day4
        {
            get => _days[3];
            set
            {
                _days[3] = value;
                OnPropertyChanged(nameof(Day4));
            }
        }
        public CCItemVM Day5
        {
            get => _days[4];
            set
            {
                _days[4] = value;
                OnPropertyChanged(nameof(Day5));
            }
        }
        public CCItemVM Day6
        {
            get => _days[5];
            set
            {
                _days[5] = value;
                OnPropertyChanged(nameof(Day6));
            }
        }
        public CCItemVM Day7
        {
            get => _days[6];
            set
            {
                _days[6] = value;
                OnPropertyChanged(nameof(Day7));
            }
        }
        #endregion
        private CCItemVM[] _days = new CCItemVM[7];
        private int currentIdx = 0;
        public void Add(CCItemVM itemVm)
        {
            _days[currentIdx++ % 7] = itemVm;
        }

        public IEnumerator<CCItemVM> GetEnumerator()
        {
            return (IEnumerator<CCItemVM>) _days.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}