using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.Windows;

namespace Blueberry.WPF.UserControls
{
    public partial class CustomerList : UserControl
    {
        public event EventHandler<CustomerPageEventArgs> CustomerModified;
        public CustomerList()
        {
            InitializeComponent();
        }
        
        private void DetailsOnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var customer = button.Tag as Customer;
            List<Order> orders;
            if (customer.Orders == null)
            {
                orders = new List<Order>();
            }
            else
            {
                orders = customer.Orders.OrderBy(o => o.DateOfRealization).ToList();
            }
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