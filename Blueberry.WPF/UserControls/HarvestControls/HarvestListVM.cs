using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;

namespace Blueberry.WPF.UserControls.HarvestControls
{
    public class HarvestListVM : INotifyPropertyChanged
    {
        public float FullHarvestAmount { get; set; }
        public DateTime Date { get; set; }
        public IGrouping<DateTime,Harvest> Source { get; set; }
        public IEnumerable<Harvest> Harvests { get; set; }
        public HarvestListVM()
        {
            DBConnector.GetInstance().HarvestChanged += Refresh;
        }

        public void Refresh()
        {
            FullHarvestAmount = Source.Select(h => h.Amount).Sum();
            OnPropertyChanged(nameof(FullHarvestAmount));
            Date = Source.Key;
            OnPropertyChanged(nameof(Date));
            Harvests = Source.Select(h => h);
            OnPropertyChanged(nameof(Harvests));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}