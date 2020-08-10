using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Enums;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.Pages.Statistics
{
    public class StatisticsVM : INotifyPropertyChanged
    {
        #region Properties

        private StatisticType _currentStatistic;
        private IEnumerable<StatisticsStructure> _dataSource;
        private string _title;
        private ICommand _statisticTypeCommand;
        private bool _isColumnVisible;
        private bool _isPieVisible;
        public bool IsColumnSeriesVisible
        {
            get => _isColumnVisible;
            set
            {
                _isColumnVisible = value;
                if (value)
                {
                    IsPieSeriesVisible = false;
                }
                OnPropertyChanged(nameof(IsColumnSeriesVisible));
            }
        }
        public bool IsPieSeriesVisible
        {
            get => _isPieVisible;
            set
            {
                _isPieVisible = value;
                if (value)
                {
                    IsColumnSeriesVisible = false;
                }
                OnPropertyChanged(nameof(IsPieSeriesVisible));
            }
        }
        public ICommand StatisticTypeCommand
        {
            get
            {
                if (_statisticTypeCommand == null) { _statisticTypeCommand = new  RelayCommand(
                    p => true,
                    p => SetContent((StatisticType) Enum.Parse(typeof(StatisticType),p.ToString()))
                );}
                return _statisticTypeCommand;
            }
        }

        public IEnumerable<StatisticsStructure> DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                OnPropertyChanged(nameof(DataSource));
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        #endregion
        public StatisticsVM()
        {
            SetContent(StatisticType.Harvest);
        }

        private bool CanExecute(object parameter)
        {
            StatisticType type = (StatisticType) Enum.Parse(typeof(StatisticType), parameter.ToString());
            return _currentStatistic != type;
        }

        private void SetCurrentStatisticProperty(StatisticType type)
        {
            if (type == StatisticType.Employees)
            {
                IsPieSeriesVisible = true;
            }
            else
            {
                IsColumnSeriesVisible = true;
            }
            _currentStatistic = type;
        }

        private void SetContent(StatisticType type)
        {
            SetCurrentStatisticProperty(type);
            switch (type)
            {
                case StatisticType.Harvest:
                    Title = "Zebranych kilogramów w dniu";
                    LoadHarvestStats();
                    break;
                case StatisticType.Employees:
                    LoadEmployeesStats();
                    Title = "Zebranych kilogramów przez pracownika";
                    break;
                case StatisticType.Sold:
                    Title = "Sprzedanych kilogramów w dniu";
                    LoadRealizedStats();
                    break;
                case StatisticType.Order:
                    Title = "Przyjętych zamówień w dniu";
                    LoadDateOfOrderStats();
                    break;
                case StatisticType.Localization:
                    Title = "Lokalizacja klientów";
                    LoadsLocalizationStats();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        private void LoadHarvestStats()
        {
            var groups = DBConnector.GetInstance().GetHarvests().GroupBy(h => h.DateTime.Date)
                .OrderBy(hg => hg.Key.Date);

            if (!groups.Any())
            { return; }
            
            var source = new List<StatisticsStructure>();

            var currentDate = groups.First().Key.Date;
            var stopDate = groups.Last().Key.Date.AddDays(1);
            
            foreach (var day in groups)
            {
                while (currentDate<stopDate && (day.Key.Date.Day != currentDate.Day || day.Key.Date.Month != currentDate.Month))
                {
                    source.Add(new StatisticsStructure(currentDate.ToShortDateString(), 0));
                    currentDate = currentDate.AddDays(1);
                }
                
                source.Add(new StatisticsStructure(
                    day.Key.Date.ToShortDateString(),
                    day.Select(h => h.Amount).Sum()
                ));
                currentDate = currentDate.AddDays(1);
            }
            DataSource = source;
        }
        
        private void LoadEmployeesStats()
        {
            var employees = DBConnector.GetInstance()
                .GetEmployees()
                .OrderBy(e => e.TotalCollected);
            DataSource = employees.Select(e => new StatisticsStructure(
                e.ToString(),
                e.TotalCollected
            ));
        }
        
        private void LoadRealizedStats()
        {
            var stats = DBConnector.GetInstance().GetOrders().Where(o => o.Status == OrderStatus.Realized)
                .GroupBy(o => o.DateOfRealization.Date)
                .OrderBy(g => g.Key.Date);

            if (!stats.Any()) { return; }
            
            var source = new List<StatisticsStructure>();
            var currentDate = stats.First().Key.Date;
            var stopDate = stats.Last().Key.Date.AddDays(1);
            
            foreach (var day in stats)
            {
                while (currentDate<stopDate && (day.Key.Date.Day != currentDate.Day || day.Key.Date.Month != currentDate.Month))
                {
                    source.Add(new StatisticsStructure(currentDate.ToShortDateString(), 0));
                    currentDate = currentDate.AddDays(1);
                }
                
                source.Add(new StatisticsStructure(
                    day.Key.ToShortDateString(),
                    day.Select(o => o.Amount).Sum()
                ));
                currentDate = currentDate.AddDays(1);
            }
            DataSource = source;
        }
        
        private void LoadDateOfOrderStats()
        {
            var stats = 
                DBConnector.GetInstance().GetOrders().GroupBy(o => o.DateOfOrder.Date)
                .OrderBy(o => o.Key.Date);
            
            if (!stats.Any()) { return; }
            
            var source = new List<StatisticsStructure>();
            var currentDate = stats.First().Key.Date;
            var stopDate = stats.Last().Key.Date.AddDays(1);
            
            foreach (var day in stats)
            {
                while (currentDate<stopDate && 
                       (day.Key.Date.Day != currentDate.Day || day.Key.Date.Month != currentDate.Month))
                {
                    source.Add(new StatisticsStructure(currentDate.ToShortDateString(), 0));
                    currentDate = currentDate.AddDays(1);
                }
                
                source.Add(new StatisticsStructure(
                    day.Key.ToShortDateString(),
                    day.Select(o => o.Amount).Sum()
                ));
                currentDate = currentDate.AddDays(1);
            }
            DataSource = source;
        }
        
        private void LoadsLocalizationStats()
        {
            var stats = DBConnector.GetInstance().GetCustomers()
                .Where(c => !string.IsNullOrEmpty(c.Address.City))
                .GroupBy(c => c.Address.City.ToLower())
                .OrderBy(g => g.Key).ToList();
            var source = new List<StatisticsStructure>();
            foreach (var city in stats)
            {
                source.Add(new StatisticsStructure(
                    city.Key,
                    city.Select(c => 1).Sum()
                ));
            }

            DataSource = source.OrderByDescending(l => l.Value)
                .ThenBy(l => l.Key);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}