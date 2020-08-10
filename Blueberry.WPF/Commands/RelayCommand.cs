using System;
using System.Windows.Input;

namespace Blueberry.WPF.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<object> _onEcecute;
        private Func<object, bool> _onCanExecute;

        public RelayCommand(Func<object, bool> onCanExecute, Action<object> onEcecute)
        {
            _onCanExecute = onCanExecute;
            _onEcecute = onEcecute;
        }

        public bool CanExecute(object parameter)
        {
            return _onCanExecute == null || _onCanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _onEcecute.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}