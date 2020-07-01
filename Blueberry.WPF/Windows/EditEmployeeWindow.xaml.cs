using System;
using System.Globalization;
using System.Windows;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.Windows
{
    public partial class EditEmployeeWindow : Window
    {
        private Employee Employee;
        
        public EditEmployeeWindow()
        {
            InitializeComponent();
        }
        
        public Employee Edit(Employee employee)
        {
            Employee = new Employee(employee);
            Refresh();
            base.ShowDialog();

            return Employee;
        }
        
        private void DiscardOnClick(object sender, RoutedEventArgs e)
        {
            Employee = null;
            this.Close();
        }

        private void SaveOnClick(object sender, RoutedEventArgs e)
        {
            Info.Text = "";
            try
            {
                var firstName = !string.IsNullOrEmpty(FirstNameTextBox.Text)
                    ? FirstNameTextBox.Text
                    : throw new ArgumentException();
                var lastName = !string.IsNullOrEmpty(LastNameTextBox.Text)
                    ? LastNameTextBox.Text
                    : throw new ArgumentException();
                var rate = !string.IsNullOrEmpty(RateTextBox.Text)
                    ? Convert.ToDouble(RateTextBox.Text)
                    : throw new ArgumentException();
                var phoneNumber = !string.IsNullOrEmpty(PhoneNumberTextBox.Text)
                    ? Convert.ToInt32(PhoneNumberTextBox.Text)
                    : throw new ArgumentException();
                Employee.Rate = (float) rate;
                Employee.FirstName = firstName;
                Employee.LastName = lastName;
                Employee.PhoneNumber = phoneNumber;
                this.Close();
            }
            catch (ArgumentException)
            {
                Info.Text = "Pola nie moga być puste";
                Refresh();
            }
            catch (FormatException)
            {
                Info.Text = "Niepoprawna wartość liczbowa";
                Refresh();
            }
        }

        private void Refresh()
        {
            FirstNameTextBox.Text = Employee.FirstName;
            LastNameTextBox.Text = Employee.LastName;
            PhoneNumberTextBox.Text = Employee.PhoneNumber.ToString();
            RateTextBox.Text = Employee.Rate.ToString(CultureInfo.InvariantCulture);
        }
    }
}