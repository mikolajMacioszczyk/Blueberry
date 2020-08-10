using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Blueberry.DLL.Enums;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.Pages;
using Blueberry.WPF.Pages.Calendar;
using Blueberry.WPF.Pages.Customers;
using Blueberry.WPF.Pages.EmployeePages;
using Blueberry.WPF.Pages.HarvestPages;
using Blueberry.WPF.Pages.Statistics;

namespace Blueberry.WPF.MainWindowFolder
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Properties
        private Dictionary<PageType,Page> pages;
        private PageType _currentPage;
        public PageType CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();                    
                }
            }
        }
        private ICommand _goToPage;
        public ICommand GoToPage
        {
            get
            {
                if (_goToPage == null)
                {
                    _goToPage = new RelayCommand(p => CurrentPage != (PageType) Enum.Parse(typeof(PageType), p.ToString()),
                        p => ChangePage((PageType) Enum.Parse(typeof(PageType), p.ToString())));
                }
                return _goToPage;
            }
        }
        private Page _actualPage;
        public Page ActualPage
        {
            get => _actualPage;
            set
            {
                _actualPage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region constructor

        public ViewModel()
        {
            CreatePages();
            ChangePage(PageType.HomePage);
        }

        private void CreatePages()
        {
            pages = new Dictionary<PageType, Page>
            {
                {PageType.HomePage, new HomePage()},
                {PageType.OrderPage, new OrderPage()},
                {PageType.CustomersPage, new CustomersPage()},
                {PageType.CalendarPage, new CalendarPage()},
                {PageType.EmployerPage, new EmployerPage()},
                {PageType.NewEmployeePage, new NewEmployeePage()},
                {PageType.SalaryPage, new SalaryPage()},
                {PageType.NewHarvestPage, new NewHarvestPage()},
                {PageType.HarvestHistoryPage, new HarvestHistoryPage()},
                {PageType.StatisticsPage, new StatisticsPage()}
            };
        }
        #endregion
        
        private void ChangePage(PageType newPage)
        {
            CurrentPage = newPage;
            ActualPage = pages[CurrentPage];
            CommandManager.InvalidateRequerySuggested();
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
