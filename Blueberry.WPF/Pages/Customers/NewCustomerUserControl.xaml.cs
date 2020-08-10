using System;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.Pages.Customers;

namespace Blueberry.WPF.UserControls
{
    public partial class NewCustomerUserControl : UserControl
    {
        public NewCustomerUserControl(NewCustomerVM newCustomerVm)
        {
            DataContext = newCustomerVm;
            InitializeComponent();
        }
    }
}