using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.Pages.Orders.OrderControls;

namespace Blueberry.WPF.Pages.Orders
{
    public class OrderPageVM : INotifyPropertyChanged
    {
        #region Properties
        private DBConnector _connector;
        private ICommand _sortCommand;
        private ICommand _selectCommand;
        private ICommand _changeContentCommand;
        private ICommand _doneCommand;
        private ICommand _cancelCommand;
        private ICommand _editCommand;
        private SortBy _selectedSort;
        private OrderStatus _selectedStatus;
        private bool _isNewOrderVisible = false;
        private bool _isOrderListVisible = true;
        private bool _isEditOrderVisible = false;
        public EditOrderVM EditOrderVm { get; set; } = new EditOrderVM();
        public bool IsNewOrderVisible
        {
            get => _isNewOrderVisible;
            set
            {
                if (value)
                {
                    _isNewOrderVisible = true;
                    _isOrderListVisible = false;
                    _isEditOrderVisible = false;
                    OnPropertyChanged(nameof(IsNewOrderVisible));
                    OnPropertyChanged(nameof(IsOrderListVisible));
                    OnPropertyChanged(nameof(IsEditOrderVisible));
                }
            }
        }
        public bool IsOrderListVisible
        {
            get => _isOrderListVisible;
            set
            {
                if (value)
                {
                    _isOrderListVisible = true;
                    _isNewOrderVisible = false;
                    _isEditOrderVisible = false;
                    OnPropertyChanged(nameof(IsOrderListVisible));
                    OnPropertyChanged(nameof(IsNewOrderVisible));
                    OnPropertyChanged(nameof(IsEditOrderVisible));
                }
            }
        }
        public bool IsEditOrderVisible
        {
            get => _isEditOrderVisible;
            set
            {
                if (value)
                {
                    _isEditOrderVisible = true;
                    _isNewOrderVisible = false;
                    _isOrderListVisible = false;
                    OnPropertyChanged(nameof(IsOrderListVisible));
                    OnPropertyChanged(nameof(IsNewOrderVisible));
                    OnPropertyChanged(nameof(IsEditOrderVisible));
                }
            }
        }
        public ICommand DoneCommand
        {
            get
            {
                if (_doneCommand == null) { _doneCommand = new RelayCommand(
                    p => SelectedStatus != OrderStatus.Realized,
                    p =>
                    {
                        if (!(p is int)) return;
                        int id = (int) p;
                        Order o = DBConnector.GetInstance().GetOrders().FirstOrDefault(or => or.Id == id);
                        DBConnector.GetInstance().ModifyOrder(
                            o,
                            new Modification[]
                            {
                                new Modification(o.Status, OrderStatus.Realized)
                            }
                            );
                        o.Status = OrderStatus.Realized;
                        Orders.Remove(o);
                        Orders.Add(o);
                    }
                    ); }
                return _doneCommand;
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null) { _cancelCommand = new RelayCommand(
                    p => SelectedStatus != OrderStatus.Cancelled,
                    p =>
                    {
                        if (!(p is int)) return;
                        int id = (int) p;
                        Order o = DBConnector.GetInstance().GetOrders().FirstOrDefault(or => or.Id == id);
                        DBConnector.GetInstance().ModifyOrder(
                            o,
                            new Modification[]
                            {
                                new Modification(o.Status, OrderStatus.Cancelled)
                            }
                        );
                        o.Status = OrderStatus.Cancelled;
                        Orders.Remove(o);
                        Orders.Add(o);
                    }
                ); }
                return _cancelCommand;
            }
        }
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null) { _editCommand = new RelayCommand(
                    p => true,
                    p =>
                    {
                        if (!(p is int)) return;
                        int id = (int) p;
                        Order o = DBConnector.GetInstance().GetOrders().FirstOrDefault(or => or.Id == id);
                        EditOrderVm.SelectedOrder = o;
                        IsEditOrderVisible = true;
                    }
                ); }
                return _editCommand;
            }
        }
        public ICommand SortCommand
        {
            get
            {
                if (_sortCommand == null) { _sortCommand = new RelayCommand(
                    p => Convert.ToInt32(p) != (int) SelectedSort,
                    p => SelectedSort = (SortBy) Convert.ToInt32(p)
                    ); }
                return _sortCommand;
            }
        }
        public ICommand SelectCommand
        {
            get
            {    
                if (_selectCommand == null) { _selectCommand = new RelayCommand(
                    p => Convert.ToInt32(p) != (int) SelectedStatus,
                    p => SelectedStatus = (OrderStatus) Convert.ToInt32(p)
                    ); }
                return _selectCommand;
            }
        }
        public ICommand ChangeContentCommand
        {    
            get
            {
                if (_changeContentCommand == null)
                {
                    _changeContentCommand = new ChangeContentCommand(
                        p =>
                        {
                            int.TryParse(p.ToString(), out int number);
                            if (number == 0) {IsOrderListVisible = true;}
                            else {IsNewOrderVisible = true;}
                        },
                        p => true);
                }
                return _changeContentCommand;
            }
        }
        public SortBy SelectedSort
        {
            get => _selectedSort;
            set
            {
                _selectedSort = value;
                OnPropertyChanged(nameof(SelectedSort));
                SetOrders();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public OrderStatus SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
                SetOrders();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public ObservableCollection<Order> Orders { get; set; }
        
        #endregion
        public OrderPageVM()
        {
            _connector = DBConnector.GetInstance();
            _connector.OrdersChanged += SetOrders;
            SetOrders();
        }

        private void ClearOrders()
        {
            if (Orders != null)
            {
                int count = Orders.Count;
                for (int i = 0; i < count; i++)
                {
                    Orders.RemoveAt(0);
                }
            }
            else
            {
                Orders = new ObservableCollection<Order>();
            }
        }

        private void SetOrders()
        {
            ClearOrders();
            var list = _connector.GetOrders().Where(o => o.Status == SelectedStatus);
            IOrderedEnumerable<Order> sorted;
            switch (SelectedSort)
            {
                case SortBy.Date:
                    sorted = list.OrderBy(o => o.DateOfRealization);
                    break;
                case SortBy.Customer:
                    sorted = list.OrderBy(o => o.Customer);
                    break;
                case SortBy.Priority:
                    sorted = list.OrderBy(o => o.Priority);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            foreach (var item in sorted)
            {
                Orders.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}