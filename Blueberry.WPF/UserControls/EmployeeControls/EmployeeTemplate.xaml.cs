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
    public partial class EmployeeTemplate : UserControl
    {
        public event EventHandler<EmployeeEditedEventArgs> EmployeeEdited;
        public event EventHandler PaymentNeeded;
        public EmployeeTemplate()
        {
            InitializeComponent();
        }

        private void PayOnClick(object sender, RoutedEventArgs e)
        {
            PaymentNeeded?.Invoke(this, e);
        }
        
        private void EditOnClick(object sender, RoutedEventArgs e)
        {
            Employee oldEmployee = (sender as Button).DataContext as Employee;
            var newEmployeeWindow = new EditEmployeeWindow();
            var afterEditing = newEmployeeWindow.Edit(oldEmployee);
            if (afterEditing == null)
            { return; }
            var modifications = GetAndMakeModifications(oldEmployee, afterEditing);
            if (modifications.Length == 0)
            { return; }
            EmployeeEdited?.Invoke(this, new EmployeeEditedEventArgs(oldEmployee, modifications));
        }

        private Modification[] GetAndMakeModifications(Employee before, Employee after)
        {
            var output = new List<Modification>();
            if (!before.FirstName.Equals(after.FirstName))
            {
                output.Add(new Modification(before.FirstName, after.FirstName));
                before.FirstName = after.FirstName;
            }
            if (!before.LastName.Equals(after.LastName))
            {
                output.Add(new Modification(before.LastName, after.LastName));
                before.LastName = after.LastName;
            }
            if (!before.PhoneNumber.Equals(after.PhoneNumber))
            {
                output.Add(new Modification(before.PhoneNumber, after.PhoneNumber));
                before.PhoneNumber = after.PhoneNumber;
            }
            if (!before.Rate.Equals(after.Rate))
            {
                output.Add(new Modification(before.Rate, after.Rate));
                before.Rate = after.Rate;
            }

            return output.ToArray();
        }
    }
}