using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Enums;
using Blueberry.WPF.PageEventArgs;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages
{
    public partial class SalaryPage : Page
    {
        private readonly ViewModel _model;
        private SortEmployeeBy _sortBy = SortEmployeeBy.ByRate;
        public event EventHandler<EmployeeEditedEventArgs> Payment; 

        public SalaryPage(ViewModel model)
        {
            _model = model;
            InitializeComponent();
            Payment += _model.OnEmployeeModifiedEventHandler;
        }

        private void SortOnClick(object sender, RoutedEventArgs e)
        {
            var button = (sender as RadioButton);
            var tag = button.Tag;
            _sortBy = (SortEmployeeBy) Enum.Parse(typeof(SortEmployeeBy), tag.ToString());
            ReLoad();
        }

        private void ReLoad()
        {
            switch (_sortBy)
            {
                case SortEmployeeBy.ByName:
                    SalaryItemsControl.DataContext = _model.Employees.OrderBy(o => o.LastName);
                    break;
                case SortEmployeeBy.ByRate:
                    SalaryItemsControl.DataContext = _model.Employees.OrderByDescending(o => o.Rate);
                    break;
                case SortEmployeeBy.ByCollected:
                    SalaryItemsControl.DataContext = _model.Employees.OrderByDescending(o => o.TotalCollected);
                    break;
                case SortEmployeeBy.ByUnpaided:
                    SalaryItemsControl.DataContext = _model.Employees.OrderByDescending(o => o.UnPaided);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SalaryPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            ReLoad();
        }

        private void SalaryTemplate_OnEmployeePaided(object sender, EmployeeEditedEventArgs e)
        {
            Payment?.Invoke(sender, e);
            ReLoad();
        }
    }
}