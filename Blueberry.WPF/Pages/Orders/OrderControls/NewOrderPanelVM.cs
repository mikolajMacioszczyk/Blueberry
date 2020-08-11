using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.Pages.Orders.OrderControls
{
    public class NewOrderPanelVM : INotifyPropertyChanged
    {
        public event Action ContentChangeRequested;
        #region Properties
        private Customer _selectedCustomer;
        private Priority _selectedPriority;
        private DateTime _orderDate;
        private DateTime _realizationDate;
        private ICommand _addOrderCommand;
        private ICommand _discardCommand;
        private int _amount;

        public ICommand AddOrderCommand
        {
            get {
                if (_addOrderCommand == null)
                {
                    _addOrderCommand = new RelayCommand(
                        p => CanAdd(),
                        p => AddNewOrder()
                    );
                }
                return _addOrderCommand;
            }
        }
        public ICommand DiscardCommand
        {
            get {
                if (_discardCommand == null)
                {
                    _discardCommand = new RelayCommand(
                        p => true,
                        p => Discard()
                    );
                }
                return _addOrderCommand;
            }
        }
        public IEnumerable<Customer> Customers => DBConnector.GetInstance().GetCustomers();
        public IEnumerable<Priority> Priorities => Enum.GetValues(typeof(Priority)).Cast<Priority>();
        public Customer SelectedCustomer
        {
            
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged(nameof(SelectedCustomer));
                }
            }
        }
        public Priority SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                if (_selectedPriority != value)
                {
                    _selectedPriority = value;
                    OnPropertyChanged(nameof(SelectedPriority));                    
                }
            }
        }
        public DateTime OrderDate
        {
            
            get => _orderDate.Date;
            set
            {
                if (_orderDate != value)
                {
                    _orderDate = value;
                    OnPropertyChanged(nameof(RealizationDate));
                }
            }
        }
        public DateTime RealizationDate
        {
            
            get => _realizationDate.Date;
            set
            {
                if (_realizationDate != value)
                {
                    _realizationDate = value;
                    OnPropertyChanged(nameof(RealizationDate));
                }
            }
        }
        public int Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        #endregion
        public NewOrderPanelVM()
        {
            DBConnector.GetInstance().CustomersChanged += () => { OnPropertyChanged(nameof(Customers)); };
            Clear();
        }

        private void Clear()
        {
            if (Customers.Any()) { SelectedCustomer = Customers.First(); }
            SelectedPriority = Priority.MiddlePriority;
            OrderDate = DateTime.Now;
            Amount = 0;
            RealizationDate = DateTime.Now.AddDays(7);
        }

        private bool CanAdd()
        {
            return _amount > 0 && _realizationDate >= _orderDate;
        }

        private void AddNewOrder()
        {
            Order order = new Order()
            {
                Amount = _amount,
                Customer = _selectedCustomer,
                Priority = _selectedPriority,
                Status = OrderStatus.Waiting,
                CustomerId = _selectedCustomer.Id,
                DateOfOrder = _orderDate,
                DateOfRealization = _realizationDate
            };
            DBConnector.GetInstance().AddOrderAsync(order);
            Clear();
            ContentChangeRequested?.Invoke();
        }

        private void Discard()
        {
            Clear();
            ContentChangeRequested?.Invoke();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}