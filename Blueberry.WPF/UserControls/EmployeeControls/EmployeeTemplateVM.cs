using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.UserControls.EmployeeControls
{
    public class EmployeeTemplateVM : INotifyPropertyChanged
    {
        private ICommand _editCommand;
        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }

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
                    _payCommmand = new RelayCommand(p => true, p => throw new InvalidOperationException("Nie zaimplementowano płacenia"));
                }
                return _payCommmand;
            }
        }

        private void EditEmployee()
        {
            throw new System.NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}