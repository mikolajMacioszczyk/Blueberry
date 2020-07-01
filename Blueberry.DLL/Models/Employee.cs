using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.DLL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public float Rate { get; set; }
        public float TotalCollected { get; set; }
        public float UnPaided { get; set; }

        public Employee() { }

        public Employee(Employee employee)
        {
            Id = employee.Id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            PhoneNumber = employee.PhoneNumber;
            Rate = employee.Rate;
            TotalCollected = employee.TotalCollected;
            UnPaided = employee.UnPaided;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }

        public string FullString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, " +
                   $"{nameof(PhoneNumber)}: {PhoneNumber}, {nameof(Rate)}: {Rate}, {nameof(TotalCollected)}: {TotalCollected}, {nameof(UnPaided)}: {UnPaided}";
        }
    }
}
