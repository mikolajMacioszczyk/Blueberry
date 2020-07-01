using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages
{
    public partial class NewEmployeePage : Page
    {
        public event EventHandler<NewEmployeeEventArgs> EmployeeAdded;
        
        private readonly ViewModel _model;

        public NewEmployeePage(ViewModel model)
        {
            _model = model;
            InitializeComponent();
            EmployeeAdded += _model.OnEmployeeAddedEventHandler;
        }

        private void InsertOnClick(object sender, RoutedEventArgs args)
        {
            try
            {
                var employee = GetEmployeeFromTextBoxes();
                EmployeeAdded?.Invoke(this, new NewEmployeeEventArgs(employee));
            }
            catch (FormatException)
            {
                InfoBox.Text = "Niepoprawna warotść liczbowa";
            }
            catch (ArgumentException exception)
            {
                InfoBox.Text = exception.Message;
            }
        }

        private Employee GetEmployeeFromTextBoxes()
        {
            var firstName = FirstNameTextBox.Text;
            var lastName = LastNameTextBox.Text;
            if (_model.Employees.Any(e => e.FirstName == firstName && e.LastName == lastName))
            {
                throw new ArgumentException("Pracownik o padanym imieniu i nazwisku już istnieje");
            }

            var phoneNumber = !string.IsNullOrEmpty(PhoneNumberTextBox.Text) ? Convert.ToInt32(PhoneNumberTextBox.Text) : 0;
            var rate = (float) Convert.ToDouble(RateTextBox.Text);
                
            var employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Rate = rate
            };
            return employee;
        }

        private void DiscardOnClick(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            InfoBox.Text = string.Empty;
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            PhoneNumberTextBox.Text = string.Empty;
            RateTextBox.Text = string.Empty;
        }
    }
}