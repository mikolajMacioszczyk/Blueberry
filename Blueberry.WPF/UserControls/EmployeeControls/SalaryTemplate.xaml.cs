using System;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;

namespace Blueberry.WPF.UserControls
{
    public partial class SalaryTemplate : UserControl
    {
        public event EventHandler<EmployeeEditedEventArgs> EmployeePaided; 
        public SalaryTemplate()
        {
            InitializeComponent();
        }

        private void Pay(Employee employee, float oldValue, float newValue)
        {
            if (oldValue < 0.01)
            { return; }
            EmployeePaided?.Invoke(this, new EmployeeEditedEventArgs(employee, new []{new Modification(oldValue, newValue)}));
        }

        private void PayAllOnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button.DataContext as Employee;
            
            var amountBefore = employee.UnPaided;
            employee.UnPaided = 0;
            Pay(employee, amountBefore, employee.UnPaided);
        }

        private void PayPartOnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button.DataContext as Employee;

            PayGrid.Visibility = Visibility.Visible;

            PaySlider.Maximum = employee.UnPaided;
            PaySlider.Value = employee.UnPaided;
        }

        private void PayOnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button.DataContext as Employee;
            var amountBefore = employee.UnPaided;
            employee.UnPaided -= (float) PaySlider.Value;
            Pay(employee, amountBefore, employee.UnPaided);
        }

        private void DiscardOnClick(object sender, RoutedEventArgs e)
        {
            PayGrid.Visibility = Visibility.Collapsed;
        }
    }
}