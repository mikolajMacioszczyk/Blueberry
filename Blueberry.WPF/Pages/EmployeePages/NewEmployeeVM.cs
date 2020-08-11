using System;
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
    public class NewEmployeeVM : INotifyPropertyChanged
    {
        private static string validationString1 = "Pola nie mogą być puste";
        private static string validationString2 = "Niepoprawny numer telefonu";
        private static string validationString3 = "Niepoprawna stawka";
        private static string validationString4 = "Pracownik o podanym imieniu i nazwisku już istnieje";

        public event Action<PageType> ChangeContentRequested; 

        #region Properties
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
        private float _rate;
        public float Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(p => true,
                        p => Add());
                }
                return _addCommand;
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
        private ICommand _changeContentCommand;
        public ICommand ChangeContentCommand
        {
            get
            {
                if (_changeContentCommand == null)
                {
                    _changeContentCommand = new RelayCommand(p => true,
                        p => ChangeContentRequested?.Invoke(PageType.EmployerPage));
                }
                return _changeContentCommand;
            }
        }
        #endregion

        private void Add()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(PhoneNumber))
            {
                throw new InvalidOperationException(validationString1);
            }

            if (DBConnector.GetInstance().GetEmployees().Any(e => e.FirstName.Equals(FirstName) && e.LastName.Equals(LastName)))
            {
                throw new InvalidOperationException(validationString4);
            }

            int number;
            try
            {
                number = Convert.ToInt32(PhoneNumber);
                if (PhoneNumber.Length != 9)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                throw new InvalidOperationException(validationString2);
            }
            if (Rate < 0.1)
            {
                throw new InvalidOperationException(validationString3);
            }
            var employee = new Employee()
            {
                FirstName = _firstName,
                LastName = _lastName,
                Rate = _rate,
                PhoneNumber = number,
                TotalCollected = 0,
                UnPaided = 0
            };
            DBConnector.GetInstance().AddEmployeeAsync(employee);
            Clear();
        }

        private void Discard()
        {
            Clear();
        }

        private void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            Rate = 0;
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