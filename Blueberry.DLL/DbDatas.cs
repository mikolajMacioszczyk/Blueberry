using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Blueberry.DLL.Models;

namespace Blueberry.DLL
{
    public class DbDatas
    {
        public event Action<IEnumerable<Order>> OrdersChanged;
        public event Action<IEnumerable<Harvest>> HarvestChanged;
        public event Action<IEnumerable<Address>> AddressesChanged;
        public event Action<IEnumerable<Customer>> CustomersChanged;
        #region Properties
        private float? _pricePerKilo;
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
    }
}