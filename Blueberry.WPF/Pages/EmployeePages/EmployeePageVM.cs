using System;
using System.Collections.ObjectModel;
using System.Linq;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.UserControls.EmployeeControls;

namespace Blueberry.WPF.Pages.EmployeePages
{
    public class EmployeePageVM
    {
        public event Action<PageType> ContentSwitchRequested;
        public ObservableCollection<EmployeeTemplateVM> EmployeeModels { get; set; }
        public EmployeePageVM()
        {
            DBConnector.GetInstance().EmployeesChanged += Refresh;
            Refresh();
        }

        private void Refresh()
        {
            var employees = DBConnector.GetInstance().GetEmployees().OrderBy(e => e.LastName).ThenBy(e => e.FirstName)
                .ThenBy(e => e.Id);
            if (EmployeeModels == null)
            {
                EmployeeModels = new ObservableCollection<EmployeeTemplateVM>();
            }
            EmployeeModels.Clear();
            var data = employees.Select(e =>
            {
                var model = new EmployeeTemplateVM(e);
                model.ContentSwitchRequested += t => ContentSwitchRequested.Invoke(t);
                return model;
            });
            foreach (var vm in data)
            {
                EmployeeModels.Add(vm);
            }
        }
    }
}