using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Blueberry.WPF.Enums;
using Blueberry.WPF.Pages;
using Blueberry.WPF.Pages.HarvestPages;
using Blueberry.WPF.ViewModels;
using StatisticsPage = Blueberry.WPF.Pages.StatisticsPage;

namespace Blueberry.WPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Page> Pages;
        private int currentPageIdx;
        private ViewModel Model;
        
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Model = new ViewModel();
            CreatePages();
            MainFrame.Navigate(Pages[0]);
            currentPageIdx = 0;
        }

        private void CreatePages()
        {
            var newEmployeePage = new NewEmployeePage(Model);
            newEmployeePage.EmployeeAdded += (sender, args) =>
            {
                GoToPage(PageType.EmployerPage.ToString());
            };
            var employerPage = new EmployerPage(Model);
            employerPage.AskSalaryPageNavigate += (sender, args) =>
            {
                GoToPage(PageType.SalaryPage.ToString());
            };
            Pages = new List<Page>()
            {
                new HomePage(Model),
                new OrderPage(Model),
                new CustomersPage(Model),
                new CalendarPage(Model),
                employerPage,
                new SalaryPage(Model), 
                newEmployeePage,
                new NewHarvestPage(Model),
                new HarvestHistoryPage(Model),
                new StatisticsPage(Model)
            };
        }

        private void GoToPageCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter == null)
            {
                return;
            }
            int type = (int)Enum.Parse(typeof(PageType), e.Parameter.ToString());
            if (currentPageIdx == type)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void GoToPage(string destination)
        {
            int type = (int)Enum.Parse(typeof(PageType), destination);
            MainFrame.Navigate(Pages[type]);
            currentPageIdx = type;  
        }

        private void GoToPageExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            GoToPage(e.Parameter.ToString());
        }
    }
}
