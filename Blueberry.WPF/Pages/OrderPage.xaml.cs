using Blueberry.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Blueberry.WPF.ExtensionMethods;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.Windows;

namespace Blueberry.WPF.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private ViewModel _model;
        private SortBy _sortByFilter = SortBy.Priority;
        private OrderStatus _statusFilter = OrderStatus.Waiting;
        public event EventHandler<OrderPageEventAgrs> OrderChanged;

        public OrderPage(ViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            _model = model;
            FilterOrders();
        }

        private void FilterOrders()
        {
            switch (_sortByFilter)
            {
                case SortBy.Date:
                    OrdersItemsControl.DataContext =
                        _model.Orders.Where(o => o.Status == _statusFilter).OrderBy(o => o.DateOfRealization);
                    break;
                case SortBy.Customer:
                    OrdersItemsControl.DataContext =
                        _model.Orders.Where(o => o.Status == _statusFilter).OrderBy(o => o.Customer);
                    break;
                case SortBy.Priority:
                    OrdersItemsControl.DataContext =
                        _model.Orders.Where(o => o.Status == _statusFilter).OrderBy(o => o.Priority);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RefreshOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RefreshOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter == null)
            {
                return;
            }
            _sortByFilter = (SortBy) Enum.Parse(typeof(SortBy), e.Parameter.ToString());
            FilterOrders();
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

        private void FindOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void FindOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter == null)
            {
                return;
            }
            _statusFilter = (OrderStatus) Enum.Parse(typeof(OrderStatus), e.Parameter.ToString());
            FilterOrders();
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
            if (_statusFilter == OrderStatus.Cancelled) { return; }
            var button = sender as Button;
            var oldOrder = button.Tag as Order;
            var newOrder = new Order(oldOrder);
            newOrder.Status = OrderStatus.Cancelled;
            UpdateOrders(oldOrder,newOrder, new Modification(oldOrder.Status, OrderStatus.Cancelled));
        }

        private void UpdateOrders(Order old, Order @new, params Modification[] modifications)
        {
            OrderChanged?.Invoke(this, new OrderPageEventAgrs(old, @new, modifications));
            FilterOrders();
        }

        private void NewOrderOnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }

    internal enum SortBy
    {
        Date,
        Customer,
        Priority
    }
}