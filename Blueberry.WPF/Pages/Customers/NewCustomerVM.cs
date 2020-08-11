using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.Pages.Customers
{
    public class NewCustomerVM : INotifyPropertyChanged
    {
        private static string _validationString1 = "Pola oznaczone gwiazdką muszą być wypełnione";
        private static string _validationString2 = "Telefon powinien być numerem składającym się z 9 cyfr";
        private static string _validationString3 = "Klient o podanym imieniu i nazwisku już istnieje";

        public event Action Done;
        
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
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }
        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged();
            }
        }
        private int _house;
        public int House
        {
            get { return _house; }
            set
            {
                _house = value;
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
        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(p => true,
                        p =>
                        {
                            Add();
                        });
                }
                return _submitCommand;
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
                        p =>
                        {
                            Discard();
                        });
                }
                return _discardCommand;
            }
        }
        #endregion
        // zrobić dependencyProp w xaml i podpiąć się do jego wartości
        private void Add()
        {
            if (Validate())
            {
                var address = GetAddress();
                var customer = new Customer()
                {
                    FirstName = _firstName,
                    LastName = _lastName,
                    Number = _phoneNumber,
                    Orders = new List<Order>(),
                    Address = address
                };
                DBConnector.GetInstance().AddCustomerAsync(customer);
                Clear();
                Done?.Invoke();
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(PhoneNumber))
            {
                Info = _validationString1;
                return false;
            }

            try
            {
                var int32 = Convert.ToInt32(PhoneNumber);
                if (_phoneNumber.Length != 9)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException e)
            {
                Info = _validationString2;
                return false;
            }
            if (DBConnector.GetInstance().GetCustomers().Any(c => c.FirstName.Equals(FirstName) && c.LastName.Equals(LastName)))
            {
                Info = _validationString3;
                return false;
            }
            return true;
        }

        private Address GetAddress()
        {
            Address address;
            try
            {
                if (House == 0 && Street == null && City == null)
                {
                    address = Address.Empty;
                }
                else
                {
                    address = DBConnector.GetInstance().GetAddresses().First(a =>
                        a.City.Equals(City) && a.House == House && a.Street.Equals(Street));
                }
                
            }
            catch (InvalidOperationException)
            {
                address = new Address()
                {
                    City = _city,
                    House = _house,
                    Street = _street,
                };
                DBConnector.GetInstance().AddAddressAsync(address);
            }
            return address;
        }
        
        private void Discard()
        {
            Clear();
            Done?.Invoke();
        }

        private void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            City = string.Empty;
            Street = string.Empty;
            House = 0;
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