using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.UserControls.EmployeeControls
{
    public partial class EmployeeTemplate : UserControl
    {
        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            "PropertyType", typeof(Employee), typeof(EmployeeTemplate));

        public Employee Employee
        {
            get { return (Employee) GetValue(PropertyTypeProperty); }
            set { SetValue(PropertyTypeProperty, value); }
        }
        public EmployeeTemplate()
        {
            InitializeComponent();
            DataContext = new EmployeeTemplateVM()
            {
                Employee = this.Employee
            };
        }
    }
}