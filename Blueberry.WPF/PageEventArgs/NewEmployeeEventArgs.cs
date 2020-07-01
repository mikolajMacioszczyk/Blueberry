using Blueberry.DLL.Models;

namespace Blueberry.WPF.PageEventArgs
{
    public class NewEmployeeEventArgs
    {
        public Employee Employee { get; }

        public NewEmployeeEventArgs(Employee employee)
        {
            Employee = employee;
        }
    }
}