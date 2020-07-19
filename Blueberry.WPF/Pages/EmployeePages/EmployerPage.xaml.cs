using System;
using System.Windows.Controls;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages
{
    public partial class EmployerPage : Page
    {
        private readonly ViewModel _model;
        public event EventHandler AskSalaryPageNavigate;

        public EmployerPage(ViewModel model)
        {
            _model = model;
            DataContext = _model.Employees;
            InitializeComponent();
        }
        private void EmployeeTemplate_OnPaymentNeeded(object sender, EventArgs e)
        {
            AskSalaryPageNavigate?.Invoke(sender, e);
        }
    }
}