using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
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
        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }
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
        #endregion

        private void Add()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(PhoneNumber))
            {
                Info = validationString1;
                return;
            }

            if (DBConnector.GetInstance().GetEmployees().Any(e => e.FirstName.Equals(FirstName) && e.LastName.Equals(LastName)))
            {
                Info = validationString4;
                return;
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
                Info = validationString2;
                return;
            }
            if (Rate < 0.1)
            {
                Info = validationString3;
                return;
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
            DBConnector.GetInstance().AddEmployee(employee);
            Clear();
            throw new InvalidCastException("Wrzyc messageboxa");
        }

        private void Discard()
        {
            Clear();
            throw new InvalidCastException("Wrzuć messageboxa");
        }

        private void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            Rate = 0;
            Info = string.Empty;
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