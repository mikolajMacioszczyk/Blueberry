using Blueberry.DLL.Models;

namespace Blueberry.WPF.PageEventArgs
{
    public class HarvestGroupAddedEventArgs
    {
        public Harvest[] Harvests { get; set; }

        public HarvestGroupAddedEventArgs(Harvest[] harvests)
        {
            Harvests = harvests;
        }
    }
}