using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Blueberry.DLL.Models;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages.HarvestPages
{
    public partial class NewHarvestPage : Page
    {
        private readonly ViewModel _model;
        private ObservableCollection<Harvest> Added;
        public event EventHandler<HarvestGroupAddedEventArgs> HarvestGroupAdded;
        public NewHarvestPage(ViewModel model)
        {
            _model = model;
            HarvestGroupAdded += model.OnHarvestGroupAddedEventHandler;
            InitializeComponent();
            Refresh();
        }
    

        private void DiscardOnClick(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    
        private void AddOnClick(object sender, RoutedEventArgs e)
        {
            if (Added.Count != 0)
            {
                foreach (var harvest in Added)
                {
                    harvest.Employee.TotalCollected += harvest.Amount;
                    harvest.Employee.UnPaided += harvest.Amount;
                }
                
                HarvestGroupAdded?.Invoke(this, new HarvestGroupAddedEventArgs(Added.ToArray()));
                Refresh();
            }
        }

        private void Refresh()
        {
            Added = new ObservableCollection<Harvest>();
            JustAddedHarvestControl.DataContext = Added;

            EmployeesComboBox.DataContext = _model.Employees.OrderBy(e => e.LastName).ToList();
            EmployeesComboBox.SelectedIndex = 0;
        }

        private void AddHarvestOnClick(object sender, RoutedEventArgs e)
        {
            var employee = EmployeesComboBox.SelectedValue as Employee;
            float.TryParse(AmountTextBox.Text.Replace('.',','), out float amount);
            var date = DateTime.Today;
            
            Added.Add(new Harvest()
            {
                Employee = employee,
                Amount =  amount,
                DateTime = date
            });
        }

        private void NewHarvestPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}