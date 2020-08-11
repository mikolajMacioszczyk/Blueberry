using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.UserControls.EmployeeControls;

namespace Blueberry.WPF.Pages.EmployeePages
{
    public class SalaryPageVM : INotifyPropertyChanged
    {
        private SortEmployeeBy _sortBy;
        private SortEmployeeBy SortBy
        {
            get => _sortBy;
            set
            {
                _sortBy = value; 
                SetEmployees();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        private ICommand _changeSort;
        public ICommand ChangeSort
        {
            get
            {
                if (_changeSort == null)
                {
                    _changeSort = new RelayCommand(p =>
                    {
                        SortEmployeeBy input = (SortEmployeeBy) Enum.Parse(typeof(SortEmployeeBy), p.ToString());
                        return SortBy != input;
                    }, p =>
                    {
                        SortBy = (SortEmployeeBy) Enum.Parse(typeof(SortEmployeeBy), p.ToString());
                    });
                }
                return _changeSort;
            }
        }
        private List<SalaryTemplateVM> _salaryModels;
        public List<SalaryTemplateVM> SalaryModels
        {
            get => _salaryModels;
            set
            {
                _salaryModels = value;
                OnPropertyChanged();
            }
        }

        public SalaryPageVM()
        {
            SalaryModels = new List<SalaryTemplateVM>();
            Refresh();
            DBConnector.GetInstance().EmployeesChanged += Refresh;
        }

        private void Refresh()
        {
            SetEmployees();   
        }

        private async void SetEmployees()
        {
            await Task.Factory.StartNew(() =>
            {
                var data = DBConnector.GetInstance().GetEmployees();
                IOrderedEnumerable<Employee> sorted;
                switch (SortBy)
                {
                    case SortEmployeeBy.ByName:
                        sorted = data.OrderBy(e => e.LastName).ThenBy(e => e.FirstName);
                        break;
                    case SortEmployeeBy.ByRate:
                        sorted = data.OrderByDescending(e => e.Rate);
                        break;
                    case SortEmployeeBy.ByCollected:
                        sorted = data.OrderByDescending(e => e.TotalCollected);
                        break;
                    case SortEmployeeBy.ByUnpaided:
                        sorted = data.OrderByDescending(e => e.UnPaided);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                SalaryModels = sorted.Select(e => new SalaryTemplateVM(e)).ToList();
            });
        }
        
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}