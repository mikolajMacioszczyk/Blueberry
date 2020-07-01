using Blueberry.DLL.Models;
using Blueberry.WPF.UserControls;

namespace Blueberry.WPF.PageEventArgs
{
    public class EmployeeEditedEventArgs
    {
        public Employee Edited { get; }
        public Modification[] Modifications { get; }

        public EmployeeEditedEventArgs(Employee edited, Modification[] modifications)
        {
            Edited = edited;
            Modifications = modifications;
        }
    }
}