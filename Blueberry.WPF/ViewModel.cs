using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.Pages;

namespace Blueberry.WPF
{
    public class ViewModel : IDisposable
    {
        private DBConnector _connector;
        public ObservableCollection<Order> Orders { get; }
        public ObservableCollection<Customer> Customers { get; }
        public float PricePerKilo => 15;
        
        public ViewModel()
        {
            _connector = new DBConnector();
            Orders = new ObservableCollection<Order>(_connector.GetOrders());
            Customers = new ObservableCollection<Customer>(_connector.GetCustomers());
        }

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

        public void Dispose()
        {
            _connector?.Dispose();
        }
    }
}
