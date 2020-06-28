using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Blueberry.DLL.Models;

namespace Blueberry.DLL
{
    public class DBConnector : IDisposable
    {
        private BlueberryContext _context;
        private List<Order> Orders;
        private List<Customer> Customers;
        public DBConnector()
        {
            _context = new BlueberryContext();
        }

        public List<Customer> GetCustomers()
        {
            if (Customers == null)
            {
                Customers = _context.Customers.Include(c => c.Address).ToList();
            }
            return Customers;
        }

        public List<Order> GetOrders()
        {
            if (Orders == null)
            {
                Orders = _context.Orders.Include(o => o.Customer).Include(o => o.Customer.Address).ToList();
            }
            return Orders;
        }

        public void ModifyOrder(Order modifiedOrder, Modification[] modifications)
        {
            var record = new Record()
            {
                Message =$"Modification order {modifiedOrder.FullString()}: " + string.Join(", ",modifications.Select(m => $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
            };
            _context.Records.Add(record);
        }

        public void ModifyCustomer(Customer old, Modification[] modifications)
        {
            var record = new Record()
            {
                Message =$"Modification custmer {old.FullString()}: " + string.Join(", ",modifications.Select(m => $"property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}', ")),
            };
            _context.Records.Add(record);
        }
        
        public void AddOrder(Order order)
        {
            var record = new Record()
            {
                Message =$"Added new order: {order.FullString()}: ",
            };
            _context.Orders.Add(order);
            _context.Records.Add(record);
        }

        public void Dispose()
        {
            _context.SaveChanges();
            _context?.Dispose();
        }
    }
}