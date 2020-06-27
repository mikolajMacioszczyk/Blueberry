using System;
using System.Collections.Generic;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.PageEventArgs
{
    public class OrderPageEventAgrs : EventArgs
    {
        public Order Old { get; }
        public Order New { get; }
        public Modification[] Modifications { get; }

        public OrderPageEventAgrs(Order old, Order @new, params Modification[] modifications)
        {
            Old = old;
            New = @new;
            Modifications = modifications;
        }
    }
}