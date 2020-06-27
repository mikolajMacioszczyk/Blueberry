using Blueberry.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.DLL
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BlueberryContext();
            var customer = context.Customers.Single(c => c.Id == 1);
            var customer2 = context.Customers.Single(c => c.Id == 2);
            var customer3 = context.Customers.Single(c => c.Id == 3);

            //context.Orders.RemoveRange(context.Orders.Where(o => o.Id > 10));

            var order = new Order()
            {
                Id = 1,
                Customer = customer,
                Amount = 15,
                DateOfOrder = DateTime.Now,
                DateOfRealization = DateTime.Now.AddDays(1),
                Priority = Priority.HighPriority,
                Status = OrderStatus.Waiting
            };
            
            var order2 = new Order()
            {
                Id = 2,
                Customer = customer2,
                Amount = 25,
                DateOfOrder = DateTime.Now,
                DateOfRealization = DateTime.Now.AddDays(1),
                Priority = Priority.MiddlePriority,
                Status = OrderStatus.Cancelled
            };
            var order3 = new Order()
            {
                Id = 3,
                Customer = customer,
                Amount = 5,
                DateOfOrder = DateTime.Now,
                DateOfRealization = DateTime.Now.AddDays(1),
                Priority = Priority.LowPriority,
                Status = OrderStatus.Realized
            };

            context.Orders.Add(order);
            context.Orders.Add(order3);
            context.Orders.Add(order2);
            context.SaveChanges();
        }
    }
}
