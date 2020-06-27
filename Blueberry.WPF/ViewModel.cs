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
        public float PricePerKilo => 15;
        
        public ViewModel()
        {
            _connector = new DBConnector();
            Orders = new ObservableCollection<Order>(_connector.GetOrders());
        }

        public void OnOrdersChangedEventHandler(object sender, OrderPageEventAgrs args)
        {
            if (args.Modifications.Length == 0) { return; }
            Orders.Remove(args.Old);
            Orders.Add(args.New);
            _connector.ModifyOrder(args.Old, args.New, args.Modifications);
        }

        public void Dispose()
        {
            _connector?.Dispose();
        }
    }
}
