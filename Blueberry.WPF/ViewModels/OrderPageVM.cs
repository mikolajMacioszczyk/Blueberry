using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.Enums;

namespace Blueberry.WPF.ViewModels
{
    public class OrderPageVM : INotifyPropertyChanged
    {
        private ICommand _sortCommand;

        public ICommand SortCommand
        {
            get
            {
                if (_sortCommand == null) { _sortCommand = new SortByCommand(this); }
                return _sortCommand;
            }
        }

        private SortBy _selectedSort;

        public SortBy SelectedSort
        {
            get { return _selectedSort;; }
            set
            {
                _selectedSort = value;
                OnPropertyChanged(nameof(SelectedSort));
            }
        }
        private DBConnector _connector;

        public List<Order> Orders
        {
            get
            {
                switch (SelectedSort)
                {
                    case SortBy.Date:
                        return _connector.GetOrders().OrderBy(o => o.DateOfRealization).ToList();
                    case SortBy.Customer:
                        return _connector.GetOrders().OrderBy(o => o.Customer).ToList();
                    case SortBy.Priority:
                        return _connector.GetOrders().OrderBy(o => o.Priority).ToList();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public OrderPageVM()
        {
            _connector = DBConnector.GetInstance();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}