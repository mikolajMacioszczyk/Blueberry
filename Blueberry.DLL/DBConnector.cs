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
        public DBConnector()
        {
            _context = new BlueberryContext();
        }

        public List<Order> GetOrders()
        {
            if (Orders == null)
            {
                Orders = _context.Orders.Include(o => o.Customer).Include(o => o.Customer.Address).ToList();
            }
            return Orders;
        }

        public void ModifyOrder(Order oldOrder, Order newOrder, Modification[] modifications)
        {
            var record = new Record()
            {
                Order = newOrder,
                Message = string.Join(", ",modifications.Select(m => $"Modification property {m.Type} =>  from '{m.OldValue}' to '{m.NewValue}'")),
            };
            _context.Orders.Remove(oldOrder);
            _context.Orders.Add(newOrder);
            _context.Records.Add(record);
        }

        public void Dispose()
        {
            _context.SaveChanges();
            _context?.Dispose();
        }
    }
}