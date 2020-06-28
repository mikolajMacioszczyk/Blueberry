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
    public class Address : INotifyPropertyChanged
    {
        private int _house;
        private string _street;
        private string _city;

        #region Properties
        public int Id { get; set; }

        public int House
        {
            get => _house;
            set
            {
                if (_house!= value)
                {
                    _house = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Street
        {
            get => _street;
            set
            {
                if (_street != value)
                {
                    _street = value;
                    OnPropertyChanged();
                }
            }
        }

        public string City
        {
            get => _city;
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        public override string ToString()
        {
            return $"{City}, {Street}, {House}";
        }

        protected bool Equals(Address other)
        {
            return House == other.House && Street == other.Street && City == other.City;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = House;
                hashCode = (hashCode * 397) ^ (Street != null ? Street.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                return hashCode;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
