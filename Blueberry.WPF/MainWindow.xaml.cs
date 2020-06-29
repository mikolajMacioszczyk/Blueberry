using Blueberry.WPF.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Blueberry.DLL.Models;
using Blueberry.WPF.Enums;

namespace Blueberry.WPF
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

        public void Initialize()
        {
            Model = new ViewModel();
            var homePage = new HomePage(Model);
            var orderPage =  new OrderPage(Model);
            orderPage.OrderChanged += Model.OnOrdersChangedEventHandler;
            orderPage.OrderAdded += Model.OnOrderAddedEventHandler;
            var customersPage = new CustomersPage(Model);
            customersPage.CustomerModified += Model.OnCustomerModifiedEventHandler;
            customersPage.CustomerAdded += Model.OnCustomerAddedEventHandler;
            var calendarPage =  new CalendarPage(Model);
            Pages = new List<Page>()
            {
                homePage,
                orderPage,
                customersPage,
                calendarPage
            };
            MainFrame.Navigate(Pages[0]);
            currentPageIdx = 0;
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

        private void GoToPageExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int type = (int)Enum.Parse(typeof(PageType), e.Parameter.ToString());
            MainFrame.Navigate(Pages[type]);
            currentPageIdx = type;  
        }

        private void CloseOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Model.Dispose();
            Application.Current.Shutdown();
        }
    }
}
