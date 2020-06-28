using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Blueberry.DLL.Models;
using Blueberry.WPF.Enums;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.Windows;

namespace Blueberry.WPF.UserControls
{
    public partial class OrderList : UserControl
    {
        public event EventHandler<OrderPageEventAgrs> OrderChanged; 
        public OrderList()
        {
            InitializeComponent();
        }
        
        private void DoneButtonOnClick(object sender, RoutedEventArgs e)
        {
            Button source = sender as Button;
            var oldOrder = source?.Tag as Order;
            if (oldOrder.Status == OrderStatus.Realized) return;
            var newOrder = new Order(oldOrder);
            newOrder.Status = OrderStatus.Realized;
            UpdateOrders(oldOrder,newOrder, new Modification(oldOrder.Status, OrderStatus.Realized));
        }
        
        private void EditOnClick(object sender, RoutedEventArgs e)
        { 
            var button = sender as Button;
            var oldOrder = button.Tag as Order;
            var newOrder = new EditOrderWindow(oldOrder).PromptDialog();
            
            var changes = new List<Modification>();

            if (oldOrder.Amount != newOrder.Amount)
            {
                changes.Add(new Modification(oldOrder.Amount, newOrder.Amount));
            }
            if (oldOrder.Priority != newOrder.Priority)
            {
                changes.Add(new Modification(oldOrder.Priority, newOrder.Priority));
            }
            if (oldOrder.Status != newOrder.Status)
            {
                changes.Add(new Modification(oldOrder.Status, newOrder.Status));
            }
            if (oldOrder.DateOfRealization != newOrder.DateOfRealization)
            {
                changes.Add(new Modification(oldOrder.DateOfRealization, newOrder.DateOfRealization));
            }
            
            UpdateOrders(oldOrder,newOrder, changes.ToArray());
        }
        
        private void CancelOnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var oldOrder = button.Tag as Order;
            if (oldOrder.Status == OrderStatus.Cancelled) { return; }
            var newOrder = new Order(oldOrder);
            newOrder.Status = OrderStatus.Cancelled;
            UpdateOrders(oldOrder,newOrder, new Modification(oldOrder.Status, OrderStatus.Cancelled));
        }
        
        private void UpdateOrders(Order old, Order @new, params Modification[] modifications)
        {
            OrderChanged?.Invoke(this, new OrderPageEventAgrs(old, @new, modifications));
        }
    }
}