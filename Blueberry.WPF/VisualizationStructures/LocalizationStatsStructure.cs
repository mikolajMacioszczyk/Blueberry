namespace Blueberry.WPF.VisualizationStructures
{
    public class LocalizationStatsStructure
    {
        public string Key { get; set; }
        public int Value { get; set; }

        public LocalizationStatsStructure(string key, int value)
        {
            Key = key;
            Value = value;
        }
    }
}