using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Blueberry.DLL.Annotations;

namespace Blueberry.DLL.Models
{
    public class Customer : IComparable<Customer>, INotifyPropertyChanged
    {
        #region Properties
        private string _firstName;
        private string _lastName;
        private string _number;
        public int Id { get; set; }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value!= _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();                    
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Number
        {
            get => _number;
            set
            {
                if (value != _number)
                {
                    _number = value;
                    OnPropertyChanged();                    
                }
            }
        }
        public Address Address { get; set; }

        #endregion
        public IList<Order> Orders { get; set; }

        public Customer() { }

        public Customer(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Number = customer.Number;
            Address = new Address()
            {
                Id = customer.Address.Id,
                City = customer.Address.City,
                House = customer.Address.House,
                Street = customer.Address.Street
            };
            Orders = customer.Orders;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public string FullString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Number)}: {Number}, {nameof(Address)}: {Address}, {nameof(Orders)}: {Orders}";
        }


        public int CompareTo(Customer other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var firstNameComparison = string.Compare(FirstName, other.FirstName, StringComparison.Ordinal);
            if (firstNameComparison != 0) return firstNameComparison;
            return string.Compare(LastName, other.LastName, StringComparison.Ordinal);
        }

        private sealed class FirstNameLastNameEqualityComparer : IEqualityComparer<Customer>
        {
            public bool Equals(Customer x, Customer y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.FirstName == y.FirstName && x.LastName == y.LastName;
            }

            public int GetHashCode(Customer obj)
            {
                unchecked
                {
                    return ((obj.FirstName != null ? obj.FirstName.GetHashCode() : 0) * 397) ^ (obj.LastName != null ? obj.LastName.GetHashCode() : 0);
                }
            }
        }

        public static IEqualityComparer<Customer> FirstNameLastNameComparer { get; } = new FirstNameLastNameEqualityComparer();
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
