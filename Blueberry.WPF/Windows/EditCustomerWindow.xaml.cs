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
                Customer.FirstName = !string.IsNullOrEmpty(FirstNameTextBox.Text)
                    ? FirstNameTextBox.Text
                    : throw new ArgumentException();
                Customer.LastName = !string.IsNullOrEmpty(LastNameTextBox.Text)
                    ? LastNameTextBox.Text
                    : throw new ArgumentException();
                Customer.Number = !string.IsNullOrEmpty(PhoneNumberTextBox.Text)
                    ? PhoneNumberTextBox.Text
                    : throw new ArgumentException();
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
            catch (ArgumentException)
            {
                Refresh();
                InfoBox.Text = "Pola nie mogą być puste";
            }
        }

        private void CancelOnClick(object sender, RoutedEventArgs e)
        {
            Customer = null;
            this.Close();
        }
    }
}