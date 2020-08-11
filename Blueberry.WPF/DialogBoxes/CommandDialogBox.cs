using System;
using System.Windows;
using System.Windows.Input;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.DialogBoxes
{
    public class CommandDialogBox : DialogBox
    {
        public override ICommand Show
        {
            get
            {
                if (show == null)
                {
                    show = new RelayCommand(
                        p => true,
                        p =>
                        {
                            try
                            {
                                executeCommand(CommandBefore, CommandParameter);
                                execute(p);
                                executeCommand(CommandAfter, CommandParameter);
                            }
                            catch (InvalidOperationException e)
                            {
                                MessageBox.Show((string) e.Message, string.Empty,
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        );
                }
                return show;
            }
        }
        
        protected static readonly DependencyProperty commandParameterProperty = 
            DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(CommandDialogBox));

        public object CommandParameter
        {
            get { return GetValue(commandParameterProperty); }
            set { SetValue(commandParameterProperty, value);}
        }

        protected static void executeCommand(ICommand command, object commandParameter)
        {
            if (command != null)
                if (command.CanExecute(commandParameter))
                    command.Execute(commandParameter);
        }
        
        protected static readonly DependencyProperty commandBeforeProperty =
            DependencyProperty.Register(nameof(CommandBefore), typeof(ICommand), typeof(CommandDialogBox));

        public ICommand CommandBefore
        {
            get { return (ICommand) GetValue(commandBeforeProperty); }
            set {SetValue(commandBeforeProperty, value);}
        }
        
        protected static readonly DependencyProperty commandAfterProperty =
            DependencyProperty.Register(nameof(CommandAfter), typeof(ICommand), typeof(CommandDialogBox));

        public ICommand CommandAfter
        {
            get { return (ICommand) GetValue(commandAfterProperty); }
            set {SetValue(commandAfterProperty, value);}
        }
    }
}