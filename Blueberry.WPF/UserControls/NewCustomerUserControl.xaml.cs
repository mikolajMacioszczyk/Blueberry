using System;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;

namespace Blueberry.WPF.UserControls
{
    public partial class NewCustomerUserControl : UserControl
    {
        public event EventHandler<NewCustomerEventArgs> CustomerAdded; 
        public event EventHandler Discarded; 
        public NewCustomerUserControl()
        {
            InitializeComponent();
        }

        private void SubmitOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var firstName = !string.IsNullOrEmpty(FirstNameTextBox.Text)
                    ? FirstNameTextBox.Text
                    : throw new ArgumentException();
                
                var lastName = !string.IsNullOrEmpty(LastNameTextBox.Text)
                    ? LastNameTextBox.Text
                    : throw new ArgumentException();
                
                var phoneNumber = Convert.ToInt32(PhoneNumberTextBox.Text);
                
                var city = !string.IsNullOrEmpty(CityTextBox.Text)
                    ? CityTextBox.Text
                    : throw new ArgumentException();
                
                var street = !string.IsNullOrEmpty(StreetTextBox.Text)
                    ? StreetTextBox.Text
                    : throw new ArgumentException();

                var house = Convert.ToInt32(HouseTextBox.Text);
                
                CustomerAdded?.Invoke(this, new NewCustomerEventArgs(firstName,lastName,phoneNumber.ToString(),city, street, house));
            }
            catch (ArgumentException)
            {
                InfoBox.Text = "Pola nie mogą być puste";
            }
            catch (FormatException)
            {
                InfoBox.Text = "Niepoprawna wartość liczbowa";
            }
        }
        
        private void DiscardOnClick(object sender, RoutedEventArgs e)
        {
            Discarded?.Invoke(this, EventArgs.Empty);
        }
    }
}