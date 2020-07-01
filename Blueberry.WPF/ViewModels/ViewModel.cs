using System;
using System.Collections.ObjectModel;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;

namespace Blueberry.WPF.ViewModels
{
    public class ViewModel : IDisposable
    {
        #region Properties
        private DBConnector _connector;
        private ObservableCollection<Order> _orders;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Address> _addresses;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Harvest> _harvests;

        public ObservableCollection<Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new ObservableCollection<Order>(_connector.GetOrders());
                }
                return _orders;
            }
        }
        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new ObservableCollection<Customer>(_connector.GetCustomers());
                }
                return _customers;
            }
        }
        public ObservableCollection<Address> Addresses
        {
            get
            {
                if (_addresses == null)
                {
                    _addresses = new ObservableCollection<Address>(_connector.GetAddresses());
                }
                return _addresses;
            }
        }

        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (_employees == null)
                {
                    _employees = new ObservableCollection<Employee>(_connector.GetEmployees());
                }
                return _employees;
            }
        }
        public ObservableCollection<Harvest> Harvests
        {
            get
            {
                if (_harvests == null)
                {
                    _harvests = new ObservableCollection<Harvest>(_connector.GetHarvests());
                }
                return _harvests;
            }
        }
        #endregion
        public float PricePerKilo => 15;
        
        public ViewModel()
        {
            _connector = DBConnector.GetInstance;
        }

        #region EventHadlers

        public void OnOrdersChangedEventHandler(object sender, OrderPageEventAgrs args)
        {
            if (args.Modifications.Length == 0) { return; }
            var old = args.Old;
            var after = args.New;
            old.Amount = after.Amount;
            old.Priority = after.Priority;
            old.Status = after.Status;
            old.DateOfRealization = after.DateOfRealization;
            _connector.ModifyOrder(args.Old, args.Modifications);
        }

        public void OnOrderAddedEventHandler(object sender, NewOrderEventArgs args)
        {
            Orders.Add(args.Order);
            _connector.AddOrder(args.Order);
        }

        public void OnCustomerModifiedEventHandler(object sender, CustomerPageEventArgs args)
        {
            if (args.Modifications.Length == 0) { return; }

            var old = args.OldValue;
            var @new = args.NewValue;
            old.FirstName = @new.FirstName;
            old.LastName = @new.LastName;
            old.Number = @new.Number;
            old.Address.City = @new.Address.City;
            old.Address.Street = @new.Address.Street;
            old.Address.House = @new.Address.House;
            _connector.ModifyCustomer(args.OldValue, args.Modifications);
        }
        
        public void OnCustomerAddedEventHandler(object sender, CustomerAddedEventArgs args)
        {
            Customers.Add(args.Customer);
            if (args.IsAddressNew)
            {
                Addresses.Add(args.Customer.Address);
            }
            _connector.AddCustomer(args.Customer, args.IsAddressNew);
        }

        public void OnEmployeeAddedEventHandler(object sender, NewEmployeeEventArgs args)
        {
            Employees.Add(args.Employee);
            _connector.AddEmployee(args.Employee);
        }

        public void OnEmployeeModifiedEventHandler(object sender, EmployeeEditedEventArgs args)
        {
            Employees.Remove(args.Edited);
            Employees.Add(args.Edited);
            _connector.ModifyEmployee(args.Edited, args.Modifications);
        }

        public void OnHarvestGroupAddedEventHandler(object sender, HarvestGroupAddedEventArgs args)
        {
            foreach (var harvest in args.Harvests)
            {
                Harvests.Add(harvest);
                _connector.AddHarvest(harvest);
            }
        }

        #endregion

        public void Dispose()
        {
            _connector?.Save();
        }
    }
}
