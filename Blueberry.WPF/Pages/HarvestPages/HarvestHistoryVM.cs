using System.Collections;
using System.Linq;
using Blueberry.DLL;
using Blueberry.DLL.Models;

namespace Blueberry.WPF.Pages.HarvestPages
{
    public class HarvestHistoryVM
    {
        public IOrderedEnumerable<Harvest> HarvestGroups { get; private set; }

        public HarvestHistoryVM()
        {
            LoadHarvests();
            DBConnector.GetInstance().HarvestChanged += LoadHarvests;
        }

        private void LoadHarvests()
        {
            HarvestGroups = DBConnector.GetInstance().GetHarvests()
                .OrderBy(h => h.DateTime.Date);
        }
    }
}