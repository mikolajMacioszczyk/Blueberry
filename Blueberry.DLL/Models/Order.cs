using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Blueberry.DLL.Annotations;

namespace Blueberry.DLL.Models
{
    public class Order : INotifyPropertyChanged

    {
        private float _amount;
        private Priority _priority;
        private OrderStatus _status;
        private DateTime _dateOfRealization;

        public Order()
        {
        }

        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public float Amount
        {
            get => _amount;
            set
            {
                if (Math.Abs(value - _amount) > 0.01)
                {
                    _amount = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime DateOfOrder { get; set; }

        public DateTime DateOfRealization
        {
            get => _dateOfRealization;
            set
            {
                if (_dateOfRealization != value)
                {
                    _dateOfRealization = value;
                    OnPropertyChanged();
                }
            }
        }

        public Priority Priority
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged();
                }
            }
        }

        public OrderStatus Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public Order(Order argsOrder)
        {
            Id = argsOrder.Id;
            Customer = argsOrder.Customer;
            Amount = argsOrder.Amount;
            DateOfOrder = argsOrder.DateOfOrder;
            DateOfRealization = argsOrder.DateOfRealization;
            Priority = argsOrder.Priority;
            Status = argsOrder.Status;
        }

        public string FullString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Customer)}: {Customer}, {nameof(Amount)}: {Amount}, {nameof(DateOfOrder)}: {DateOfOrder}, " +
                $"{nameof(DateOfRealization)}: {DateOfRealization}, {nameof(Priority)}: {Priority}, {nameof(Status)}: {Status}";
        }

        public override string ToString()
        {
            string dateString = DateOfRealization.ToShortDateString();
            return $"Klient: {Customer},  Ilość: {Amount},  Do: {dateString}";
        }

        protected bool Equals(Order other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Order) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}