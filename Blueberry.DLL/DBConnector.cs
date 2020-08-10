using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Blueberry.DLL.Models;

namespace Blueberry.DLL
{
    public class DBConnector
    {
        private BlueberryContext _context;
        private ObservableCollection<Order> _orders;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Address> _addresses;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Harvest> _harvests;
        private float? _pricePerKilo;
        
        public float PricePerKilo
        {
            get
            {
                if (!_pricePerKilo.HasValue)
                {
                    _pricePerKilo = _context.Datas.First().PricePerKilo;
                }
                return _pricePerKilo.Value;
            }
        }
        
        private static DBConnector Instance = new DBConnector();
        public static DBConnector GetInstance() => Instance;
        public event Action OrdersChanged;
        public event Action CustomersChanged;
        public event Action AddressesChanged;
        public event Action EmployeesChanged;
        public event Action HarvestChanged;

        private DBConnector()
        {
            _context = new BlueberryContext();
        }

        public ObservableCollection<Customer> GetCustomers()
        {
            if (_customers == null)
            {
                _customers = new ObservableCollection<Customer>(_context.Customers.Include(c => c.Address));
            }
            return _customers;
        }

        public ObservableCollection<Order> GetOrders()
        {
            if (_orders == null)
            {
                _orders = new ObservableCollection<Order>(_context.Orders.Include(o => o.Customer).Include(o => o.Customer.Address));
            }
            return _orders;
        }

        public ObservableCollection<Address> GetAddresses()
        {
            if (_addresses == null)
            {
                _addresses = new ObservableCollection<Address>(_context.Addresses);
            }

            return _addresses;
        }

        public ObservableCollection<Employee> GetEmployees()
        {
            if (_employees == null)
            {
                _employees = new ObservableCollection<Employee>(_context.Employees);
            }

            return _employees;
        }
        
        public ObservableCollection<Harvest> GetHarvests()
        {
            if (_harvests == null)
            {
                _harvests = new ObservableCollection<Harvest>(_context.Harvests);
            }
            return _harvests;
        }

        public void ModifyOrder(Order modifiedOrder, Modification[] modifications)
        {
            var record = new Record()
            {
                Message =$"Modification order {modifiedOrder.FullString()}: " + string.Join(", ",modifications.Select(m => $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
            };
            _context.Records.Add(record);
            OrdersChanged?.Invoke();
        }

        public void ModifyEmployee(Employee old, Modification[] modifications)
        {
            var record = new Record()
            {
                Message =$"Modification employee {old.FullString()}: " + string.Join(", ",modifications.Select(m => $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
            };
            _context.Records.Add(record);
            EmployeesChanged?.Invoke();
        }
        
        public void ModifyCustomer(Customer old, Modification[] modifications)
        {
            var record = new Record()
            {
                Message =$"Modification customer {old.FullString()}: " + string.Join(", ",modifications.Select(m => $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
            };
            _context.Records.Add(record);
            CustomersChanged?.Invoke();
        }

        public void AddCustomer(Customer customer)
        {
            var record = new Record()
            {
                Message = $"Added new customer: {customer.FullString()}"
            };
            _context.Customers.Add(customer);
            _customers.Add(customer);
            _context.Records.Add(record);
            CustomersChanged?.Invoke();
        }
        
        public void AddOrder(Order order)
        {
            var record = new Record()
            {
                Message =$"Added new order: {order.FullString()}: ",
            };
            _orders.Add(order);
            _context.Orders.Add(order);
            _context.Records.Add(record);
            OrdersChanged?.Invoke();
        }
        
        public void AddEmployee(Employee employee)
        {
            var record = new Record()    
            {
                Message =$"Added new employee: {employee.FullString()}: ",
            };
            _employees.Add(employee);
            _context.Employees.Add(employee);
            _context.Records.Add(record);
            EmployeesChanged?.Invoke();
        }

        public void AddException(Exception exception)
        {
            var blueberryex = new BlueberryException()
            {
                StackTrance = exception.Message +"\n"+ exception.StackTrace,
                IsSolved = false
            };
            _context.Exceptions.Add(blueberryex);
        }
        
        
        public void AddHarvest(Harvest harvest)
        {
            var record = new Record()    
            {
                Message =$"Added new harvest: {harvest.FullString()}: ",
            };
            _harvests.Add(harvest);
            _context.Harvests.Add(harvest);
            _context.Records.Add(record);
            HarvestChanged?.Invoke();
        }

        public void AddAddress(Address address)
        {
            var record = new Record()
            {
                Message = $"Added new address: {address.ToString()}"
            };
            _context.Addresses.Add(address);
            _addresses.Add(address);
            _context.Records.Add(record);
            AddressesChanged?.Invoke();
        }

        public void Save()
        {
            _context.SaveChanges();
            _context?.Dispose();
        }
    }
}