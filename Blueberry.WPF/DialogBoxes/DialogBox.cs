using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.DialogBoxes
{
    public abstract class DialogBox : FrameworkElement,INotifyPropertyChanged
    {
        #region INotifyPropertChnaged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        protected Action<object> execute = null;
        
        protected static readonly DependencyProperty captionProperty =
            DependencyProperty.Register(nameof(Caption), typeof(string), typeof(DialogBox), new PropertyMetadata(""));
        public string Caption
        {
            get { return (string) GetValue(captionProperty); }
            set{ SetValue(captionProperty, value);}
        }
        protected ICommand show;

        public virtual ICommand Show
        {
            get
            {
                if (show == null) 
                    show = new RelayCommand(
                        p => true, 
                        p => execute.Invoke(p));
                return show;
            }
        }
    }
}