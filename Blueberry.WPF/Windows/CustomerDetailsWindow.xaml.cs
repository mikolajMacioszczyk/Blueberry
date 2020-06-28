using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.Windows
{
    public partial class CustomerDetailsWindow : Window
    {
        public CustomerDetailsWindow(IEnumerable<Order> listOfOrder)
        {
            InitializeComponent();
            DataContext = listOfOrder;
        }
    }
}