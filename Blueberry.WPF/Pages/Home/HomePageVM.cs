using System;
using Blueberry.DLL.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.WPF.Annotations;

namespace Blueberry.WPF.ViewModels
{
    public class HomePageVM : INotifyPropertyChanged
    {
        private float _solded;
        private float _droped;
        private float _price;
        public string SoldedInfo => $"Sprzedane kilogramy: {_solded}";
        public string DropedInfo => $"Zebrane kilogramy: {_droped}";
        public string PricePerKgInfo => $"Cena za kilogram: {_price}";
        public string IncomeInfo => $"Przychód: {_solded * _price}";
        public string WaitingRoom1 { get; set; }
        public string WaitingRoom2 { get; set; }
        public string WaitingRoom3 { get; set; }
        public DateTime Date { get; set; }
        public string Timer { get; set; }
        private DBConnector _connector;
        public HomePageVM()
        {
            SetTick();
            SetConnector();
            SetStatistics();
        }

        private void SetConnector()
        {
            _connector = DBConnector.GetInstance();
            _connector.OrdersChanged += OnOrdersChanged;
            _connector.HarvestChanged += OnHarvestsHanged;
        }
        private void SetStatistics()
        {
            SetOrdersStatistics(_connector.GetOrders());
            SetHarvestStatistics(_connector.GetHarvests());
            SetPrice(_connector.PricePerKilo);
        }

        private void OnOrdersChanged()
        {
            SetOrdersStatistics(_connector.GetOrders());
        }

        private void OnHarvestsHanged()
        {
            SetHarvestStatistics(_connector.GetHarvests());
        }

        public void SetOrdersStatistics(IEnumerable<Order> orders)
        {
            _solded = orders.Where(o => o.Status == OrderStatus.Realized).Select(o => o.Amount).Sum();
            OnPropertyChanged(nameof(SoldedInfo));
            OnPropertyChanged(nameof(IncomeInfo));
            
            var waiting = orders.Where(o => o.Status == OrderStatus.Waiting)
                .OrderBy(o => o.DateOfRealization).ToArray();
            string[] orderMessages = new string[] {"","","" };
            for (int i = 0; i < Math.Min(waiting.Length, 3); i++)
            {
                orderMessages[i] = $"{i + 1}. {waiting[i].ToString()}";
            }

            WaitingRoom1 = orderMessages[0];
            OnPropertyChanged(nameof(WaitingRoom1));
            WaitingRoom2 = orderMessages[1];
            OnPropertyChanged(nameof(WaitingRoom2));
            WaitingRoom3 = orderMessages[2];
            OnPropertyChanged(nameof(WaitingRoom3));
        }

        public void SetHarvestStatistics(IEnumerable<Harvest> harvests)
        {
            _droped = harvests.Select(h => h.Amount).Sum();
            OnPropertyChanged(nameof(DropedInfo));
        }

        public void SetPrice(float price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Price must be positive");
            }
            _price = price;
            OnPropertyChanged(nameof(PricePerKgInfo));
            OnPropertyChanged(nameof(IncomeInfo));
        }
        
        private void SetTick()
        {
            Date = DateTime.Now.Date;
            OnPropertyChanged(nameof(DateTime));
            var timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            timer.Tick += TimerTick;
            timer.Start();
        }
        
        private void TimerTick(object sender, EventArgs e)
        {
            Timer = DateTime.Now.ToLongTimeString();
            OnPropertyChanged(nameof(Timer));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
