using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blueberry.DLL.Models;

namespace Blueberry.DLL
{
    public class DBConnector
    {
        private BlueberryContext _context;
        private List<Order> _orders;
        private List<Customer> _customers;
        private List<Address> _addresses;
        private List<Employee> _employees;
        private List<Harvest> _harvests;
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

        public IEnumerable<Customer> GetCustomers()
        {
            if (_customers == null)
            {
                _customers = new List<Customer>(_context.Customers.Include(c => c.Address));
            }
            return _customers;
        }

        public IEnumerable<Order> GetOrders()
        {
            if (_orders == null)
            {
                _orders = new List<Order>(_context.Orders.Include(o => o.Customer).Include(o => o.Customer.Address));
            }
            return _orders;
        }

        public IEnumerable<Address> GetAddresses()
        {
            if (_addresses == null)
            {
                _addresses = new List<Address>(_context.Addresses);
            }

            return _addresses;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            if (_employees == null)
            {
                _employees = new List<Employee>(_context.Employees);
            }

            return _employees;
        }
        
        public IEnumerable<Harvest> GetHarvests()
        {
            if (_harvests == null)
            {
                _harvests = new List<Harvest>(_context.Harvests);
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
        public async void ModifyOrderAsync(Order modifiedOrder, Modification[] modifications)
        {
            await Task.Factory.StartNew(() =>
            {
                var record = new Record()
                {
                    Message = $"Modification order {modifiedOrder.FullString()}: " + string.Join(", ",
                        modifications.Select(m =>
                            $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
                };
                _context.Records.Add(record);
                _context.SaveChanges();
            });
            OrdersChanged?.Invoke();
        }

        public void ModifyEmployee(Employee old, Modification[] modifications)
        {
            var record = new Record()
            {
                Message =$"Modification employee {old.FullString()}: " + string.Join(", ",modifications.Select(m => $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
            };
            _context.Records.Add(record);
            _context.SaveChanges();
            EmployeesChanged?.Invoke();
        }
        
        public async void ModifyEmployeeAsync(Employee old, Modification[] modifications)
        {
            await Task.Factory.StartNew(() =>
            {
                var record = new Record()
                {
                    Message = $"Modification employee {old.FullString()}: " + string.Join(", ",
                        modifications.Select(m =>
                            $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
                };
                _context.Records.Add(record);
                _context.SaveChanges();
            });
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
        
        public async void ModifyCustomerAsync(Customer old, Modification[] modifications)
        {
            await Task.Factory.StartNew(() =>
            {
                var record = new Record()
                {
                    Message = $"Modification customer {old.FullString()}: " + string.Join(", ",
                        modifications.Select(m =>
                            $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
                };
                _context.Records.Add(record);
                _context.SaveChanges();
            });
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
        
        public async void AddCustomerAsync(Customer customer)
        {
            await Task.Factory.StartNew(() =>
            {
                var record = new Record()
                {
                    Message = $"Added new customer: {customer.FullString()}"
                };
                _context.Customers.Add(customer);
                _context.Records.Add(record);
                _context.SaveChanges();
            });
            _customers.Add(customer);
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
        
        public async void AddOrderAsync(Order order)
        {
            await Task.Factory.StartNew(() =>
            {
                var record = new Record()
                {
                    Message = $"Added new order: {order.FullString()}: ",
                };
                _context.Orders.Add(order);
                _context.Records.Add(record);
                _context.SaveChanges();
            });
            _orders.Add(order);
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
        public void AddEmployeeAsync(Employee employee)
        {
            Task.Factory.StartNew(() =>
            {
                var record = new Record()
                {
                    Message = $"Added new employee: {employee.FullString()}: ",
                };
                _context.Employees.Add(employee);
                _context.Records.Add(record);
                _context.SaveChanges();
            });
            _employees.Add(employee);
            EmployeesChanged?.Invoke();
        }

        public async void AddExceptionAsync(Exception exception)
        {
            await Task.Factory.StartNew(() =>
            {
                var blueberryex = new BlueberryException()
                {
                    StackTrance = exception.Message + "\n" + exception.StackTrace,
                    IsSolved = false
                };
                _context.Exceptions.Add(blueberryex);
                _context.SaveChanges();
            });
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
        
        public void AddHarvestAsync(Harvest harvest)
        {
            Task.Factory.StartNew(() =>
            {
                var record = new Record()
                {
                    Message = $"Added new harvest: {harvest.FullString()}: ",
                };
                _context.Harvests.Add(harvest);
                _context.Records.Add(record);
                _context.SaveChanges();
            });
            _harvests.Add(harvest);
            HarvestChanged?.Invoke();
        }
        
        public void AddEnumerableHarvestAsync(List<Harvest> harvests)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < harvests.Count(); i++)
                {
                    var harvest = harvests[i];
                    var record = new Record()
                    {
                        Message = $"Added new harvest: {harvest.FullString()}: "
                    };
                    _context.Harvests.Add(harvest);
                    _context.Records.Add(record);
                }
                _context.SaveChanges();
            });
            
            foreach (var harvest in harvests)
            {
                _harvests.Add(harvest);
            }
            Thread.MemoryBarrier();
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
        
        public async void AddAddressAsync(Address address)
        {
            await Task.Factory.StartNew(() =>
            {
                var record = new Record()
                {
                    Message = $"Added new address: {address.ToString()}"
                };
                _context.Addresses.Add(address);
                _context.Records.Add(record);
                _context.SaveChanges();
            });
            _addresses.Add(address);
            AddressesChanged?.Invoke();
        }

        public void Save()
        {
            _context.SaveChanges();
            _context?.Dispose();
        }
    }
}