using System;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.PageEventArgs
{
    public class CustomerPageEventArgs : EventArgs
    {
        public Customer OldValue { get; set; }
        public Customer NewValue { get; set; }
        public Modification[] Modifications;

        public CustomerPageEventArgs(Customer oldValue, Customer newValue, Modification[] modifications)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Modifications = modifications;
        }
    }
}