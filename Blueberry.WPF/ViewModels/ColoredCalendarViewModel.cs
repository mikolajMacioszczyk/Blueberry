using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Blueberry.WPF.Annotations;

namespace Blueberry.WPF.ViewModels
{
    public class ColoredCalendarViewModel : INotifyPropertyChanged
    {
        public int Day { get; set; }
        public SolidColorBrush Color { get; set; }
        public float Amount { get; set; }

        public ColoredCalendarViewModel() { }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}