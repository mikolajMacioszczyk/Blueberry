using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.UserControls.EmployeeControls
{
    public partial class SalaryTemplate : UserControl
    {
        public static readonly DependencyProperty EmployeeProperty = DependencyProperty.Register(
            nameof(Employee),
            typeof(Employee),
            typeof(SalaryTemplate));
        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                DataContext = new SalaryTemplateVM(_employee);
            }
        }
        public SalaryTemplate()
        {
            InitializeComponent();
        }
    }
}