using System;
using System.Windows.Input;
using Blueberry.DLL.Enums;
using Blueberry.WPF.Pages.Orders;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Commands
{
    public class SelectCommand : ICommand
    {
        private readonly OrderPageVM _model;

        public SelectCommand(OrderPageVM model)
        {
            _model = model ?? throw new ArgumentNullException("OrderPageModel");
        }
    
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int value = parameter == null ? 0 : parameter is int ? (int) parameter : 0;
            _model.SelectedSort = (SortBy) value;
        }

        public event EventHandler CanExecuteChanged;
    }
}