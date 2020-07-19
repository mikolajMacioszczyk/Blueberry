namespace Blueberry.WPF.Pages.Statistics
{
    public struct StatisticsStructure
    {
        public string Key { get; set; }
        public float Value { get; set; }

        public StatisticsStructure(string key, float value)
        {
            Key = key;
            Value = value;
        }
    }
}