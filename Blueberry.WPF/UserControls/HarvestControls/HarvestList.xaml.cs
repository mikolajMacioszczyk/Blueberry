using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.UserControls.HarvestControls
{
    public partial class HarvestList : UserControl
    {
        public HarvestList()
        {
            InitializeComponent();
            var harvests = DataContext as IEnumerable<Harvest>;
            if (harvests != null && harvests.Any())
            {
                DayTextBlock.Text = $"Zbiory z dnia {harvests.First().DateTime}";
                FullAmountTextBlock.Text = $"Razem zebranych kilogramów: {harvests.Select(h => h.Amount).Sum()}";
            }
        }

        private void HarvestList_OnLoaded(object sender, RoutedEventArgs e)
        {
            var harvests = DataContext as IEnumerable<Harvest>;
            if (harvests != null && harvests.Any())
            {
                DayTextBlock.Text = harvests.First().DateTime.ToShortDateString();
                var fullAmount = harvests.Select(h => h.Amount).Sum();
                FullAmountTextBlock.Text = fullAmount.ToString();
                FullAmountTextBlock.Foreground = GetForegroundColor(fullAmount);
            }
        }

        private SolidColorBrush GetForegroundColor(float fullAmount)
        {
            if (fullAmount < 10)
            {
                return Brushes.DarkOrange;
            }

            if (fullAmount < 30)
            {
                return Brushes.Goldenrod;
            }

            if (fullAmount < 50)
            {
                return Brushes.DeepSkyBlue;
            }
            return Brushes.ForestGreen;
        }
    }
}