using System;
using System.Collections.Generic;

namespace Blueberry.DLL.Models
{
    public class Harvest
    {
        public int Id { get; set; }        
        public float Amount { get; set; }
        public DateTime DateTime { get; set; }
        public Employee Employee { get; set; }

        public string FullString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Amount)}: {Amount}, {nameof(DateTime)}: {DateTime}, {nameof(Employee)}: {Employee}";
        }
    }
}