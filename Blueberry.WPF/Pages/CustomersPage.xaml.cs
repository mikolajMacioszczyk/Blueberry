using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.UserControls;
using Blueberry.WPF.Windows;

namespace Blueberry.WPF.Pages
{
    public partial class CustomersPage : Page
    {
        public event EventHandler<CustomerPageEventArgs> CustomerModified; 
        public event EventHandler<CustomerAddedEventArgs> CustomerAdded;

        private ViewModel _model;
        private CustomerList _customerList;
        private NewCustomerUserControl _newCustomerControl;
        public CustomersPage(ViewModel model)
        {
            _model = model;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _newCustomerControl = new NewCustomerUserControl();

            void OnNewCustomerControlOnDiscarded(object sender, EventArgs args)
            {
                AddButton.Visibility = Visibility.Visible;
                RightSide.Content = _customerList;
            }

            _newCustomerControl.Discarded += OnNewCustomerControlOnDiscarded;
            _newCustomerControl.CustomerAdded += OnCustomerAddedEventHandler;
            
            _customerList = new CustomerList();
            _customerList.CustomerModified += (sender, args) => CustomerModified?.Invoke(sender, args);
            _customerList.DataContext = _model.Customers.OrderBy(c => c.LastName);
            
            RightSide.Content = _customerList;
        }

        private void NewCustomerOnClick(object sender, RoutedEventArgs e)
        {
            AddButton.Visibility = Visibility.Hidden;
            RightSide.Content = _newCustomerControl;
        }

        private void OnCustomerAddedEventHandler(object sender, NewCustomerEventArgs args)
        {
            RightSide.Content = _customerList;
            AddButton.Visibility = Visibility.Visible;
            if (_model.Customers.Any(c => c.FirstName.Equals(args.FirstName) && c.LastName.Equals(args.LastName)))
            {
                return;
            }

            Address address;
            bool isAddressNew = false;
            try
            {
                address = _model.Addresses.Single(a => a.City.Equals(args.City) && a.Street.Equals(args.Street) && a.House.Equals(args.House));
            }
            catch (InvalidOperationException)
            {
                isAddressNew = true;
                address = new Address()
                {
                    City = args.City,
                    Street = args.Street,
                    House = args.House
                };
            }
            var customer = new Customer()
            {
                FirstName = args.FirstName,
                LastName = args.LastName,
                Number = args.PhoneNumber,
                Address = address,
                Orders =  new List<Order>()
            };
            CustomerAdded?.Invoke(this, new CustomerAddedEventArgs(customer, isAddressNew));
            _customerList.DataContext = _model.Customers.OrderBy(c => c.LastName);
        }
    }
}