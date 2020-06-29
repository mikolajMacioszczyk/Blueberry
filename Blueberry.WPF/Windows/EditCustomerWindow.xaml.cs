using System;
using System.Windows;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.Windows
{
    public partial class EditCustomerWindow : Window
    {
        private Customer Customer;
        private Customer Save;
        private Address SaveAddress;
        
        public EditCustomerWindow()
        {
            InitializeComponent();
        }

        public Customer Edit(Customer customer)
        {
            Customer = new Customer(customer);
            Save = new Customer(customer);
            SaveAddress = new Address(customer.Address);
            Refresh();
            base.ShowDialog();
            return Customer;
        }

        private void Refresh()
        {
            InfoBox.Text = "";
            
            Customer = new Customer(Save);
            
            FirstNameTextBox.Text = Save.FirstName;
            LastNameTextBox.Text = Save.LastName;
            PhoneNumberTextBox.Text = Save.Number;
            CityTextBox.Text = SaveAddress.City;
            StreetTextBox.Text = SaveAddress.Street;
            HouseTextBox.Text = SaveAddress.House.ToString();
        }

        private void SubmitOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer.FirstName = FirstNameTextBox.Text;
                Customer.LastName = LastNameTextBox.Text;
                Customer.Number = Convert.ToInt32(PhoneNumberTextBox.Text).ToString();
                Customer.Address.City = CityTextBox.Text;
                Customer.Address.Street = StreetTextBox.Text;
                Customer.Address.House = Convert.ToInt32(HouseTextBox.Text);
                this.Close();
            }
            catch (FormatException)
            {
                Refresh();
                InfoBox.Text = "Nieprawidłowa wartość liczbowa";
            }
        }

        private void CancelOnClick(object sender, RoutedEventArgs e)
        {
            Customer = null;
            this.Close();
        }
    }
}