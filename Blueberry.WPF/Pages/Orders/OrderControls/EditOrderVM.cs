using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.Converters;

namespace Blueberry.WPF.Pages.Orders.OrderControls
{
    public class EditOrderVM : INotifyPropertyChanged
    {
        public event Action ChangeContentRequested;
        private AngToPlStatusConverter statusConverter = new AngToPlStatusConverter();
        private AngToPlPriorityConverter priorityConverter = new AngToPlPriorityConverter();
        private Order _selectedOrder;
        private PriorityPolishNames _selectedPriority;
        private OrderStatusPolishNames _selectedStatus;
        private float _amount;
        private DateTime _orderDate;
        private DateTime _realizationDate;
        private ICommand _submitCommand;
        private ICommand _discardCommand;

        public ICommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(
                        p => IsValid(),
                        p =>
                        {
                            SubmitEditOrder();
                            ChangeContentRequested?.Invoke();
                        });                    
                }
                return _submitCommand;
            }
        }

        public ICommand DiscardCommand
        {
            get
            {
                if (_discardCommand == null)
                {
                    _discardCommand = new RelayCommand(
                        p => true,
                        p =>
                        {
                            Clear();
                            ChangeContentRequested?.Invoke();
                        });                    
                }
                return _discardCommand;
            }
        }

        public float Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                Clear();
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        public PriorityPolishNames SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
            }
        }
        public OrderStatusPolishNames SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }
        public DateTime OrderDate
        {
            get => _orderDate;
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public DateTime RealizationDate
        {
            get => _realizationDate;
            set
            {
                _realizationDate = value;
                OnPropertyChanged(nameof(RealizationDate));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public Array Priorities => Enum.GetValues(typeof(PriorityPolishNames));
        public Array Statuses => Enum.GetValues(typeof(OrderStatusPolishNames));
        private bool IsValid()
        {
            return Amount >= 0 && RealizationDate >= OrderDate;
        }
        private void SubmitEditOrder()
        {
            var oldAmount = _selectedOrder.Amount;
            var oldPriority = _selectedOrder.Priority;
            var oldStatus = _selectedOrder.Status;
            var oldOrderDate = _selectedOrder.DateOfOrder;
            var oldRealizationDate = _selectedOrder.DateOfRealization;
            Update();
            DBConnector.GetInstance().ModifyOrderAsync(
                _selectedOrder, new Modification[]
                {
                    new Modification(oldAmount, _selectedOrder.Amount),
                    new Modification(oldPriority, _selectedOrder.Priority),
                    new Modification(oldStatus, _selectedOrder.Status),
                    new Modification(oldOrderDate, _selectedOrder.DateOfOrder),
                    new Modification(oldRealizationDate, _selectedOrder.DateOfRealization),
                }
                );
        }

        private void Update()
        {
            _selectedOrder.Amount = Amount;
            _selectedOrder.Priority = (Priority) priorityConverter.ConvertBack(SelectedPriority, null,null,null);
            _selectedOrder.Status = (OrderStatus) statusConverter.ConvertBack(SelectedStatus, null, null, null);
            _selectedOrder.DateOfOrder = OrderDate;
            _selectedOrder.DateOfRealization = RealizationDate;
        }
        private void Clear()
        {
            SelectedPriority = (PriorityPolishNames) priorityConverter.Convert(_selectedOrder.Priority, typeof(PriorityPolishNames), null,null);
            Amount = _selectedOrder.Amount;
            SelectedStatus = (OrderStatusPolishNames) statusConverter.Convert(_selectedOrder.Status, typeof(OrderStatusPolishNames), null, null);
            OrderDate = _selectedOrder.DateOfOrder;
            RealizationDate = _selectedOrder.DateOfRealization;
        }
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