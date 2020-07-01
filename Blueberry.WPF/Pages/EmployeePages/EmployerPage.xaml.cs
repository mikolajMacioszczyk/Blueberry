using System;
using System.Windows.Controls;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages
{
    public partial class EmployerPage : Page
    {
        private readonly ViewModel _model;
        public event EventHandler<EmployeeEditedEventArgs> EmployeeEdited;
        public event EventHandler AskSalaryPageNavigate;

        public EmployerPage(ViewModel model)
        {
            _model = model;
            EmployeeEdited += _model.OnEmployeeModifiedEventHandler;
            DataContext = _model.Employees;
            InitializeComponent();
        }

        private void EmployeeTemplate_OnEmployeeEdited(object sender, EmployeeEditedEventArgs e)
        {
            EmployeeEdited?.Invoke(sender, e);
        }

        private void EmployeeTemplate_OnPaymentNeeded(object sender, EventArgs e)
        {
            AskSalaryPageNavigate?.Invoke(sender, e);
        }
    }
}