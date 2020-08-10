using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private Employee _selectedEmployee;
        private IEnumerable<Employee> _employees;
        private int _amount;
        private ICommand _addHarvest;
        private ICommand _addWholeHarvests;
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
        public ICommand AddHarvestCommand
        {
            get
            {
                if (_addHarvest == null)
                {
                    _addHarvest = new RelayCommand(
                        p => Validate(),
                        p => AddSingleHarvest()
                    );                    
                }
                return _addHarvest;
            }
        }
        public ICommand AddWholeHarvestCommand
        {
            get
            {
                if (_addWholeHarvests == null)
                {
                    _addWholeHarvests = new RelayCommand(
                        p => Added.Count != 0,
                        p => AddWholeHarvest()
                    );                    
                }
                return _addWholeHarvests;
            }
        }
        public IEnumerable<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
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
            var connector = DBConnector.GetInstance();
            foreach (var harvest in Added)
            {
                connector.AddHarvest(harvest);
            }
            ClearAdded();
        }

        private void ClearAdded()
        {
            Added.Clear();
            CommandManager.InvalidateRequerySuggested();
        }

        private void AddSingleHarvest()    
        {
            var harvest = new Harvest()
            {
                Amount = this._amount,
                Employee = this._selectedEmployee,
                DateTime = DateTime.Now
            };
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