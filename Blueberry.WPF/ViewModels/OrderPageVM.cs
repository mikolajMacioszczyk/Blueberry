namespace Blueberry.WPF.ViewModels
{
    public class OrderPageVM
    {
        public bool SortByDate { get; set; } = true;
        public bool SortByClient { get; set; } = false;
        public bool SortByPriority { get; set; } = false;
    }
}