using System.ComponentModel;
using System.Runtime.CompilerServices;
using Blueberry.WPF.Annotations;

namespace Blueberry.WPF.UserControls.ColoredCalendarDir
{
    public class ColoredCalendarVM : INotifyPropertyChanged
    {
        

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