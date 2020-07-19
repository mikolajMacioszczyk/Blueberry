using System;
using System.Windows.Input;

namespace Blueberry.WPF.Commands
{
    public class ChangeContentCommand : ICommand
    {
        private readonly Action<object> _onExecute;
        private readonly Func<object, bool> _onCanExecute;

        public ChangeContentCommand(Action<object> onExecute, Func<object, bool> onCanExecute)
        {
            _onExecute = onExecute;
            _onCanExecute = onCanExecute;
        }
        
        public bool CanExecute(object parameter)
        {
            return _onCanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _onExecute.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}