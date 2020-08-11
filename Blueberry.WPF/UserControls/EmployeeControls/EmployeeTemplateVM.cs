using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementation;

namespace Blueberry.WPF.UserControls.EmployeeControls
{
    public class EmployeeTemplateVM : INotifyPropertyChanged
    {
        private static string validationString1 = "Pola nie mogą być puste";
        private static string validationString2 = "Stawka nie może być ujemna";
        private static string validationString3 = "Numer telefonu powinien składać się z 9 cyfr";
        private static string validationString4 = "Pracownik o podanych danych już istnieje";
        
        public event Action<PageType> ContentSwitchRequested;

        #region Properties
        private UserControl _show = new ShowEmployee();
        private UserControl _edit = new EditEmployee();
        private UserControl _content;
        public UserControl Content
        {
            get => _content;
            set
            {
                _content = value;
                if (value == _edit)
                {
                    Padding = 7;
                    Thickness = 5;
                    Brush = Brushes.Teal;
                }
                else
                {
                    Padding = 5;
                    Thickness = 3;
                    Brush = Brushes.DarkGray;
                }
                OnPropertyChanged();
            }
        }
        private int _padding;
        public int Padding
        {
            get { return _padding; }
            set
            {
                _padding = value;
                OnPropertyChanged();
            }
        }
        private int _thickness;
        public int Thickness
        {
            get { return _thickness; }
            set
            {
                _thickness = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush _brush;
        public SolidColorBrush Brush
        {
            get { return _brush; }
            set
            {
                _brush = value;
                OnPropertyChanged();
            }
        }
        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
        private Employee _copy;
        public Employee Copy
        {
            get { return _copy; }
            set
            {
                _copy = value;
                OnPropertyChanged();
            }
        }
        private string _info;
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(
                        p => true,
                        p => EditEmployee()
                    );
                }
                return _editCommand;
            }
        }
        private ICommand _payCommmand;
        public ICommand PayCommand
        {
            get
            {
                if (_payCommmand == null)
                {
                    _payCommmand = new RelayCommand(p => true, p => ContentSwitchRequested?.Invoke(PageType.SalaryPage));
                }
                return _payCommmand;
            }
        }
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(p => true, p => Save());
                }
                return _saveCommand;
            }
        }
        private ICommand _discardCommand;
        public ICommand DiscardCommand
        {
            get
            {
                if (_discardCommand == null)
                {
                    _discardCommand = new RelayCommand(p => true,
                        p => Discard());
                }
                return _discardCommand;
            }
        }
        #endregion
        
        public EmployeeTemplateVM(Employee employee)
        {
            _employee = employee;
            Copy = new Employee(employee);
            _edit.DataContext = this;
            _show.DataContext = this;
            Content = new ShowEmployee();
        }
        
        private void Discard()
        {
            Copy.Rate = Employee.Rate;
            Copy.FirstName = Employee.FirstName;
            Copy.LastName = Employee.LastName;
            Copy.PhoneNumber = Employee.PhoneNumber;
            Copy.TotalCollected = Employee.TotalCollected;
            Copy.UnPaided = Employee.UnPaided;

            Info = string.Empty;
            Content = _show;
        }
        
        private void Save()
        {
            try
            {
                Validate();
            }
            catch (InvalidOperationException e)
            {
                Info = e.Message;
                return;
            }
            Info = string.Empty;
            DBConnector.GetInstance().ModifyEmployeeAsync(Employee, GetModifications());
            Content = _show;
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Copy.FirstName) || string.IsNullOrEmpty(Copy.LastName))
            {
                throw new InvalidOperationException(validationString1);
            }
            if (Copy.Rate <= 0)
            {
                throw new InvalidOperationException(validationString2);
            }
            if (Copy.PhoneNumber < 100000000 || Copy.PhoneNumber > 999999999)
            {
                throw new InvalidOperationException(validationString3);
            }

            if ((!Employee.FirstName.Equals(Copy.LastName) || !Employee.LastName.Equals(Copy.LastName)) &&
                DBConnector.GetInstance().GetEmployees().Any(e => e.FirstName.Equals(Copy.FirstName) && e.LastName.Equals(Copy.LastName)))
            {
                throw new InvalidOperationException(validationString4);
            }
        }

        private Modification[] GetModifications()
        {
            List<Modification> output = new List<Modification>();
            if (Math.Abs(Employee.Rate - Copy.Rate) > 0.1)
            {
                output.Add(new Modification(Employee.Rate, Copy.Rate));
                Employee.Rate = Copy.Rate;
            }
            if (!Employee.FirstName.Equals(Copy.FirstName))
            {
                output.Add(new Modification(Employee.FirstName, Copy.LastName));
                Employee.FirstName = Copy.FirstName;
            }
            if (!Employee.LastName.Equals(Copy.LastName))
            {
                output.Add(new Modification(Employee.LastName, Copy.LastName));
                Employee.LastName = Copy.LastName;
            }
            if (!Employee.PhoneNumber.Equals(Copy.PhoneNumber))
            {
                output.Add(new Modification(Employee.PhoneNumber, Copy.PhoneNumber));
                Employee.PhoneNumber = Copy.PhoneNumber;
            }
            return output.ToArray();
        }

        private void EditEmployee()
        {
            Content = _edit;
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