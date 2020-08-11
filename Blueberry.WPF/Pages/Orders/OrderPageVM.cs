using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.Pages.Orders.OrderControls;

namespace Blueberry.WPF.Pages.Orders
{
    internal enum OrderContent
    {
        List = 0,
        New = 1,
        Edit = 2
    }
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
        private NewOrderPanelVM _newOrderPanelVm = new NewOrderPanelVM();
        private EditOrderVM EditOrderVm = new EditOrderVM();
        private UserControl _newOrderPanel = new NewOrderPanel();
        private UserControl _editOrderPanel = new EditOrderPanel();
        private UserControl _orderLstPanel = new OrderList();
        private UserControl _content;
        public UserControl Content
        {    
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
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
                        o.Status = OrderStatus.Realized;
                        DBConnector.GetInstance().ModifyOrderAsync(
                            o,
                            new Modification[]
                            {
                                new Modification(o.Status, OrderStatus.Realized)
                            }
                        );
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
                        o.Status = OrderStatus.Cancelled;
                        DBConnector.GetInstance().ModifyOrderAsync(
                            o,
                            new Modification[]
                            {
                                new Modification(o.Status, OrderStatus.Cancelled)
                            }
                        );
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
                        ContentSwitch(OrderContent.Edit);
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
                        p => ContentSwitch((OrderContent) Enum.Parse(typeof(OrderContent), p.ToString())),
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
            _newOrderPanelVm.ContentChangeRequested += () => ContentSwitch(0);
            _orderLstPanel.DataContext = this;
            EditOrderVm.ChangeContentRequested += () => ContentSwitch(0);
            _editOrderPanel.DataContext = EditOrderVm;
            _newOrderPanel.DataContext = _newOrderPanelVm;
            Content = _orderLstPanel;
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
                    sorted = list.OrderByDescending(o => o.Priority);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            foreach (var item in sorted)
            {
                Orders.Add(item);
            }
        }
        
        private void ContentSwitch(OrderContent content)
        {
            switch (content)
            {
                case OrderContent.List:
                    Content = _orderLstPanel;
                    break;
                case OrderContent.New:
                    Content = _newOrderPanel;
                    break;
                case OrderContent.Edit:
                    Content = _editOrderPanel;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(content), content, null);
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