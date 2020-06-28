using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.Windows;

namespace Blueberry.WPF.Pages
{
    public partial class CustomersPage : Page
    {
        public event EventHandler<CustomerPageEventArgs> CustomerModified; 
        
        private ViewModel _model;
        public CustomersPage(ViewModel model)
        {
            _model = model;
            InitializeComponent();
            CustomersItemControl.DataContext = _model.Customers.OrderBy(c => c.LastName);
        }

        private void DetailsOnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var customer = button.Tag as Customer;
            var orders = customer.Orders.OrderBy(o => o.DateOfRealization);
            new CustomerDetailsWindow(orders).ShowDialog();
        }
        
        private void EditOnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var oldCustomer = button.Tag as Customer;
            var newCustomer = new EditCustomerWindow().Edit(oldCustomer);
            if (newCustomer != null)
            {
                CustomerModified?.Invoke(this, new CustomerPageEventArgs(oldCustomer, newCustomer, GetModifications(oldCustomer, newCustomer)));
            }
        }

        private Modification[] GetModifications(Customer before, Customer after)
        {
            var modifications = new List<Modification>();
            if (!before.FirstName.Equals(after.FirstName))
            {
                modifications.Add(new Modification(before.FirstName, after.FirstName));
            }
            if (!before.LastName.Equals(after.LastName))
            {
                modifications.Add(new Modification(before.LastName, after.LastName));
            }
            if (!before.Number.Equals(after.Number))
            {
                modifications.Add(new Modification(before.Number, after.Number));
            }
            if (!before.Address.Equals(after.Address))
            {
                modifications.Add(new Modification(before.Address, after.Address));
            }
            return modifications.ToArray();
        }
    }
}