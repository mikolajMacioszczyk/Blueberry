using System;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.PageEventArgs
{
    public class NewOrderEventArgs : EventArgs
    {
        public Order Order { get; }

        public NewOrderEventArgs(Order order)
        {
            Order = order;
        }
    }
}