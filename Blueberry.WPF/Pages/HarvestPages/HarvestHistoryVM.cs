using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.UserControls.HarvestControls;

namespace Blueberry.WPF.Pages.HarvestPages
{
    public class HarvestHistoryVM
    {
        public IEnumerable<HarvestListVM> HarvestGroups { get; private set; }

        public HarvestHistoryVM()
        {
            LoadHarvests();
            DBConnector.GetInstance().HarvestChanged += LoadHarvests;
        }

        private void LoadHarvests()
        {
             HarvestGroups = DBConnector.GetInstance().GetHarvests()
                .GroupBy(h => h.DateTime.Date)
                .Select(h =>
                {
                    var output = new HarvestListVM()
                    {
                        Source = h
                    };
                    output.Refresh();
                    return output;
                }).ToList();
        }
    }
}