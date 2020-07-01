using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using Blueberry.DLL.Models;
using Blueberry.WPF.ViewModels;
using Blueberry.WPF.VisualizationStructures;

namespace Blueberry.WPF.Pages
{
    public partial class StatisticsPage : Page
    {
        private readonly ViewModel _model;
        private Dictionary<Chart, bool> IsReloaded;

        public StatisticsPage(ViewModel model)
        {
            _model = model;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Clear();
            HarvestStats.Visibility = Visibility.Visible;
            
            ReloadHarvestStats();
            
            IsReloaded = new Dictionary<Chart, bool>();
            IsReloaded.Add(HarvestStats, true);
            IsReloaded.Add(EmployeesStats, false);
            IsReloaded.Add(RealizedStats, false);
            IsReloaded.Add(DateOfOrderStats, false);
            IsReloaded.Add(LocalizationStats, false);
        }

        private void ReloadHarvestStats()
        {
            var groups = _model.Harvests.GroupBy(h => h.DateTime.Date)
                .OrderBy(hg => hg.Key.Date);

            if (!groups.Any())
            { return; }
            
            var context = new List<HarvestPerDayStructure>();

            var currentDate = groups.First().Key.Date;
            var stopDate = groups.Last().Key.Date.AddDays(1);
            
            foreach (var day in groups)
            {
                while (currentDate<stopDate && (day.Key.Date.Day != currentDate.Day || day.Key.Date.Month != currentDate.Month))
                {
                    context.Add(new HarvestPerDayStructure(currentDate, 0));
                    currentDate = currentDate.AddDays(1);
                }
                
                context.Add(new HarvestPerDayStructure(
                    day.Key.Date,
                    day.Select(h => h.Amount).Sum()
                ));
                currentDate = currentDate.AddDays(1);
            }
            HarvestStats.DataContext = context;
        }
            
        private void ReloadEmployeesStats()
        {
            EmployeesStats.DataContext = _model.Employees.Select(e => new EmployeesStatsStructure(e, e.TotalCollected));
        }

        private void ReloadRealizedStats()
        {
            var stats = _model.Orders.Where(o => o.Status == OrderStatus.Realized)
                .GroupBy(o => o.DateOfRealization.Date)
                .OrderBy(g => g.Key.Date);

            if (!stats.Any()) { return; }
            
            var context = new List<RealizedStatsStructure>();
            var currentDate = stats.First().Key.Date;
            var stopDate = stats.Last().Key.Date.AddDays(1);
            
            foreach (var day in stats)
            {
                while (currentDate<stopDate && (day.Key.Date.Day != currentDate.Day || day.Key.Date.Month != currentDate.Month))
                {
                    context.Add(new RealizedStatsStructure(currentDate, 0));
                    currentDate = currentDate.AddDays(1);
                }
                
                context.Add(new RealizedStatsStructure(
                    day.Key.Date,
                    day.Select(o => o.Amount).Sum()
                ));
                currentDate = currentDate.AddDays(1);
            }
            RealizedStats.DataContext = context;
        }
        
        private void ReloadDateOfOrderStats()
        {
            var stats = _model.Orders.GroupBy(o => o.DateOfOrder.Date)
                .OrderBy(o => o.Key.Date);
            
            if (!stats.Any()) { return; }
            
            var context = new List<RealizedStatsStructure>();
            var currentDate = stats.First().Key.Date;
            var stopDate = stats.Last().Key.Date.AddDays(1);
            
            foreach (var day in stats)
            {
                while (currentDate<stopDate && (day.Key.Date.Day != currentDate.Day || day.Key.Date.Month != currentDate.Month))
                {
                    context.Add(new RealizedStatsStructure(currentDate, 0));
                    currentDate = currentDate.AddDays(1);
                }
                
                context.Add(new RealizedStatsStructure(
                    day.Key.Date,
                    day.Select(o => o.Amount).Sum()
                ));
                currentDate = currentDate.AddDays(1);
            }
            DateOfOrderStats.DataContext = context;
        }
        
        private void ReloadsLocalizationStats()
        {
            var stats = _model.Customers.Where(c => !string.IsNullOrEmpty(c.Address.City)).GroupBy(c => c.Address.City.ToLower())
                                                    .OrderBy(g => g.Key).ToList();
            var context = new List<LocalizationStatsStructure>();
            foreach (var city in stats)
            {
                context.Add(new LocalizationStatsStructure(
                    city.Key,
                    city.Select(c => 1).Sum()
                    ));
            }

            LocalizationStats.DataContext = context.OrderByDescending(l => l.Value).ThenBy(l => l.Key);
        }

        private void HarvestStatsOnClick(object sender, RoutedEventArgs e)
        {
            Clear();
            HarvestStats.Visibility = Visibility.Visible;

            if (!IsReloaded[HarvestStats])
            {
                IsReloaded[HarvestStats] = true;
                ReloadHarvestStats();
            }
        }

        private void EmployeesStatsOnClick(object sender, RoutedEventArgs e)
        {
            Clear();
            EmployeesStats.Visibility = Visibility.Visible;
            
            if (!IsReloaded[EmployeesStats])
            {
                IsReloaded[EmployeesStats] = true;
                ReloadEmployeesStats();
            }
        }
        
        private void RealizedStatsOnClick(object sender, RoutedEventArgs e)
        {
            Clear();
            RealizedStats.Visibility = Visibility.Visible;
            
            if (!IsReloaded[RealizedStats])
            {
                IsReloaded[RealizedStats] = true;
                ReloadRealizedStats();
            }
        }
            
        private void AcceptedStatsOnClick(object sender, RoutedEventArgs e)
        {
            Clear();
            DateOfOrderStats.Visibility = Visibility.Visible;
            
            if (!IsReloaded[DateOfOrderStats])
            {
                IsReloaded[DateOfOrderStats] = true;
                ReloadDateOfOrderStats();
            }
        }

        private void LocalizationStatsOnClick(object sender, RoutedEventArgs e)
        {
            Clear();
            LocalizationStats.Visibility = Visibility.Visible;
            
            if (!IsReloaded[LocalizationStats])
            {
                IsReloaded[LocalizationStats] = true;
                ReloadsLocalizationStats();
            }
        }

        private void Clear()
        {
            EmployeesStats.Visibility = Visibility.Collapsed;
            HarvestStats.Visibility = Visibility.Collapsed;
            RealizedStats.Visibility = Visibility.Collapsed;
            DateOfOrderStats.Visibility = Visibility.Collapsed;
            LocalizationStats.Visibility = Visibility.Collapsed;
        }
        
        private void StatisticsPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
    }
}