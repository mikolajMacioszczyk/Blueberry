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
using Blueberry.WPF.Enums;
using Blueberry.WPF.ExtensionMethods;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.UserControls;
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
        private OrderList _orderList;
        private NewOrderPanel _newOrderPanel;

        public event EventHandler<NewOrderEventArgs> OrderAdded; 
        public event EventHandler<OrderPageEventAgrs> OrderChanged;

        public OrderPage(ViewModel model)
        {
            InitializeComponent();
            _model = model;
            Initialize();
        }

        private void Initialize()
        {
            _newOrderPanel = new NewOrderPanel(_model);
            _newOrderPanel.OrderAdded += (sender, args) =>
            {
                OrderAdded?.Invoke(sender, args);
                RightSideControl.Content = _orderList;
                FilterOrders();
            };
            _orderList = new OrderList();
            RightSideControl.Content = _orderList;
            _orderList.OrderChanged += (sender, args) =>
            {
                OrderChanged?.Invoke(sender, args);
                FilterOrders();
            };
            FilterOrders();
        }

        private void FilterOrders()
        {
            switch (_sortByFilter)
            {
                case SortBy.Date:
                    _orderList.DataContext =
                        _model.Orders.Where(o => o.Status == _statusFilter).OrderBy(o => o.DateOfRealization).ToList();
                    break;
                case SortBy.Customer:
                    _orderList.DataContext =
                        _model.Orders.Where(o => o.Status == _statusFilter).OrderBy(o => o.Customer).ToList();
                    break;
                case SortBy.Priority:
                    _orderList.DataContext =
                        _model.Orders.Where(o => o.Status == _statusFilter).OrderByDescending(o => o.Priority).ToList();
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

        private void NewOrderOnClick(object sender, RoutedEventArgs e)
        {
            RightSideControl.Content = _newOrderPanel;
        }
        
        private void ListOnClick(object sender, RoutedEventArgs e)
        {
            RightSideControl.Content = _orderList;
        }
    }
}