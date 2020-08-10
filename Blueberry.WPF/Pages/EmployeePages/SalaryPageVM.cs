using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.Pages.EmployeePages
{
    public class SalaryPageVM : INotifyPropertyChanged
    {
        private SortEmployeeBy _sortBy;
        private SortEmployeeBy SortBy
        {
            get { return _sortBy; }
            set
            {
                _sortBy = value; 
                SetEmployees();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        private ICommand _changeSort;
        private List<Employee> _employees;

        public ICommand ChangeSort
        {
            get
            {
                if (_changeSort == null)
                {
                    _changeSort = new RelayCommand(p =>
                    {
                        SortEmployeeBy input = p is SortEmployeeBy ? (SortEmployeeBy) p : SortEmployeeBy.ByName;
                        return SortBy != input;
                    }, p =>
                    {
                        SortBy = p is SortEmployeeBy ? (SortEmployeeBy) p : SortEmployeeBy.ByName;
                    });
                }
                return _changeSort;
            }
        }

        public List<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public SalaryPageVM()
        {
            Employees = new List<Employee>();
            SetEmployees();
            DBConnector.GetInstance().EmployeesChanged += SetEmployees;
        }

        private void SetEmployees()
        {
            Employees.Clear();
            var data = DBConnector.GetInstance().GetEmployees();
            switch (SortBy)
            {
                case SortEmployeeBy.ByName:
                    Employees = data.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
                    break;
                case SortEmployeeBy.ByRate:
                    Employees = data.OrderBy(e => e.Rate).ToList();
                    break;
                case SortEmployeeBy.ByCollected:
                    Employees = data.OrderBy(e => e.TotalCollected).ToList();
                    break;
                case SortEmployeeBy.ByUnpaided:
                    Employees = data.OrderBy(e => e.UnPaided).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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