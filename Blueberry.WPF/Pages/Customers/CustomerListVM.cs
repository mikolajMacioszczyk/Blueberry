using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.Windows;

namespace Blueberry.WPF.Pages.Customers
{
    public class CustomerListVM : INotifyPropertyChanged
    {
        private IEnumerable<Customer> _customers;
        public IEnumerable<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        private ICommand _detailsCommand;
        public ICommand DetailsCommand
        {
            get
            {
                if (_detailsCommand == null)
                {
                    _detailsCommand = new RelayCommand(p => true,
                        p =>
                        {
                            var customer = p as Customer;
                            List<Order> orders;
                            if (customer.Orders == null)
                            {
                                orders = new List<Order>();
                            }
                            else
                            {
                                orders = customer.Orders.OrderBy(o => o.DateOfRealization).ToList();
                            }
                            new CustomerDetailsWindow(){DataContext = orders}.ShowDialog();
                        });                    
                }
                return _detailsCommand;
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(p => true,
                        p =>
                        {
                            ModifyCustomer(p);
                        });   
                }
                return _editCommand;
            }
        }

        public CustomerListVM()
        {
            LoadCustomers();
            DBConnector.GetInstance().CustomersChanged += LoadCustomers;
        }

        private void LoadCustomers()
        {
            Customers = DBConnector.GetInstance().GetCustomers().OrderBy(c => c.LastName).ThenBy(c => c.FirstName)
                .ThenBy(c => c.Id);
        }

        private void ModifyCustomer(object parameter)
        {
            var oldCustomer = parameter as Customer;
            var newCustomer = new EditCustomerWindow().Edit(oldCustomer);
            if (newCustomer != null)
            {
                DBConnector.GetInstance().ModifyCustomerAsync(oldCustomer,GetModifications(oldCustomer,newCustomer));
            }
        }
        
        private Modification[] GetModifications(Customer before, Customer after)
        {
            var modifications = new List<Modification>();
            if (!before.FirstName.Equals(after.FirstName))
            {
                modifications.Add(new Modification(before.FirstName, after.FirstName));
                before.FirstName = after.FirstName;
            }
            if (!before.LastName.Equals(after.LastName))
            {
                modifications.Add(new Modification(before.LastName, after.LastName));
                before.LastName = after.LastName;
            }
            if (!before.Number.Equals(after.Number))
            {
                modifications.Add(new Modification(before.Number, after.Number));
                before.Number = after.Number;
            }
            if (!before.Address.Equals(after.Address))
            {
                modifications.Add(new Modification(before.Address, after.Address));
                before.Address = after.Address;
            }
            return modifications.ToArray();
        }
        
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}