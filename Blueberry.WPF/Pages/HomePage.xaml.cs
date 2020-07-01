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
using System.Windows.Threading;
using Blueberry.DLL.Models;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private DispatcherTimer timer;
        private ViewModel _model;
        public HomePage(ViewModel Model)
        {
            InitializeComponent();
            DataContext = Model;
            _model = Model;
        }

        private void timerTick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void HomeLoaded(object sender, RoutedEventArgs e)
        {
            SetStatistics();
            SetWaitingOrders();
            SetTick();
        }

        private void SetStatistics()
        {
            Droped.Text = $"xDDDDDD";
            var solded = _model.Orders.Where(o => o.Status == OrderStatus.Realized).Select(o => o.Amount);
            Solded.Text =
                $"Sprzedane kilogramy: {solded.Sum()}";
            PricePerKilo.Text = $"Cena za kilogram: {_model.PricePerKilo.ToString()}";
            Income.Text = $"Przychód: {solded.Sum()*_model.PricePerKilo}";
        }

        private void SetWaitingOrders()
        {
            var waitingOrders = _model.Orders.Where(o => o.Status == OrderStatus.Waiting)
                .OrderBy(o => o.DateOfRealization).ToArray();
            string[] orderMessages = new string[] {"","","" };
            for (int i = 0; i < Math.Min(waitingOrders.Length, 3); i++)
            {
                orderMessages[i] = $"{i + 1}. {waitingOrders[i].ToString()}";
            }

            Order1.Text = orderMessages[0];
            Order2.Text = orderMessages[1];
            Order3.Text = orderMessages[2];
        }

        private void SetTick()
        {
            lblDate.Content = DateTime.Now.ToShortDateString();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void HomeUnloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
