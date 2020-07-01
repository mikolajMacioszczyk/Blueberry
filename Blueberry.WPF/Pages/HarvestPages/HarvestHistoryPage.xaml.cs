using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages.HarvestPages
{
    public partial class HarvestHistoryPage : Page
    {
        private readonly ViewModel _model;

        public HarvestHistoryPage(ViewModel model)
        {
            _model = model;
            Reload();
            InitializeComponent();
        }

        private void HarvestHistoryPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            var harvesGroups = _model.Harvests.GroupBy(h => h.DateTime).OrderBy(hg => hg.Key.Date).ToList();
            DataContext = harvesGroups;
        }
    }
}