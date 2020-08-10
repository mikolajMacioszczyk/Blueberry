using System;
using System.Windows;
using System.Windows.Input;

namespace Blueberry.WPF.DialogBoxes
{
    public class MessageDialogBox : CommandDialogBox
    {
        public MessageBoxResult? LastResult { get; set; }
        public MessageBoxButton Buttons { get; set; } = MessageBoxButton.OK;
        public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;

        public bool IsLasResultYes
        {
            get
            {
                if (!LastResult.HasValue) return false;
                return LastResult.Value == MessageBoxResult.Yes;
            }
        }
        
        public bool IsLasResultNo
        {
            get
            {
                if (!LastResult.HasValue) return false;
                return LastResult.Value == MessageBoxResult.No;
            }
        }
        
        public bool IsLasResultCancel
        {
            get
            {
                if (!LastResult.HasValue) return false;
                return LastResult.Value == MessageBoxResult.Cancel;
            }
        }
        
        public bool IsLasResultOK
        {
            get
            {
                if (!LastResult.HasValue) return false;
                return LastResult.Value == MessageBoxResult.OK;
            }
        }

        public MessageDialogBox()
        {
            execute = o =>
            {
                LastResult = MessageBox.Show((string) o, Caption, Buttons, Icon);
                OnPropertyChanged(nameof(LastResult));
                switch (LastResult)
                {
                    case MessageBoxResult.OK:
                        OnPropertyChanged(nameof(IsLasResultOK));
                        executeCommand(CommandOk, CommandParameter);
                        break;
                    case MessageBoxResult.Cancel:
                        OnPropertyChanged(nameof(IsLasResultCancel));
                        executeCommand(CommandCancell, CommandParameter);
                        break;
                    case MessageBoxResult.Yes:
                        OnPropertyChanged(nameof(IsLasResultYes));
                        executeCommand(CommandYes, CommandParameter);
                        break;
                    case MessageBoxResult.No:
                        OnPropertyChanged(nameof(IsLasResultNo));
                        executeCommand(CommandNo, CommandParameter);
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };
        }
        
        public static readonly DependencyProperty commandYesProperty =
            DependencyProperty.Register(nameof(CommandYes), typeof(ICommand), typeof(MessageDialogBox));
        public ICommand CommandYes
        {
            get { return (ICommand) GetValue(commandYesProperty); }
            set { SetValue(commandYesProperty, value);}
        }
        
        public static readonly DependencyProperty commandNoProperty =
            DependencyProperty.Register(nameof(CommandNo), typeof(ICommand), typeof(MessageDialogBox));
        public ICommand CommandNo
        {
            get { return (ICommand) GetValue(commandNoProperty); }
            set { SetValue(commandNoProperty, value);}
        }
        
        public static readonly DependencyProperty commandOkProperty =
            DependencyProperty.Register(nameof(CommandOk), typeof(ICommand), typeof(MessageDialogBox));
        public ICommand CommandOk
        {
            get { return (ICommand) GetValue(commandOkProperty); }
            set { SetValue(commandOkProperty, value);}
        }
        
        public static readonly DependencyProperty commandCancellProperty =
            DependencyProperty.Register(nameof(CommandCancell), typeof(ICommand), typeof(MessageDialogBox));
        public ICommand CommandCancell
        {
            get { return (ICommand) GetValue(commandCancellProperty); }
            set { SetValue(commandCancellProperty, value);}
        }
    }
}