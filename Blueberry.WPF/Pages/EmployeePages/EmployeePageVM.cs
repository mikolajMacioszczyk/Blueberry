using System.Collections.ObjectModel;
using System.Linq;
using Blueberry.DLL;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.Pages.EmployeePages
{
    public class EmployeePageVM
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public EmployeePageVM()
        {
            DBConnector.GetInstance().EmployeesChanged += Refresh;
            Refresh();
        }

        private void Refresh()
        {
            Employees = new ObservableCollection<Employee>(
                DBConnector.GetInstance().GetEmployees().OrderBy(e => e.LastName)
                );
        }
    }
}