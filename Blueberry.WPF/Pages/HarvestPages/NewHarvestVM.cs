using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.Pages.HarvestPages
{
    public class NewHarvestVM : INotifyPropertyChanged
    {
        #region Properties
        private ICommand _discard;
        public ICommand DiscardCommand
        {
            get
            {
                if (_discard == null)
                {
                    _discard = new RelayCommand(
                        p => Added.Count != 0,
                        p => ClearAdded()
                        );   
                }
                return _discard;
            }
        }
        private ICommand _addHarvestCommand;
        public ICommand AddHarvestCommand
        {
            get
            {
                if (_addHarvestCommand == null)
                {
                    _addHarvestCommand = new RelayCommand(
                        p => Validate(),
                        p => AddSingleHarvest()
                    );                    
                }
                return _addHarvestCommand;
            }
        }
        private ICommand _addWholeHarvestsCommand;
        public ICommand AddWholeHarvestCommand
        {
            get
            {
                if (_addWholeHarvestsCommand == null)
                {
                    _addWholeHarvestsCommand = new RelayCommand(
                        p => Added.Count != 0,
                        p => AddWholeHarvest()
                    );                    
                }
                return _addWholeHarvestsCommand;
            }
        }
        private IEnumerable<Employee> _employees;
        public IEnumerable<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public ObservableCollection<Harvest> Added { get; } = new ObservableCollection<Harvest>();

        #endregion
        public NewHarvestVM()
        {
            LoadEmployees();
            DBConnector.GetInstance().EmployeesChanged += LoadEmployees;
        }

        private void AddWholeHarvest()
        {
            DBConnector.GetInstance().AddEnumerableHarvestAsync(new List<Harvest>(Added));
            ClearAdded();
        }

        private void ClearAdded()
        {
            Added.Clear();
            CommandManager.InvalidateRequerySuggested();
        }

        private void AddSingleHarvest()
        {
            Harvest harvest;
            if (Added.Any(h => h.Employee.Equals(SelectedEmployee)))
            {
                harvest = Added.First(h => h.Employee.Equals(SelectedEmployee));
                harvest.Amount += Amount;
                Added.Remove(harvest);
            }
            else
            {
                harvest = new Harvest()
                {
                    Amount = this._amount,
                    Employee = this._selectedEmployee,
                    DateTime = DateTime.Now
                };
            }
            Added.Add(harvest);
            CommandManager.InvalidateRequerySuggested();
        }

        private bool Validate()
        {
            return _selectedEmployee != null && Amount > 0;
        }
        private void LoadEmployees()
        {
            Employees = DBConnector.GetInstance().GetEmployees().OrderBy(e => e.LastName);
        }
        
        #region INotifyProertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}