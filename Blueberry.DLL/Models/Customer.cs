using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.DLL.Models
{
    public class Customer : IComparable<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
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
    }
}
