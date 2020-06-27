﻿using System;
using System.Windows;
using Blueberry.DLL.Models;
using Blueberry.WPF.Enums;
using Blueberry.WPF.Pages;

namespace Blueberry.WPF.Windows
{
    public partial class EditOrderWindow : Window
    {
        private Order Order;
        private Order Save;
        public EditOrderWindow(Order order)
        {
            InitializeComponent();
            Order = new Order(order);
            DataContext = Order;
            
            PriorityComboBox.DataContext = Enum.GetValues(typeof(PriorityPolishNames));
            PriorityComboBox.SelectedIndex = ((int) order.Priority) - 1;

            StatusComboBox.DataContext = Enum.GetValues(typeof(OrderStatusPolishNames));
            StatusComboBox.SelectedIndex = (int) order.Status;
            Save = new Order(Order);
        }

        public Order PromptDialog()
        {
            base.ShowDialog();
            return this.Order;
        }    
        
        private void SubmitOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Order.Amount = Convert.ToInt32(AmountTextBox.Text);
                Order.Priority = (Priority) (PriorityComboBox.SelectedIndex+1);
                Order.Status = (OrderStatus) StatusComboBox.SelectedIndex;
                Order.DateOfRealization = Convert.ToDateTime(RealizationDate.SelectedDate);
                this.Close();
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Niepoprawna wartość liczbowa");
                Restore();
            }
        }

        private void Restore()
        {
            Order.Amount = Save.Amount;
            AmountTextBox.Text = Save.Amount.ToString();
            Order.Priority = Save.Priority;
            PriorityComboBox.SelectedValue = Save.Priority;
            Order.Status = Save.Status;
            StatusComboBox.SelectedValue = Save.Status;
            RealizationDate.SelectedDate = Save.DateOfRealization;
        }
    }
}